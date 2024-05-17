using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class ConnectionString
    {
        public SqlConnection GetCon()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = @"";
            return Con;
        }
    }
}
