namespace ExcelCompare
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnLoad = new System.Windows.Forms.Button();
            this.linkOpenPathA = new System.Windows.Forms.LinkLabel();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtPathA = new System.Windows.Forms.TextBox();
            this.linkOpenPathB = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathB = new System.Windows.Forms.TextBox();
            this.treeViewExcels = new System.Windows.Forms.TreeView();
            this.tabControlA = new System.Windows.Forms.TabControl();
            this.tabPageA = new System.Windows.Forms.TabPage();
            this.tabControlB = new System.Windows.Forms.TabControl();
            this.tabPageB = new System.Windows.Forms.TabPage();
            this.btnPreDiff = new System.Windows.Forms.Button();
            this.btnNextDiff = new System.Windows.Forms.Button();
            this.tabControlA.SuspendLayout();
            this.tabControlB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(1059, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(84, 57);
            this.btnLoad.TabIndex = 43;
            this.btnLoad.Text = "比较";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // linkOpenPathA
            // 
            this.linkOpenPathA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkOpenPathA.AutoSize = true;
            this.linkOpenPathA.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkOpenPathA.Location = new System.Drawing.Point(1014, 19);
            this.linkOpenPathA.Name = "linkOpenPathA";
            this.linkOpenPathA.Size = new System.Drawing.Size(23, 12);
            this.linkOpenPathA.TabIndex = 41;
            this.linkOpenPathA.TabStop = true;
            this.linkOpenPathA.Text = "...";
            this.linkOpenPathA.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenPathAClient_LinkClicked);
            // 
            // lblClient
            // 
            this.lblClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClient.AutoSize = true;
            this.lblClient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblClient.Location = new System.Drawing.Point(22, 19);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(47, 12);
            this.lblClient.TabIndex = 38;
            this.lblClient.Text = "主目录:";
            // 
            // txtPathA
            // 
            this.txtPathA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathA.ForeColor = System.Drawing.Color.Gray;
            this.txtPathA.Location = new System.Drawing.Point(86, 15);
            this.txtPathA.Name = "txtPathA";
            this.txtPathA.Size = new System.Drawing.Size(922, 21);
            this.txtPathA.TabIndex = 37;
            this.txtPathA.Tag = "ClientPath";
            this.txtPathA.DoubleClick += new System.EventHandler(this.txtPathA_DoubleClick);
            // 
            // linkOpenPathB
            // 
            this.linkOpenPathB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkOpenPathB.AutoSize = true;
            this.linkOpenPathB.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkOpenPathB.Location = new System.Drawing.Point(1014, 51);
            this.linkOpenPathB.Name = "linkOpenPathB";
            this.linkOpenPathB.Size = new System.Drawing.Size(23, 12);
            this.linkOpenPathB.TabIndex = 46;
            this.linkOpenPathB.TabStop = true;
            this.linkOpenPathB.Text = "...";
            this.linkOpenPathB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOpenPathBClient_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(20, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 45;
            this.label1.Text = "对比目录:";
            // 
            // txtPathB
            // 
            this.txtPathB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathB.ForeColor = System.Drawing.Color.Gray;
            this.txtPathB.Location = new System.Drawing.Point(85, 47);
            this.txtPathB.Name = "txtPathB";
            this.txtPathB.Size = new System.Drawing.Size(923, 21);
            this.txtPathB.TabIndex = 44;
            this.txtPathB.Tag = "ClientPath";
            this.txtPathB.DoubleClick += new System.EventHandler(this.txtPath2_DoubleClick);
            // 
            // treeViewExcels
            // 
            this.treeViewExcels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeViewExcels.HideSelection = false;
            this.treeViewExcels.HotTracking = true;
            this.treeViewExcels.Location = new System.Drawing.Point(5, 84);
            this.treeViewExcels.Name = "treeViewExcels";
            this.treeViewExcels.ShowNodeToolTips = true;
            this.treeViewExcels.Size = new System.Drawing.Size(204, 536);
            this.treeViewExcels.TabIndex = 47;
            this.treeViewExcels.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewExcels_NodeMouseClick);
            this.treeViewExcels.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            // 
            // tabControlA
            // 
            this.tabControlA.AllowDrop = true;
            this.tabControlA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlA.Controls.Add(this.tabPageA);
            this.tabControlA.Location = new System.Drawing.Point(215, 84);
            this.tabControlA.Name = "tabControlA";
            this.tabControlA.SelectedIndex = 0;
            this.tabControlA.Size = new System.Drawing.Size(1038, 260);
            this.tabControlA.TabIndex = 48;
            // 
            // tabPageA
            // 
            this.tabPageA.Location = new System.Drawing.Point(4, 22);
            this.tabPageA.Name = "tabPageA";
            this.tabPageA.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageA.Size = new System.Drawing.Size(1030, 234);
            this.tabPageA.TabIndex = 0;
            this.tabPageA.Text = "主目录";
            this.tabPageA.UseVisualStyleBackColor = true;
            // 
            // tabControlB
            // 
            this.tabControlB.AllowDrop = true;
            this.tabControlB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlB.Controls.Add(this.tabPageB);
            this.tabControlB.Location = new System.Drawing.Point(215, 350);
            this.tabControlB.Name = "tabControlB";
            this.tabControlB.SelectedIndex = 0;
            this.tabControlB.Size = new System.Drawing.Size(1038, 270);
            this.tabControlB.TabIndex = 49;
            // 
            // tabPageB
            // 
            this.tabPageB.Location = new System.Drawing.Point(4, 22);
            this.tabPageB.Name = "tabPageB";
            this.tabPageB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageB.Size = new System.Drawing.Size(1030, 244);
            this.tabPageB.TabIndex = 0;
            this.tabPageB.Text = "对比目录";
            this.tabPageB.UseVisualStyleBackColor = true;
            // 
            // btnPreDiff
            // 
            this.btnPreDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreDiff.Location = new System.Drawing.Point(1171, 12);
            this.btnPreDiff.Name = "btnPreDiff";
            this.btnPreDiff.Size = new System.Drawing.Size(77, 23);
            this.btnPreDiff.TabIndex = 50;
            this.btnPreDiff.Text = "上一个";
            this.btnPreDiff.UseVisualStyleBackColor = true;
            this.btnPreDiff.Click += new System.EventHandler(this.btnPreDiff_Click);
            // 
            // btnNextDiff
            // 
            this.btnNextDiff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextDiff.Location = new System.Drawing.Point(1171, 45);
            this.btnNextDiff.Name = "btnNextDiff";
            this.btnNextDiff.Size = new System.Drawing.Size(77, 23);
            this.btnNextDiff.TabIndex = 51;
            this.btnNextDiff.Text = "下一个";
            this.btnNextDiff.UseVisualStyleBackColor = true;
            this.btnNextDiff.Click += new System.EventHandler(this.btnNextDiff_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 624);
            this.Controls.Add(this.btnNextDiff);
            this.Controls.Add(this.btnPreDiff);
            this.Controls.Add(this.tabControlB);
            this.Controls.Add(this.tabControlA);
            this.Controls.Add(this.treeViewExcels);
            this.Controls.Add(this.linkOpenPathB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathB);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.linkOpenPathA);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.txtPathA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Compare";
            this.tabControlA.ResumeLayout(false);
            this.tabControlB.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.LinkLabel linkOpenPathA;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtPathA;
        private System.Windows.Forms.LinkLabel linkOpenPathB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathB;
        private System.Windows.Forms.TreeView treeViewExcels;
        private System.Windows.Forms.TabControl tabControlA;
        private System.Windows.Forms.TabPage tabPageA;
        private System.Windows.Forms.TabControl tabControlB;
        private System.Windows.Forms.TabPage tabPageB;
        private System.Windows.Forms.Button btnPreDiff;
        private System.Windows.Forms.Button btnNextDiff;
    }
}

