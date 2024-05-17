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
using WindowsFormsApp1.Log_In_Form;
using WindowsFormsApp1.Patient_Management;

namespace WindowsFormsApp1.dentist_info
{
    public partial class Dentist_Info : Form
    {
        public Dentist_Info()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();

        // Make ComboBox Get Data From Row DentistID In DentistTB3
        public void FillDoctor()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select DentistID from DentistTB3", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DentistID", typeof(string));
            dt.Load(rdr);
            comboBox1.ValueMember = "DentistID";
            comboBox1.DataSource = dt;
            Con.Close();
        }
        //


        // Shows Data When The Form Is Opened ( Loaded )
        private void Dentist_Info_Load(object sender, EventArgs e)
        {
            FillDoctor();
            populate();
        }
        //

        // Show the Data On the DataGridView
        void populate()
        {
            MyDentistInfo Pat = new MyDentistInfo();
            String query = "Select * from DentistTB3";
            DataSet ds = Pat.ShowDoctorInfo(query);
            dataGridView1.DataSource = ds.Tables[0];



        }
        //
        // Start Of Navigation Bar
        private void label17_Click(object sender, EventArgs e)
        {
            DocAppointments appointments = new DocAppointments();
            appointments.Show(this);
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Add_Patient add = new Add_Patient();
            add.Show(this);
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Payments.Payments payments = new Payments.Payments();
            payments.Show(this);
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Medical_History.Medical_History mdhistory = new Medical_History.Medical_History();
            mdhistory.Show(this);
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Dental_History.Dental_History dnhistory = new Dental_History.Dental_History();
            dnhistory.Show(this);
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            X_Rays.X_Rays xrays = new X_Rays.X_Rays();
            xrays.Show(this);
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Dentist_Info dentistInfo = new Dentist_Info();
            dentistInfo.Show(this);
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show(this);
            this.Hide();
        }
        // End Of Navigation Bar


        // Save Doctor's Info
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "insert into DentistTB3  values('"+ textBox1.Text + "','" + textBox2.Text +  "')";
            MyDentistInfo Pat = new MyDentistInfo();
            try
            {
                Pat.AddDoctor(query);
                MessageBox.Show("Doctor's info Saved");
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //

        // Miss Click
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // Miss Click
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
