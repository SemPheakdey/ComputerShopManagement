namespace C_ShopProject
{
    partial class ReportStaffOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportStaffOption));
            this.ReportAllStaff = new System.Windows.Forms.Button();
            this.ReportActiveStaff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ReportAllStaff
            // 
            this.ReportAllStaff.Font = new System.Drawing.Font("Khmer OS Siemreap", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportAllStaff.Location = new System.Drawing.Point(99, 208);
            this.ReportAllStaff.Margin = new System.Windows.Forms.Padding(4);
            this.ReportAllStaff.Name = "ReportAllStaff";
            this.ReportAllStaff.Size = new System.Drawing.Size(408, 112);
            this.ReportAllStaff.TabIndex = 0;
            this.ReportAllStaff.Text = "បុគ្គលិកធ្លាប់បម្រើការ​ និងកំពុងបម្រើការ";
            this.ReportAllStaff.UseVisualStyleBackColor = true;
            this.ReportAllStaff.Click += new System.EventHandler(this.ReportAllStaff_Click);
            // 
            // ReportActiveStaff
            // 
            this.ReportActiveStaff.Font = new System.Drawing.Font("Khmer OS Siemreap", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReportActiveStaff.Location = new System.Drawing.Point(580, 208);
            this.ReportActiveStaff.Margin = new System.Windows.Forms.Padding(4);
            this.ReportActiveStaff.Name = "ReportActiveStaff";
            this.ReportActiveStaff.Size = new System.Drawing.Size(294, 112);
            this.ReportActiveStaff.TabIndex = 1;
            this.ReportActiveStaff.Text = "បុគ្គលិកកំពុងបម្រើការ";
            this.ReportActiveStaff.UseVisualStyleBackColor = true;
            this.ReportActiveStaff.Click += new System.EventHandler(this.ReportActiveStaff_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Khmer OS Siemreap", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(219, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 72);
            this.label1.TabIndex = 2;
            this.label1.Text = "របាយការណ៍បុគ្គលិកក្រុមហ៊ុន\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReportStaffOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 403);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReportActiveStaff);
            this.Controls.Add(this.ReportAllStaff);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReportStaffOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportStaffOption";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReportAllStaff;
        private System.Windows.Forms.Button ReportActiveStaff;
        private System.Windows.Forms.Label label1;
    }
}