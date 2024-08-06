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
    public partial class FrmPatientInfo : Form
    {
        public FrmPatientInfo()
        {
            InitializeComponent();
        }

        public string tc;

        SqlConnect cnt = new SqlConnect();
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmPatientInfo_Load(object sender, EventArgs e)
        {
            //name surname
            LblTc.Text = tc;
            SqlCommand command = new SqlCommand("Select PatientName,PatientSurname" +
                " From Table_Patients where PatientTc=@p1", cnt.connection());
            command.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LblNameSurname.Text = dr[0] + " " + dr[1];
            }
            cnt.connection().Close();

            //history 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Appointments " +
                "where PatientTc =" + tc, cnt.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //department

            SqlCommand command2 = new SqlCommand("Select BranchName From Table_Branch" , cnt.connection());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                CmbDepartment.Items.Add(dr2[0]);
            }
            cnt.connection().Close();
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoctor.Items.Clear();
            SqlCommand command3 = new SqlCommand("Select DoctorName, DoctorSurname " +
                "From Table_Doctors where DoctorBranch=@p1", cnt.connection());
            command3.Parameters.AddWithValue("@p1", CmbDepartment.Text);
            SqlDataReader dr3 = command3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoctor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            cnt.connection().Close();
        }

        private void CmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Appointments " +
                "where AppointmentBranch='"+CmbDepartment.Text +"' and AppointmentStatus=0",cnt.connection());
            //sadece durumu 0 olanlar görüntülenecek
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void LnkEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormEditInfo ei = new FormEditInfo();
            ei.TcNo = LblTc.Text;
            ei.Show(); 
        }
        //hangi hücreye tıklarsak randevu id otomatik atanması için
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView2.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView2.Rows[select].Cells[0].Value.ToString();
        }
        //boş randevuları alma, şikayet yazma
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Tbl_Appointments set AppointmentStatus=1, " +
                "PatientTc=@p1, PatientProblem=@p2 where AppointmentId=@p3", cnt.connection());
            command.Parameters.AddWithValue("@p1", LblTc.Text);
            command.Parameters.AddWithValue("@p2", RchProblem.Text);
            command.Parameters.AddWithValue("@p3", TxtId.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Appointment created successfully!", "Information",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
