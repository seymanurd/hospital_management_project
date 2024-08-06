using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Application_Project
{
    public partial class FrmLogins : Form
    {
        public FrmLogins()
        {
            InitializeComponent();
        }

        private void BtnPatientLogin_Click(object sender, EventArgs e)
        {
            FrmPatientLogin pl = new FrmPatientLogin();
            pl.Show();
            this.Hide();
        }

        private void BtnDoctorLogin_Click(object sender, EventArgs e)
        {
            FrmDoctorLogin dl = new FrmDoctorLogin();
            dl.Show();
            this.Hide();
        }

        private void BtnSecretaryLogin_Click(object sender, EventArgs e)
        {
            FrmSecretaryLogin sl = new FrmSecretaryLogin();
            sl.Show();
            this.Hide();
        }

        private void FrmLogins_Load(object sender, EventArgs e)
        {

        }
    }
}
