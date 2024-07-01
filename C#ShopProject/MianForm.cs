using EmployeeManagementSystem;
using System;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class MianForm : Form
    {
        private readonly string _username;

        public MianForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void signout_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are You Sure you want to logout?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            this.Hide();  // Hide the current form

            // Handle FormClosed event to show MainForm when Dashboard is closed
            dashboardForm.FormClosed += (s, args) =>
            {
                this.Show();  // Show MainForm
                dashboardForm.Dispose(); // Dispose the Dashboard form instance
            };

            dashboardForm.Show();  // Show the new form
        }

        private void staff_btn_Click(object sender, EventArgs e)
        {
            AddStaff addStaffForm = new AddStaff();
            this.Hide();  // Hide the current form

            // Handle FormClosed event to show MainForm when AddStaff is closed
            addStaffForm.FormClosed += (s, args) =>
            {
                this.Show();  // Show MainForm
                addStaffForm.Dispose(); // Dispose the AddStaff form instance
            };

            addStaffForm.Show();  // Show the new form
        }

      
      

        private void Activity_btn_Click_1(object sender, EventArgs e)
        {
            DeliveryForm deliveryForm = new DeliveryForm();
            this.Hide();  // Hide the current form

            // Handle FormClosed event to show MainForm when DeliveryForm is closed
            deliveryForm.FormClosed += (s, args) =>
            {
                this.Show();  // Show MainForm
                deliveryForm.Dispose(); // Dispose the DeliveryForm form instance
            };

            deliveryForm.Show();  // Show the new form
        }

        private void Import_btn_Click(object sender, EventArgs e)
        {
            importForm importForm = new importForm();
            this.Hide();  // Hide the current form

            // Handle FormClosed event to show MainForm when DeliveryForm is closed
            importForm.FormClosed += (s, args) =>
            {
                this.Show();  // Show MainForm
                importForm.Dispose(); // Dispose the DeliveryForm form instance
            };

            importForm.Show();  // Show the new form
        }

        private void Sell_btn_Click(object sender, EventArgs e)
        {
            SellForm sellForm = new SellForm(_username);
            this.Hide();  // Hide the current form

            // Handle FormClosed event to show MainForm when SellForm is closed
            sellForm.FormClosed += (s, args) =>
            {
                this.Show();  // Show MainForm
                sellForm.Dispose(); // Dispose the SellForm instance
            };

            sellForm.Show();  // Show the new form
        }
    }
}
