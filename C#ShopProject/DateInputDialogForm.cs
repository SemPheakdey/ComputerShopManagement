using System;
using System.Windows.Forms;

namespace C_ShopProject
{
    public partial class DateInputDialogForm : Form
    {
        public DateTime SelectedDate { get; private set; }

        public DateInputDialogForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            SelectedDate = dateTimePicker1.Value.Date; // Capture only date part
            DialogResult = DialogResult.OK; // Set dialog result to OK
            Close(); // Close the form

        }

        private void btnCancelbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Set dialog result to Cancel if cancel button clicked
            Close(); // Close the form
        }
    }
}
