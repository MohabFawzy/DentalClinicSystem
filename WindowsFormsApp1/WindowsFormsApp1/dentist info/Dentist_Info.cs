using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Patient_Management;

namespace WindowsFormsApp1.dentist_info
{
    public partial class Dentist_Info : Form
    {
        public Dentist_Info()
        {
            InitializeComponent();
        }

        private void Dentist_Info_Load(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {
            Appointments appointments = new Appointments();
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


    }
}
