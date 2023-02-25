using FitnessValleyManager.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessValleyManager
{
    public partial class FRM_LISTE_ABONNEES : Form
    {
        DAL_SUBSCRIBER DAL_SUBSCRIBER = new DAL_SUBSCRIBER();
        public FRM_LISTE_ABONNEES()
        {
            InitializeComponent();
        }

        public static Image StrToImg(string Strimage)
        {
            byte[] img = Convert.FromBase64String(Strimage);

            MemoryStream ms = new MemoryStream(img);

            return Image.FromStream(ms);
        }


        private async void GetAll()
        {
            DataTable dataTable = await DAL_SUBSCRIBER.GetAllSubscribers();
            DG_Subscribers.DataSource = dataTable;
            //DG_Subscribers.Rows.Add(dataTable.Rows.Count);
            //for (int i = 0; i < dataTable.Rows.Count; i++)
            //{
            //    DG_Subscribers.Rows[i].Cells[1].Value = Image.FromFile("photos\\1.png");
            //    DG_Subscribers.Rows[i].Cells[2].Value = dataTable.Rows[i][1].ToString();
            //    DG_Subscribers.Rows[i].Cells[3].Value = dataTable.Rows[i][3].ToString();
            //    DG_Subscribers.Rows[i].Cells[4].Value = dataTable.Rows[i][4].ToString();
            //    DG_Subscribers.Rows[i].Cells[5].Value = dataTable.Rows[i][5].ToString();
            //    DG_Subscribers.Rows[i].Cells[6].Value = dataTable.Rows[i][6].ToString();
            //    DG_Subscribers.Rows[i].Cells[8].Value = dataTable.Rows[i][8].ToString();
            //    DG_Subscribers.Rows[i].Cells[10].Value = dataTable.Rows[i][10].ToString();
            //} 
            lblCountSub.Text = DG_Subscribers.Rows.Count.ToString(); 
        }

        private async void Messages_Load(object sender, EventArgs e)
        {
            GetAll(); 
        }

        private async void DG_Subscribers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataTable dataTable = await DAL_SUBSCRIBER.GetByIDSubscribers(int.Parse(DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[2].Value.ToString()));

            //if (dataTable.Rows.Count > 0)
            //{
            //    txtLieuNaiss_SUB.Text = dataTable.Rows[0][7].ToString(); //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[7].Value.ToString();
            //    txtAdresse_SUB.Text = dataTable.Rows[0][7].ToString();  //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[11].Value.ToString();
            //    txtEmail_SUB.Text = dataTable.Rows[0][7].ToString();  //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[15].Value.ToString();
            //    txtNationalite_SUB.Text = dataTable.Rows[0][7].ToString();  //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[13].Value.ToString();
            //} 
        }

        private void DG_Subscribers_SelectionChanged(object sender, EventArgs e)
        {
            //if (DG_Subscribers.Rows.Count > 0)
            //{
            //    txtLieuNaiss_SUB.Text = DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[9].Value.ToString();
            //    txtAdresse_SUB.Text = DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[10].Value.ToString();
            //    txtEmail_SUB.Text = DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[11].Value.ToString();
            //    txtNationalite_SUB.Text = DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[12].Value.ToString();
            //}
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (DG_Subscribers.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد المشترك من القائمة");
                return;
            }

            if (DG_Subscribers.SelectedRows.Count > 0)
            {

                MessageBox.Show(DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[0].Value.ToString());
                var frm = new FRM_AJOUTER_ABONNE("FRM_SUBSCRIBER_LIST", int.Parse(DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[2].Value.ToString()),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[3].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[4].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[5].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[6].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[7].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[8].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[9].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[10].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[11].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[12].Value.ToString(),
                    DG_Subscribers.Rows[DG_Subscribers.CurrentCell.RowIndex].Cells[13].Value.ToString(),
                    imgageQRCode,
                     imgageQRCode);
                frm.ShowDialog();
            }
        }

        private async void DG_Subscribers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                
            //DataTable dataTable = await DAL_SUBSCRIBER.GetByIDSubscribers(int.Parse(DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[2].Value.ToString()));

            //if (dataTable.Rows.Count > 0)
            //{
            //    txtLieuNaiss_SUB.Text = dataTable.Rows[0][7].ToString(); //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[7].Value.ToString();
            //    txtAdresse_SUB.Text = dataTable.Rows[0][7].ToString();  //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[11].Value.ToString();
            //    txtEmail_SUB.Text = dataTable.Rows[0][7].ToString();  //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[15].Value.ToString();
            //    txtNationalite_SUB.Text = dataTable.Rows[0][7].ToString();  //DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[13].Value.ToString();
            //}
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (DG_Subscribers.CurrentRow == null)
            {
                MessageBox.Show("من فضلك حدد المشترك من القائمة");
                return;
            }

            if (DG_Subscribers.SelectedRows.Count > 0)
            {
                if (DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[2].Value.ToString() != "ADMIN")
                {
                    if (MessageBox.Show("هل تريد حذف ؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        MessageBox.Show(DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[0].Value.ToString());
                        int Resp = await DAL_SUBSCRIBER.DeleteSubscriber(DG_Subscribers.Rows[DG_Subscribers.CurrentRow.Index].Cells[0].Value.ToString());

                        if (Resp == 1)
                        {
                            GetAll();
                        } 
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (DG_Subscribers.Rows.Count > 0)
            {

                Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                xcelApp.Application.Workbooks.Add(Type.Missing);

                for (int i = 1; i < DG_Subscribers.Columns.Count + 1; i++)
                {
                    xcelApp.Cells[1, i] = DG_Subscribers.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < DG_Subscribers.Rows.Count; i++)
                {
                    for (int j = 0; j < DG_Subscribers.Columns.Count; j++)
                    {
                        xcelApp.Cells[i + 2, j + 1] = DG_Subscribers.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcelApp.Columns.AutoFit();
                xcelApp.Visible = true;
            }
        }
    }
}
