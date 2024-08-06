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
    public partial class FrmDoctorEditInfo : Form
    {
        public FrmDoctorEditInfo()
        {
            InitializeComponent();
        }
        SqlConnect cnt = new SqlConnect();
        public string TCNum;
        private void FrmDoctorEditInfo_Load(object sender, EventArgs e)
        {
            MskTc.Text = TCNum;

            SqlCommand command = new SqlCommand("Select * From Table_Doctors where DoctorTC=@p1", cnt.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                TxtName.Text = dr[1].ToString();
                TxtSurname.Text = dr[2].ToString();
                CmbDepartment.Text = dr[3].ToString();
                TxtPassword.Text = dr[5].ToString();
            }
            cnt.connection().Close();
        }

        private void BtnEditInfo_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Table_Doctors set  DoctorName=@p1, DoctorSurname=@p2, DoctorBranch=@p3, DoctorPassword=@p4 where DoctorTC=@p5", cnt.connection());
            command.Parameters.AddWithValue("@p1", TxtName.Text);
            command.Parameters.AddWithValue("@p2", TxtSurname.Text);
            command.Parameters.AddWithValue("@p3", CmbDepartment.Text);
            command.Parameters.AddWithValue("@p4", TxtPassword.Text);
            command.Parameters.AddWithValue("@p5", MskTc.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
