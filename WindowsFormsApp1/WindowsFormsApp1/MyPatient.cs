using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    internal class MyPatient
    {
        public void AddPatient( string query)
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
        public void DeletePatient( string query )
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

        public class PatientDatabaseHelper
        {
            public void UpdatePatient(string query, string patientName, string patientPhone, string patientAge, string patientGender, string patientAddress, int patientID)
            {
                ConnectionString MyConnection = new ConnectionString();
                using (SqlConnection Con = MyConnection.GetCon())
                {
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        if (!string.IsNullOrEmpty(patientName))
                            cmd.Parameters.AddWithValue("@patientName", patientName);
                        if (!string.IsNullOrEmpty(patientPhone))
                            cmd.Parameters.AddWithValue("@patientPhone", patientPhone);
                        if (!string.IsNullOrEmpty(patientAge))
                            cmd.Parameters.AddWithValue("@patientAge", patientAge);
                        if (!string.IsNullOrEmpty(patientGender))
                            cmd.Parameters.AddWithValue("@patientGender", patientGender);
                        if (!string.IsNullOrEmpty(patientAddress))
                            cmd.Parameters.AddWithValue("@patientAddress", patientAddress);

                        // Add patientID parameter
                        cmd.Parameters.AddWithValue("@patientID", patientID);

                        Con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }













        public DataSet ShowPatient(string query)
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
