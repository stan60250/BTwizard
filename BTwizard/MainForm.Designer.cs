namespace BTwizard
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView_Mission = new System.Windows.Forms.ListView();
            this.tabPage = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView_File = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView_Structure = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbLogger = new System.Windows.Forms.TextBox();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.treeView_File = new System.Windows.Forms.TreeView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView_Mission);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPage);
            this.splitContainer1.Size = new System.Drawing.Size(745, 545);
            this.splitContainer1.SplitterDistance = 248;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView_Mission
            // 
            this.listView_Mission.AllowDrop = true;
            this.listView_Mission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Mission.Location = new System.Drawing.Point(0, 0);
            this.listView_Mission.Name = "listView_Mission";
            this.listView_Mission.ShowItemToolTips = true;
            this.listView_Mission.Size = new System.Drawing.Size(248, 545);
            this.listView_Mission.TabIndex = 0;
            this.listView_Mission.UseCompatibleStateImageBehavior = false;
            this.listView_Mission.View = System.Windows.Forms.View.List;
            this.listView_Mission.SelectedIndexChanged += new System.EventHandler(this.listView_Mission_SelectedIndexChanged);
            this.listView_Mission.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_Mission_DragDrop);
            this.listView_Mission.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView_Mission_DragEnter);
            // 
            // tabPage
            // 
            this.tabPage.Controls.Add(this.tabPage4);
            this.tabPage.Controls.Add(this.tabPage3);
            this.tabPage.Controls.Add(this.tabPage1);
            this.tabPage.Controls.Add(this.tabPage2);
            this.tabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage.Location = new System.Drawing.Point(0, 0);
            this.tabPage.Name = "tabPage";
            this.tabPage.SelectedIndex = 0;
            this.tabPage.Size = new System.Drawing.Size(493, 545);
            this.tabPage.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.treeView_File);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(485, 519);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "File Tree";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView_File);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(485, 519);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "File List";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView_File
            // 
            this.listView_File.AllowDrop = true;
            this.listView_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_File.Location = new System.Drawing.Point(3, 3);
            this.listView_File.Name = "listView_File";
            this.listView_File.ShowItemToolTips = true;
            this.listView_File.Size = new System.Drawing.Size(479, 513);
            this.listView_File.SmallImageList = this.imgIcon;
            this.listView_File.TabIndex = 1;
            this.listView_File.UseCompatibleStateImageBehavior = false;
            this.listView_File.View = System.Windows.Forms.View.Details;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView_Structure);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(485, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Structure";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView_Structure
            // 
            this.treeView_Structure.AllowDrop = true;
            this.treeView_Structure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_Structure.Location = new System.Drawing.Point(3, 3);
            this.treeView_Structure.Name = "treeView_Structure";
            this.treeView_Structure.Size = new System.Drawing.Size(479, 513);
            this.treeView_Structure.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbLogger);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(485, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logger";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbLogger
            // 
            this.tbLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLogger.Enabled = false;
            this.tbLogger.Location = new System.Drawing.Point(3, 3);
            this.tbLogger.Multiline = true;
            this.tbLogger.Name = "tbLogger";
            this.tbLogger.Size = new System.Drawing.Size(479, 513);
            this.tbLogger.TabIndex = 1;
            // 
            // imgIcon
            // 
            this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcon.Images.SetKeyName(0, "torrent.ico");
            this.imgIcon.Images.SetKeyName(1, "file.ico");
            this.imgIcon.Images.SetKeyName(2, "folder.ico");
            this.imgIcon.Images.SetKeyName(3, "folder_open.ico");
            // 
            // treeView_File
            // 
            this.treeView_File.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_File.ImageIndex = 0;
            this.treeView_File.ImageList = this.imgIcon;
            this.treeView_File.Location = new System.Drawing.Point(0, 0);
            this.treeView_File.Name = "treeView_File";
            this.treeView_File.SelectedImageIndex = 0;
            this.treeView_File.Size = new System.Drawing.Size(485, 519);
            this.treeView_File.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 545);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BTwizard";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabPage.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView_Mission;
        private System.Windows.Forms.ImageList imgIcon;
        private System.Windows.Forms.TabControl tabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView treeView_Structure;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox tbLogger;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listView_File;
        private System.Windows.Forms.TreeView treeView_File;
    }
}

