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
using WindowsFormsApp1.Appointments;
using WindowsFormsApp1.Log_In_Form;
using WindowsFormsApp1.Payments;
using static WindowsFormsApp1.MyPatient;

namespace WindowsFormsApp1.Patient_Management
{
    public partial class AssistantPM : Form
    {
        public AssistantPM()
        {
            InitializeComponent();
        }

        // Show the Data On the DataGridView
        void populate()
        {
            MyPatient Pat = new MyPatient();
            String query = "Select * from patientTB1";
            DataSet ds = Pat.ShowPatient(query);
            dataGridView1.DataSource = ds.Tables[0];
        }
        //
        // Shows Data When The Form Is Opened ( Loaded )
        private void AssistantPM_Load(object sender, EventArgs e)
        {
            populate();
        }
        //

        // Start Of NavBar
        private void label4_Click(object sender, EventArgs e)
        {
            AssistantPM assistantPM = new AssistantPM();
            assistantPM.Show(this);
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AssistantApp assistantApp = new AssistantApp();
            assistantApp.Show(this);
            this.Hide();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            AssistantPay assistantPay = new AssistantPay();
            assistantPay.Show(this);
            this.Hide();
        }
        private void label18_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show(this);
            this.Hide();
        }
        // End Of NavBar

        // start Of Insertion
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into patientTB1   values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox4.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Patient Successfully Added");
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // End Of Insertion
        int key = 0;
        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

                if (textBox1.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
            else
            {

                key = 0;
            }
        }
        // End Of Delete

        // Start Of Update
        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                // Start building the query
                string query = "UPDATE patientTB1 SET ";
                List<string> updateFields = new List<string>();

                // Check if each field has a value and add it to the update query
                if (!string.IsNullOrEmpty(textBox1.Text)) // Update patientName if it's not empty
                    updateFields.Add("patientName = @patientName");
                if (!string.IsNullOrEmpty(textBox2.Text)) // Update patientPhone if it's not empty
                    updateFields.Add("patientPhone = @patientPhone");
                if (!string.IsNullOrEmpty(textBox3.Text)) // Update patientAge if it's not empty
                    updateFields.Add("patientAge = @patientAge");
                if (comboBox1.SelectedItem != null) // Update patientGender if it's not empty
                    updateFields.Add("patientGender = @patientGender");
                if (!string.IsNullOrEmpty(textBox4.Text)) // Update patientAddress if it's not empty
                    updateFields.Add("patientAddress = @patientAddress");

                // Combine all update fields into the query
                query += string.Join(", ", updateFields);

                // Add the WHERE clause
                query += " WHERE patientID = @patientID";

                try
                {
                    // Assign parameter values
                    string patientName = textBox1.Text;
                    string patientPhone = textBox2.Text; // Assuming phone number is entered in textBox2
                    string patientAge = textBox3.Text; // Assuming age is entered in textBox3
                    string patientGender = comboBox1.SelectedItem?.ToString(); // Handle null selected item
                    string patientAddress = textBox4.Text;
                    int patientID = Convert.ToInt32(textBox5.Text);

                    // Create an instance of PatientDatabaseHelper class
                    PatientDatabaseHelper dbHelper = new PatientDatabaseHelper();

                    // Call the UpdatePatient method through the instance
                    dbHelper.UpdatePatient(query, patientName, patientPhone, patientAge, patientGender, patientAddress, patientID);

                    MessageBox.Show("Patient Successfully Updated");
                    populate(); // Assuming this method populates your UI with updated data
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a Patient's ID to update.");
            }
            // End Of Update
        }

    }
}
