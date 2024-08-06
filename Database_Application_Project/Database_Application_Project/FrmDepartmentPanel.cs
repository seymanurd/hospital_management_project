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
    public partial class FrmDepartmentPanel : Form
    {
        public FrmDepartmentPanel()
        {
            InitializeComponent();
        }
        SqlConnect cnt = new SqlConnect();
        private void FrmDepartmentPanel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Branch",cnt.connection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Table_Branch (BranchName) values (@b1)", cnt.connection());
            command.Parameters.AddWithValue("@b1", TxtDepartmentName.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("New department added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int select = dataGridView1.SelectedCells[0].RowIndex;
            TxtId.Text = dataGridView1.Rows[select].Cells[0].Value.ToString();
            TxtDepartmentName.Text = dataGridView1.Rows[select].Cells[1].Value.ToString();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Delete From Table_Branch where BranchName=@b1", cnt.connection());
            command.Parameters.AddWithValue("@b1", TxtDepartmentName.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Deletion process completed successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Update Table_Branch set BranchName=@b1 where BranchId=@b2", cnt.connection());
            command.Parameters.AddWithValue("@b1", TxtDepartmentName.Text);
            command.Parameters.AddWithValue("@b2", TxtId.Text);
            command.ExecuteNonQuery();
            cnt.connection().Close();
            MessageBox.Show("Department updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
