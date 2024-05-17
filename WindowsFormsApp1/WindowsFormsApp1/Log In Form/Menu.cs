using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.dentist_info;
using WindowsFormsApp1.Patient_Management;

namespace WindowsFormsApp1.Log_In_Form
{
    public partial class Menu : Form
    {
        public Menu()
        {

            InitializeComponent();
        }

        // Start Of Navigation Bar
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

        private void label1_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show(this);
            this.Hide();
        }
        // End Of Navigation Bar

        // Miss Click
        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    

      
}
