using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class MyAppoinments
    {
        public void AddPatient(string query)
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
        public void DeletePatient(string query)
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
        public class AppDatabaseHelper
        {
            public void UpdateAppointment(string query, string patientName, DateTime todayDate, DateTime sessionDate, string sessionTime)
            {
                ConnectionString MyConnection = new ConnectionString();
                using (SqlConnection Con = MyConnection.GetCon())
                {
                    using (SqlCommand cmd = new SqlCommand(query, Con))
                    {
                        cmd.Parameters.AddWithValue("@patientName", patientName);
                        cmd.Parameters.AddWithValue("@todayDate", todayDate);
                        cmd.Parameters.AddWithValue("@sessionDate", sessionDate);
                        cmd.Parameters.AddWithValue("@sessionTime", sessionTime);

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

