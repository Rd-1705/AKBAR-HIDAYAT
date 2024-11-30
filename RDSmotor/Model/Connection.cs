using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDSmotor.Model
{
    internal class Connection
    {
        public MySqlCommand cmd;
        public DataSet ds;
        public MySqlDataAdapter da;

        public MySqlConnection GetConn()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;user=root;database=RDSMotor;Allow User Variables=True";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                ;
                MessageBox.Show("Koneksi gagal" + ex.Message);
            }
            return conn;
        }
    }
}
