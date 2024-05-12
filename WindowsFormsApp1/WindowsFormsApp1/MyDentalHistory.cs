using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MyDentalHistory
    {
        public void AddDentalHistory(string query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            Con.Close();

        }
        public void DeleteDentalHistory(string query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.GetCon();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            Con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            Con.Close();
        }






        public class DHDatabaseHelper
        {
            public void UpdateDentalHistory(string query, string patientName, string frecuancy_of_dental_vists,
                string frecuancy_of_dental_proohylaxis, string past_experince_during_after_dental_extraction,
                string past_experince_during_after_local_anasthesia, string past_periodontal_therapy,
                string past_orthodontic_treatment, string fixed_or_removebale_prosthesis_history, string root_canal_treatment, string surgical_proceduars, string complications_of_previous_dental_treatment
                , string radiation_therapy_for_oral_and_facial_structures)
            {
                ConnectionString MyConnection = new ConnectionString();
                using (SqlConnection Con = MyConnection.GetCon())
                {
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        if (!string.IsNullOrEmpty(patientName))
                            cmd.Parameters.AddWithValue("@patientName", patientName);
                        if (!string.IsNullOrEmpty(frecuancy_of_dental_vists) || string.IsNullOrEmpty(frecuancy_of_dental_vists))
                            cmd.Parameters.AddWithValue("@frecuancy_of_dental_vists", frecuancy_of_dental_vists);
                        if (!string.IsNullOrEmpty(frecuancy_of_dental_proohylaxis) || string.IsNullOrEmpty(frecuancy_of_dental_proohylaxis))
                            cmd.Parameters.AddWithValue("@frecuancy_of_dental_proohylaxis", frecuancy_of_dental_proohylaxis);
                        if (!string.IsNullOrEmpty(past_experince_during_after_dental_extraction) || string.IsNullOrEmpty(past_experince_during_after_dental_extraction)  )
                            cmd.Parameters.AddWithValue("@past_experince_during_after_dental_extraction", past_experince_during_after_dental_extraction);
                        if (!string.IsNullOrEmpty(past_experince_during_after_local_anasthesia) || string.IsNullOrEmpty(past_experince_during_after_local_anasthesia)  )
                            cmd.Parameters.AddWithValue("@past_experince_during_after_local_anasthesia", past_experince_during_after_local_anasthesia);
                        if (!string.IsNullOrEmpty(past_periodontal_therapy) || string.IsNullOrEmpty(past_periodontal_therapy))
                            cmd.Parameters.AddWithValue("@past_periodontal_therapy", past_periodontal_therapy);
                        if (!string.IsNullOrEmpty(past_orthodontic_treatment) || string.IsNullOrEmpty(past_orthodontic_treatment)  )
                            cmd.Parameters.AddWithValue("@past_orthodontic_treatment", past_orthodontic_treatment);
                        if (!string.IsNullOrEmpty(fixed_or_removebale_prosthesis_history)  || string.IsNullOrEmpty(fixed_or_removebale_prosthesis_history))
                            cmd.Parameters.AddWithValue("@fixed_or_removebale_prosthesis_history", fixed_or_removebale_prosthesis_history);
                        if (!string.IsNullOrEmpty(root_canal_treatment) || string.IsNullOrEmpty(root_canal_treatment))
                            cmd.Parameters.AddWithValue("@root_canal_treatment", root_canal_treatment);
                        if (!string.IsNullOrEmpty(surgical_proceduars) || string.IsNullOrEmpty(surgical_proceduars))
                            cmd.Parameters.AddWithValue("@surgical_proceduars", surgical_proceduars);
                        if (!string.IsNullOrEmpty(complications_of_previous_dental_treatment) || string.IsNullOrEmpty(complications_of_previous_dental_treatment))
                            cmd.Parameters.AddWithValue("@complications_of_previous_dental_treatment", complications_of_previous_dental_treatment);
                        if (!string.IsNullOrEmpty(radiation_therapy_for_oral_and_facial_structures) || string.IsNullOrEmpty(radiation_therapy_for_oral_and_facial_structures))
                            cmd.Parameters.AddWithValue("radiation_therapy_for_oral_and_facial_structures", radiation_therapy_for_oral_and_facial_structures);


                        Con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }


        public DataSet ShowDentalHistory(string query)
        {
            ConnectionString MyConnection = new ConnectionString();
            SqlConnection Con = MyConnection.GetCon();
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
