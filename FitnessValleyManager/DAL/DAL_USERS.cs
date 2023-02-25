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
    public class DAL_USERS
    {
        IFirebaseClient client;
        IFirebaseConfig con = new FirebaseConfig
        {
            AuthSecret = "OiU15ePqRhbCfb05N0QVKKoaTKDBLqRMqrCH5Qg2",
            BasePath = "https://dbfitnessvalley-default-rtdb.firebaseio.com/"
        };

        public DAL_USERS()
        {
            client = new FirebaseClient(con);
        }
         

        //Add new Users In database
        public async Task<int> AddUsers(int ID_USER, string USERNAME_CLUB, string PASSWORD_CLUB) 
        {
            int Reponce = 0;
            var dt = new CLS_USERS
            {
                ID_USER = ID_USER,
                USERNAME_CLUB = USERNAME_CLUB,
                PASSWORD_CLUB = PASSWORD_CLUB
            };

            var Resp = await client.PushAsync("TBL_USERS", dt);
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

        //Update  Users In database
        public async Task<int> UpdateUsers(string Keys, int ID_USER, string USERNAME_CLUB, string PASSWORD_CLUB)
        {
            int Reponce = 0;
            var dt = new CLS_USERS
            {
                ID_USER = ID_USER,
                USERNAME_CLUB = USERNAME_CLUB,
                PASSWORD_CLUB = PASSWORD_CLUB
            };

            var Resp = await client.UpdateAsync("TBL_USERS/" + Keys, dt);
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

        //Delete  Users In database
        public async Task<int> DeleteUsers(string Keys)
        {
            int Reponce = 0;
            var Resp = await client.DeleteAsync("TBL_USERS/" + Keys);
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

        //GetAll Users
        public async Task<DataTable> GetAllUserss()
        {
            DataTable dataTableUsers = new DataTable();
            dataTableUsers.Columns.Add("Keys", typeof(string));
            dataTableUsers.Columns.Add("رقم المستخدم", typeof(string));
            dataTableUsers.Columns.Add("اسم المستخدم", typeof(string));
            dataTableUsers.Columns.Add("كلمة المرور", typeof(string));
            

           var Res = await client.GetAsync("TBL_USERS");
            Dictionary<string, CLS_USERS> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_USERS>>(Res.Body.ToString());
            foreach (var line in data)
            {
                dataTableUsers.Rows.Add(new object[] {line.Key.ToString(),line.Value.ID_USER ,line.Value.USERNAME_CLUB ,line.Value.PASSWORD_CLUB});

            }
            return dataTableUsers;
        }

        //GetAll Users
        public async Task<DataTable> GetByIDUserss(int ID_USER)
        {
            DataTable dataTableUsers = new DataTable();
            dataTableUsers.Columns.Add("A", typeof(string));
            dataTableUsers.Columns.Add("B", typeof(string));
            dataTableUsers.Columns.Add("C", typeof(string));
            dataTableUsers.Columns.Add("D", typeof(string));


            var Res = await client.GetAsync("TBL_USERS");
            Dictionary<string, CLS_USERS> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_USERS>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if(line.Value.ID_USER == ID_USER)
                {
                    dataTableUsers.Rows.Add(new object[] { line.Key.ToString(), line.Value.ID_USER, line.Value.USERNAME_CLUB, line.Value.PASSWORD_CLUB });
                } 
            }
            return dataTableUsers;
        }

        //Check Login Users
        public async Task<bool> IfUserExist(int ID_USER)
        {
            bool IfExist = false;

            var Res = await client.GetAsync("TBL_USERS");
            Dictionary<string, CLS_USERS> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_USERS>>(Res.Body.ToString());
            foreach (var line in data)
            {
                if (line.Value.ID_USER == ID_USER)
                {
                    IfExist = true; 
                }
            }
            return IfExist;
        }


        //Incrementer ID of Subscriber
        public async Task<int> IncrementID()
        {
            var Res = await client.GetAsync("TBL_USERS");
            Dictionary<string, CLS_USERS> data = JsonConvert.DeserializeObject<Dictionary<string, CLS_USERS>>(Res.Body.ToString());

            int maxim = 0;
            List<int> listID = new List<int>();
            foreach (var item in data)
            {
                listID.Add(item.Value.ID_USER);
            }
            maxim = listID.Max() + 1;
            return maxim;
        }

    }
}
