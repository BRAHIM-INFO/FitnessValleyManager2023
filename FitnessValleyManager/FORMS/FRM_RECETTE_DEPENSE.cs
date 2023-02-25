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

namespace FitnessValleyManager.FORMS
{
    public partial class FRM_RECETTE_DEPENSE : Form
    {
        DAL.DAL_RECETTE_DEPENSE DAL_RECETTE_DEPENSE = new DAL_RECETTE_DEPENSE(); 
        bool IfUpdate = false;
        string KeysVal = "";
        string TYPE_REC_DEP = "الايرادات";
        public FRM_RECETTE_DEPENSE()
        {
            InitializeComponent();
        }

        private async void GetAll()
        {
            DataTable DtBoucket = await DAL_RECETTE_DEPENSE.GetAllDep_Rec();

            DG_Rec_Dep.DataSource = DtBoucket;
            DG_Rec_Dep.Columns[0].Visible = false;
            lblCount_Rec_Dep.Text = DG_Rec_Dep.Rows.Count.ToString();

            if (DG_Rec_Dep.Rows.Count == 0)
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
            txtDESCRIP_REC_DEP.Enabled = Values; 
            txtDISTIN_REC_DEP.Enabled = Values;
            txtFACT_REC_DEP.Enabled = Values;
            txtID_REC_DEP.Enabled = Values;
            txtMNT_VAT_REC_DEP.Enabled = Values;
            txtTOTAL_REC_DEP.Enabled = Values;
            txtVAT_REC_DEP.Enabled = Values;
            txtWITHOUT_VAT_REC_DEP.Enabled = Values;
            txtDATE_REC_DEP.Enabled = Values;
        }

        public void EmptyData()
        {
            txtDESCRIP_REC_DEP.Text = string.Empty;
            txtDISTIN_REC_DEP.Text = string.Empty;
            txtFACT_REC_DEP.Text = string.Empty;
            txtID_REC_DEP.Text = string.Empty;
            txtMNT_VAT_REC_DEP.Text = "0";
            txtTOTAL_REC_DEP.Text = "0";
            txtVAT_REC_DEP.Text = "0";
            txtWITHOUT_VAT_REC_DEP.Text = "0";
            txtDATE_REC_DEP.Value = DateTime.Now; 
        }

        private async void CmdNew_Click(object sender, EventArgs e)
        {
            IfUpdate = false;
            EmptyData();
            EnableAll(true);

            //incrimenter ID Subscriber 
            int NewID = await DAL_RECETTE_DEPENSE.IncrementID();
            txtID_REC_DEP.Text = NewID.ToString();

            RB_TYPE_REC.Checked = true;
            CmdNew.Enabled = false;
            CmdSave.Enabled = true;
            CmdClose.Enabled = true;
        }

        private void FRM_RECETTE_DEPENSE_Load(object sender, EventArgs e)
        {
            GetAll();
            //if (DG_Rec_Dep.Rows.Count > 0)
            //{
            //    DG_Rec_Dep.MultiSelect = false;
            //    DG_Rec_Dep.MultiSelect = true;
            //    DG_Rec_Dep.Rows[0].Selected = true;
            //} 
        }

        private async void CmdSave_Click(object sender, EventArgs e)
        {
            if (txtFACT_REC_DEP.Text == string.Empty | txtDISTIN_REC_DEP.Text == string.Empty | txtTOTAL_REC_DEP.Text == string.Empty | txtWITHOUT_VAT_REC_DEP.Text == string.Empty)
            {
                MessageBox.Show("رجاء أدخل جميع البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IfUpdate == true)
            {
                int Resp = await DAL_RECETTE_DEPENSE.UpdateDep_Rec( KeysVal, int.Parse(txtID_REC_DEP.Text), TYPE_REC_DEP, txtFACT_REC_DEP.Text,txtDATE_REC_DEP.Value.ToShortDateString(),txtDISTIN_REC_DEP.Text,txtDESCRIP_REC_DEP.Text, double.Parse(txtWITHOUT_VAT_REC_DEP.Text.Replace(".", ",")), double.Parse(txtVAT_REC_DEP.Text.Replace(".", ",")), double.Parse(txtMNT_VAT_REC_DEP.Text.Replace(".", ",")), double.Parse(txtTOTAL_REC_DEP.Text.Replace(".", ",")));

                if (Resp == 1)
                {
                    MessageBox.Show("تم تعديل " + TYPE_REC_DEP + " بنجاح", "تعديل  " + TYPE_REC_DEP + "  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                int Resp = await DAL_RECETTE_DEPENSE.AddDep_Rec(int.Parse(txtID_REC_DEP.Text), TYPE_REC_DEP, txtFACT_REC_DEP.Text, txtDATE_REC_DEP.Value.ToShortDateString(), txtDISTIN_REC_DEP.Text, txtDESCRIP_REC_DEP.Text, double.Parse(txtWITHOUT_VAT_REC_DEP.Text.Replace(".", ",")), double.Parse(txtVAT_REC_DEP.Text.Replace(".", ",")), double.Parse(txtMNT_VAT_REC_DEP.Text.Replace(".", ",")), double.Parse(txtTOTAL_REC_DEP.Text.Replace(".", ",")));
                if (Resp == 1)
                {
                    MessageBox.Show("تم إنشاء " + TYPE_REC_DEP + " بنجاح", "إضافة  "+ TYPE_REC_DEP + " جديدة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmdNew.Enabled = true;
                    CmdSave.Enabled = false;
                    CmdClose.Enabled = false;
                    EmptyData();
                    EnableAll(false);
                    GetAll();
                }
            }
        }

        private void RB_TYPE_REC_CheckedChanged(object sender, EventArgs e)
        {
            if(RB_TYPE_REC.Checked)
            {
                TYPE_REC_DEP = "الايرادات";
            }else
            {
                TYPE_REC_DEP = "المصروفات";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DG_Rec_Dep.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد الفاتورة من القائمة");
                return;
            }

            if (DG_Rec_Dep.SelectedRows.Count > 0)
            { 
                KeysVal = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[0].Value.ToString();
                txtID_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[1].Value.ToString();
                if (DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[2].Value.ToString() == "الايرادات")
                {
                    RB_TYPE_REC.Checked = true;
                }
                else
                {
                    RB_TYPE_DEP.Checked = true;
                }

                txtFACT_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[3].Value.ToString();
                txtDATE_REC_DEP.Value = DateTime.Parse(DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[4].Value.ToString());
                txtDISTIN_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[5].Value.ToString();
                txtDESCRIP_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[6].Value.ToString();
                txtWITHOUT_VAT_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[7].Value.ToString();
                txtVAT_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[8].Value.ToString();
                txtMNT_VAT_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[9].Value.ToString();
                txtTOTAL_REC_DEP.Text = DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[10].Value.ToString(); 

                var valor = txtWITHOUT_VAT_REC_DEP.Text.Replace("€", "");
                txtWITHOUT_VAT_REC_DEP.Text = string.Format("{0:C}", Convert.ToDouble(valor)).Replace("€", "");

                var valor1 = txtMNT_VAT_REC_DEP.Text.Replace("€", "");
                txtMNT_VAT_REC_DEP.Text = string.Format("{0:C}", Convert.ToDouble(valor1)).Replace("€", "");

                var valor2 = txtTOTAL_REC_DEP.Text.Replace("€", "");
                txtTOTAL_REC_DEP.Text = string.Format("{0:C}", Convert.ToDouble(valor2)).Replace("€", "");

                EnableAll(true);
                IfUpdate = true;
                CmdNew.Enabled = false;
                CmdSave.Enabled = true;
                CmdClose.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (DG_Rec_Dep.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد الفاتورة من القائمة");
                return;
            }

            if (DG_Rec_Dep.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("هل تريد حذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    int Resp = await DAL_RECETTE_DEPENSE.DeleteDep_Rec(DG_Rec_Dep.Rows[DG_Rec_Dep.CurrentRow.Index].Cells[0].Value.ToString());

                    if (Resp == 1)
                    {
                        GetAll();
                    }

                }
            }
        }

        private void txtTOTAL_REC_DEP_Leave(object sender, EventArgs e)
        {
            try
            {
                Double value = double.Parse(txtTOTAL_REC_DEP.Text);
                txtTOTAL_REC_DEP.Text = value.ToString("N");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void txtTOTAL_REC_DEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txtTOTAL_REC_DEP.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            EmptyData();
            CmdNew.Enabled = true;
            CmdSave.Enabled = false;
            IfUpdate = false;
            RB_TYPE_REC.Checked = true;
        }

        private void DG_Rec_Dep_SelectionChanged(object sender, EventArgs e)
        {
           
            
        }
        private void CalculeMontant()
        {
            double Sum = 0;
            double Vat = double.Parse(txtVAT_REC_DEP.Text);
            double WithoutVat = double.Parse(txtWITHOUT_VAT_REC_DEP.Text);
            double AmountVat = 0;

            AmountVat = Vat * (WithoutVat / 100)   ;
            Sum = (AmountVat + WithoutVat);
            txtMNT_VAT_REC_DEP.Text = AmountVat.ToString();
            txtTOTAL_REC_DEP.Text = Sum.ToString();

            //var valor = txtVAT_REC_DEP.Text.Replace("€", "");
            //txtVAT_REC_DEP.Text = string.Format("{0:C}", Convert.ToDouble(valor)).Replace("€", "");

            //var valor1 = txtWITHOUT_VAT_REC_DEP.Text.Replace("€", "");
            //txtWITHOUT_VAT_REC_DEP.Text = string.Format("{0:C}", Convert.ToDouble(valor1)).Replace("€", "");

            //var valor2 = txtTOTAL_REC_DEP.Text.Replace("€", "");
            //txtTOTAL_REC_DEP.Text = string.Format("{0:C}", Convert.ToDouble(valor2)).Replace("€", "");
        }

        private void txtVAT_REC_DEP_TextChanged(object sender, EventArgs e)
        {
            if (txtVAT_REC_DEP.Text == String.Empty) txtVAT_REC_DEP.Text = "0";
            CalculeMontant();
        }

        private void txtWITHOUT_VAT_REC_DEP_TextChanged(object sender, EventArgs e)
        {
            if (txtWITHOUT_VAT_REC_DEP.Text == String.Empty) txtVAT_REC_DEP.Text = "0";
            CalculeMontant();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (DG_Rec_Dep.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < DG_Rec_Dep.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = DG_Rec_Dep.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < DG_Rec_Dep.Rows.Count; i++)
                {
                    for (int j = 0; j < DG_Rec_Dep.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = DG_Rec_Dep.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }

        private void txtWITHOUT_VAT_REC_DEP_Leave(object sender, EventArgs e)
        {
            try
            {
                Double value = double.Parse(txtWITHOUT_VAT_REC_DEP.Text);
                txtWITHOUT_VAT_REC_DEP.Text = value.ToString("N");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void txtMNT_VAT_REC_DEP_Leave(object sender, EventArgs e)
        {
            try
            {
                Double value = double.Parse(txtMNT_VAT_REC_DEP.Text);
                txtMNT_VAT_REC_DEP.Text = value.ToString("N");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }
    }
}
