using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Database_Application_Project
{
    class SqlConnect
    {
        public SqlConnection connection()
        {
            SqlConnection connect = new SqlConnection("Data Source=DESKTOP-P4A1KSH\\SQLEXPRESS;Initial Catalog=HospitalManagement;Integrated Security=True");
            connect.Open();
            return connect;
        }

    }
}
