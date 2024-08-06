using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Database_Application_Project
{
    public partial class FrmSecretaryLogin : Form
    {
        public FrmSecretaryLogin()
        {
            InitializeComponent();
        }
        SqlConnect cnt = new SqlConnect();
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From Table_Secretary where SecretaryTC=@p1 and SecretaryPassword=@p2", cnt.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", TxtPassword.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                FrmSecretaryInfo secretaryInfo = new FrmSecretaryInfo();
                secretaryInfo.TCnum = MskTc.Text;
                secretaryInfo.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid ID or password!");
            }
            cnt.connection().Close();
        }

        private void FrmSecretaryLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
