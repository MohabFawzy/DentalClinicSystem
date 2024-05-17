using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Appointments;
using WindowsFormsApp1.Log_In_Form;
using WindowsFormsApp1.Patient_Management;

namespace WindowsFormsApp1.Payments
{
    public partial class AssistantPay : Form
    {
        public AssistantPay()
        {
            InitializeComponent();
        }


        // Make The ComboBox Get Data From Row patientName In patientTB1
        ConnectionString MyCon = new ConnectionString();
        public void FillPayments()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select patientName from patientTB1", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("patientName", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "patientName";
            comboBox1.DataSource = dt;
            Con.Close();
        }
        //


        // Show the Data On the DataGridView
        void populate()
        {
            MyPayments Pat = new MyPayments();
            String query = "Select * from paymentTB4";
            DataSet ds = Pat.ShowPayments(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        // Shows Data When The Form Is Opened ( Loaded )
        private void AssistantPay_Load(object sender, EventArgs e)
        {
            FillPayments();
            populate();
        }


        // Start Of NavBar
        private void label18_Click(object sender, EventArgs e)
        {
            AssistantPM assistantPM = new AssistantPM();
            assistantPM.Show(this);
            this.Hide();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            AssistantApp assistantApp = new AssistantApp();
            assistantApp.Show(this);
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            AssistantPay assistantPay = new AssistantPay();
            assistantPay.Show(this);
            this.Hide();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show(this);
            this.Hide();
        }
        // End Of NavBar


        // Start Of Insertion
        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int Total_cost))
            {
                MessageBox.Show("Please enter a valid Total Cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out int paid))
            {
                MessageBox.Show("Please enter a valid Paid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve session date for the patient
            DateTime sessionDate = GetSessionDate(comboBox1.SelectedValue.ToString());

            // Calculate the rest
            int rest = Total_cost - paid;

            // Insert data into the database
            InsertDataIntoDatabase(comboBox1.SelectedValue.ToString(), Total_cost, paid, sessionDate, rest);
            // Display the Data
            populate();
        }

        // Get Session Date From sessionDate Roe In AppointmentTB2
        private DateTime GetSessionDate(string patientName)
        {
            DateTime sessionDate = DateTime.MinValue; // Default value if no sessionDate found
            try
            {

                ConnectionString connectionStringObj = new ConnectionString();
                string connectionString = connectionStringObj.GetCon().ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT sessionDate FROM AppointmentTB2 WHERE patientName = @patientName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientName", patientName);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        sessionDate = Convert.ToDateTime(result);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching session date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sessionDate;
        }
        //
        // Insert all Data into the DataBase
        private void InsertDataIntoDatabase(string patientName, int Total_cost, int paid, DateTime date_of_payment, int rest)
        {
            try
            {
                // Instantiate ConnectionString class to get the connection string
                ConnectionString connectionStringObj = new ConnectionString();
                string connectionString = connectionStringObj.GetCon().ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO paymentTB4 (patientName, Total_cost, Paid, Date_of_payment, Rest) VALUES (@patientName, @Total_cost, @paid, @Date_of_payment, @Rest)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientName", patientName);
                    command.Parameters.AddWithValue("@Total_cost", Total_cost);
                    command.Parameters.AddWithValue("@paid", paid);
                    command.Parameters.AddWithValue("@Date_of_payment", date_of_payment);
                    command.Parameters.AddWithValue("@Rest", rest);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting data into the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // End Of Insrtion 


        // Start Of Update
        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int Total_cost))
            {
                MessageBox.Show("Please enter a valid Total Cost.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox2.Text, out int paid))
            {
                MessageBox.Show("Please enter a valid Paid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int rest = Total_cost - paid;

            if (!string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                // Update data in the database based on patientName
                UpdateDataInDatabase(comboBox1.SelectedValue.ToString(), Total_cost, paid, dateTimePicker1.Value.Date, rest);

                // Refresh the data in the DataGridView
                populate();
            }
            else
            {
                MessageBox.Show("Please select a patient name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Update Data In The DataBase
        private void UpdateDataInDatabase(string patientName, int Total_cost, int paid, DateTime date_of_payment, int rest)
        {
            try
            {
                // Instantiate ConnectionString class to get the connection string
                ConnectionString connectionStringObj = new ConnectionString();
                string connectionString = connectionStringObj.GetCon().ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE paymentTB4 SET Total_cost = @Total_cost, Paid = @paid, Date_of_payment = @Date_of_payment, Rest = @Rest WHERE patientName = @patientName";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@patientName", patientName);
                    command.Parameters.AddWithValue("@Total_cost", Total_cost);
                    command.Parameters.AddWithValue("@paid", paid);
                    command.Parameters.AddWithValue("@Date_of_payment", date_of_payment);
                    command.Parameters.AddWithValue("@Rest", rest);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating data in the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // End Of Update

        //Start Of Delete
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedPatient = comboBox1.SelectedValue.ToString();
                string sqlquery;
                ConnectionString MyConnection = new ConnectionString();
                SqlConnection Con = MyConnection.GetCon();
                Con.Open();
                sqlquery = "DELETE FROM paymentTB4 WHERE patientName = @patientName";

                try
                {
                    SqlCommand cmd = new SqlCommand(sqlquery, Con);
                    cmd.Parameters.AddWithValue("@patientName", selectedPatient);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Deleted Successfully");
                        populate();
                    }
                    else
                    {
                        MessageBox.Show("No records deleted. Patient not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient");
            }
            //  End Of Delete
        }

    }

}

