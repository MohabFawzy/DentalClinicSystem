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
using WindowsFormsApp1.Patient_Management;
using static WindowsFormsApp1.MyDentalHistory;


namespace WindowsFormsApp1.Dental_History
{
    public partial class Dental_History : Form
    {
        public Dental_History()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();
        public void Fillpatient()
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
        private void Dental_History_Load(object sender, EventArgs e)
        {
            Fillpatient();
        }

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
            Medical_History.Medical_History mdhistory = new Medical_History.Medical_History();
            mdhistory.Show(this);
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Dental_History dnhistory = new Dental_History();
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


        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            string searchText = comboBox1.Text.ToLower();


            comboBox1.Items.Clear();


            DataTable dt = GetDataFromAppointmentTB2();


            foreach (DataRow row in dt.Rows)
            {
                string itemName = row["patientName"].ToString();


                if (itemName.ToLower().Contains(searchText))
                {
                    comboBox1.Items.Add(itemName);
                }
            }


            comboBox1.DroppedDown = true;
        }

        private DataTable GetDataFromAppointmentTB2()
        {
            DataTable dt = new DataTable();
            try
            {

                using (SqlConnection con = MyCon.GetCon())
                {
                    con.Open();
                    string query = "SELECT patientName FROM dentalhistoryTB8";

                    // Execute SQL query
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader rdr = cmd.ExecuteReader();
                        dt.Load(rdr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dt;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Construct the parameterized query with column names specified
            string query = "INSERT INTO dentalhistoryTB8 (patientName, frecuancy_of_dental_vists, frecuancy_of_dental_proohylaxis, past_experince_during_after_dental_extraction, past_experince_during_after_local_anasthesia, past_periodontal_therapy, past_orthodontic_treatment, fixed_or_removebale_prosthesis_history, root_canal_treatment, surgical_proceduars, complications_of_previous_dental_treatment, radiation_therapy_for_oral_and_facial_structures) VALUES (@patientName, @frecuancy_of_dental_vists, @frecuancy_of_dental_proohylaxis, @past_experince_during_after_dental_extraction, @past_experince_during_after_local_anasthesia, @past_periodontal_therapy, @past_orthodontic_treatment, @fixed_or_removebale_prosthesis_history, @root_canal_treatment, @surgical_proceduars, @complications_of_previous_dental_treatment, @radiation_therapy_for_oral_and_facial_structures)";

            try
            {
                using (SqlConnection connection = MyCon.GetCon())
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        cmd.Parameters.AddWithValue("@patientName", comboBox1.SelectedValue ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@frecuancy_of_dental_vists", textBox1.Text);
                        cmd.Parameters.AddWithValue("@frecuancy_of_dental_proohylaxis", textBox2.Text);
                        cmd.Parameters.AddWithValue("@past_experince_during_after_dental_extraction", textBox3.Text);
                        cmd.Parameters.AddWithValue("@past_experince_during_after_local_anasthesia", textBox4.Text);
                        cmd.Parameters.AddWithValue("@past_periodontal_therapy", textBox5.Text);
                        cmd.Parameters.AddWithValue("@past_orthodontic_treatment", textBox6.Text);
                        cmd.Parameters.AddWithValue("@fixed_or_removebale_prosthesis_history", textBox7.Text);
                        cmd.Parameters.AddWithValue("@root_canal_treatment", textBox8.Text);
                        cmd.Parameters.AddWithValue("@surgical_proceduars", textBox9.Text);
                        cmd.Parameters.AddWithValue("@complications_of_previous_dental_treatment", textBox10.Text);
                        cmd.Parameters.AddWithValue("@radiation_therapy_for_oral_and_facial_structures", textBox11.Text);

                        // Execute the query
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Patient Successfully Added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                // Start building the query
                string query = "UPDATE dentalhistoryTB8 SET ";
                List<string> updateFields = new List<string>();

                // Check if each field has a value and add it to the update query
                if (comboBox1.SelectedValue != null && !string.IsNullOrEmpty(comboBox1.SelectedValue.ToString())) // Update patientName if it's not empty
                    updateFields.Add("patientName = @patientName");
                if (!string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox1.Text)) 
                    updateFields.Add("frecuancy_of_dental_vists = @frecuancy_of_dental_vists");
                if (!string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox2.Text)) 
                    updateFields.Add("frecuancy_of_dental_proohylaxis = @frecuancy_of_dental_proohylaxis");
                if (!string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox3.Text)) 
                    updateFields.Add("past_experince_during_after_dental_extraction = @past_experince_during_after_dental_extraction");
                if (!string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox4.Text)  ) 
                    updateFields.Add("past_experince_during_after_local_anasthesia = @past_experince_during_after_local_anasthesia");
                if (!string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox5.Text)) 
                    updateFields.Add("past_periodontal_therapy = @past_periodontal_therapy");
                if (!string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox6.Text)  ) 
                    updateFields.Add("past_orthodontic_treatment = @past_orthodontic_treatment");
                if (!string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox7.Text)) 
                    updateFields.Add("fixed_or_removebale_prosthesis_history = @fixed_or_removebale_prosthesis_history");
                if (!string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox8.Text)) 
                    updateFields.Add("root_canal_treatment = @root_canal_treatment");
                if (!string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox9.Text)) 
                    updateFields.Add("surgical_proceduars = @surgical_proceduars");
                if (!string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox10.Text)  ) 
                    updateFields.Add("complications_of_previous_dental_treatment = @complications_of_previous_dental_treatment");
                if (!string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox11.Text)  ) 
                    updateFields.Add("radiation_therapy_for_oral_and_facial_structures = @radiation_therapy_for_oral_and_facial_structures");



                // Combine all update fields into the query
                query += string.Join(", ", updateFields);

                // Add the WHERE clause
                query += " WHERE patientName = @patientName";

                try
                {
                    // Assign parameter values





                    string patientName = comboBox1.SelectedValue.ToString();
                    string frecuancy_of_dental_vists = textBox1.Text;
                    string frecuancy_of_dental_proohylaxis = textBox2.Text;
                    string past_experince_during_after_dental_extraction = textBox3.Text;
                    string past_experince_during_after_local_anasthesia = textBox4.Text;
                    string past_periodontal_therapy = textBox5.Text;
                    string past_orthodontic_treatment = textBox6.Text;
                    string fixed_or_removebale_prosthesis_history = textBox7.Text;
                    string root_canal_treatment = textBox8.Text;
                    string surgical_proceduars = textBox9.Text;
                    string complications_of_previous_dental_treatment = textBox10.Text;
                    string radiation_therapy_for_oral_and_facial_structures = textBox11.Text;

                    

                    // Create an instance of PatientDatabaseHelper class
                    DHDatabaseHelper dhdbHelper = new DHDatabaseHelper();

                    // Call the UpdatePatient method through the instance
                    dhdbHelper.UpdateDentalHistory(query, patientName, frecuancy_of_dental_vists, frecuancy_of_dental_proohylaxis, past_experince_during_after_dental_extraction,
                        past_experince_during_after_local_anasthesia, past_periodontal_therapy, past_orthodontic_treatment, fixed_or_removebale_prosthesis_history, root_canal_treatment,
                        surgical_proceduars, complications_of_previous_dental_treatment, radiation_therapy_for_oral_and_facial_structures);

                    MessageBox.Show("Dental History Successfully Updated");
                    //populate(); // Assuming this method populates your UI with updated data
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a Patient's Name to update.");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
