using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class connection
    {
        //firebase connection Settings
        public IFirebaseConfig fc = new FirebaseConfig()
        {
            AuthSecret = "dw3BXZsgtt1Byuueoo3kcLQiIQam7mF7Th7r5fnX",
            BasePath = "https://teacherscreensharing-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;
        //Code to warn console if class cannot connect when called.
        public connection()
        {
            try
            {
                client = new FireSharp.FirebaseClient(fc);
            }
            catch (Exception)
            {
                Console.WriteLine("NOT Connected!");
            }
        }
    }
}
