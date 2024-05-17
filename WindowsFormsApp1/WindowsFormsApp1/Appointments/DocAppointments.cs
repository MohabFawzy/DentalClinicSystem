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
using WindowsFormsApp1.dentist_info;
using WindowsFormsApp1.Log_In_Form;
using WindowsFormsApp1.Patient_Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.MyAppoinments;

namespace WindowsFormsApp1
{
    public partial class DocAppointments : Form
    {
        public DocAppointments()
        {
            InitializeComponent();
        }

        // Make The ComboBox Get Data From Row patientName In patientTB1
        ConnectionString MyCon = new ConnectionString();
        public void Fillpatient() 
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select patientName from patientTB1",Con);
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
            MyAppoinments Pat = new MyAppoinments();
            String query = "Select * from AppointmentTB2";
            DataSet ds = Pat.ShowAppoinment(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        //

        // Shows Data When The Form Is Opened ( Loaded )
        private void Appointments_Load(object sender, EventArgs e)
        {
            Fillpatient();
            populate();

        }
        //
       
        // Start Of Navigation Bar
        private void label13_Click(object sender, EventArgs e)
        {
            DocAppointments appointments = new DocAppointments();
            appointments.Show(this);
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Add_Patient add = new Add_Patient();
            add.Show(this);
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Payments.Payments payments = new Payments.Payments();
            payments.Show(this);
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Medical_History.Medical_History mdhistory = new Medical_History.Medical_History();
            mdhistory.Show(this);
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Dental_History.Dental_History dnhistory = new Dental_History.Dental_History();
            dnhistory.Show(this);
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            X_Rays.X_Rays xrays = new X_Rays.X_Rays();
            xrays.Show(this);
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dentist_Info dentistInfo = new Dentist_Info();
            dentistInfo.Show(this);
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show(this);
            this.Hide();
        }
        // End Of Navigation Bar





        // Start Of Insertion
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into AppointmentTB2  values('" + comboBox1.SelectedValue.ToString() + "','" + dateTimePicker1.Value.Date + "','" + dateTimePicker2.Value.Date + "','" + dateTimePicker3.Value.TimeOfDay + "')";
            MyAppoinments Pat = new MyAppoinments();
            try
            {
                Pat.AddAppoinment(query);
                MessageBox.Show("Appointment Successfully Added");
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // End Of Insertion
        // Start Of Delete
        private void button4_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedPatient = comboBox1.SelectedValue.ToString();
                string sqlquery;
                ConnectionString MyConnection = new ConnectionString();
                SqlConnection Con = MyConnection.GetCon();
                Con.Open();
                sqlquery = "DELETE FROM AppointmentTB2 WHERE patientName = @patientName";

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
        }
        // End Of Delete


        // Start Of Update
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {

                string query = "UPDATE AppointmentTB2 SET ";
                List<string> updateFields = new List<string>();

                // Check if each field has a value and add it to the update query
                if (comboBox1.SelectedItem != null && !string.IsNullOrEmpty(comboBox1.SelectedItem.ToString())) // Update patientName if it's not empty
                    updateFields.Add("patientName = @patientName");
                if (dateTimePicker1.Value != null)
                    updateFields.Add("todayDate = @todayDate");
                if (dateTimePicker2.Value != null)                                 
                    updateFields.Add("sessionDate = @sessionDate");
                if (dateTimePicker3.Value != null)
                    updateFields.Add("sessionTime = @sessionTime");
                


                // Combine all update fields into the query
                query += string.Join(", ", updateFields);

                    // Add the WHERE clause
                    query += " WHERE patientName = @patientName";
                try { 
                    // Assign parameter values
                    string patientName = comboBox1.SelectedValue.ToString();                 
                    DateTime todayDate = dateTimePicker1.Value.Date; 
                    DateTime sessionDate = dateTimePicker2.Value.Date; 
                    string sessionTime = dateTimePicker3.Value.ToString(); 


                    // Create an instance of AppointmentHelper class
                    AppDatabaseHelper appHelper = new AppDatabaseHelper();

                    // Call the UpdateAppointment method through the instance
                    appHelper.UpdateAppointment(query, patientName, todayDate, sessionDate, sessionTime);

                    MessageBox.Show("Appointment Successfully Updated");
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // END Of Update

        }
        // Miss Click
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // Miss Click
        private void button2_Click(object sender, EventArgs e)
        {

        }
        // Miss Click
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }



}
