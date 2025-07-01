using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentTask.Client
{
    public partial class StudentEditForm : Form
    {
        public StudentEditForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter Full Name!","Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return; 
            }

            if (string.IsNullOrWhiteSpace(txtNationalCode.Text))
            {
                MessageBox.Show("Please Enter National code!", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNationalCode.Focus();
                return;
            }


            Student = new StudentModel()
            {
                FullName = txtFullName.Text,
                NationalCode = txtNationalCode.Text,
                BirthDate = DateOnly.FromDateTime(dateTimePicker1.Value)
            };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
