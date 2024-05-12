using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.Log_In_Form
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }



        private void Register_Load(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(sender, e);
            
        }



        // Start Of Show Password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if ( checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox3.UseSystemPasswordChar = true;
            }
            else
            {
                textBox3.UseSystemPasswordChar = false;
            }
        }
        // End Of Show Password


        // Register's Back Button
        private void button1_Click(object sender, EventArgs e)
        {
            LogIn login = new LogIn();
            login.Show(this);
            this.Hide();
        }

        // Start Of Insertion
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match. Please re-enter");
                return;
            }

            if (comboBox1.SelectedItem.ToString() == "Doctor")
            {
                string query = "insert into EmployeeTB10 (Title ,Doctor ,Password ) values('" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                MyEmployees Pat = new MyEmployees();
                try
                {
                    Pat.AddEmployee(query);
                    MessageBox.Show("Employee Successfully Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox1.SelectedItem.ToString() == "Assistant")
            {
                string query = "insert into EmployeeTB10 (Title ,Assistant ,Password ) values('" + comboBox1.SelectedItem.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "')";
                MyEmployees Pat = new MyEmployees();
                try
                {
                    Pat.AddEmployee(query);
                    MessageBox.Show("Employee Successfully Added");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        // End Of Insertion



    }
}
