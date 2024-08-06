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
    public partial class FrmPatientLogin : Form
    {
        public FrmPatientLogin()
        {
            InitializeComponent();
        }

        SqlConnect cnt = new SqlConnect();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LnkSignup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPatientSignUp ps = new FrmPatientSignUp();
            ps.Show();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From Table_Patients Where PatientTc=@p1 and PatientPassword=@p2", cnt.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.Parameters.AddWithValue("@p2", TxtPassword.Text);
            SqlDataReader dr = command.ExecuteReader();
            if(dr.Read())
            {
                FrmPatientInfo pi = new FrmPatientInfo();
                pi.tc = MskTc.Text;
                pi.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Tc Id or password!");
            }
            cnt.connection().Close();
        }

        private void FrmPatientLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
