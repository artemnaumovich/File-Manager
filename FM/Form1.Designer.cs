namespace FM
{
    partial class fMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftDirs = new System.Windows.Forms.ListBox();
            this.rightDirs = new System.Windows.Forms.ListBox();
            this.leftFiles = new System.Windows.Forms.ListBox();
            this.rightFiles = new System.Windows.Forms.ListBox();
            this.leftSelectDrive = new System.Windows.Forms.ComboBox();
            this.rightSelectDrive = new System.Windows.Forms.ComboBox();
            this.leftSelectExtension = new System.Windows.Forms.ComboBox();
            this.rightSelectExtension = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewFile = new System.Windows.Forms.Button();
            this.btnNewDirectory = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftDirs
            // 
            this.leftDirs.BackColor = System.Drawing.SystemColors.Window;
            this.leftDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftDirs.FormattingEnabled = true;
            this.leftDirs.ItemHeight = 22;
            this.leftDirs.Location = new System.Drawing.Point(21, 91);
            this.leftDirs.Name = "leftDirs";
            this.leftDirs.Size = new System.Drawing.Size(320, 532);
            this.leftDirs.TabIndex = 0;
            this.leftDirs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemMouseClick);
            this.leftDirs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMain_KeyDown);
            this.leftDirs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DirMouseDoubleClick);
            // 
            // rightDirs
            // 
            this.rightDirs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightDirs.FormattingEnabled = true;
            this.rightDirs.ItemHeight = 22;
            this.rightDirs.Location = new System.Drawing.Point(728, 91);
            this.rightDirs.Name = "rightDirs";
            this.rightDirs.Size = new System.Drawing.Size(320, 532);
            this.rightDirs.TabIndex = 1;
            this.rightDirs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemMouseClick);
            this.rightDirs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMain_KeyDown);
            this.rightDirs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DirMouseDoubleClick);
            // 
            // leftFiles
            // 
            this.leftFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftFiles.FormattingEnabled = true;
            this.leftFiles.ItemHeight = 22;
            this.leftFiles.Location = new System.Drawing.Point(347, 91);
            this.leftFiles.Name = "leftFiles";
            this.leftFiles.Size = new System.Drawing.Size(320, 532);
            this.leftFiles.TabIndex = 3;
            this.leftFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemMouseClick);
            this.leftFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMain_KeyDown);
            this.leftFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileMouseDoubleClick);
            // 
            // rightFiles
            // 
            this.rightFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rightFiles.FormattingEnabled = true;
            this.rightFiles.ItemHeight = 22;
            this.rightFiles.Location = new System.Drawing.Point(1054, 91);
            this.rightFiles.Name = "rightFiles";
            this.rightFiles.Size = new System.Drawing.Size(320, 532);
            this.rightFiles.TabIndex = 4;
            this.rightFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ItemMouseClick);
            this.rightFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMain_KeyDown);
            this.rightFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileMouseDoubleClick);
            // 
            // leftSelectDrive
            // 
            this.leftSelectDrive.DisplayMember = "3";
            this.leftSelectDrive.FormattingEnabled = true;
            this.leftSelectDrive.Items.AddRange(new object[] {
            "C:\\",
            "D:\\"});
            this.leftSelectDrive.Location = new System.Drawing.Point(21, 655);
            this.leftSelectDrive.Name = "leftSelectDrive";
            this.leftSelectDrive.Size = new System.Drawing.Size(121, 24);
            this.leftSelectDrive.TabIndex = 5;
            this.leftSelectDrive.Text = "C:\\";
            this.leftSelectDrive.ValueMember = "2";
            this.leftSelectDrive.SelectedIndexChanged += new System.EventHandler(this.SelectedDriveChanged);
            // 
            // rightSelectDrive
            // 
            this.rightSelectDrive.DisplayMember = "3";
            this.rightSelectDrive.FormattingEnabled = true;
            this.rightSelectDrive.Items.AddRange(new object[] {
            "C:\\",
            "D:\\"});
            this.rightSelectDrive.Location = new System.Drawing.Point(728, 655);
            this.rightSelectDrive.Name = "rightSelectDrive";
            this.rightSelectDrive.Size = new System.Drawing.Size(121, 24);
            this.rightSelectDrive.TabIndex = 6;
            this.rightSelectDrive.Text = "D:\\";
            this.rightSelectDrive.ValueMember = "2";
            this.rightSelectDrive.SelectedIndexChanged += new System.EventHandler(this.SelectedDriveChanged);
            // 
            // leftSelectExtension
            // 
            this.leftSelectExtension.FormattingEnabled = true;
            this.leftSelectExtension.Items.AddRange(new object[] {
            "All files",
            ".txt",
            ".html"});
            this.leftSelectExtension.Location = new System.Drawing.Point(347, 655);
            this.leftSelectExtension.Name = "leftSelectExtension";
            this.leftSelectExtension.Size = new System.Drawing.Size(121, 24);
            this.leftSelectExtension.TabIndex = 7;
            this.leftSelectExtension.Text = "All files";
            this.leftSelectExtension.SelectedIndexChanged += new System.EventHandler(this.SelectExtensionChanged);
            // 
            // rightSelectExtension
            // 
            this.rightSelectExtension.FormattingEnabled = true;
            this.rightSelectExtension.Items.AddRange(new object[] {
            "All files",
            ".txt",
            ".html"});
            this.rightSelectExtension.Location = new System.Drawing.Point(1054, 655);
            this.rightSelectExtension.Name = "rightSelectExtension";
            this.rightSelectExtension.Size = new System.Drawing.Size(121, 24);
            this.rightSelectExtension.TabIndex = 8;
            this.rightSelectExtension.Text = "All files";
            this.rightSelectExtension.SelectedIndexChanged += new System.EventHandler(this.SelectExtensionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelete.Location = new System.Drawing.Point(24, 715);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 46);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "F8 Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DelMouseClick);
            // 
            // btnRename
            // 
            this.btnRename.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRename.Location = new System.Drawing.Point(171, 715);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(118, 46);
            this.btnRename.TabIndex = 10;
            this.btnRename.Text = "F2 Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RenameMouseClick);
            // 
            // btnMove
            // 
            this.btnMove.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMove.Location = new System.Drawing.Point(319, 715);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(118, 46);
            this.btnMove.TabIndex = 12;
            this.btnMove.Text = "F6 Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnMove_MouseClick);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1394, 28);
            this.menuStrip.TabIndex = 14;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.moveToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(146, 26);
            this.moveToolStripMenuItem.Text = "Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.MoveToolStripMenuItem_Click);
            // 
            // btnNewFile
            // 
            this.btnNewFile.Location = new System.Drawing.Point(898, 715);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(124, 46);
            this.btnNewFile.TabIndex = 15;
            this.btnNewFile.Text = "New File";
            this.btnNewFile.UseVisualStyleBackColor = true;
            this.btnNewFile.Click += new System.EventHandler(this.BtnNewFile_Click);
            // 
            // btnNewDirectory
            // 
            this.btnNewDirectory.Location = new System.Drawing.Point(1048, 715);
            this.btnNewDirectory.Name = "btnNewDirectory";
            this.btnNewDirectory.Size = new System.Drawing.Size(127, 46);
            this.btnNewDirectory.TabIndex = 16;
            this.btnNewDirectory.Text = "New Directory";
            this.btnNewDirectory.UseVisualStyleBackColor = true;
            this.btnNewDirectory.Click += new System.EventHandler(this.BtnNewDirectory_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(1253, 715);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(121, 46);
            this.btnHelp.TabIndex = 17;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.Location = new System.Drawing.Point(472, 715);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(127, 46);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search (txt files)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 787);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnNewDirectory);
            this.Controls.Add(this.btnNewFile);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.rightSelectExtension);
            this.Controls.Add(this.leftSelectExtension);
            this.Controls.Add(this.rightSelectDrive);
            this.Controls.Add(this.leftSelectDrive);
            this.Controls.Add(this.rightFiles);
            this.Controls.Add(this.leftFiles);
            this.Controls.Add(this.rightDirs);
            this.Controls.Add(this.leftDirs);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FileManager";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FMain_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox leftDirs;
        public System.Windows.Forms.ListBox rightDirs;
        public System.Windows.Forms.ListBox leftFiles;
        public System.Windows.Forms.ListBox rightFiles;
        private System.Windows.Forms.ComboBox leftSelectDrive;
        private System.Windows.Forms.ComboBox rightSelectDrive;
        private System.Windows.Forms.ComboBox leftSelectExtension;
        private System.Windows.Forms.ComboBox rightSelectExtension;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.Button btnNewFile;
        private System.Windows.Forms.Button btnNewDirectory;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnSearch;
    }
}

