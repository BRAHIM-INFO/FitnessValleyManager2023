using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp;
using FireSharp.Response;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;
using FitnessValleyManager.ENTITIES;
using System.IO;
using System.Drawing.Imaging;

namespace FitnessValleyManager.DAL
{
    public class DAL_SETTING
    {
        IFirebaseClient client;
        IFirebaseConfig con = new FirebaseConfig
        {
            AuthSecret = "OiU15ePqRhbCfb05N0QVKKoaTKDBLqRMqrCH5Qg2",
            BasePath = "https://dbfitnessvalley-default-rtdb.firebaseio.com/"
        };

        public DAL_SETTING()
        {
            client = new FirebaseClient(con);
        }

        

        public static string ImgToStr(PictureBox pic)
        {
            MemoryStream ms = new MemoryStream();
            pic.Image.Save(ms, pic.Image.RawFormat);
            return Convert.ToBase64String(ms.ToArray());
        }

        //Add new Setting In database
        public async Task<int> AddSetting(int ID_CLUB, string NOM_CLUB, string FISCALE_CLUB, string ADRESSE_CLUB, string PAY_CLUB, string TEL_CLUB, string Email_SUB, string WEBSITEEmail_SUB,  PictureBox ImageLOGO_SUB)
        {
            int Reponce = 0;
            var dt = new CLS_SETTING
            {
                ID_CLUB = ID_CLUB,
                NOM_CLUB = NOM_CLUB,
                FISCALE_CLUB = FISCALE_CLUB,
                ADRESSE_CLUB = ADRESSE_CLUB,
                PAY_CLUB = PAY_CLUB,
                TEL_CLUB = TEL_CLUB,
                Email_SUB = Email_SUB,
                WEBSITEEmail_SUB = WEBSITEEmail_SUB,
                ImageLOGO_SUB = ImgToStr(ImageLOGO_SUB)
            };

            var Resp = await client.PushAsync("TBL_SETTING", dt);
            if (Resp.StatusCode.ToString() == "OK")
            {
                Reponce = 1;
            }
            else
            {
                Reponce = 0;
            }
            return Reponce;
        }

        //Update  Setting In database
        public async Task<int> UpdateSetting(string Keys, int ID_CLUB, string NOM_CLUB, string FISCALE_CLUB, string ADRESSE_CLUB, string PAY_CLUB, string TEL_CLUB, string Email_SUB, string WEBSITEEmail_SUB,PictureBox  ImageLOGO_SUB)
        {
            int Reponce = 0;
            var dt = new CLS_SETTING
            {
                ID_CLUB = ID_CLUB,
                NOM_CLUB = NOM_CLUB,
                FISCALE_CLUB = FISCALE_CLUB,
                ADRESSE_CLUB = ADRESSE_CLUB,
                PAY_CLUB = PAY_CLUB,
                TEL_CLUB = TEL_CLUB,
                Email_SUB = Email_SUB,
                WEBSITEEmail_SUB = WEBSITEEmail_SUB,
                ImageLOGO_SUB = ImgToStr(ImageLOGO_SUB)
            };

            var Resp =  await client.UpdateAsync("TBL_SETTING/" + Keys, dt);
            if (Resp.StatusCode.ToString() == "OK")
            {
                Reponce = 1;
            }
            else
            {
                Reponce = 0;
            }
            return Reponce;

        }

        //Delete  Setting In database
        public async void DeleteSetting(string Keys)
        {
            await client.DeleteAsync("TBL_SETTING/" + Keys);
        }

        //GetAll Setting
        public async Task<DataTable> GetAllSettings()
        {
            DataTable dataTableSetting = new DataTable();
            dataTableSetting.Columns.Add("A", typeof(string));
            dataTableSetting.Columns.Add("B", typeof(string));
            dataTableSetting.Columns.Add("C", typeof(string));
            dataTableSetting.Columns.Add("D", typeof(string));
            dataTableSetting.Columns.Add("E", typeof(string));
            dataTableSetting.Columns.Add("F", typeof(string));
            dataTableSetting.Columns.Add("G", typeof(string));
            dataTableSetting.Columns.Add("H", typeof(string));
            dataTableSetting.Columns.Add("w", typeof(string));
            dataTableSetting.Columns.Add("ImgQrcode", typeof(string));


            var Res = await client.GetAsync("TBL_SETTING");
            Dictionary<string, CLS_SETTING> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SETTING>>(Res.Body.ToString());
            foreach (var line in data)
            {
                dataTableSetting.Rows.Add(new object[] {line.Key.ToString(),line.Value.ID_CLUB ,line.Value.NOM_CLUB ,line.Value.FISCALE_CLUB ,line.Value.ADRESSE_CLUB ,
                    line.Value.PAY_CLUB ,line.Value.TEL_CLUB ,line.Value.Email_SUB ,line.Value.WEBSITEEmail_SUB , line.Value.ImageLOGO_SUB });

            }
            return dataTableSetting;
        } 

        //Get image from database
        public Image stringToImage(string inputString)
        {
            byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);

            // Don't need to use the constructor that takes the starting offset and length
            // as we're using the whole byte array.
            MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms, true, true);
            return image;
        }
 

        //GetAll Setting Image
        public async Task<Image> GetImageSetting(int ID_SUB)
        {
            Image ImgSub = FitnessValleyManager.Properties.Resources.icons8_school_director_48;
            var Res = await client.GetAsync("TBL_SETTING");
            Dictionary<string, CLS_SETTING> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SETTING>>(Res.Body.ToString());
            foreach (var line in data)
            { 
                ImgSub = stringToImage(line.Value.ImageLOGO_SUB); 
            }
            return ImgSub;
        }

    }
}
