namespace MySaverManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.listCategory = new System.Windows.Forms.ListView();
            this.treeSaves = new System.Windows.Forms.TreeView();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnReadonly = new System.Windows.Forms.Button();
            this.treePopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelStatus = new System.Windows.Forms.Label();
            this.treePopupMenu.SuspendLayout();
            this.categoryPopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSavePath
            // 
            this.txtSavePath.Location = new System.Drawing.Point(12, 12);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(376, 21);
            this.txtSavePath.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(406, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(71, 21);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(483, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 21);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // listCategory
            // 
            this.listCategory.AutoArrange = false;
            this.listCategory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCategory.HideSelection = false;
            this.listCategory.Location = new System.Drawing.Point(14, 41);
            this.listCategory.MultiSelect = false;
            this.listCategory.Name = "listCategory";
            this.listCategory.Size = new System.Drawing.Size(189, 304);
            this.listCategory.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listCategory.TabIndex = 3;
            this.listCategory.UseCompatibleStateImageBehavior = false;
            this.listCategory.View = System.Windows.Forms.View.List;
            this.listCategory.SelectedIndexChanged += new System.EventHandler(this.listCategory_SelectedIndexChanged);
            this.listCategory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listCategory_MouseDown);
            // 
            // treeSaves
            // 
            this.treeSaves.Location = new System.Drawing.Point(210, 41);
            this.treeSaves.Name = "treeSaves";
            this.treeSaves.Size = new System.Drawing.Size(349, 303);
            this.treeSaves.TabIndex = 4;
            this.treeSaves.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeSaves_NodeMouseClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(15, 355);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(187, 26);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import Current Save";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(208, 356);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(179, 24);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load Current Save";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnReadonly
            // 
            this.btnReadonly.Location = new System.Drawing.Point(390, 356);
            this.btnReadonly.Name = "btnReadonly";
            this.btnReadonly.Size = new System.Drawing.Size(170, 24);
            this.btnReadonly.TabIndex = 7;
            this.btnReadonly.Text = "Toggle Readonly";
            this.btnReadonly.UseMnemonic = false;
            this.btnReadonly.UseVisualStyleBackColor = true;
            this.btnReadonly.Click += new System.EventHandler(this.btnReadonly_Click);
            // 
            // treePopupMenu
            // 
            this.treePopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFoldToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.treePopupMenu.Name = "treePopupMenu";
            this.treePopupMenu.Size = new System.Drawing.Size(132, 70);
            this.treePopupMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.treePopupMenu_ItemClicked);
            // 
            // newFoldToolStripMenuItem
            // 
            this.newFoldToolStripMenuItem.Name = "newFoldToolStripMenuItem";
            this.newFoldToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newFoldToolStripMenuItem.Text = "New Fold";
            this.newFoldToolStripMenuItem.Click += new System.EventHandler(this.newFoldToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // categoryPopupMenu
            // 
            this.categoryPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCategoryToolStripMenuItem});
            this.categoryPopupMenu.Name = "categoryPopupMenu";
            this.categoryPopupMenu.Size = new System.Drawing.Size(160, 26);
            // 
            // newCategoryToolStripMenuItem
            // 
            this.newCategoryToolStripMenuItem.Name = "newCategoryToolStripMenuItem";
            this.newCategoryToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newCategoryToolStripMenuItem.Text = "New Category";
            this.newCategoryToolStripMenuItem.Click += new System.EventHandler(this.newCategoryToolStripMenuItem_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(18, 397);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 12);
            this.labelStatus.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 423);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnReadonly);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.treeSaves);
            this.Controls.Add(this.listCategory);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSavePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Darksouls Savefiles Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.treePopupMenu.ResumeLayout(false);
            this.categoryPopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListView listCategory;
        private System.Windows.Forms.TreeView treeSaves;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnReadonly;
        private System.Windows.Forms.ContextMenuStrip treePopupMenu;
        private System.Windows.Forms.ToolStripMenuItem newFoldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip categoryPopupMenu;
        private System.Windows.Forms.ToolStripMenuItem newCategoryToolStripMenuItem;
        private System.Windows.Forms.Label labelStatus;
    }
}

