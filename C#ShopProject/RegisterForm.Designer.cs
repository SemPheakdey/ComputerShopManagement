namespace C_ShopProject
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.Register_showpassword = new System.Windows.Forms.CheckBox();
            this.signup_password = new System.Windows.Forms.TextBox();
            this.signup_user = new System.Windows.Forms.TextBox();
            this.SignUp_login_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.signInBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Register_showpassword
            // 
            this.Register_showpassword.AutoSize = true;
            this.Register_showpassword.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Register_showpassword.Location = new System.Drawing.Point(745, 346);
            this.Register_showpassword.Margin = new System.Windows.Forms.Padding(4);
            this.Register_showpassword.Name = "Register_showpassword";
            this.Register_showpassword.Size = new System.Drawing.Size(169, 37);
            this.Register_showpassword.TabIndex = 16;
            this.Register_showpassword.Text = "បង្ហាញលេខសម្ងាត់";
            this.Register_showpassword.UseVisualStyleBackColor = true;
            this.Register_showpassword.CheckedChanged += new System.EventHandler(this.Register_showpassword_CheckedChanged);
            // 
            // signup_password
            // 
            this.signup_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_password.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_password.Location = new System.Drawing.Point(572, 302);
            this.signup_password.Margin = new System.Windows.Forms.Padding(4);
            this.signup_password.Name = "signup_password";
            this.signup_password.PasswordChar = '*';
            this.signup_password.Size = new System.Drawing.Size(342, 36);
            this.signup_password.TabIndex = 15;
            // 
            // signup_user
            // 
            this.signup_user.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signup_user.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signup_user.Location = new System.Drawing.Point(572, 194);
            this.signup_user.Margin = new System.Windows.Forms.Padding(4);
            this.signup_user.Name = "signup_user";
            this.signup_user.Size = new System.Drawing.Size(342, 36);
            this.signup_user.TabIndex = 14;
            // 
            // SignUp_login_btn
            // 
            this.SignUp_login_btn.BackColor = System.Drawing.SystemColors.Highlight;
            this.SignUp_login_btn.FlatAppearance.BorderSize = 0;
            this.SignUp_login_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.SignUp_login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SignUp_login_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp_login_btn.ForeColor = System.Drawing.Color.White;
            this.SignUp_login_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SignUp_login_btn.Location = new System.Drawing.Point(573, 396);
            this.SignUp_login_btn.Margin = new System.Windows.Forms.Padding(4);
            this.SignUp_login_btn.Name = "SignUp_login_btn";
            this.SignUp_login_btn.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.SignUp_login_btn.Size = new System.Drawing.Size(143, 53);
            this.SignUp_login_btn.TabIndex = 13;
            this.SignUp_login_btn.Text = "បញ្ចូល";
            this.SignUp_login_btn.UseVisualStyleBackColor = false;
            this.SignUp_login_btn.Click += new System.EventHandler(this.SignUp_login_btn_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(568, 241);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 52);
            this.label3.TabIndex = 12;
            this.label3.Text = "លេខសម្ងាត់";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(568, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 52);
            this.label2.TabIndex = 11;
            this.label2.Text = "ឈ្មោះគណនី";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Khmer OS Siemreap", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Location = new System.Drawing.Point(561, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 73);
            this.label1.TabIndex = 10;
            this.label1.Text = "បង្កើតគណនី\r\n";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.signInBtn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-4, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 559);
            this.panel1.TabIndex = 9;
            // 
            // signInBtn
            // 
            this.signInBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.signInBtn.FlatAppearance.BorderSize = 0;
            this.signInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInBtn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInBtn.ForeColor = System.Drawing.Color.White;
            this.signInBtn.Location = new System.Drawing.Point(165, 454);
            this.signInBtn.Margin = new System.Windows.Forms.Padding(4);
            this.signInBtn.Name = "signInBtn";
            this.signInBtn.Size = new System.Drawing.Size(145, 57);
            this.signInBtn.TabIndex = 7;
            this.signInBtn.Text = "ចូលគណនី";
            this.signInBtn.UseVisualStyleBackColor = false;
            this.signInBtn.Click += new System.EventHandler(this.signInBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(131, 395);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 72);
            this.label6.TabIndex = 6;
            this.label6.Text = "ចូលទៅកាន់គណនីរបស់អ្នក\r\n\r\n";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Khmer OS Siemreap", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Location = new System.Drawing.Point(44, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(445, 231);
            this.label5.TabIndex = 5;
            this.label5.Text = "ប្រព័ន្ធគ្រប់គ្រងហាងកុំព្យូរទ័រ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(772, 396);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(143, 53);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "លុបចោល";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(971, 554);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Register_showpassword);
            this.Controls.Add(this.signup_password);
            this.Controls.Add(this.signup_user);
            this.Controls.Add(this.SignUp_login_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Register_showpassword;
        private System.Windows.Forms.TextBox signup_password;
        private System.Windows.Forms.TextBox signup_user;
        private System.Windows.Forms.Button SignUp_login_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button signInBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
    }
}