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
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter Username & Password");
                return;
            }

            // Check for valid username and password
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (LoginIsValid(username, password))
            {
                MessageBox.Show("Login Successful!");
                // Now, check the role of the logged-in user
                if (CheckIfUserIsDoctor(username))
                {
                    // Do something for doctors
                    MessageBox.Show("Welcome Doctor " + username);
                    Menu menu = new Menu();
                    menu.Show(this);
                    this.Hide();
                }
                else if (CheckIfUserIsAssistant(username))
                {
                    // Do something for assistants
                    MessageBox.Show("Welcome " + username);
                    AssistantMenu menu = new AssistantMenu();
                    menu.Show(this);
                    this.Hide();
                }
                else
                {
                    // Handle other cases
                    MessageBox.Show("User is not a doctor or an assistant.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }

        private bool LoginIsValid(string username, string password)
        {
            // Query the database to check if the username and password match
            using (SqlConnection connection = new ConnectionString().GetCon())
            {
                string query = "SELECT COUNT(*) FROM EmployeeTB10 WHERE Username = @Username AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private bool CheckIfUserIsDoctor(string username)
        {
            // Query the database to check if the username has the title 'doctor'
            using (SqlConnection connection = new ConnectionString().GetCon())
            {
                string query = "SELECT COUNT(*) FROM EmployeeTB10 WHERE Username = @Username AND Title = 'Doctor'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private bool CheckIfUserIsAssistant(string username)
        {
            // Query the database to check if the username has the title 'assistant'
            using (SqlConnection connection = new ConnectionString().GetCon())
            {
                string query = "SELECT COUNT(*) FROM EmployeeTB10 WHERE Username = @Username AND Title = 'Assistant'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }



    }
}


