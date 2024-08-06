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
    public partial class FrmDoctorPanel : Form
    {
        public FrmDoctorPanel()
        {
            InitializeComponent();
        }
        SqlConnect cnt = new SqlConnect();
        private void FrmDoctorPanel_Load(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From Table_Doctors", cnt.connection());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            
            //department combobox

            SqlCommand command2 = new SqlCommand("Select BranchName From Table_Branch", cnt.connection());
            SqlDataReader dr2 = command2.ExecuteReader();
            while (dr2.Read())
            {
                CmbDepartment.Items.Add(dr2[0]);
            }
            cnt.connection().Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Table_Doctors (DoctorName, DoctorSurname, DoctorBranch, DoctorTC, DoctorPassword) values (@d1,@d2,@d3,@d4,@d5)", cnt.connection());
            command.Parameters.AddWithValue("@d1", TxtName.Text);
            command.Parameters.AddWithValue("@d2", TxtSurname.Text);
            command.Parameters.AddWithValue("@d3", CmbDepartment.Text);
            command.Parameters.AddWithValue("@d4", MskTc.Text);
            command.Parameters.AddWithValue("@d5", TxtPassword.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("New doctor added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //in doctor panel if we are select any other box, my panel full of the information 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            TxtName.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[select].Cells[2].Value.ToString();
            CmbDepartment.Text = dataGridView1.Rows[select].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[select].Cells[4].Value.ToString();
            TxtPassword.Text = dataGridView1.Rows[select].Cells[5].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Delete From Table_Doctors where DoctorTC=@p1", cnt.connection());
            command.Parameters.AddWithValue("@p1", MskTc.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Deletion process completed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Table_Doctors set DoctorName=@d1, DoctorSurname=@d2, DoctorBranch=@d3,  DoctorPassword=@d5 where DoctorTC=@d4", cnt.connection());
            command.Parameters.AddWithValue("@d1", TxtName.Text);
            command.Parameters.AddWithValue("@d2", TxtSurname.Text);
            command.Parameters.AddWithValue("@d3", CmbDepartment.Text);
            command.Parameters.AddWithValue("@d4", MskTc.Text);
            command.Parameters.AddWithValue("@d5", TxtPassword.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Doctor updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
