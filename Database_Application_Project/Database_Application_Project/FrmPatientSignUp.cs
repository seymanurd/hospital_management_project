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
    public partial class FrmPatientSignUp : Form
    {
        public FrmPatientSignUp()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        SqlConnect cnt = new SqlConnect();

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Table_Patients(PatientName,PatientSurname,PatientTc,PatientPhone," +
                "PatientPassword,PatientGender) values (@p1,@p2,@p3,@p4,@p5,@p6)", cnt.connection());
            command.Parameters.AddWithValue("@p1", TxtName.Text);
            command.Parameters.AddWithValue("@p2", TxtSurname.Text);
            command.Parameters.AddWithValue("@p3", MskTc.Text);
            command.Parameters.AddWithValue("@p4", MskPhone.Text);
            command.Parameters.AddWithValue("@p5", TxtPassword.Text);
            command.Parameters.AddWithValue("@p6", CmbGender.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Registration successful! Your password:" + TxtPassword.Text, "Information",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void FrmPatientSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
