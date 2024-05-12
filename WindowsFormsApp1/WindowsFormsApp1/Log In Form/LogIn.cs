using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp1.Log_In_Form
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        // Register Button
        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show(this);
            this.Hide();
        }
        //

        // Make The CheckBox Work When Form Open ( Load )
        private void LogIn_Load(object sender, EventArgs e)
        {
            checkBox1_CheckedChanged(sender, e);
        }
        //
        // Show Password
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
        //

        //Login Button
        private void button1_Click(object sender, EventArgs e)
        {
            // Start Admin Login

                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Enter Username & Password");
                    return;
                }

                // Check for valid username and password
                if (textBox1.Text.Equals("Admin", StringComparison.OrdinalIgnoreCase) && textBox2.Text.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Login Successful!");
                    Menu menu = new Menu();
                    menu.Show(this);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
            // End Admin Login   
    }
}


