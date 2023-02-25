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
    public class DAL_BOUCKET
    {
        IFirebaseClient client;
        IFirebaseConfig con = new FirebaseConfig
        {
            AuthSecret = "OiU15ePqRhbCfb05N0QVKKoaTKDBLqRMqrCH5Qg2",
            BasePath = "https://dbfitnessvalley-default-rtdb.firebaseio.com/"
        };

        public DAL_BOUCKET()
        {
            client = new FirebaseClient(con);
        }


        //Add new Bouckets In database
        public async Task<int> AddBouckets(int ID_BOUCKET, string NOM_BOUCKET, string DELAI_BOUCKET, double PRICE_BOUCKET)
        {
            int Reponce = 0;
            var dt = new CLS_BOUCKET
            {
                ID_BOUCKET = ID_BOUCKET,
                NOM_BOUCKET = NOM_BOUCKET,
                DELAI_BOUCKET = DELAI_BOUCKET,
                PRICE_BOUCKET = PRICE_BOUCKET
            };

            var Resp = await client.PushAsync("TBL_BOUCKETS", dt);
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

        //Update  Bouckets In database
        public async Task<int> UpdateBouckets(string Keys, int ID_BOUCKET, string NOM_BOUCKET, string DELAI_BOUCKET, double PRICE_BOUCKET)
        {
            int Reponce = 0;
            var dt = new CLS_BOUCKET
            {
                ID_BOUCKET = ID_BOUCKET,
                NOM_BOUCKET = NOM_BOUCKET,
                DELAI_BOUCKET = DELAI_BOUCKET,
                PRICE_BOUCKET = PRICE_BOUCKET
            };

            var Resp = await client.UpdateAsync("TBL_BOUCKETS/" + Keys, dt);
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

        //Delete  Bouckets In database
        public async Task<int> DeleteBouckets(string Keys)
        {
            int Reponce = 0;
            var Resp = await client.DeleteAsync("TBL_BOUCKETS/" + Keys);
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

        //GetAll Bouckets
        public async Task<DataTable> GetAllBoucketss()
        {
            DataTable dataTableBouckets = new DataTable();
            dataTableBouckets.Columns.Add("Keys", typeof(string));
            dataTableBouckets.Columns.Add("رقم الباقة", typeof(string));
            dataTableBouckets.Columns.Add("اسم الباقة", typeof(string));
            dataTableBouckets.Columns.Add("مدة الباقة", typeof(string));
            dataTableBouckets.Columns.Add("سعر الباقة", typeof(double));


            var Res = await client.GetAsync("TBL_BOUCKETS");
            Dictionary<string, CLS_BOUCKET> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_BOUCKET>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if(line.Value.NOM_BOUCKET != "DEFAULT")
                {
                    dataTableBouckets.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_BOUCKET, line.Value.NOM_BOUCKET, line.Value.DELAI_BOUCKET, line.Value.PRICE_BOUCKET });
                } 
            }
            return dataTableBouckets;
        }

        //GetAll Bouckets
        public async Task<DataTable> GetByIDBoucketss(int ID_USER)
        {
            DataTable dataTableBouckets = new DataTable();
            dataTableBouckets.Columns.Add("Keys", typeof(string));
            dataTableBouckets.Columns.Add("رقم الباقة", typeof(string));
            dataTableBouckets.Columns.Add("اسم الباقة", typeof(string));
            dataTableBouckets.Columns.Add("مدة الباقة", typeof(string));
            dataTableBouckets.Columns.Add("سعر الباقة", typeof(double));


            var Res = await client.GetAsync("TBL_BOUCKETS");
            Dictionary<string, CLS_BOUCKET> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_BOUCKET>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_BOUCKET == ID_USER)
                {
                    dataTableBouckets.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_BOUCKET, line.Value.NOM_BOUCKET, line.Value.DELAI_BOUCKET, line.Value.PRICE_BOUCKET });
                }
            }
            return dataTableBouckets;
        }
         

        //Incrementer ID of Subscriber
        public async Task<int> IncrementID()
        {
            var Res = await client.GetAsync("TBL_BOUCKETS");
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
