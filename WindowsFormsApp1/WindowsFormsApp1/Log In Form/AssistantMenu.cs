using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Appointments;
using WindowsFormsApp1.Patient_Management;
using WindowsFormsApp1.Payments;

namespace WindowsFormsApp1.Log_In_Form
{
    public partial class AssistantMenu : Form
    {
        public AssistantMenu()
        {
            InitializeComponent();
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
    }
}
