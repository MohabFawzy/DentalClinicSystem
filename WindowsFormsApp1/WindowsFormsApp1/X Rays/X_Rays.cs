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

namespace WindowsFormsApp1.X_Rays
{
    public partial class X_Rays : Form
    {
        public X_Rays()
        {
            InitializeComponent();
        }


        // Make ComboBox Get Data From Row patientName In patientTB1
        ConnectionString MyCon = new ConnectionString();
        public void FillXRays()
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
        private void X_Rays_Load(object sender, EventArgs e)
        {
            FillXRays();
        }
        //

        // Start of Navigation Bar
        private void label22_Click(object sender, EventArgs e)
        {
            DocAppointments appointments = new DocAppointments();
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
            Medical_History.Medical_History mdhistory = new Medical_History.Medical_History();
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
            X_Rays xrays = new X_Rays();
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

        // Start on Insertion
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO XrayTB7 (patientName, Periapical, Panoramic, CBCT, Orthodantic, Cebhaometric, Bitewing, Dental_Examination_Recordpatient_ID, Dental_Examination_Recordresults_Of_Dental_Examainations) " +
       "VALUES (@patientName, @Periapical, @Panoramic, @CBCT, @Orthodantic, @Cebhaometric, @Bitewing, @Dental_Examination_Recordpatient_ID, @Dental_Examination_Recordresults_Of_Dental_Examainations)";


            try
            {
                using (SqlConnection connection = MyCon.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@patientName", comboBox1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Periapical", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Panoramic", textBox2.Text);
                        cmd.Parameters.AddWithValue("@CBCT", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Orthodantic", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Cebhaometric", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Bitewing", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Dental_Examination_Recordpatient_ID", textBox7.Text);
                        cmd.Parameters.AddWithValue("@Dental_Examination_Recordresults_Of_Dental_Examainations", textBox8.Text);


                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("X Rays Successfully Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // End Of Insertion
    }


    }

