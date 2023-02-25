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
     public class DAL_NON_ABONEMENT
    {
        IFirebaseClient client;
        IFirebaseConfig con = new FirebaseConfig
        {
            AuthSecret = "OiU15ePqRhbCfb05N0QVKKoaTKDBLqRMqrCH5Qg2",
            BasePath = "https://dbfitnessvalley-default-rtdb.firebaseio.com/"
        };

        public DAL_NON_ABONEMENT()
        {
            client = new FirebaseClient(con);
        }


        //Add new NonAbonement In database
        public async Task<int> AddNonAbonement(int ID_BOUCKET, string NOM_BOUCKET, string DELAI_BOUCKET, double PRICE_BOUCKET)
        {
            int Reponce = 0;
            var dt = new CLS_BOUCKET
            {
                ID_BOUCKET = ID_BOUCKET,
                NOM_BOUCKET = NOM_BOUCKET,
                DELAI_BOUCKET = DELAI_BOUCKET,
                PRICE_BOUCKET = PRICE_BOUCKET
            };

            var Resp = await client.PushAsync("TBL_NON_ABONEMENT", dt);
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

        //Update  NonAbonement In database
        public async Task<int> UpdateNonAbonement(string Keys, int ID_BOUCKET, string NOM_BOUCKET, string DELAI_BOUCKET, double PRICE_BOUCKET)
        {
            int Reponce = 0;
            var dt = new CLS_BOUCKET
            {
                ID_BOUCKET = ID_BOUCKET,
                NOM_BOUCKET = NOM_BOUCKET,
                DELAI_BOUCKET = DELAI_BOUCKET,
                PRICE_BOUCKET = PRICE_BOUCKET
            };

            var Resp = await client.UpdateAsync("TBL_NON_ABONEMENT/" + Keys, dt);
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

        //Delete  NonAbonement In database
        public async Task<int> DeleteNonAbonement(string Keys)
        {
            int Reponce = 0;
            var Resp = await client.DeleteAsync("TBL_NON_ABONEMENT/" + Keys);
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

        //GetAll NonAbonement
        public async Task<DataTable> GetAllNonAbonement()
        {
            DataTable dataTableNonAbonement = new DataTable();
            dataTableNonAbonement.Columns.Add("Keys", typeof(string));
            dataTableNonAbonement.Columns.Add("رقم الباقة", typeof(string));
            dataTableNonAbonement.Columns.Add("اسم الباقة", typeof(string));
            dataTableNonAbonement.Columns.Add("مدة الباقة", typeof(string));
            dataTableNonAbonement.Columns.Add("سعر الباقة", typeof(double));


            var Res = await client.GetAsync("TBL_NON_ABONEMENT");
            Dictionary<string, CLS_BOUCKET> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_BOUCKET>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.NOM_BOUCKET != "DEFAULT")
                {
                    dataTableNonAbonement.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_BOUCKET, line.Value.NOM_BOUCKET, line.Value.DELAI_BOUCKET, line.Value.PRICE_BOUCKET });
                }
            }
            return dataTableNonAbonement;
        }

        //GetAll NonAbonement
        public async Task<DataTable> GetByIDNonAbonement(int ID_USER)
        {
            DataTable dataTableNonAbonement = new DataTable();
            dataTableNonAbonement.Columns.Add("Keys", typeof(string));
            dataTableNonAbonement.Columns.Add("رقم الباقة", typeof(string));
            dataTableNonAbonement.Columns.Add("اسم الباقة", typeof(string));
            dataTableNonAbonement.Columns.Add("مدة الباقة", typeof(string));
            dataTableNonAbonement.Columns.Add("سعر الباقة", typeof(double));


            var Res = await client.GetAsync("TBL_NON_ABONEMENT");
            Dictionary<string, CLS_BOUCKET> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_BOUCKET>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_BOUCKET == ID_USER)
                {
                    dataTableNonAbonement.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_BOUCKET, line.Value.NOM_BOUCKET, line.Value.DELAI_BOUCKET, line.Value.PRICE_BOUCKET });
                }
            }
            return dataTableNonAbonement;
        }


        //Incrementer ID of Subscriber
        public async Task<int> IncrementID()
        {
            var Res = await client.GetAsync("TBL_NON_ABONEMENT");
            Dictionary<string, CLS_BOUCKET> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_BOUCKET>>(Res.Body.ToString());

            int maxim = 0;
            List<int> listID = new List<int>();
            foreach (var item in data)
            {
                listID.Add(item.Value.ID_BOUCKET);
            }
            maxim = listID.Max() + 1;
            return maxim;
        }
    }
}
