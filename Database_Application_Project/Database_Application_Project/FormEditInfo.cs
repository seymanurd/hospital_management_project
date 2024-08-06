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
    public partial class FormEditInfo : Form
    {
        public FormEditInfo()
        {
            InitializeComponent();
        }
        public string TcNo;

        SqlConnect cnt = new SqlConnect();
        private void BtnEditInfo_Click(object sender, EventArgs e)
        {
            SqlCommand command2 = new SqlCommand("update Table_Patients set PatientName=@p1, PatientSurname=@p2, " +
                "PatientPhone=@p3, PatientPassword=@p4, PatientGender=@p5 where PatientTC=@p6",cnt.connection());
            command2.Parameters.AddWithValue("@p1", TxtName.Text);
            command2.Parameters.AddWithValue("@p2", TxtSurname.Text);
            command2.Parameters.AddWithValue("@p3", MskPhone.Text);
            command2.Parameters.AddWithValue("@p4", TxtPassword.Text);
            command2.Parameters.AddWithValue("@p5", CmbGender.Text);
            command2.Parameters.AddWithValue("@p6", MskTc.Text);
            command2.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Your information has been updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FormEditInfo_Load(object sender, EventArgs e)
        {
            MskTc.Text = TcNo;
            SqlCommand command = new SqlCommand("Select * From Table_Patients where PatientTC = @p1", cnt.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                TxtName.Text = dr[1].ToString();
                TxtSurname.Text = dr[2].ToString();
                MskPhone.Text = dr[4].ToString();
                TxtPassword.Text = dr[5].ToString();
                CmbGender.Text = dr[6].ToString();
            }
            cnt.connection().Close();
        }
    }
}
