using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace wfPingHost
{
    public class PingHost
    {
        public string HostIP;
        public DateTime dtHost;
        public string RezultHost;
    }
    class clWriteReadinBD
    {
        public void WriteBD(string IP,DateTime dtNow,string messageBD)
        {
            string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "MyData.db";

            using (var db = new LiteDatabase(pathProg))
            {
                //TODO Найти в все точки и убрать их -> получившееся имя и будет названием таблицы 
                var col = db.GetCollection<PingHost>("Host");

                var host = new PingHost
                {
                    HostIP = IP,
                    dtHost = dtNow,
                    RezultHost = messageBD
                };

                col.Insert(host);
            }
            //System.Diagnostics.Debug.WriteLine(dtNow.ToString()+"-----"+messageBD);

        }

        public void WriteFile(string IP, DateTime dtNow, string messageBD)
        {
            //System.Diagnostics.Debug.WriteLine(dtNow.ToString() + "-----" + messageBD);

            try
            {
                //Записываем в локальный файл
                string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Log.txt";

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathProg, true))
                {
                    string tmptxt = String.Format("{0:dd.MM.yyyy HH:mm:ss};{1};{2}", dtNow, IP, messageBD);
                    file.WriteLine(tmptxt);
                    file.Close();
                }
            }
            catch
            { }

        }
    }
}
