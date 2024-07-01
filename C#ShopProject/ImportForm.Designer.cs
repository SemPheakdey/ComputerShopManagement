namespace C_ShopProject
{
    partial class importForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date_import = new System.Windows.Forms.DateTimePicker();
            this.Supplier_import = new System.Windows.Forms.TextBox();
            this.Price_import = new System.Windows.Forms.TextBox();
            this.Itemname_import = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.add_importform_btn = new System.Windows.Forms.Button();
            this.search_import_btn = new System.Windows.Forms.Button();
            this.update_importform_btn = new System.Windows.Forms.Button();
            this.Qty_import = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Contact_import = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Total_import = new System.Windows.Forms.TextBox();
            this.report_importform_btn = new System.Windows.Forms.Button();
            this.delete_import_form = new System.Windows.Forms.Button();
            this.refreash_btn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.Itemcode_import = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Khmer OS Battambang", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
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
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(31, 82);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1391, 295);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Date_import
            // 
            this.Date_import.CalendarFont = new System.Drawing.Font("Khmer OS Battambang", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_import.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_import.Location = new System.Drawing.Point(229, 412);
            this.Date_import.Margin = new System.Windows.Forms.Padding(4);
            this.Date_import.Name = "Date_import";
            this.Date_import.Size = new System.Drawing.Size(452, 36);
            this.Date_import.TabIndex = 1;
            this.Date_import.Value = new System.DateTime(2024, 6, 3, 9, 40, 56, 0);
            // 
            // Supplier_import
            // 
            this.Supplier_import.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Supplier_import.Location = new System.Drawing.Point(229, 468);
            this.Supplier_import.Margin = new System.Windows.Forms.Padding(4);
            this.Supplier_import.Name = "Supplier_import";
            this.Supplier_import.Size = new System.Drawing.Size(452, 36);
            this.Supplier_import.TabIndex = 2;
            // 
            // Price_import
            // 
            this.Price_import.Font = new System.Drawing.Font("Khmer OS Battambang", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price_import.Location = new System.Drawing.Point(1023, 506);
            this.Price_import.Margin = new System.Windows.Forms.Padding(4);
            this.Price_import.Name = "Price_import";
            this.Price_import.Size = new System.Drawing.Size(399, 41);
            this.Price_import.TabIndex = 3;
            this.Price_import.TextChanged += new System.EventHandler(this.Price_import_TextChanged);
            // 
            // Itemname_import
            // 
            this.Itemname_import.Font = new System.Drawing.Font("Khmer OS Battambang", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Itemname_import.Location = new System.Drawing.Point(1023, 444);
            this.Itemname_import.Margin = new System.Windows.Forms.Padding(4);
            this.Itemname_import.Name = "Itemname_import";
            this.Itemname_import.Size = new System.Drawing.Size(399, 41);
            this.Itemname_import.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 470);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "ឈ្មោះអ្នកផ្គត់ផ្គង់";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 414);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 36);
            this.label2.TabIndex = 6;
            this.label2.Text = "កាលបរិច្ឆេទ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(829, 450);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 36);
            this.label3.TabIndex = 7;
            this.label3.Text = "ឈ្មោះទំនិញ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(829, 505);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 36);
            this.label4.TabIndex = 8;
            this.label4.Text = "តម្លៃក្នុងមួយឯកតា";
            // 
            // add_importform_btn
            // 
            this.add_importform_btn.BackColor = System.Drawing.Color.White;
            this.add_importform_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_importform_btn.ForeColor = System.Drawing.Color.Black;
            this.add_importform_btn.Image = ((System.Drawing.Image)(resources.GetObject("add_importform_btn.Image")));
            this.add_importform_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_importform_btn.Location = new System.Drawing.Point(61, 597);
            this.add_importform_btn.Margin = new System.Windows.Forms.Padding(4);
            this.add_importform_btn.Name = "add_importform_btn";
            this.add_importform_btn.Size = new System.Drawing.Size(107, 55);
            this.add_importform_btn.TabIndex = 9;
            this.add_importform_btn.Text = "បញ្ចូល";
            this.add_importform_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_importform_btn.UseVisualStyleBackColor = false;
            this.add_importform_btn.Click += new System.EventHandler(this.add_importform_btn_Click);
            // 
            // search_import_btn
            // 
            this.search_import_btn.BackColor = System.Drawing.Color.White;
            this.search_import_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_import_btn.ForeColor = System.Drawing.Color.Black;
            this.search_import_btn.Image = ((System.Drawing.Image)(resources.GetObject("search_import_btn.Image")));
            this.search_import_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.search_import_btn.Location = new System.Drawing.Point(219, 597);
            this.search_import_btn.Margin = new System.Windows.Forms.Padding(4);
            this.search_import_btn.Name = "search_import_btn";
            this.search_import_btn.Size = new System.Drawing.Size(120, 55);
            this.search_import_btn.TabIndex = 10;
            this.search_import_btn.Text = "ស្វែងរក";
            this.search_import_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.search_import_btn.UseVisualStyleBackColor = false;
            this.search_import_btn.Click += new System.EventHandler(this.search_import_btn_Click);
            // 
            // update_importform_btn
            // 
            this.update_importform_btn.BackColor = System.Drawing.Color.White;
            this.update_importform_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_importform_btn.ForeColor = System.Drawing.Color.Black;
            this.update_importform_btn.Image = ((System.Drawing.Image)(resources.GetObject("update_importform_btn.Image")));
            this.update_importform_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.update_importform_btn.Location = new System.Drawing.Point(1123, 684);
            this.update_importform_btn.Margin = new System.Windows.Forms.Padding(4);
            this.update_importform_btn.Name = "update_importform_btn";
            this.update_importform_btn.Size = new System.Drawing.Size(113, 55);
            this.update_importform_btn.TabIndex = 12;
            this.update_importform_btn.Text = "កែប្រែ";
            this.update_importform_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.update_importform_btn.UseVisualStyleBackColor = false;
            this.update_importform_btn.Click += new System.EventHandler(this.update_importform_btn_Click);
            // 
            // Qty_import
            // 
            this.Qty_import.Font = new System.Drawing.Font("Khmer OS Battambang", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qty_import.Location = new System.Drawing.Point(1023, 561);
            this.Qty_import.Margin = new System.Windows.Forms.Padding(4);
            this.Qty_import.Name = "Qty_import";
            this.Qty_import.Size = new System.Drawing.Size(399, 41);
            this.Qty_import.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(829, 566);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 36);
            this.label5.TabIndex = 14;
            this.label5.Text = "ចំនួន";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 530);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 36);
            this.label6.TabIndex = 15;
            this.label6.Text = "លេខទំនាក់ទំនង";
            // 
            // Contact_import
            // 
            this.Contact_import.Font = new System.Drawing.Font("Khmer OS Battambang", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contact_import.Location = new System.Drawing.Point(229, 528);
            this.Contact_import.Margin = new System.Windows.Forms.Padding(4);
            this.Contact_import.Name = "Contact_import";
            this.Contact_import.Size = new System.Drawing.Size(452, 36);
            this.Contact_import.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(829, 623);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 36);
            this.label7.TabIndex = 18;
            this.label7.Text = "តម្លៃសរុប";
            // 
            // Total_import
            // 
            this.Total_import.Font = new System.Drawing.Font("Khmer OS Battambang", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Total_import.Location = new System.Drawing.Point(1023, 619);
            this.Total_import.Margin = new System.Windows.Forms.Padding(4);
            this.Total_import.Name = "Total_import";
            this.Total_import.Size = new System.Drawing.Size(399, 41);
            this.Total_import.TabIndex = 17;
            // 
            // report_importform_btn
            // 
            this.report_importform_btn.BackColor = System.Drawing.Color.White;
            this.report_importform_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_importform_btn.ForeColor = System.Drawing.Color.Black;
            this.report_importform_btn.Image = ((System.Drawing.Image)(resources.GetObject("report_importform_btn.Image")));
            this.report_importform_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.report_importform_btn.Location = new System.Drawing.Point(526, 597);
            this.report_importform_btn.Margin = new System.Windows.Forms.Padding(4);
            this.report_importform_btn.Name = "report_importform_btn";
            this.report_importform_btn.Size = new System.Drawing.Size(155, 55);
            this.report_importform_btn.TabIndex = 19;
            this.report_importform_btn.Text = "របាយការណ៍";
            this.report_importform_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.report_importform_btn.UseVisualStyleBackColor = false;
            this.report_importform_btn.Click += new System.EventHandler(this.report_importform_btn_Click);
            // 
            // delete_import_form
            // 
            this.delete_import_form.BackColor = System.Drawing.Color.White;
            this.delete_import_form.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_import_form.ForeColor = System.Drawing.Color.Black;
            this.delete_import_form.Image = ((System.Drawing.Image)(resources.GetObject("delete_import_form.Image")));
            this.delete_import_form.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delete_import_form.Location = new System.Drawing.Point(1273, 684);
            this.delete_import_form.Margin = new System.Windows.Forms.Padding(4);
            this.delete_import_form.Name = "delete_import_form";
            this.delete_import_form.Size = new System.Drawing.Size(149, 55);
            this.delete_import_form.TabIndex = 20;
            this.delete_import_form.Text = "លុបចោល";
            this.delete_import_form.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete_import_form.UseVisualStyleBackColor = false;
            this.delete_import_form.Click += new System.EventHandler(this.delete_import_form_Click);
            // 
            // refreash_btn
            // 
            this.refreash_btn.BackColor = System.Drawing.Color.White;
            this.refreash_btn.Font = new System.Drawing.Font("Khmer OS Siemreap", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreash_btn.ForeColor = System.Drawing.Color.Black;
            this.refreash_btn.Image = ((System.Drawing.Image)(resources.GetObject("refreash_btn.Image")));
            this.refreash_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreash_btn.Location = new System.Drawing.Point(374, 597);
            this.refreash_btn.Margin = new System.Windows.Forms.Padding(4);
            this.refreash_btn.Name = "refreash_btn";
            this.refreash_btn.Size = new System.Drawing.Size(117, 55);
            this.refreash_btn.TabIndex = 21;
            this.refreash_btn.Text = "សម្អាត";
            this.refreash_btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refreash_btn.UseVisualStyleBackColor = false;
            this.refreash_btn.Click += new System.EventHandler(this.refreash_btn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Khmer OS Siemreap", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(830, 402);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 36);
            this.label9.TabIndex = 24;
            this.label9.Text = "កូតទំនិញ";
            // 
            // Itemcode_import
            // 
            this.Itemcode_import.Font = new System.Drawing.Font("Khmer OS Battambang", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Itemcode_import.Location = new System.Drawing.Point(1023, 395);
            this.Itemcode_import.Margin = new System.Windows.Forms.Padding(4);
            this.Itemcode_import.Name = "Itemcode_import";
            this.Itemcode_import.Size = new System.Drawing.Size(399, 41);
            this.Itemcode_import.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Khmer OS Siemreap", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label8.Location = new System.Drawing.Point(502, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(524, 77);
            this.label8.TabIndex = 25;
            this.label8.Text = "តារាងបញ្ចូលទិន្នន័យទំនិញ\r\n";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // importForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1456, 775);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Itemcode_import);
            this.Controls.Add(this.refreash_btn);
            this.Controls.Add(this.delete_import_form);
            this.Controls.Add(this.report_importform_btn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Total_import);
            this.Controls.Add(this.Contact_import);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Qty_import);
            this.Controls.Add(this.update_importform_btn);
            this.Controls.Add(this.search_import_btn);
            this.Controls.Add(this.add_importform_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Itemname_import);
            this.Controls.Add(this.Price_import);
            this.Controls.Add(this.Supplier_import);
            this.Controls.Add(this.Date_import);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "importForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportForm";
            this.Load += new System.EventHandler(this.importForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker Date_import;
        private System.Windows.Forms.TextBox Supplier_import;
        private System.Windows.Forms.TextBox Price_import;
        private System.Windows.Forms.TextBox Itemname_import;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add_importform_btn;
        private System.Windows.Forms.Button search_import_btn;
        private System.Windows.Forms.Button update_importform_btn;
        private System.Windows.Forms.TextBox Qty_import;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Contact_import;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Total_import;
        private System.Windows.Forms.Button report_importform_btn;
        private System.Windows.Forms.Button delete_import_form;
        private System.Windows.Forms.Button refreash_btn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Itemcode_import;
        private System.Windows.Forms.Label label8;
    }
}