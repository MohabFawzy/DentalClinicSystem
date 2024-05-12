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

namespace WindowsFormsApp1.Medical_History
{
    public partial class Medical_History : Form
    {
        public Medical_History()
        {
            InitializeComponent();
        }


        // Make ComboBox Get Data From Row patientName In patientTB1
        ConnectionString MyCon = new ConnectionString();
        public void FillMedicalHistory()
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










        // Shows Data When The Form Is Opened ( Loaded )
        private void Form1_Load(object sender, EventArgs e)
        {
            FillMedicalHistory();
        }
        //



        // Start Of Navigation Bar
        private void label22_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
            appointments.Show(this);
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Add_Patient add = new Add_Patient();
            add.Show(this);
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Payments.Payments payments = new Payments.Payments();
            payments.Show(this);
            this.Hide();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            Medical_History mdhistory = new Medical_History();
            mdhistory.Show(this);
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dental_History.Dental_History dnhistory = new Dental_History.Dental_History();
            dnhistory.Show(this);
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            X_Rays.X_Rays xrays = new X_Rays.X_Rays();
            xrays.Show(this);
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Dentist_Info dentistInfo = new Dentist_Info();
            dentistInfo.Show(this);
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show(this);
            this.Hide();
        }
        // End Of Navigation Bar
        // Start Of Insertion
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO MedicalhistoryTB5 (patientName, Past_illness, Present_illness, Medication, Allergy, Hospitalization, Immunization, Infection, Blood_transfusion, Pregnancy) " +
                  "VALUES (@patientName, @Past_illness, @Present_illness, @Medication, @Allergy, @Hospitalization, @Immunization, @Infection, @Blood_transfusion, @Pregnancy)";

            try
            {
                using (SqlConnection connection = MyCon.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@patientName", comboBox1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Past_illness", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Present_illness", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Medication", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Allergy", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Hospitalization", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Immunization", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Infection", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Blood_transfusion", textBox8.Text);
                        cmd.Parameters.AddWithValue("@Pregnancy", textBox9.Text);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Medical History Successfully Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // End Of Insertion

        // Miss Click
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //
       
    }














}

