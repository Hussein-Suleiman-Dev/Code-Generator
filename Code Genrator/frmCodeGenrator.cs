using SQLCodeGenerator.Database;
using SQLCodeGenerator.Genrator;
using SQLCodeGenerator.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Genrator
{
    public partial class frmCodeGenrator : Form
    {
        public frmCodeGenrator(string DataBase,string Server)
        {
            InitializeComponent();
            lblDatabaseName.Text= DataBase;
            lblServerName.Text= Server;
            this.Text= "Code Genrator - " + DataBase;
            chkl.ItemCheck += chkl_ItemCheck;
        }
        void _LoadTables()
        {
            List<string> tables = clsDatabaseReader.GetTables();
            foreach (string table in tables)
            {

                chkl.Items.Add(table);
            }
        }
        private void frmCodeGenrator_Load(object sender, EventArgs e)
        {
            _LoadTables();
          //  MessageBox.Show(clsDataAccessSettings.ConnectionString);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked)
            {
                for (int i = 0; i < chkl.Items.Count; i++)
                {
                    chkl.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chkl.Items.Count; i++)
                {
                    chkl.SetItemChecked(i, false);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputPath.Text = dialog.SelectedPath;
            }
        }
     
       private void _CompareDAL(clsTableInfo table)
        {
            StringBuilder code = new StringBuilder();

            if (chkAddDAL.Checked)
            {
                code.AppendLine(
                    clsDALGenrator.GenerateAddMethod(table));
            }

            if (chkDeleteDAL.Checked)
            {
                code.AppendLine(
                    clsDALGenrator.GenerateDeleteMethod(table));
            }

            if (chkFindDAL.Checked)
            {
                code.AppendLine(
                    clsDALGenrator.GenerateGetByIDMethod(table));
            }

            if (chkUpdateDAL.Checked)
            {
                code.AppendLine(
                    clsDALGenrator.GenerateUpdateMethod(table));
            }

            if (chkGetAllDAL.Checked)
            {
                code.AppendLine(
                    clsDALGenrator.GenerateGetAllMethod(table));
            }

            clsDALGenrator.SaveFile(
                table,
                code.ToString(),
                txtOutputPath.Text);
        }


        private void chkl_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btnGenrate.Enabled =
                e.NewValue == CheckState.Checked ||
                chkl.CheckedItems.Count > 1;
        }

        private void btnGenrate_Click(object sender, EventArgs e)
        {
            if(chkl.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select at least one table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtOutputPath.Text=="")
            {
                MessageBox.Show("Please select an output path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnGenrate.Enabled = true;
            bool DTO=chkDTO.Checked;
            bool DAL = chkDAL.Checked;
           bool BLL = chkBLL.Checked;
            if (rbAllClasses.Checked)
            {
                if (DAL || BLL||DTO)
                {
                    foreach (object Item in chkl.CheckedItems)
                    {
                        clsTableInfo table =
                            clsDatabaseReader.GetTableSchema(Item.ToString());

                        if (DAL)
                        {
                         clsDALGenrator.SaveFile(table, clsDALGenrator.GenerateDALClass(table), txtOutputPath.Text);
                        }

                        if (BLL)
                        {

                            clsGenrateBLL.SaveFileBLL(table, clsGenrateBLL.GenerateBLL(table), txtOutputPath.Text.Trim());
                        }
                        if (DTO)
                        {
                            clsGeneratorDTO.genrateDTO(table, txtOutputPath.Text);
                        }
                    }
                }

            
            }
            bool anyCheckedDAL = gbCustomFunctionDal.Controls
                   .OfType<CheckBox>()
                   .Any(chk => chk.Checked);
            bool anyCheckedBLL = gbCustomFunction.Controls
                  .OfType<CheckBox>()
                  .Any(chk => chk.Checked);
            if (rbCutomFunction.Checked)
            {

               

                if (!anyCheckedDAL||!anyCheckedBLL)
                {
                    MessageBox.Show("Please select at least one option.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                } 
                    
                    
                foreach (object item in chkl.CheckedItems)
                { 
                    clsTableInfo table = clsDatabaseReader.GetTableSchema(item.ToString());
                    if (chkAddDAL.Checked ||chkDeleteDAL.Checked ||chkFindDAL.Checked ||chkUpdateDAL.Checked ||chkGetAllDAL.Checked)
                    {
                        _CompareDAL(table);
                    }
                    if (chkAdd.Checked || chkDelete.Checked || chkFind.Checked || chkUpdate.Checked || chkGetAll.Checked)
                    {
                        clsGenrateBLL.GenerateCustomBLL( table,txtOutputPath.Text,chkFind.Checked,chkAdd.Checked,chkUpdate.Checked,chkDelete.Checked, chkGetAll.Checked, true);
                    }
                    if(chkDTO.Checked)
                    {
                        clsGeneratorDTO.genrateDTO(table, txtOutputPath.Text);
                    }
                }
            
            }
            MessageBox.Show("Saved Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void rbCutomFunction_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCutomFunction.Checked)
            {
                gbCustomFunction.Visible = true;
                gbCustomFunctionDal.Visible = true;
                chkDAL.Enabled = false;
                chkBLL.Enabled=false;

            }
            else { gbCustomFunction.Visible = false;
            gbCustomFunctionDal.Visible= false;
                chkDAL.Enabled = true;
                chkBLL.Enabled = true;
            }
        }

        private void rbCutomFunction_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbCutomFunction.Checked)
            {
                gbCustomFunction.Visible = true;
gbCustomFunctionDal.Visible = true;
                chkDAL.Enabled = false; chkBLL.Enabled = false;
            }
            else
            {
                gbCustomFunction.Visible = false;
                gbCustomFunctionDal.Visible = false;
                chkDAL.Enabled = true; chkBLL.Enabled = true;
            }
        }

      

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                btnGenrate.Enabled = chkl.CheckedItems.Count > 0;
            }));
            for (int i = 0; i < chkl.Items.Count; i++)
            {
                chkl.SetItemChecked(
            i,
            chkSelectAll.Checked);
            }
        }

        private void chkDTO_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDAL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkBLL_CheckedChanged(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                btnGenrate.Enabled = chkl.CheckedItems.Count > 0;
            }));
        }
    }
}
