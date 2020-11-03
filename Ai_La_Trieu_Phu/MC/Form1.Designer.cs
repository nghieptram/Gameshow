namespace MC
{
    partial class frmMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMC));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbout_us = new System.Windows.Forms.Button();
            this.btnQuestion = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.aboutusUC1 = new MC.UserControls.AboutusUC();
            this.questionsUC = new MC.UserControls.QuestionsUC();
            this.dashboardUC = new MC.UserControls.DashboardUC();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.toolTip_Close = new System.Windows.Forms.ToolTip(this.components);
            this.questionsUC2 = new MC.UserControls.QuestionsUC();
            this.dashboardUC2 = new MC.UserControls.DashboardUC();
            this.dashboardUC1 = new MC.UserControls.DashboardUC();
            this.questionsUC1 = new MC.UserControls.QuestionsUC();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAbout_us);
            this.panel1.Controls.Add(this.btnQuestion);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 347);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "MC";
            // 
            // btnAbout_us
            // 
            this.btnAbout_us.FlatAppearance.BorderSize = 0;
            this.btnAbout_us.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout_us.ForeColor = System.Drawing.Color.White;
            this.btnAbout_us.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout_us.Image")));
            this.btnAbout_us.Location = new System.Drawing.Point(1, 253);
            this.btnAbout_us.Name = "btnAbout_us";
            this.btnAbout_us.Size = new System.Drawing.Size(141, 45);
            this.btnAbout_us.TabIndex = 2;
            this.btnAbout_us.Text = "  Thông Tin";
            this.btnAbout_us.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout_us.UseVisualStyleBackColor = true;
            this.btnAbout_us.Click += new System.EventHandler(this.btnAbout_us_Click);
            // 
            // btnQuestion
            // 
            this.btnQuestion.FlatAppearance.BorderSize = 0;
            this.btnQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestion.ForeColor = System.Drawing.Color.White;
            this.btnQuestion.Image = ((System.Drawing.Image)(resources.GetObject("btnQuestion.Image")));
            this.btnQuestion.Location = new System.Drawing.Point(1, 202);
            this.btnQuestion.Name = "btnQuestion";
            this.btnQuestion.Size = new System.Drawing.Size(141, 45);
            this.btnQuestion.TabIndex = 0;
            this.btnQuestion.Text = "  Câu Hỏi";
            this.btnQuestion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuestion.UseVisualStyleBackColor = true;
            this.btnQuestion.Click += new System.EventHandler(this.btnQuestion_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.Location = new System.Drawing.Point(1, 151);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(141, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "  Dashboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(0)))), ((int)(((byte)(127)))));
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(142, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(501, 10);
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(142, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(125, 25);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Dashboard";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(604, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(38, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip_Close.SetToolTip(this.btnClose, "Đóng cửa sổ");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.aboutusUC1);
            this.panel2.Controls.Add(this.questionsUC);
            this.panel2.Controls.Add(this.dashboardUC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(142, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 303);
            this.panel2.TabIndex = 7;
            // 
            // aboutusUC1
            // 
            this.aboutusUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutusUC1.Location = new System.Drawing.Point(0, 0);
            this.aboutusUC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.aboutusUC1.Name = "aboutusUC1";
            this.aboutusUC1.Size = new System.Drawing.Size(501, 303);
            this.aboutusUC1.TabIndex = 2;
            // 
            // questionsUC
            // 
            this.questionsUC.BackColor = System.Drawing.Color.White;
            this.questionsUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionsUC.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionsUC.Location = new System.Drawing.Point(0, 0);
            this.questionsUC.Name = "questionsUC";
            this.questionsUC.Size = new System.Drawing.Size(501, 303);
            this.questionsUC.TabIndex = 1;
            // 
            // dashboardUC
            // 
            this.dashboardUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardUC.Location = new System.Drawing.Point(0, 0);
            this.dashboardUC.Margin = new System.Windows.Forms.Padding(13779572, 41854912, 13779572, 41854912);
            this.dashboardUC.Name = "dashboardUC";
            this.dashboardUC.Size = new System.Drawing.Size(501, 303);
            this.dashboardUC.TabIndex = 0;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panelHeader;
            this.bunifuDragControl1.Vertical = true;
            // 
            // toolTip_Close
            // 
            this.toolTip_Close.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTip_Close.ToolTipTitle = "Thoát";
            // 
            // questionsUC2
            // 
            this.questionsUC2.BackColor = System.Drawing.Color.White;
            this.questionsUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionsUC2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionsUC2.Location = new System.Drawing.Point(0, 0);
            this.questionsUC2.Name = "questionsUC2";
            this.questionsUC2.Size = new System.Drawing.Size(501, 303);
            this.questionsUC2.TabIndex = 1;
            // 
            // dashboardUC2
            // 
            this.dashboardUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardUC2.Location = new System.Drawing.Point(0, 0);
            this.dashboardUC2.Margin = new System.Windows.Forms.Padding(21, 28, 21, 28);
            this.dashboardUC2.Name = "dashboardUC2";
            this.dashboardUC2.Size = new System.Drawing.Size(501, 303);
            this.dashboardUC2.TabIndex = 0;
            // 
            // dashboardUC1
            // 
            this.dashboardUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboardUC1.Location = new System.Drawing.Point(0, 0);
            this.dashboardUC1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dashboardUC1.Name = "dashboardUC1";
            this.dashboardUC1.Size = new System.Drawing.Size(501, 303);
            this.dashboardUC1.TabIndex = 0;
            // 
            // questionsUC1
            // 
            this.questionsUC1.BackColor = System.Drawing.Color.White;
            this.questionsUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionsUC1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionsUC1.Location = new System.Drawing.Point(0, 0);
            this.questionsUC1.Name = "questionsUC1";
            this.questionsUC1.Size = new System.Drawing.Size(501, 303);
            this.questionsUC1.TabIndex = 1;
            // 
            // frmMC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(643, 347);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMC";
            this.Text = "MC";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnAbout_us;
        private System.Windows.Forms.Button btnQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel2;
        private UserControls.DashboardUC dashboardUC1;
        private UserControls.QuestionsUC questionsUC1;
        private UserControls.DashboardUC dashboardUC2;
        private UserControls.QuestionsUC questionsUC2;
        private UserControls.DashboardUC dashboardUC;
        private UserControls.QuestionsUC questionsUC;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.ToolTip toolTip_Close;
        private UserControls.AboutusUC aboutusUC1;
    }
}

