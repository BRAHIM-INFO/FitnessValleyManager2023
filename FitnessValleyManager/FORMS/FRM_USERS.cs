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
    public partial class FRM_USERS : Form
    {
        DAL.DAL_USERS DAL_USERS = new DAL_USERS();
        bool IfUpdate = false;
        string KeysVal = "";
        public FRM_USERS()
        {
            InitializeComponent();
        }

        private void FRM_USERS_Load(object sender, EventArgs e)
        {
            GetAll();
        }

        public void EmptyData()
        {
            txtID_USER.Text = string.Empty;
            txtUSERNAME_CLUB.Text = string.Empty;
            txtPASSWORD_CLUBConferme.Text = string.Empty;
            txtPASSWORD_CLUB.Text = string.Empty;
        }

        public void EnableAll(bool Values)
        {
            txtID_USER.Enabled = Values;
            txtUSERNAME_CLUB.Enabled = Values;
            txtPASSWORD_CLUBConferme.Enabled = Values;
            txtPASSWORD_CLUB.Enabled = Values; 
        }

        private async void GetAll()
        { 
            DataTable DtUsers = await DAL_USERS.GetAllUserss(); 
            DGUsers.DataSource = DtUsers;
            DGUsers.Columns[0].Visible = false;
            lblCountUsers.Text = DGUsers.Rows.Count.ToString();

            if (DGUsers.Rows.Count == 0)
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

        private async void CmdNew_Click(object sender, EventArgs e)
        {
            IfUpdate = false;
            EmptyData();
            EnableAll(true);

            //incrimenter ID Subscriber 
            int NewID = await DAL_USERS.IncrementID();
            txtID_USER.Text = NewID.ToString();

            CmdNew.Enabled = false;
            CmdSave.Enabled = true;
            CmdClose.Enabled = true;
        }

        private async void CmdSave_Click(object sender, EventArgs e)
        {
            if (txtID_USER.Text == string.Empty | txtUSERNAME_CLUB.Text == string.Empty | txtPASSWORD_CLUBConferme.Text == string.Empty | txtPASSWORD_CLUB.Text == string.Empty)
            {
                MessageBox.Show("رجاء أدخل جميع البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IfUpdate == true)
            {
                int Resp = await DAL_USERS.UpdateUsers(KeysVal , int.Parse(txtID_USER.Text), txtUSERNAME_CLUB.Text, txtPASSWORD_CLUB.Text);

                if (Resp == 1)
                {
                    MessageBox.Show("تم تعديل المستخدم بنجاح", "تعديل  المستخدم  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmdSave.Enabled = false;
                    CmdClose.Enabled = false;
                    EmptyData();
                    EnableAll(false);
                    GetAll();
                }
            }
            else
            {
                if (txtUSERNAME_CLUB.Text != "ADMIN")
                {
                    int Resp = await DAL_USERS.AddUsers(int.Parse(txtID_USER.Text), txtUSERNAME_CLUB.Text, txtPASSWORD_CLUB.Text);
                    if (Resp == 1)
                    {
                        MessageBox.Show("تم إنشاء المستخدم بنجاح", "إضافة  مستخدم جديد ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CmdSave.Enabled = false;
                        CmdClose.Enabled = false;
                        EmptyData();
                        EnableAll(false);
                        GetAll();
                    }
                }
            }
        } 
        

        private void txtUSERNAME_CLUB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPASSWORD_CLUB.Focus();
            }
        }

        private void txtPASSWORD_CLUB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPASSWORD_CLUBConferme.Focus();
            }
        }

        private void txtPASSWORD_CLUBConferme_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtPASSWORD_CLUB.Text == txtPASSWORD_CLUBConferme.Text)
                {
                    CmdSave.Focus();
                }
                else
                { 
                    MessageBox.Show("عذرا خطأ في كلمة المرور", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } 
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DGUsers.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد المستخدم من القائمة");
                return;
            }

            if (DGUsers.SelectedRows.Count > 0)
            {

                KeysVal = DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[0].Value.ToString();
                txtID_USER.Text = DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[1].Value.ToString();
                txtUSERNAME_CLUB.Text = DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[2].Value.ToString();
                txtPASSWORD_CLUB.Text = DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[3].Value.ToString();
                txtPASSWORD_CLUBConferme.Text = DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[3].Value.ToString();
                EnableAll(true);
                IfUpdate = true;
                CmdNew.Enabled = false;
                CmdSave.Enabled = true;
                CmdClose.Enabled = true;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (DGUsers.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد المستخدم من القائمة");
                return;
            }

            if (DGUsers.SelectedRows.Count > 0)
            {
                if (DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[2].Value.ToString() != "ADMIN")
                {
                    if (MessageBox.Show("هل تريد حذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {

                        int Resp = await DAL_USERS.DeleteUsers(DGUsers.Rows[DGUsers.CurrentRow.Index].Cells[0].Value.ToString());

                        if (Resp == 1)
                        {
                            GetAll();
                        }

                    }
                }
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
            if (DGUsers.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < DGUsers.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = DGUsers.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < DGUsers.Rows.Count; i++)
                {
                    for (int j = 0; j < DGUsers.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = DGUsers.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
