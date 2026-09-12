using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLCodeGenerator.Database;
namespace Code_Genrator
{
    public partial class frmCodeGenratorMain : Form
    {
        public frmCodeGenratorMain()
        {
            InitializeComponent();
        }
       
        void _LoadDatabases()
        {
            DataTable dt = clsDataAccessSettings.GetAllDatabase();
            cmbDatabases.DataSource = dt;
            cmbDatabases.DisplayMember = "name";
      
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _LoadDatabases();
            cmbAuthentication.SelectedIndex = 0;
            cmbDatabases.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtServerName.Text.Trim()))
            { 
            MessageBox.Show("Please enter server name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }


            if(clsDataAccessSettings.TestConnection(txtServerName.Text.Trim(), txtUserName.Text.Trim(), txtPassword.Text.Trim(), cmbAuthentication.SelectedIndex == 1))
            {
                MessageBox.Show("Connection successful!","Success",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (cmbAuthentication.SelectedIndex == 1)
                {
                    clsDataAccessSettings.ConnectionString = $"Server={txtServerName.Text.Trim()};Database={cmbDatabases.Text};User Id={txtUserName.Text.Trim()};Password={txtPassword.Text.Trim()}";
                }
                else
                {
                    clsDataAccessSettings.ConnectionString =
                $"Server={txtServerName.Text.Trim()};" +
                $"Database={cmbDatabases.Text};" +
                $"Integrated Security=True;";
                }
                    
                    btnGoToGenrat.Visible = true;
              //pbPhoto.Visible = true;

            }
            else
            {
                MessageBox.Show("Connection failed!","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAuthentication.SelectedIndex == 0)
            {
                lblPassword.Visible = false;
                lblUserName.Visible = false;
                txtPassword.Visible = false;
                txtUserName.Visible = false;
            }
            else 
            {
                lblPassword.Visible =true;
                lblUserName.Visible =true;
                txtPassword.Visible =true;
                txtUserName.Visible =true;

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGoToGenrat_Click(object sender, EventArgs e)
        {
            frmCodeGenrator codeGenrator = new frmCodeGenrator(cmbDatabases.Text, txtServerName.Text);
            codeGenrator.ShowDialog();
        }
    }
}
