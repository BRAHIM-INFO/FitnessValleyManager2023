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

namespace FitnessValleyManager.FORMS
{
    public partial class FRM_SETTING : Form
    {
        DAL.DAL_SETTING DAL_SETTING = new DAL_SETTING();
        public FRM_SETTING()
        {
            InitializeComponent();
        }

        public void EmptyData()
        {
            txtNOM_CLUB.Text = string.Empty;
            txtFISCALE_CLUB.Text = string.Empty;
            txtADRESSE_CLUB.Text = string.Empty;
            txtPAY_CLUB.Text = string.Empty;
            txtTEL_CLUB.Text = string.Empty;
            txtEmail_SUB.Text = string.Empty;
            txtEmail_SUB.Text = string.Empty;
            txtWEBSITEEmail_SUB.Text = string.Empty;
            ImageLOGO_SUB.Image = Properties.Resources.icons8_school_director_48;
        }


        private async void CmdSave_Click(object sender, EventArgs e)
        {
            int Resp = await DAL_SETTING.UpdateSetting("-NP2Abj44-Y624t3DtoV", 1, txtNOM_CLUB.Text, txtFISCALE_CLUB.Text, txtADRESSE_CLUB.Text, txtPAY_CLUB.Text, txtTEL_CLUB.Text, txtEmail_SUB.Text, txtWEBSITEEmail_SUB.Text, ImageLOGO_SUB);


            if (Resp == 1) { MessageBox.Show("تم تعديل البيانات بنجاح", ""); }
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            EmptyData();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        } 
       

        public static Image StrToImg(string  Strimage)
        {
            byte[] img = Convert.FromBase64String(Strimage);

            MemoryStream ms = new MemoryStream(img);

            return Image.FromStream(ms);
        }


        private async void FRM_SETTING_Load(object sender, EventArgs e)
        { 
            DataTable dataTable = await DAL_SETTING.GetAllSettings();

            dataGridView1.DataSource = dataTable;

            txtNOM_CLUB.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();  
            txtFISCALE_CLUB.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();  
            txtADRESSE_CLUB.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            txtPAY_CLUB.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();  
            txtTEL_CLUB.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
            txtEmail_SUB.Text = dataGridView1.Rows[0].Cells[7].Value.ToString();
            txtWEBSITEEmail_SUB.Text = dataGridView1.Rows[0].Cells[8].Value.ToString(); 

            ImageLOGO_SUB.Image = StrToImg(dataGridView1.Rows[0].Cells[9].Value.ToString());

            //byte[] bytes = Encoding.ASCII.GetBytes(dataGridView1.Rows[0].Cells[9].Value.ToString());
            //ImageLOGO_SUB.Image =  byteArrayToImage(bytes);
        }

        private void BtnParcour_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Files Images|*.JPG; *.PNG; *.GIF; *.BMP";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                ImageLOGO_SUB.Image = Image.FromFile(Ofd.FileName); 
            }
        }
    }
}

