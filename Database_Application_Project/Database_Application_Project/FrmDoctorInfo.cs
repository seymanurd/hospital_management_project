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
    public partial class FrmDoctorInfo : Form
    {
        public FrmDoctorInfo()
        {
            InitializeComponent();
        }
        SqlConnect cnt = new SqlConnect();
        public string TcNumb;
        private void LblTc_Click(object sender, EventArgs e)
        {

        }

        private void FrmDoctorInfo_Load(object sender, EventArgs e)
        {
            LblTc.Text = TcNumb;

            //doctor Name surname
            SqlCommand command = new SqlCommand("Select DoctorName,DoctorSurname From Table_Doctors where DoctorTC=@p1", cnt.connection());
            command.Parameters.AddWithValue("@p1", LblTc.Text);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LblNameSurname.Text = dr[0] + " " + dr[1];
            }
            cnt.connection().Close();

            //Randevu listesi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Appointments where AppointmentDoctor ='" + LblNameSurname.Text+"'", cnt.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEditInfo_Click(object sender, EventArgs e)
        {
            FrmDoctorEditInfo dei = new FrmDoctorEditInfo();
            dei.TCNum = LblTc.Text;
            dei.Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            RchProblem.Text = dataGridView1.Rows[select].Cells[7].Value.ToString();
        }
    }
}
