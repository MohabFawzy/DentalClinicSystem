using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MyXRay
    {


        public void AddXRays(string query)
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
        public void DeleteXRays(string query)
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






        public class XRDatabaseHelper
        {
            public void UpdateMedicalHistory(string query, string patientName, string Periapical, string panoramic, string CBCT , string Orthodantic, string Cebhaometric, string Bitewing,
                string Dental_Examination_Recordpatient_ID , string Dental_Examination_Recordresults_Of_Dental_Examainations)
            {
                ConnectionString MyConnection = new ConnectionString();
                using (SqlConnection Con = MyConnection.GetCon())
                {
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        if (!string.IsNullOrEmpty(patientName))
                            cmd.Parameters.AddWithValue("@patientName", patientName);
                        if (!string.IsNullOrEmpty(Periapical) || string.IsNullOrEmpty(Periapical))
                            cmd.Parameters.AddWithValue("@Periapical", Periapical);
                        if (!string.IsNullOrEmpty(panoramic) || string.IsNullOrEmpty(panoramic))
                            cmd.Parameters.AddWithValue("@panoramic", panoramic);
                        if (!string.IsNullOrEmpty(CBCT) || string.IsNullOrEmpty(CBCT))
                            cmd.Parameters.AddWithValue("@CBCT", CBCT);
                        if (!string.IsNullOrEmpty(Orthodantic) || string.IsNullOrEmpty(Orthodantic))
                            cmd.Parameters.AddWithValue("@Orthodantic", Orthodantic);
                        if (!string.IsNullOrEmpty(Cebhaometric) || string.IsNullOrEmpty(Cebhaometric))
                            cmd.Parameters.AddWithValue("@Cebhaometric", Cebhaometric);
                        if (!string.IsNullOrEmpty(Bitewing) || string.IsNullOrEmpty(Bitewing))
                            cmd.Parameters.AddWithValue("@Bitewing", Bitewing);
                        if (!string.IsNullOrEmpty(Dental_Examination_Recordpatient_ID) || string.IsNullOrEmpty(Dental_Examination_Recordpatient_ID))
                            cmd.Parameters.AddWithValue("@Dental_Examination_Recordpatient_ID", Dental_Examination_Recordpatient_ID);
                        if (!string.IsNullOrEmpty(Dental_Examination_Recordresults_Of_Dental_Examainations) || string.IsNullOrEmpty(Dental_Examination_Recordresults_Of_Dental_Examainations))
                            cmd.Parameters.AddWithValue("@Dental_Examination_Recordresults_Of_Dental_Examainations", Dental_Examination_Recordresults_Of_Dental_Examainations);
                        Con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }

        }


        public DataSet ShowXRays(string query)
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

