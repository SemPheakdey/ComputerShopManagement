namespace C_ShopProject
{
    partial class MianForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MianForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Sell_btn = new System.Windows.Forms.Button();
            this.Import_btn = new System.Windows.Forms.Button();
            this.Activity_btn = new System.Windows.Forms.Button();
            this.signout = new System.Windows.Forms.Button();
            this.staff_btn = new System.Windows.Forms.Button();
            this.dashboard_btn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Sell_btn);
            this.panel2.Controls.Add(this.Import_btn);
            this.panel2.Controls.Add(this.Activity_btn);
            this.panel2.Controls.Add(this.signout);
            this.panel2.Controls.Add(this.staff_btn);
            this.panel2.Controls.Add(this.dashboard_btn);
            this.panel2.Location = new System.Drawing.Point(-3, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1438, 787);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Khmer OS Siemreap", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(466, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 87);
            this.label1.TabIndex = 13;
            this.label1.Text = "តារាងគ្រប់គ្រងទិន្នន័យហាងកុំព្យូទ័រ";
            // 
            // Sell_btn
            // 
            this.Sell_btn.BackColor = System.Drawing.Color.White;
            this.Sell_btn.FlatAppearance.BorderSize = 0;
            this.Sell_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sell_btn.ForeColor = System.Drawing.Color.Black;
            this.Sell_btn.Image = ((System.Drawing.Image)(resources.GetObject("Sell_btn.Image")));
            this.Sell_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Sell_btn.Location = new System.Drawing.Point(171, 441);
            this.Sell_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Sell_btn.Name = "Sell_btn";
            this.Sell_btn.Padding = new System.Windows.Forms.Padding(20, 10, 31, 30);
            this.Sell_btn.Size = new System.Drawing.Size(321, 193);
            this.Sell_btn.TabIndex = 12;
            this.Sell_btn.Text = "តារាងលក់ទំនិញ";
            this.Sell_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Sell_btn.UseVisualStyleBackColor = false;
            this.Sell_btn.Click += new System.EventHandler(this.Sell_btn_Click);
            // 
            // Import_btn
            // 
            this.Import_btn.BackColor = System.Drawing.Color.White;
            this.Import_btn.FlatAppearance.BorderSize = 0;
            this.Import_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Import_btn.ForeColor = System.Drawing.Color.Black;
            this.Import_btn.Image = ((System.Drawing.Image)(resources.GetObject("Import_btn.Image")));
            this.Import_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Import_btn.Location = new System.Drawing.Point(988, 163);
            this.Import_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Import_btn.Name = "Import_btn";
            this.Import_btn.Padding = new System.Windows.Forms.Padding(20, 10, 13, 30);
            this.Import_btn.Size = new System.Drawing.Size(325, 193);
            this.Import_btn.TabIndex = 11;
            this.Import_btn.Text = "តារាងនាំចូលទំនិញ";
            this.Import_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Import_btn.UseVisualStyleBackColor = false;
            this.Import_btn.Click += new System.EventHandler(this.Import_btn_Click);
            // 
            // Activity_btn
            // 
            this.Activity_btn.BackColor = System.Drawing.Color.White;
            this.Activity_btn.FlatAppearance.BorderSize = 0;
            this.Activity_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Activity_btn.ForeColor = System.Drawing.Color.Black;
            this.Activity_btn.Image = ((System.Drawing.Image)(resources.GetObject("Activity_btn.Image")));
            this.Activity_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Activity_btn.Location = new System.Drawing.Point(590, 441);
            this.Activity_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Activity_btn.Name = "Activity_btn";
            this.Activity_btn.Padding = new System.Windows.Forms.Padding(20, 10, 35, 30);
            this.Activity_btn.Size = new System.Drawing.Size(313, 193);
            this.Activity_btn.TabIndex = 10;
            this.Activity_btn.Text = "តារាងដឹកជញ្ចូន";
            this.Activity_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Activity_btn.UseVisualStyleBackColor = false;
            this.Activity_btn.Click += new System.EventHandler(this.Activity_btn_Click_1);
            // 
            // signout
            // 
            this.signout.BackColor = System.Drawing.Color.White;
            this.signout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.signout.Font = new System.Drawing.Font("Khmer OS Siemreap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signout.ForeColor = System.Drawing.Color.Black;
            this.signout.Image = ((System.Drawing.Image)(resources.GetObject("signout.Image")));
            this.signout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.signout.Location = new System.Drawing.Point(988, 441);
            this.signout.Margin = new System.Windows.Forms.Padding(4);
            this.signout.Name = "signout";
            this.signout.Padding = new System.Windows.Forms.Padding(0, 10, 0, 30);
            this.signout.Size = new System.Drawing.Size(169, 193);
            this.signout.TabIndex = 8;
            this.signout.Text = "ចាកចេញ";
            this.signout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.signout.UseVisualStyleBackColor = false;
            this.signout.Click += new System.EventHandler(this.signout_Click);
            // 
            // staff_btn
            // 
            this.staff_btn.BackColor = System.Drawing.Color.White;
            this.staff_btn.FlatAppearance.BorderSize = 0;
            this.staff_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staff_btn.ForeColor = System.Drawing.Color.Black;
            this.staff_btn.Image = ((System.Drawing.Image)(resources.GetObject("staff_btn.Image")));
            this.staff_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.staff_btn.Location = new System.Drawing.Point(590, 163);
            this.staff_btn.Margin = new System.Windows.Forms.Padding(4);
            this.staff_btn.Name = "staff_btn";
            this.staff_btn.Padding = new System.Windows.Forms.Padding(20, 10, 35, 30);
            this.staff_btn.Size = new System.Drawing.Size(313, 193);
            this.staff_btn.TabIndex = 6;
            this.staff_btn.Text = "តារាងបុគ្គលិក";
            this.staff_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.staff_btn.UseVisualStyleBackColor = false;
            this.staff_btn.Click += new System.EventHandler(this.staff_btn_Click);
            // 
            // dashboard_btn
            // 
            this.dashboard_btn.BackColor = System.Drawing.Color.White;
            this.dashboard_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dashboard_btn.FlatAppearance.BorderSize = 10;
            this.dashboard_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard_btn.ForeColor = System.Drawing.Color.Black;
            this.dashboard_btn.Image = ((System.Drawing.Image)(resources.GetObject("dashboard_btn.Image")));
            this.dashboard_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.dashboard_btn.Location = new System.Drawing.Point(171, 163);
            this.dashboard_btn.Margin = new System.Windows.Forms.Padding(4);
            this.dashboard_btn.Name = "dashboard_btn";
            this.dashboard_btn.Padding = new System.Windows.Forms.Padding(20, 10, 33, 30);
            this.dashboard_btn.Size = new System.Drawing.Size(321, 193);
            this.dashboard_btn.TabIndex = 5;
            this.dashboard_btn.Text = "តារាងបង្ហាញទិន្នន័យ";
            this.dashboard_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.dashboard_btn.UseVisualStyleBackColor = false;
            this.dashboard_btn.Click += new System.EventHandler(this.dashboard_btn_Click);
            // 
            // MianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1435, 694);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MianForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MianForm";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button staff_btn;
        private System.Windows.Forms.Button signout;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.Button dashboard_btn;
        private System.Windows.Forms.Button Activity_btn;
        private System.Windows.Forms.Button Import_btn;
        private System.Windows.Forms.Button Sell_btn;
        private System.Windows.Forms.Label label1;
    }
}