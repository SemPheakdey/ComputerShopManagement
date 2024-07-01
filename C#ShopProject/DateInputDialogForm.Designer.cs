namespace C_ShopProject
{
    partial class DateInputDialogForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancelbtnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(132, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(355, 30);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(132, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 48);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "យល់ព្រម";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
            // 
            // btnCancelbtnCancel
            // 
            this.btnCancelbtnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelbtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelbtnCancel.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelbtnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancelbtnCancel.Location = new System.Drawing.Point(384, 171);
            this.btnCancelbtnCancel.Name = "btnCancelbtnCancel";
            this.btnCancelbtnCancel.Size = new System.Drawing.Size(103, 46);
            this.btnCancelbtnCancel.TabIndex = 2;
            this.btnCancelbtnCancel.Text = "លុបចោល";
            this.btnCancelbtnCancel.UseVisualStyleBackColor = false;
            this.btnCancelbtnCancel.Click += new System.EventHandler(this.btnCancelbtnCancel_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Khmer OS Siemreap", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label7.Location = new System.Drawing.Point(55, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(508, 57);
            this.label7.TabIndex = 23;
            this.label7.Text = "ជ្រើសរើសថ្ងៃខែបញ្ជាក់ទិន្នន័យណាមួយ\r\n\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateInputDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 260);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelbtnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "DateInputDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DateInputDialogForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancelbtnCancel;
        private System.Windows.Forms.Label label7;
    }
}