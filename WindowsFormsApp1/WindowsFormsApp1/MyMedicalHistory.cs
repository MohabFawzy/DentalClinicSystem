using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MyMedicalHistory
    {

        public void AddMedicalHistory(string query)
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
        public void DeleteMedicalHistory(string query)
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






        public class MHDatabaseHelper
        {
            public void UpdateMedicalHistory(string query, string patientName, string Past_illness, string Present_illness, string Medication, string Allergy, string Hospitalization,
                string Immunization, string Infection, string Blood_transfusion, string Pregnancy)
            {
                ConnectionString MyConnection = new ConnectionString();
                using (SqlConnection Con = MyConnection.GetCon())
                {
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        if (!string.IsNullOrEmpty(patientName))
                            cmd.Parameters.AddWithValue("@patientName", patientName);
                        if (!string.IsNullOrEmpty(Past_illness) || string.IsNullOrEmpty(Past_illness))
                            cmd.Parameters.AddWithValue("@Past_illness", Past_illness);
                        if (!string.IsNullOrEmpty(Present_illness) || string.IsNullOrEmpty(Present_illness))
                            cmd.Parameters.AddWithValue("@Present_illness", Present_illness);
                        if (!string.IsNullOrEmpty(Medication) || string.IsNullOrEmpty(Medication))
                            cmd.Parameters.AddWithValue("@Medication", Medication);
                        if (!string.IsNullOrEmpty(Allergy) || string.IsNullOrEmpty(Allergy))
                            cmd.Parameters.AddWithValue("@Allergy", Allergy);
                        if (!string.IsNullOrEmpty(Hospitalization) || string.IsNullOrEmpty(Hospitalization))
                            cmd.Parameters.AddWithValue("@Hospitalization", Hospitalization);
                        if (!string.IsNullOrEmpty(Immunization) || string.IsNullOrEmpty(Immunization))
                            cmd.Parameters.AddWithValue("@Immunization", Immunization);
                        if (!string.IsNullOrEmpty(Infection) || string.IsNullOrEmpty(Infection))
                            cmd.Parameters.AddWithValue("@Infection", Infection);
                        if (!string.IsNullOrEmpty(Blood_transfusion) || string.IsNullOrEmpty(Blood_transfusion))
                            cmd.Parameters.AddWithValue("@Blood_transfusion", Blood_transfusion);
                        if (!string.IsNullOrEmpty(Pregnancy) || string.IsNullOrEmpty(Pregnancy))
                            cmd.Parameters.AddWithValue("@Pregnancy", Pregnancy);
                       


                        Con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }


        public DataSet ShowMedicalHistory(string query)
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

