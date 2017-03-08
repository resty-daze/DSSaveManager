using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySaverManager
{
    public partial class Form1 : Form
    {
        private string categoryName = "None";

        private string[] saveFileLists = { "DRAKS0005.sl2", "DARKSII0000.sl2", "user1.dat" };
        private string saveFileName = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // for debug
            txtSavePath.Text = Properties.Settings.Default.SaveFilePath;
            if (txtSavePath.Text != "")
            {
                btnUpdate_Click(sender, e);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult showResult = fbd.ShowDialog();
            if (showResult == DialogResult.OK)
            {
                txtSavePath.Text = fbd.SelectedPath;
                Properties.Settings.Default.SaveFilePath = fbd.SelectedPath;
                Properties.Settings.Default.Save();
                btnUpdate_Click(sender, e);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string dsSavePath = txtSavePath.Text;

            bool found = false;
            foreach (var sfName in saveFileLists)
            {
                var filePath = dsSavePath + '\\' + sfName;
                if (File.Exists(filePath))
                {
                    saveFileName = sfName;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Given path do not contain dark souls save file");
                listCategory.Clear();
                treeSaves.Nodes.Clear();
                // Not save a incorrect path
                Properties.Settings.Default.SaveFilePath = "";
                Properties.Settings.Default.Save();
                return;
            }

            string[] subDirs = Directory.GetDirectories(dsSavePath);
            listCategory.Clear();
            foreach (var dir in subDirs)
            {
                string cate = Path.GetFileName(dir);
                var id = listCategory.Items.Add(cate).Index;
                if (cate == categoryName)
                {
                    listCategory.SelectedIndices.Clear();
                    listCategory.SelectedIndices.Add(id);
                }
            }
            UpdateAttrLabel();
        }

        private void listCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listCategory.SelectedIndices.Count != 1)
            {
                treeSaves.BeginUpdate();
                treeSaves.Nodes.Clear();
                treeSaves.EndUpdate();
            }
            else
            {
                var id = listCategory.SelectedIndices[0];
                var dsSavePath = txtSavePath.Text;
                categoryName = listCategory.Items[id].Text;
                treeSaves.BeginUpdate();
                treeSaves.Nodes.Clear();
                addIntoTree(treeSaves.Nodes, dsSavePath + "\\" + categoryName);
                treeSaves.EndUpdate();
            }
        }

        private void addIntoTree(TreeNodeCollection nodes, string path)
        {
            string[] dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                var dirname = Path.GetFileName(dir);
                var newNode = nodes.Add(dirname);
                newNode.NodeFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
                var newnodes = newNode.Nodes;
                addIntoTree(newnodes, dir);
            }

            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var filename = Path.GetFileName(file);
                nodes.Add(filename);
            }
        }

        private string GetFullTreePath(TreeNode node)
        {
            if (node == null)
            {
                return txtSavePath.Text + "\\" + categoryName;
            }
            else
            {
                return GetFullTreePath(node.Parent) + "\\" + node.Text;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            // 1. Check save file exist
            var savefile = txtSavePath.Text + "\\" + saveFileName;
            if (!File.Exists(savefile))
            {
                MessageBox.Show("File: " + savefile + " not exist, import failed.");
                return;
            }
            // 2. Get Directory to bakup
            var dir = GetFullTreePath(treeSaves.SelectedNode);
            if (!Directory.Exists(dir))
            {
                dir = txtSavePath.Text + "\\" + categoryName;
                if (!Directory.Exists(dir))
                {
                    MessageBox.Show("Select a Path to import");
                    return;
                }
            }

            // 3. Do the Copy
            var targetFile = dir + "\\" + saveFileName + "." + DateTime.Now.ToString("yyyyMd.h.mm.ss");
            File.Copy(savefile, targetFile);
            btnUpdate_Click(sender, e);
        }

        private void treeSaves_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeSaves.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                treePopupMenu.Show(treeSaves, e.Location.X, e.Location.Y);
            }
        }

        private void treePopupMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newFoldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string foldname = "";
            DialogResult result = InputBox("Create a Fold", "Please input the fold's name:", ref foldname);

            if (result == DialogResult.OK)
            {
                var dir = GetFullTreePath(treeSaves.SelectedNode);
                if (!Directory.Exists(dir))
                {
                    dir = txtSavePath.Text + "\\" + categoryName;
                    if (!Directory.Exists(dir))
                    {
                        MessageBox.Show("Failed get a path to create in.");
                        return;
                    }
                }
                dir += "\\" + foldname;
                Directory.CreateDirectory(dir);
                btnUpdate_Click(sender, e);
            }
        }


        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newName = "";
            DialogResult result = InputBox("Rename a file", "Please input a new file name:", ref newName);

            if (result == DialogResult.OK)
            {
                var path = GetFullTreePath(treeSaves.SelectedNode);
                try
                {
                    if (File.Exists(path))
                    {
                        File.Move(path, Path.GetDirectoryName(path) + "\\" + newName);
                    }
                    else
                    {
                        Directory.Move(path, Path.GetDirectoryName(path) + "\\" + newName);
                    }
                }
                catch
                {
                }
                btnUpdate_Click(sender, e);
            }
        }


        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = GetFullTreePath(treeSaves.SelectedNode);
            if (File.Exists(path))
            {
                var filename = Path.GetFileName(path);
                DialogResult result = MessageBox.Show(this, "Are you sure to delete: " + filename, "Delete a Savefile", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RemoveReadonly(path);
                    File.Delete(path);
                    btnUpdate_Click(sender, e);
                }
            }
        }

        private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtSavePath.Text == "")
            {
                return;
            }

            string foldname = "";
            DialogResult result = InputBox("Create a Category", "Please input the Category's name:", ref foldname);
            var newPath = txtSavePath.Text + "\\" + foldname;
            if (result == DialogResult.OK && !Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
                btnUpdate_Click(sender, e);
            }
        }

        // InputBox code come from: http://www.csharp-examples.net/inputbox/
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        private void listCategory_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                categoryPopupMenu.Show(listCategory, e.Location.X, e.Location.Y);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            var bakupFilePath = GetFullTreePath(treeSaves.SelectedNode);
            if (File.Exists(bakupFilePath))
            {
                var targetFilePath = txtSavePath.Text + "\\" + saveFileName;
                if (File.Exists(targetFilePath))
                {
                    try
                    {
                        RemoveReadonly(targetFilePath + ".bak");
                        File.Delete(targetFilePath + ".bak");
                    }
                    catch
                    {
                    }
                    File.Move(targetFilePath, targetFilePath + ".bak");
                }
                File.Copy(bakupFilePath, targetFilePath);
                UpdateAttrLabel();
            }
        }

        private void btnReadonly_Click(object sender, EventArgs e)
        {
            var path = txtSavePath.Text + "\\" + saveFileName;
            var attr = File.GetAttributes(path) ^ FileAttributes.ReadOnly;
            File.SetAttributes(path, attr);
            UpdateAttrLabel();
        }

        private void UpdateAttrLabel()
        {
            var path = txtSavePath.Text + "\\" + saveFileName;
            bool isReadOnly = (File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
            labelStatus.Text = "Current Savefile [" + saveFileName + "] Status:" + (isReadOnly ? " " : " not ") + "read only.";
        }

        private void RemoveReadonly(string fileName)
        {
            File.SetAttributes(fileName, File.GetAttributes(fileName) & ~FileAttributes.ReadOnly);
        }
    }
}
