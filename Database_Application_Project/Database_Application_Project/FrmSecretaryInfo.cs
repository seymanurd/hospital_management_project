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
    public partial class FrmSecretaryInfo : Form
    {
        public FrmSecretaryInfo()
        {
            InitializeComponent();
        }
        public string TCnum;
        SqlConnect cnt = new SqlConnect();

        private void LblTc_Click(object sender, EventArgs e)
        {
           
        }

        private void FrmSecretaryInfo_Load(object sender, EventArgs e)
        {
            LblTc.Text = TCnum;

            //name surname

            SqlCommand command1 = new SqlCommand("Select SecretaryNameSurname From Table_Secretary where SecretaryTC=@p1",cnt.connection());
            command1.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr1 = command1.ExecuteReader();
            while (dr1.Read())
            {
                LblNameSurname.Text = dr1[0].ToString();

            }
            cnt.connection().Close();

            //department

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BranchName From Table_Branch",cnt.connection());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //Doctors datagrid

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select DoctorName, DoctorSurname, DoctorBranch From Table_Doctors", cnt.connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Department combobox

            SqlCommand command2 = new SqlCommand("Select BranchName From Table_Branch", cnt.connection());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                CmbDepartment.Items.Add(dr2[0]);
            }
            cnt.connection().Close();
        }
        // Appointment created
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand commandSubmit = new SqlCommand("insert into Tbl_Appointments (AppointmentDate, AppointmentTime, AppointmentBranch, AppointmentDoctor) values (@r1,@r2,@r3,@r4)", cnt.connection());
            commandSubmit.Parameters.AddWithValue("@r1", MskDate.Text);
            commandSubmit.Parameters.AddWithValue("@r2", MskTime.Text);
            commandSubmit.Parameters.AddWithValue("@r3", CmbDepartment.Text);
            commandSubmit.Parameters.AddWithValue("@r4", CmbDoctor.Text);
            commandSubmit.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Appointment created successfully!");
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoctor.Items.Clear();
            SqlCommand command = new SqlCommand("Select DoctorName, DoctorSurname From Table_Doctors where DoctorBranch=@p1", cnt.connection());
            command.Parameters.AddWithValue("@p1", CmbDepartment.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                CmbDoctor.Items.Add(dr[0] + " " + dr[1]);
            }
            cnt.connection().Close();
        }

        private void BtnDepartmentPanel_Click(object sender, EventArgs e)
        {
            FrmDepartmentPanel dp = new FrmDepartmentPanel();
            dp.Show();
        }

        private void BtnDoctorPanel_Click(object sender, EventArgs e)
        {
            FrmDoctorPanel drp = new FrmDoctorPanel();
            drp.Show();
        }

        private void BtnAppointmentPanel_Click(object sender, EventArgs e)
        {
            FrmAppointmentList al = new FrmAppointmentList();
            al.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
          
        }
    }
}
