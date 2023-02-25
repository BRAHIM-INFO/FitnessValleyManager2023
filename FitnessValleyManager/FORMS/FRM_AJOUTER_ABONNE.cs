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

namespace FitnessValleyManager
{
    public partial class FRM_AJOUTER_ABONNE : Form
    { 
        public static PictureBox Pic_PROF = new PictureBox();
       
        public static int NumIdProf = 0;
        public static int NumIdProfPoste = 0;
        bool IfUpdate = false;
        string Sex = "ذكر";
        string KeysVal = "";
        Siticone.UI.WinForms.SiticoneRoundedButton Btn_Default = new Siticone.UI.WinForms.SiticoneRoundedButton(); 
        ENTITIES.CLS_SUBSCRIBER CLS_SUBSCRIBER = new ENTITIES.CLS_SUBSCRIBER();
        DAL.DAL_SUBSCRIBER DAL_SUBSCRIBER = new DAL.DAL_SUBSCRIBER();
        string CallType;
        public FRM_AJOUTER_ABONNE(string _CallType, int ID_SUB, string RegisteCivile_SUB, string IDCard_SUB, string Nom_SUB, string DateNaiss_SUB, string LieuNaiss_SUB, string DateInscrip_SUB, string Sexe_SUB, string Phone_SUB, string Adresse_SUB,
            string Email_SUB, string Nationalite_SUB, PictureBox QrCode_SUB, PictureBox Image_SUB)
        {
            InitializeComponent();
            CallType = _CallType;
            CmdSave.Enabled = true;
            EnableAll(true);
            txtID_SUB.Text = ID_SUB.ToString();
            txtNom_SUB.Text = Nom_SUB;
            txtRegisteCivile_SUB.Text = RegisteCivile_SUB;
            txtDateNaiss_SUB.Value = DateTime.Now;// DateTime.Parse(DateNaiss_SUB);
            txtDateInscrip_SUB.Value = DateTime.Now;//DateTime.Parse(DateInscrip_SUB);
            txtLieuNaiss_SUB.Text = LieuNaiss_SUB; 
            txtAdresse_SUB.Text = Adresse_SUB;
            txtPhone_SUB.Text = Phone_SUB;
            txtEmail_SUB.Text = Email_SUB;
            txtNationalite_SUB.Text = Nationalite_SUB;
            imgageQRCode = QrCode_SUB;
            ImgAbonnee = Image_SUB;

            // cls_users.LoadPermission(2, Btn_Default, Btn_Default, Btn_Default, Btn_Default);
        }

        //public void Alert(string msg, FRM_ALERT.enmType type)
        //{
        //    FRM_ALERT frm = new FRM_ALERT();
        //    frm.showAlert(msg, type);
        //}


        
        public void EmptyData()
        {
            txtID_SUB.Text = string.Empty;
            txtNom_SUB.Text = string.Empty;
            txtLieuNaiss_SUB.Text = string.Empty;
            txtAdresse_SUB.Text = string.Empty; 
            txtPhone_SUB.Text = string.Empty; 
            txtEmail_SUB.Text = string.Empty;
            txtDateInscrip_SUB.Value = DateTime.Now;
            txtDateNaiss_SUB.Value = DateTime.Now;
            txtRegisteCivile_SUB.Text = string.Empty; 
            txtNationalite_SUB.Text = string.Empty;
            
            ImgAbonnee.Image = Properties.Resources.icons8_school_director_48; 
            imgageQRCode.Image = Properties.Resources.cf258720ded328c92d5a821c78b5a052;
        }

        public void EnableAll(bool Values)
        {
            txtID_SUB.Enabled = Values;
            txtNom_SUB.Enabled = Values;
            txtLieuNaiss_SUB.Enabled = Values;
            txtAdresse_SUB.Enabled = Values;
            txtPhone_SUB.Enabled = Values;
            txtEmail_SUB.Enabled = Values;
            txtDateNaiss_SUB.Enabled = Values;
            txtRegisteCivile_SUB.Enabled = Values; 
            txtNationalite_SUB.Enabled = Values;
            txtDateInscrip_SUB.Enabled = Values;
            ImgAbonnee.Enabled = Values;
            imgageQRCode.Enabled = Values; 
        }
         
        public async Task LOADING_DATA(DataGridView Dgs)
        { 
            try
            {
                //con = new SqlConnection(Properties.Settings.Default.DB_PersonnelManagementConnectionString300);
                //Dgs.DataSource = null;
                //con.Open();
                //cmd.Connection = con;
                //cmd.CommandText = @"SELECT ID_EMP, NOM_EMP, DATENAISS_EMP, LIEUNAISS_EMP, ADRESSE_EMP, SEX_EMP, DATEINSCR_EMP, DIPLOME_EMP, NOM_POSTE, SALAIRE_EMP, ETAT_SOC_EMP, TEL01_EMP, TEL02_EMP, EMAIL_EMP, Notes_EMP," +
                //         "IMAGE_EMP, QR_CODE_EMP, FINGER_EMP FROM TBL_EMPS";
                //await cmd.ExecuteNonQueryAsync();
                //con.Close();
                //using (SqlDataAdapter Dta = new SqlDataAdapter(cmd))
                //{
                //    DataTable dt = new DataTable();
                //    Dta.Fill(dt);
                //    Dgs.DataSource = dt;
                //}
            }
            catch (Exception ex)
            {

            }

        }

        public void FRM_EMP_ADD_Load(object sender, EventArgs e)
        {
            if (CallType == "FRM_SUBSCRIBER_LIST")
            {
                lblTitle.Text = "تعديل  بيانات مشترك";
                CmdNew.Visible = false;
                IfUpdate = true;
            }
            else
            {
                txtID_SUB.Text = "";
            }

            //int CountEMP = tBL_EMPSTableAdapter.GetData().Count;
            //if (CountEMP >= 5)
            //{
            //var frm = new Forms.FRM_EVALUATION();
            //frm.ShowDialog();
            //this.Enabled = false;
            //// }
        }

        private async void CmdNew_Click(object sender, EventArgs e)
        { 
            //int CountEMP = tBL_EMPSTableAdapter.GetData().Count;
            //if (CountEMP >= 5)
            //{
            //    var frm = new Forms.FRM_EVALUATION();
            //    frm.ShowDialog();
            //    this.Enabled = false;
            //} 


            EmptyData();
            EnableAll(true);

            //incrimenter ID Subscriber 
            int NewID = await DAL_SUBSCRIBER.IncrementID();
            txtID_SUB.Text = NewID.ToString();

            CmdNew.Enabled = false;
            CmdSave.Enabled = true; 
            BtnWebCam.Enabled = true;
            BtnParcour.Enabled = true;
            BtnCodeBarre.Enabled = true;
        }

        private async void CmdSave_Click(object sender, EventArgs e)
        {

            if (txtRegisteCivile_SUB.Text == string.Empty |   txtNom_SUB.Text == string.Empty | txtPhone_SUB.Text == string.Empty)
            {
                MessageBox.Show("رجاء أدخل جميع البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //int CountEMP = tBL_EMPSTableAdapter.GetData().Count;
            //if (CountEMP >= 5)
            //{
            //    var frm = new Forms.FRM_EVALUATION();
            //    frm.ShowDialog();
            //    this.Enabled = false;
            //}
            

            ////انشاء الباركود تلقائيا اذا لم يتم انشاءه من قبل
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            imgageQRCode.Image = qrcode.Draw(txtID_SUB.Text, 50);
 

            if (IfUpdate == false)
            {
               int Resp = await  DAL_SUBSCRIBER.AddSubscriber( int.Parse(txtID_SUB.Text), txtRegisteCivile_SUB.Text,  txtNom_SUB.Text, txtDateNaiss_SUB.Value.ToShortDateString(), txtLieuNaiss_SUB.Text,
                    txtDateInscrip_SUB.Value.ToShortDateString(), Sex , txtPhone_SUB.Text,txtAdresse_SUB.Text,txtEmail_SUB.Text, txtNationalite_SUB.Text, imgageQRCode , ImgAbonnee); 

                if(Resp == 1) { MessageBox.Show("تم إنشاء مشترك (ة) بنجاح", ""); } 
                
                //MessageBox.Show("تم إنشاء موظف (ة) بنجاح", "");
                //this.Alert("تم إنشاء موظف (ة) بنجاح", FRM_ALERT.enmType.Success);

            }
            else
            {
                int Resp = await DAL_SUBSCRIBER.UpdateSubscriber(KeysVal, int.Parse(txtID_SUB.Text), txtRegisteCivile_SUB.Text,  txtNom_SUB.Text, txtDateNaiss_SUB.Value.ToShortDateString(), txtLieuNaiss_SUB.Text,
                     txtDateInscrip_SUB.Value.ToShortDateString(), Sex, txtPhone_SUB.Text, txtAdresse_SUB.Text, txtEmail_SUB.Text, txtNationalite_SUB.Text, imgageQRCode, ImgAbonnee);

                if (Resp == 1) { MessageBox.Show("تم إنشاء مشترك (ة) بنجاح", ""); }
                //this.Alert("تم تعديل موظف (ة) بنجاح", FRM_ALERT.enmType.Success);
            } 

            //اعدادات الازرار 
            EmptyData();
            EnableAll(false);
            CmdNew.Enabled = true;
            CmdSave.Enabled = false; 
        }

        

        private void CmdModify_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID_SUB.Text))
            {
                IfUpdate = true;
                EnableAll(true);
                CmdNew.Enabled = false;
                CmdSave.Enabled = true; 
            }
        }
         
        private void CmdClose_Click(object sender, EventArgs e)
        {
            IfUpdate = false;
            CmdSave.Enabled = false;
            CmdNew.Enabled = true; 
            EmptyData();
            EnableAll(false);
        }
         

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
         
        private void BtnParcour_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ofd = new OpenFileDialog();
            Ofd.Filter = "Files Images|*.JPG; *.PNG; *.GIF; *.BMP";
            if (Ofd.ShowDialog() == DialogResult.OK)
            {
                ImgAbonnee.Image = Image.FromFile(Ofd.FileName); 
            }
        }

        private void BtnWebCam_Click(object sender, EventArgs e)
        {
            var frm = new FRM_CAM();
            frm.ShowDialog();
            ImgAbonnee.Image = Pic_PROF.Image;
        }

        private void BtnCodeBarre_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            imgageQRCode.Image = qrcode.Draw(txtID_SUB.Text, 50);
        }
 
        private void txtPrenomProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtLieuNaissProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtAdresseProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtDiplomeProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtPosteProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void TxtSalaire_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtTel01Prof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTel02Prof_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtEmailProf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        } 

        private void txtRegisteCivile_SUB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void txtIDCard_SUB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{ENTER}");
            }
        }

        private void RB_SexeMale_CheckedChanged(object sender, EventArgs e)
        {
            if(RB_SexeMale.Checked)
            {
                Sex = "ذكر";
            }
            else
            {
                Sex = "أنثى";
            }
        }

        private void RB_SexeFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (RB_SexeMale.Checked)
            {
                Sex = "أنثى";
            }
            else
            {
                Sex = "ذكر";
            }
        }
    }
}
