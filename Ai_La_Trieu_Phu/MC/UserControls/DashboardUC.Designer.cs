namespace MC.UserControls
{
    partial class DashboardUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.slidingLabel1 = new MC.UserControls.SlidingLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 33);
            this.label1.TabIndex = 27;
            this.label1.Text = "★ Hãy tham gia Ai là triệu phú 2019 để có những giây phút vui vẻ và khám phá bầu " +
    "trời kiến thức của nhân loại ★\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // slidingLabel1
            // 
            this.slidingLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.slidingLabel1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.slidingLabel1.Location = new System.Drawing.Point(52, 57);
            this.slidingLabel1.Name = "slidingLabel1";
            this.slidingLabel1.Size = new System.Drawing.Size(225, 21);
            this.slidingLabel1.Slide = false;
            this.slidingLabel1.TabIndex = 26;
            this.slidingLabel1.Text = "Chào mừng bạn đến với Ai Là Triệu Phú 2019";
            // 
            // DashboardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slidingLabel1);
            this.Name = "DashboardUC";
            this.Size = new System.Drawing.Size(321, 195);
            this.ResumeLayout(false);

        }

        #endregion

        private SlidingLabel slidingLabel1;
        private System.Windows.Forms.Label label1;
    }
}
