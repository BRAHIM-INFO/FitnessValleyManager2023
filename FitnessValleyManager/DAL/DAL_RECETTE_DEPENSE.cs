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
    public class DAL_RECETTE_DEPENSE
    {
        IFirebaseClient client;
        IFirebaseConfig con = new FirebaseConfig
        {
            AuthSecret = "OiU15ePqRhbCfb05N0QVKKoaTKDBLqRMqrCH5Qg2",
            BasePath = "https://dbfitnessvalley-default-rtdb.firebaseio.com/"
        };

        public DAL_RECETTE_DEPENSE()
        {
            client = new FirebaseClient(con);
        }


        //Add new Dep_Rec In database
        public async Task<int> AddDep_Rec(int ID_REC_DEP, string TYPE_REC_DEP, string FACT_REC_DEP, string DATE_REC_DEP, string DISTIN_REC_DEP, string DESCRIP_REC_DEP, double WITHOUT_VAT_REC_DEP, double VAT_REC_DEP, double MNT_VAT_REC_DEP, double TOTAL_REC_DEP)
        {
            int Reponce = 0;
            var dt = new CLS_RECETTE_DEPENSE
            {
                ID_REC_DEP = ID_REC_DEP,
                TYPE_REC_DEP = TYPE_REC_DEP,
                FACT_REC_DEP = FACT_REC_DEP,
                DATE_REC_DEP = DATE_REC_DEP,
                DISTIN_REC_DEP = DISTIN_REC_DEP,
                DESCRIP_REC_DEP = DESCRIP_REC_DEP,
                WITHOUT_VAT_REC_DEP = WITHOUT_VAT_REC_DEP,
                VAT_REC_DEP = VAT_REC_DEP,
                MNT_VAT_REC_DEP = MNT_VAT_REC_DEP,
                TOTAL_REC_DEP = TOTAL_REC_DEP
            };

            var Resp = await client.PushAsync("TBL_REC_DEP", dt);
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

        //Update  Dep_Rec In database
        public async Task<int> UpdateDep_Rec(string Keys, int ID_REC_DEP, string TYPE_REC_DEP, string FACT_REC_DEP, string DATE_REC_DEP, string DISTIN_REC_DEP, string DESCRIP_REC_DEP, double WITHOUT_VAT_REC_DEP, double VAT_REC_DEP, double MNT_VAT_REC_DEP, double TOTAL_REC_DEP)
        {
            int Reponce = 0;
            var dt = new CLS_RECETTE_DEPENSE
            {
                ID_REC_DEP = ID_REC_DEP,
                TYPE_REC_DEP = TYPE_REC_DEP,
                FACT_REC_DEP = FACT_REC_DEP,
                DATE_REC_DEP = DATE_REC_DEP,
                DISTIN_REC_DEP = DISTIN_REC_DEP,
                DESCRIP_REC_DEP = DESCRIP_REC_DEP,
                WITHOUT_VAT_REC_DEP = WITHOUT_VAT_REC_DEP,
                VAT_REC_DEP = VAT_REC_DEP,
                MNT_VAT_REC_DEP = MNT_VAT_REC_DEP,
                TOTAL_REC_DEP = TOTAL_REC_DEP
            };

            var Resp = await client.UpdateAsync("TBL_REC_DEP/" + Keys, dt);
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

        //Delete  Dep_Rec In database
        public async Task<int> DeleteDep_Rec(string Keys)
        {
            int Reponce = 0;
            var Resp = await client.DeleteAsync("TBL_REC_DEP/" + Keys);
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

        //GetAll Dep_Rec
        public async Task<DataTable> GetAllDep_Rec()
        {
            DataTable dataTableDep_Rec = new DataTable();
            dataTableDep_Rec.Columns.Add("Keys", typeof(string));
            dataTableDep_Rec.Columns.Add("رقم العملية", typeof(string));
            dataTableDep_Rec.Columns.Add("نوع العملية", typeof(string));
            dataTableDep_Rec.Columns.Add("رقم الفاتورة", typeof(string));
            dataTableDep_Rec.Columns.Add("التاريخ", typeof(string));
            dataTableDep_Rec.Columns.Add("المورد / العميل", typeof(string));
            dataTableDep_Rec.Columns.Add("وصف العملية", typeof(string));
            dataTableDep_Rec.Columns.Add("مبلغ بدون ضريبة", typeof(double)); 
            dataTableDep_Rec.Columns.Add("قيمة الضريبة", typeof(double));
            dataTableDep_Rec.Columns.Add("مبلغ الضريبة", typeof(double));
            dataTableDep_Rec.Columns.Add("المبلغ الاجمالي", typeof(double)); 


            var Res = await client.GetAsync("TBL_REC_DEP");
            Dictionary<string, CLS_RECETTE_DEPENSE> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_RECETTE_DEPENSE>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.TYPE_REC_DEP != "DEFAULT")
                {
                    dataTableDep_Rec.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_REC_DEP, line.Value.TYPE_REC_DEP,line.Value.FACT_REC_DEP, line.Value.DATE_REC_DEP, line.Value.DISTIN_REC_DEP, line.Value.DESCRIP_REC_DEP, line.Value.WITHOUT_VAT_REC_DEP, line.Value.VAT_REC_DEP, line.Value.MNT_VAT_REC_DEP, line.Value.TOTAL_REC_DEP });
                }
            }
            return dataTableDep_Rec;
        }

        //GetAll Dep_Rec
        public async Task<DataTable> GetByIDDep_Rec(int ID_REC_DEP)
        {
            DataTable dataTableDep_Rec = new DataTable();
            dataTableDep_Rec.Columns.Add("Keys", typeof(string));
            dataTableDep_Rec.Columns.Add("رقم العملية", typeof(string));
            dataTableDep_Rec.Columns.Add("رقم الفاتورة", typeof(string));
            dataTableDep_Rec.Columns.Add("التاريخ", typeof(string));
            dataTableDep_Rec.Columns.Add("المورد / العميل", typeof(string));
            dataTableDep_Rec.Columns.Add("وصف العملية", typeof(string));
            dataTableDep_Rec.Columns.Add("مبلغ بدون ضريبة", typeof(double));
            dataTableDep_Rec.Columns.Add("قيمة الضريبة", typeof(double));
            dataTableDep_Rec.Columns.Add("مبلغ الضريبة", typeof(double));
            dataTableDep_Rec.Columns.Add("المبلغ الاجمالي", typeof(double));



            var Res = await client.GetAsync("TBL_REC_DEP");
            Dictionary<string, CLS_RECETTE_DEPENSE> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_RECETTE_DEPENSE>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_REC_DEP == ID_REC_DEP)
                {
                    dataTableDep_Rec.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_REC_DEP, line.Value.TYPE_REC_DEP, line.Value.DATE_REC_DEP, line.Value.DISTIN_REC_DEP, line.Value.DESCRIP_REC_DEP, line.Value.WITHOUT_VAT_REC_DEP, line.Value.VAT_REC_DEP, line.Value.MNT_VAT_REC_DEP, line.Value.TOTAL_REC_DEP });
                }
            }
            return dataTableDep_Rec;
        }


        //Incrementer ID of Subscriber
        public async Task<int> IncrementID()
        {
            var Res = await client.GetAsync("TBL_REC_DEP");
            Dictionary<string, CLS_RECETTE_DEPENSE> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_RECETTE_DEPENSE>>(Res.Body.ToString());

            int maxim = 0;
            List<int> listID = new List<int>();
            foreach (var item in data)
            {
                listID.Add(item.Value.ID_REC_DEP);
            }
            maxim = listID.Max() + 1;
            return maxim;
        }
    }
}
