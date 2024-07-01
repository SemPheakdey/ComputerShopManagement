namespace EmployeeManagementSystem
{
    partial class AddStaff
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStaff));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Report_staff_btn = new System.Windows.Forms.Button();
            this.AddStaff_Search_btn = new System.Windows.Forms.Button();
            this.AddStaff_Status = new System.Windows.Forms.CheckBox();
            this.AddStaff_Position = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AddStaff_Dob = new System.Windows.Forms.DateTimePicker();
            this.Staff_dob = new System.Windows.Forms.Label();
            this.AddStaff_Salary = new System.Windows.Forms.TextBox();
            this.AddSalary = new System.Windows.Forms.Label();
            this.AddStaff_Import_btn = new System.Windows.Forms.Button();
            this.Clear_btn = new System.Windows.Forms.Button();
            this.deleteStaff_btn = new System.Windows.Forms.Button();
            this.updataStaff_btn = new System.Windows.Forms.Button();
            this.addStaff_btn = new System.Windows.Forms.Button();
            this.AddStaff_Picture = new System.Windows.Forms.PictureBox();
            this.AddStaff_PhoneNum = new System.Windows.Forms.TextBox();
            this.AddStaff_ID = new System.Windows.Forms.TextBox();
            this.AddStaff_FullName = new System.Windows.Forms.TextBox();
            this.AddStaff_Gender = new System.Windows.Forms.GroupBox();
            this.rdo_Female = new System.Windows.Forms.RadioButton();
            this.rdo_Male = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddStaff_Picture)).BeginInit();
            this.AddStaff_Gender.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(36, 97);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1360, 302);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(661, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 36);
            this.label5.TabIndex = 5;
            this.label5.Text = "បច្ចុប្បន្នភាព";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "លេខសម្គាល់";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "ឈ្មោះបុគ្គលិក";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(661, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "លេខទំនាក់ទំនង";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 139);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 36);
            this.label6.TabIndex = 6;
            this.label6.Text = "ភេទ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.Report_staff_btn);
            this.panel3.Controls.Add(this.AddStaff_Search_btn);
            this.panel3.Controls.Add(this.AddStaff_Status);
            this.panel3.Controls.Add(this.AddStaff_Position);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.AddStaff_Dob);
            this.panel3.Controls.Add(this.Staff_dob);
            this.panel3.Controls.Add(this.AddStaff_Salary);
            this.panel3.Controls.Add(this.AddSalary);
            this.panel3.Controls.Add(this.AddStaff_Import_btn);
            this.panel3.Controls.Add(this.Clear_btn);
            this.panel3.Controls.Add(this.deleteStaff_btn);
            this.panel3.Controls.Add(this.updataStaff_btn);
            this.panel3.Controls.Add(this.addStaff_btn);
            this.panel3.Controls.Add(this.AddStaff_Picture);
            this.panel3.Controls.Add(this.AddStaff_PhoneNum);
            this.panel3.Controls.Add(this.AddStaff_ID);
            this.panel3.Controls.Add(this.AddStaff_FullName);
            this.panel3.Controls.Add(this.AddStaff_Gender);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(36, 406);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1365, 318);
            this.panel3.TabIndex = 7;
            // 
            // Report_staff_btn
            // 
            this.Report_staff_btn.BackColor = System.Drawing.Color.White;
            this.Report_staff_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Report_staff_btn.ForeColor = System.Drawing.Color.Black;
            this.Report_staff_btn.Image = ((System.Drawing.Image)(resources.GetObject("Report_staff_btn.Image")));
            this.Report_staff_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Report_staff_btn.Location = new System.Drawing.Point(520, 265);
            this.Report_staff_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Report_staff_btn.Name = "Report_staff_btn";
            this.Report_staff_btn.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.Report_staff_btn.Size = new System.Drawing.Size(165, 44);
            this.Report_staff_btn.TabIndex = 28;
            this.Report_staff_btn.Text = "របាយការណ៍";
            this.Report_staff_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Report_staff_btn.UseVisualStyleBackColor = false;
            this.Report_staff_btn.Click += new System.EventHandler(this.Report_staff_btn_Click);
            // 
            // AddStaff_Search_btn
            // 
            this.AddStaff_Search_btn.BackColor = System.Drawing.Color.White;
            this.AddStaff_Search_btn.FlatAppearance.BorderSize = 0;
            this.AddStaff_Search_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_Search_btn.ForeColor = System.Drawing.Color.Black;
            this.AddStaff_Search_btn.Image = ((System.Drawing.Image)(resources.GetObject("AddStaff_Search_btn.Image")));
            this.AddStaff_Search_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddStaff_Search_btn.Location = new System.Drawing.Point(183, 263);
            this.AddStaff_Search_btn.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Search_btn.Name = "AddStaff_Search_btn";
            this.AddStaff_Search_btn.Size = new System.Drawing.Size(124, 46);
            this.AddStaff_Search_btn.TabIndex = 27;
            this.AddStaff_Search_btn.Text = "ស្វែងរក";
            this.AddStaff_Search_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddStaff_Search_btn.UseVisualStyleBackColor = false;
            this.AddStaff_Search_btn.Click += new System.EventHandler(this.AddStaff_Search_btn_Click);
            // 
            // AddStaff_Status
            // 
            this.AddStaff_Status.AutoSize = true;
            this.AddStaff_Status.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_Status.Location = new System.Drawing.Point(841, 188);
            this.AddStaff_Status.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Status.Name = "AddStaff_Status";
            this.AddStaff_Status.Size = new System.Drawing.Size(133, 37);
            this.AddStaff_Status.TabIndex = 26;
            this.AddStaff_Status.Text = "កំពុងបម្រើការ";
            this.AddStaff_Status.UseVisualStyleBackColor = true;
            // 
            // AddStaff_Position
            // 
            this.AddStaff_Position.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_Position.Location = new System.Drawing.Point(841, 137);
            this.AddStaff_Position.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Position.Name = "AddStaff_Position";
            this.AddStaff_Position.Size = new System.Drawing.Size(304, 36);
            this.AddStaff_Position.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(661, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 36);
            this.label7.TabIndex = 23;
            this.label7.Text = "តួនាទី";
            // 
            // AddStaff_Dob
            // 
            this.AddStaff_Dob.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_Dob.Location = new System.Drawing.Point(183, 202);
            this.AddStaff_Dob.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Dob.Name = "AddStaff_Dob";
            this.AddStaff_Dob.Size = new System.Drawing.Size(301, 36);
            this.AddStaff_Dob.TabIndex = 22;
            this.AddStaff_Dob.Value = new System.DateTime(2024, 6, 9, 21, 35, 28, 0);
            // 
            // Staff_dob
            // 
            this.Staff_dob.AutoSize = true;
            this.Staff_dob.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staff_dob.Location = new System.Drawing.Point(16, 203);
            this.Staff_dob.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Staff_dob.Name = "Staff_dob";
            this.Staff_dob.Size = new System.Drawing.Size(148, 36);
            this.Staff_dob.TabIndex = 21;
            this.Staff_dob.Text = "ថ្ងៃ ខែ ឆ្នាំកំណើត";
            // 
            // AddStaff_Salary
            // 
            this.AddStaff_Salary.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_Salary.Location = new System.Drawing.Point(841, 78);
            this.AddStaff_Salary.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Salary.Name = "AddStaff_Salary";
            this.AddStaff_Salary.Size = new System.Drawing.Size(304, 36);
            this.AddStaff_Salary.TabIndex = 19;
            // 
            // AddSalary
            // 
            this.AddSalary.AutoSize = true;
            this.AddSalary.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSalary.Location = new System.Drawing.Point(661, 79);
            this.AddSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AddSalary.Name = "AddSalary";
            this.AddSalary.Size = new System.Drawing.Size(107, 36);
            this.AddSalary.TabIndex = 18;
            this.AddSalary.Text = "ប្រាក់បៀវត្ស";
            // 
            // AddStaff_Import_btn
            // 
            this.AddStaff_Import_btn.BackColor = System.Drawing.Color.White;
            this.AddStaff_Import_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_Import_btn.ForeColor = System.Drawing.Color.Black;
            this.AddStaff_Import_btn.Image = ((System.Drawing.Image)(resources.GetObject("AddStaff_Import_btn.Image")));
            this.AddStaff_Import_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddStaff_Import_btn.Location = new System.Drawing.Point(1201, 191);
            this.AddStaff_Import_btn.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Import_btn.Name = "AddStaff_Import_btn";
            this.AddStaff_Import_btn.Size = new System.Drawing.Size(160, 47);
            this.AddStaff_Import_btn.TabIndex = 17;
            this.AddStaff_Import_btn.Text = "បញ្ចូលរូបភាព";
            this.AddStaff_Import_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddStaff_Import_btn.UseVisualStyleBackColor = false;
            this.AddStaff_Import_btn.Click += new System.EventHandler(this.AddStaff_Import_btn_Click);
            // 
            // Clear_btn
            // 
            this.Clear_btn.BackColor = System.Drawing.Color.White;
            this.Clear_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear_btn.ForeColor = System.Drawing.Color.Black;
            this.Clear_btn.Image = ((System.Drawing.Image)(resources.GetObject("Clear_btn.Image")));
            this.Clear_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Clear_btn.Location = new System.Drawing.Point(353, 265);
            this.Clear_btn.Margin = new System.Windows.Forms.Padding(4);
            this.Clear_btn.Name = "Clear_btn";
            this.Clear_btn.Padding = new System.Windows.Forms.Padding(0, 0, 11, 0);
            this.Clear_btn.Size = new System.Drawing.Size(131, 44);
            this.Clear_btn.TabIndex = 16;
            this.Clear_btn.Text = "សម្អាត";
            this.Clear_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Clear_btn.UseVisualStyleBackColor = false;
            this.Clear_btn.Click += new System.EventHandler(this.Clear_btn_Click);
            // 
            // deleteStaff_btn
            // 
            this.deleteStaff_btn.BackColor = System.Drawing.Color.White;
            this.deleteStaff_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteStaff_btn.ForeColor = System.Drawing.Color.Black;
            this.deleteStaff_btn.Image = ((System.Drawing.Image)(resources.GetObject("deleteStaff_btn.Image")));
            this.deleteStaff_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteStaff_btn.Location = new System.Drawing.Point(1217, 257);
            this.deleteStaff_btn.Margin = new System.Windows.Forms.Padding(4);
            this.deleteStaff_btn.Name = "deleteStaff_btn";
            this.deleteStaff_btn.Size = new System.Drawing.Size(143, 44);
            this.deleteStaff_btn.TabIndex = 15;
            this.deleteStaff_btn.Text = "លុបចោល";
            this.deleteStaff_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteStaff_btn.UseVisualStyleBackColor = false;
            this.deleteStaff_btn.Click += new System.EventHandler(this.deleteStaff_btn_Click);
            // 
            // updataStaff_btn
            // 
            this.updataStaff_btn.BackColor = System.Drawing.Color.White;
            this.updataStaff_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updataStaff_btn.ForeColor = System.Drawing.Color.Black;
            this.updataStaff_btn.Image = ((System.Drawing.Image)(resources.GetObject("updataStaff_btn.Image")));
            this.updataStaff_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updataStaff_btn.Location = new System.Drawing.Point(1075, 257);
            this.updataStaff_btn.Margin = new System.Windows.Forms.Padding(4);
            this.updataStaff_btn.Name = "updataStaff_btn";
            this.updataStaff_btn.Size = new System.Drawing.Size(119, 44);
            this.updataStaff_btn.TabIndex = 14;
            this.updataStaff_btn.Text = "កែប្រែ";
            this.updataStaff_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.updataStaff_btn.UseVisualStyleBackColor = false;
            this.updataStaff_btn.Click += new System.EventHandler(this.updataStaff_btn_Click);
            // 
            // addStaff_btn
            // 
            this.addStaff_btn.BackColor = System.Drawing.Color.White;
            this.addStaff_btn.FlatAppearance.BorderSize = 0;
            this.addStaff_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStaff_btn.ForeColor = System.Drawing.Color.Black;
            this.addStaff_btn.Image = ((System.Drawing.Image)(resources.GetObject("addStaff_btn.Image")));
            this.addStaff_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addStaff_btn.Location = new System.Drawing.Point(27, 263);
            this.addStaff_btn.Margin = new System.Windows.Forms.Padding(4);
            this.addStaff_btn.Name = "addStaff_btn";
            this.addStaff_btn.Size = new System.Drawing.Size(113, 44);
            this.addStaff_btn.TabIndex = 13;
            this.addStaff_btn.Text = "រក្សាទុក";
            this.addStaff_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addStaff_btn.UseVisualStyleBackColor = false;
            this.addStaff_btn.Click += new System.EventHandler(this.addStaff_btn_Click);
            // 
            // AddStaff_Picture
            // 
            this.AddStaff_Picture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AddStaff_Picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddStaff_Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AddStaff_Picture.Location = new System.Drawing.Point(1200, 20);
            this.AddStaff_Picture.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Picture.Name = "AddStaff_Picture";
            this.AddStaff_Picture.Size = new System.Drawing.Size(160, 163);
            this.AddStaff_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AddStaff_Picture.TabIndex = 12;
            this.AddStaff_Picture.TabStop = false;
            // 
            // AddStaff_PhoneNum
            // 
            this.AddStaff_PhoneNum.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_PhoneNum.Location = new System.Drawing.Point(841, 20);
            this.AddStaff_PhoneNum.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_PhoneNum.Name = "AddStaff_PhoneNum";
            this.AddStaff_PhoneNum.Size = new System.Drawing.Size(304, 36);
            this.AddStaff_PhoneNum.TabIndex = 10;
            // 
            // AddStaff_ID
            // 
            this.AddStaff_ID.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_ID.Location = new System.Drawing.Point(183, 21);
            this.AddStaff_ID.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_ID.Name = "AddStaff_ID";
            this.AddStaff_ID.Size = new System.Drawing.Size(301, 36);
            this.AddStaff_ID.TabIndex = 9;
            // 
            // AddStaff_FullName
            // 
            this.AddStaff_FullName.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStaff_FullName.Location = new System.Drawing.Point(183, 78);
            this.AddStaff_FullName.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_FullName.Name = "AddStaff_FullName";
            this.AddStaff_FullName.Size = new System.Drawing.Size(301, 36);
            this.AddStaff_FullName.TabIndex = 8;
            // 
            // AddStaff_Gender
            // 
            this.AddStaff_Gender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AddStaff_Gender.Controls.Add(this.rdo_Female);
            this.AddStaff_Gender.Controls.Add(this.rdo_Male);
            this.AddStaff_Gender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddStaff_Gender.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddStaff_Gender.Location = new System.Drawing.Point(183, 133);
            this.AddStaff_Gender.Margin = new System.Windows.Forms.Padding(4);
            this.AddStaff_Gender.Name = "AddStaff_Gender";
            this.AddStaff_Gender.Padding = new System.Windows.Forms.Padding(4);
            this.AddStaff_Gender.Size = new System.Drawing.Size(301, 50);
            this.AddStaff_Gender.TabIndex = 7;
            this.AddStaff_Gender.TabStop = false;
            // 
            // rdo_Female
            // 
            this.rdo_Female.AutoSize = true;
            this.rdo_Female.Font = new System.Drawing.Font("Khmer OS Battambang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Female.Location = new System.Drawing.Point(155, 14);
            this.rdo_Female.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_Female.Name = "rdo_Female";
            this.rdo_Female.Size = new System.Drawing.Size(48, 28);
            this.rdo_Female.TabIndex = 1;
            this.rdo_Female.TabStop = true;
            this.rdo_Female.Text = "ស្រី";
            this.rdo_Female.UseVisualStyleBackColor = true;
            // 
            // rdo_Male
            // 
            this.rdo_Male.AutoSize = true;
            this.rdo_Male.Font = new System.Drawing.Font("Khmer OS Battambang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Male.Location = new System.Drawing.Point(8, 14);
            this.rdo_Male.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_Male.Name = "rdo_Male";
            this.rdo_Male.Size = new System.Drawing.Size(57, 28);
            this.rdo_Male.TabIndex = 0;
            this.rdo_Male.TabStop = true;
            this.rdo_Male.Text = "ប្រុស";
            this.rdo_Male.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Khmer OS Siemreap", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label4.Location = new System.Drawing.Point(492, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(555, 84);
            this.label4.TabIndex = 14;
            this.label4.Text = "តារាងបញ្ចូលទិន្នន័យបុគ្គលិក\r\n";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1421, 727);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddStaff_Picture)).EndInit();
            this.AddStaff_Gender.ResumeLayout(false);
            this.AddStaff_Gender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button AddStaff_Import_btn;
        private System.Windows.Forms.Button Clear_btn;
        private System.Windows.Forms.Button deleteStaff_btn;
        private System.Windows.Forms.Button updataStaff_btn;
        private System.Windows.Forms.Button addStaff_btn;
        private System.Windows.Forms.PictureBox AddStaff_Picture;
        private System.Windows.Forms.TextBox AddStaff_PhoneNum;
        private System.Windows.Forms.TextBox AddStaff_ID;
        private System.Windows.Forms.TextBox AddStaff_FullName;
        private System.Windows.Forms.GroupBox AddStaff_Gender;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.TextBox AddStaff_Salary;
        private System.Windows.Forms.Label AddSalary;
        private System.Windows.Forms.Label Staff_dob;
        private System.Windows.Forms.RadioButton rdo_Male;
        private System.Windows.Forms.RadioButton rdo_Female;
        private System.Windows.Forms.DateTimePicker AddStaff_Dob;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox AddStaff_Position;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox AddStaff_Status;
        private System.Windows.Forms.Button AddStaff_Search_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Report_staff_btn;
    }
}