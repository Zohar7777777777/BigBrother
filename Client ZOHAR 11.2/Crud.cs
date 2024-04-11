using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using FireSharp;
    using FireSharp.Config;
    using FireSharp.Interfaces;
    using FireSharp.Response;
    using Newtonsoft.Json;

    //namespace FirebaseMedium
    //{
        class Crud
        {
            connection conn = new connection();

            //set datas to database
            public void SetData(string Name, string IP, int port)
            {
                try
                {
                    User_Data set = new User_Data()
                    {
                        Name = Name,
                        IP = IP,
                        port = port
                    };
                    var SetData = conn.client.Set("students/" + IP.Replace('.','_'), set);
                }
                catch (Exception e)
                {
                    Console.WriteLine("SET FAILS " + e.Message);
                }

            }

            //Update datas
            public void UpdateData(string Name, string Surname, int age, String IP)
            {
                try
                {
                    User_Data set = new User_Data()
                    {
                        Name = Name,
                        IP = Surname,
                        port = age
                    };
                    var SetData = conn.client.Update("students/" + IP, set); ;
                }
                catch (Exception)
                {
                    Console.WriteLine("test");
                }
            }

            //Delete datas
            public void DeleteTeam(string IP)
            {
                try
                {
                    var SetData = conn.client.Delete("students/" + IP);
                }
                catch (Exception)
                {
                    Console.WriteLine("del");
                }
            }

            ////List of the datas
            //public Dictionary<string, User_Data> LoadData()
            //{
            //    try
            //    {
            //        FirebaseResponse al = conn.client.Get("students");
            //        Dictionary<string, User_Data> ListData = JsonConvert.DeserializeObject<Dictionary<string, User_Data>>(al.Body.ToString());
            //        return ListData;
            //    }
            //    catch (Exception)
            //    {
            //        Console.WriteLine("dic");
            //        return null;
            //    }
            //}
        }
    //}
}
