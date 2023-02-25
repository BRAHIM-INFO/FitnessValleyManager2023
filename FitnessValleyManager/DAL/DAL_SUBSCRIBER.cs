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
    public class DAL_SUBSCRIBER
    {
        IFirebaseClient client;
        IFirebaseConfig con = new FirebaseConfig
        {
            AuthSecret = "OiU15ePqRhbCfb05N0QVKKoaTKDBLqRMqrCH5Qg2",
            BasePath = "https://dbfitnessvalley-default-rtdb.firebaseio.com/"
        };

        public DAL_SUBSCRIBER()
        {
            client = new FirebaseClient(con);
        }

        public static string ImgToStr(PictureBox pic)
        {
            MemoryStream ms = new MemoryStream();
            pic.Image.Save(ms, pic.Image.RawFormat);
            return Convert.ToBase64String(ms.ToArray());
        }

        

        //Add new Subscriber In database
        public async Task<int> AddSubscriber(int ID_SUB ,string RegisteCivile_SUB ,string Nom_SUB,string DateNaiss_SUB,string LieuNaiss_SUB,string DateInscrip_SUB,string Sexe_SUB ,string Phone_SUB ,string Adresse_SUB,
            string Email_SUB, string Nationalite_SUB, PictureBox QrCode_SUB, PictureBox Image_SUB)
        {
            int Reponce = 0;
            var dt = new CLS_SUBSCRIBER
            {
                ID_SUB = ID_SUB,
                RegisteCivile_SUB = RegisteCivile_SUB, 
                Nom_SUB = Nom_SUB,
                DateNaiss_SUB = DateNaiss_SUB,
                LieuNaiss_SUB = LieuNaiss_SUB,
                DateInscrip_SUB = DateInscrip_SUB,
                Sexe_SUB = Sexe_SUB,
                Phone_SUB = Phone_SUB,
                Adresse_SUB = Adresse_SUB,
                Email_SUB = Email_SUB,
                Nationalite_SUB = Nationalite_SUB,
                QrCode_SUB = ImgToStr(QrCode_SUB),
                Image_SUB = ImgToStr(Image_SUB)
            };

          var Resp =  await client.PushAsync("TBL_SUBSCRIBER", dt); 
            if(Resp.StatusCode.ToString() == "OK")
            {
                Reponce = 1;
            }
            else
            {
                Reponce = 0;
            }
            return Reponce;
        }

        //Update  Subscriber In database
        public async Task<int> UpdateSubscriber(string Keys, int ID_SUB, string RegisteCivile_SUB , string Nom_SUB, string DateNaiss_SUB, string LieuNaiss_SUB, string DateInscrip_SUB, string Sexe_SUB, string Phone_SUB, string Adresse_SUB, string Email_SUB, string Nationalite_SUB, PictureBox QrCode_SUB, PictureBox Image_SUB)
        {
            int Reponce = 0;
            var dt = new CLS_SUBSCRIBER
            {
                ID_SUB = ID_SUB,
                RegisteCivile_SUB = RegisteCivile_SUB, 
                Nom_SUB = Nom_SUB,
                DateNaiss_SUB = DateNaiss_SUB,
                LieuNaiss_SUB = LieuNaiss_SUB,
                DateInscrip_SUB = DateInscrip_SUB,
                Sexe_SUB = Sexe_SUB,
                Phone_SUB = Phone_SUB,
                Adresse_SUB = Adresse_SUB,
                Email_SUB = Email_SUB,
                Nationalite_SUB = Nationalite_SUB,
                QrCode_SUB = ImgToStr(QrCode_SUB),
                Image_SUB = ImgToStr(Image_SUB)
            };

            var Resp = await client.UpdateAsync("TBL_SUBSCRIBER/" + Keys, dt);
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

        //Delete  Subscriber In database
        public async Task<int>  DeleteSubscriber(string Keys)
        {
            int Reponce = 0;
            var Resp = await client.DeleteAsync("TBL_SUBSCRIBER/" + Keys);
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

        //Incrementer ID of Subscriber
        public async Task<int> IncrementID()
        {
            var Res = await client.GetAsync("TBL_SUBSCRIBER");
            Dictionary<string, CLS_SUBSCRIBER> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SUBSCRIBER>>(Res.Body.ToString());

            int maxim = 0;
            List<int> listID = new List<int>();
            foreach (var item in data)
            {
                listID.Add(item.Value.ID_SUB);
            }
            maxim = listID.Max() + 1;
            return maxim;
        }

        //GetAll Subscriber
        public async Task<DataTable> GetAllSubscribers()
        {
            DataTable dataTableSubscriber = new DataTable();
            dataTableSubscriber.Columns.Add("A", typeof(string));
            dataTableSubscriber.Columns.Add("B", typeof(string));
            dataTableSubscriber.Columns.Add("Image_SUB", typeof(string));
            dataTableSubscriber.Columns.Add("C", typeof(string));
            dataTableSubscriber.Columns.Add("D", typeof(string)); 
            dataTableSubscriber.Columns.Add("F", typeof(string));
            dataTableSubscriber.Columns.Add("G", typeof(string));
            dataTableSubscriber.Columns.Add("H", typeof(string));
            dataTableSubscriber.Columns.Add("I", typeof(string));
            dataTableSubscriber.Columns.Add("J", typeof(string));
            dataTableSubscriber.Columns.Add("K", typeof(string));
            dataTableSubscriber.Columns.Add("L", typeof(string));
            dataTableSubscriber.Columns.Add("M", typeof(string)); 
            dataTableSubscriber.Columns.Add("ImgQrcode", typeof(string));


            var Res = await client.GetAsync("TBL_SUBSCRIBER");
            Dictionary<string, CLS_SUBSCRIBER> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SUBSCRIBER>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.Nom_SUB.ToString() != "DEFAULT")
                {
                    dataTableSubscriber.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_SUB   , line.Value.Image_SUB /*stringToImage(line.Value.Image_SUB)*/  , line.Value.RegisteCivile_SUB   ,
                        line.Value.Nom_SUB   , line.Value.DateNaiss_SUB   , line.Value.LieuNaiss_SUB   ,line.Value.DateInscrip_SUB   , line.Value.Sexe_SUB   , line.Value.Phone_SUB   ,
                        line.Value.Adresse_SUB   , line.Value.Email_SUB   , line.Value.Nationalite_SUB   , line.Value.QrCode_SUB /*stringToImage(line.Value.Image_SUB)*/}); 
                }
            }
            return dataTableSubscriber;
        }


        //GetAll Subscriber ByID
        public async Task<DataTable> GetByIDSubscribers(int ID_SUB)
        {
            DataTable dataTableSubscriber = new DataTable();
            dataTableSubscriber.Columns.Add("A", typeof(string));
            dataTableSubscriber.Columns.Add("B", typeof(string));
            dataTableSubscriber.Columns.Add("Image_SUB", typeof(string));
            dataTableSubscriber.Columns.Add("C", typeof(string));
            dataTableSubscriber.Columns.Add("D", typeof(string));
            dataTableSubscriber.Columns.Add("F", typeof(string));
            dataTableSubscriber.Columns.Add("G", typeof(string));
            dataTableSubscriber.Columns.Add("H", typeof(string));
            dataTableSubscriber.Columns.Add("I", typeof(string));
            dataTableSubscriber.Columns.Add("J", typeof(string));
            dataTableSubscriber.Columns.Add("K", typeof(string));
            dataTableSubscriber.Columns.Add("L", typeof(string));
            dataTableSubscriber.Columns.Add("M", typeof(string));
            dataTableSubscriber.Columns.Add("ImgQrcode", typeof(string));


            var Res = await client.GetAsync("TBL_SUBSCRIBER");
            Dictionary<string, CLS_SUBSCRIBER> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SUBSCRIBER>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_SUB == ID_SUB)
                {
                    dataTableSubscriber.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_SUB   , line.Value.Image_SUB /*stringToImage(line.Value.Image_SUB)*/  , line.Value.RegisteCivile_SUB   ,
                        line.Value.Nom_SUB   , line.Value.DateNaiss_SUB   , line.Value.LieuNaiss_SUB   ,line.Value.DateInscrip_SUB   , line.Value.Sexe_SUB   , line.Value.Phone_SUB   ,
                        line.Value.Adresse_SUB   , line.Value.Email_SUB   , line.Value.Nationalite_SUB   , line.Value.QrCode_SUB /*stringToImage(line.Value.Image_SUB)*/});
                }
            }
            return dataTableSubscriber;
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

        //GetAll Subscriber QrCode
        public async Task<Image> GetQrCodeSubscriber(int ID_SUB)
        { 
            Image Qrcode = FitnessValleyManager.Properties.Resources.cf258720ded328c92d5a821c78b5a052;
            var Res = await client.GetAsync("TBL_SUBSCRIBER");
            Dictionary<string, CLS_SUBSCRIBER> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SUBSCRIBER>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_SUB == ID_SUB)
                {
                    Qrcode = stringToImage(line.Value.QrCode_SUB);
                }
            }
            return Qrcode;
        }

        //GetAll Subscriber Image
        public async Task<Image> GetImageSubscriber(int ID_SUB)
        {
            Image ImgSub = FitnessValleyManager.Properties.Resources.icons8_school_director_48;
            var Res = await client.GetAsync("TBL_SUBSCRIBER");
            Dictionary<string, CLS_SUBSCRIBER> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_SUBSCRIBER>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_SUB == ID_SUB)
                {
                    ImgSub = stringToImage(line.Value.Image_SUB);
                }
            }
            return ImgSub;
        }

    }
}
