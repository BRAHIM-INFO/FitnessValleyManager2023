using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SqlClient;
using FitnessValleyManager.DAL; 
using FireSharp;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;

namespace FitnessValleyManager.FORMS
{
    public partial class FRM_AJOUTER_BOUCKET : Form
    { 
        DAL.DAL_BOUCKET DAL_BOUCKET = new DAL_BOUCKET(); 
        bool IfUpdate = false;
        string KeysVal = "";
        public FRM_AJOUTER_BOUCKET()
        {
            InitializeComponent();
        }

        private async void CmdNew_Click(object sender, EventArgs e)
        {
            IfUpdate = false;
            EmptyData();
            EnableAll(true);

            //incrimenter ID Subscriber 
            int NewID = await DAL_BOUCKET.IncrementID();
            txtID_BOUCKET.Text = NewID.ToString();

            CmdNew.Enabled = false;
            CmdSave.Enabled = true;
            CmdClose.Enabled = true;
        }

        private async void GetAll()
        {
            DataTable DtBoucket = await DAL_BOUCKET.GetAllBoucketss();
            DGBoucket.DataSource = DtBoucket;
            DGBoucket.Columns[0].Visible = false;
            lblCountBouckets.Text = DGBoucket.Rows.Count.ToString();

            if (DGBoucket.Rows.Count == 0)
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            }
        }


        public void EnableAll(bool Values)
        {
            txtID_BOUCKET.Enabled = Values;
            txtNOM_BOUCKET.Enabled = Values;
            txtDELAI_BOUCKET.Enabled = Values;
            txtPRICE_BOUCKET.Enabled = Values;
        }

        public void EmptyData()
        {
            txtID_BOUCKET.Text = string.Empty;
            txtNOM_BOUCKET.Text = string.Empty;
            txtDELAI_BOUCKET.Value = 1;
            txtPRICE_BOUCKET.Text = "0.00";
        }

        private void FRM_AJOUTER_BOUCKET_Load(object sender, EventArgs e)
        { 
           GetAll();
        }

        private async void CmdSave_Click(object sender, EventArgs e)
        {
            if (txtNOM_BOUCKET.Text == string.Empty | txtPRICE_BOUCKET.Text == string.Empty ) 
            {
                MessageBox.Show("رجاء أدخل جميع البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IfUpdate == true)
            {
                int Resp = await DAL_BOUCKET.UpdateBouckets(KeysVal, int.Parse(txtID_BOUCKET.Text), txtNOM_BOUCKET.Text, txtDELAI_BOUCKET.Text, double.Parse(txtPRICE_BOUCKET.Text.Replace(".", ",")));

                if (Resp == 1)
                {
                    MessageBox.Show("تم تعديل الباقة بنجاح", "تعديل  الباقة  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmdNew.Enabled = true;
                    CmdSave.Enabled = false;
                    CmdClose.Enabled = false;
                    EmptyData();
                    EnableAll(false);
                    GetAll();
                }
            }
            else
            {

                int Resp = await DAL_BOUCKET.AddBouckets(int.Parse(txtID_BOUCKET.Text), txtNOM_BOUCKET.Text, txtDELAI_BOUCKET.Text, double.Parse(txtPRICE_BOUCKET.Text.Replace(".", ",")));
                if (Resp == 1)
                {
                    MessageBox.Show("تم إنشاء الباقة بنجاح", "إضافة  باقة جديدة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmdNew.Enabled = true;
                    CmdSave.Enabled = false;
                    CmdClose.Enabled = false;
                    EmptyData();
                    EnableAll(false);
                    GetAll();
                } 
            }
        }

        private void txtNOM_BOUCKET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDELAI_BOUCKET.Focus();
            }
        }

        private void txtDELAI_BOUCKET_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPRICE_BOUCKET.Focus();
            }
        }

        private void txtPRICE_BOUCKET_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DGBoucket.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد الباقة من القائمة");
                return;
            }
 
            if (DGBoucket.SelectedRows.Count > 0)
            {
                KeysVal = DGBoucket.Rows[DGBoucket.CurrentRow.Index].Cells[0].Value.ToString();
                txtID_BOUCKET.Text = DGBoucket.Rows[DGBoucket.CurrentRow.Index].Cells[1].Value.ToString();
                txtNOM_BOUCKET.Text = DGBoucket.Rows[DGBoucket.CurrentRow.Index].Cells[2].Value.ToString();
                txtDELAI_BOUCKET.Text = DGBoucket.Rows[DGBoucket.CurrentRow.Index].Cells[3].Value.ToString();
                txtPRICE_BOUCKET.Text = DGBoucket.Rows[DGBoucket.CurrentRow.Index].Cells[4].Value.ToString();
                var valor = txtPRICE_BOUCKET.Text.Replace("€", "");
                txtPRICE_BOUCKET.Text = string.Format("{0:C}", Convert.ToDouble(valor)).Replace("€", "");

                EnableAll(true);
                IfUpdate = true;
                CmdNew.Enabled = false;
                CmdSave.Enabled = true;
                CmdClose.Enabled = true;
            }
            
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (DGBoucket.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد الباقة من القائمة");
                return;
            }
 
            if (DGBoucket.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("هل تريد حذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                { 
                    int Resp = await DAL_BOUCKET.DeleteBouckets(DGBoucket.Rows[DGBoucket.CurrentRow.Index].Cells[0].Value.ToString());

                    if (Resp == 1)
                    {
                        GetAll();
                    } 
                }
            }
        }

         

        private void txtPRICE_BOUCKET_Leave(object sender, EventArgs e)
        {
            try
            {
                Double value = double.Parse(txtPRICE_BOUCKET.Text);
                txtPRICE_BOUCKET.Text = value.ToString("N");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }  
        }

        private void txtPRICE_BOUCKET_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txtPRICE_BOUCKET.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            EmptyData();
            EnableAll(false);
            CmdNew.Enabled = true;
            CmdSave.Enabled = false;
            IfUpdate = false;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            if (DGBoucket.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < DGBoucket.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = DGBoucket.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < DGBoucket.Rows.Count; i++)
                {
                    for (int j = 0; j < DGBoucket.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = DGBoucket.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
