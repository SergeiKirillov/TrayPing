﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace wfPingHost
{


    
    class clWriteReadinBD
    {
        private static string IP = Properties.Resources.strIP;
        private static string NameDB = IP.Replace(".", "");
        private static string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + NameDB + ".db";

        public void Write(DateTime dtNow, string Status)
        {
            try
            {
                if ((Convert.ToBoolean(Properties.Resources.strLogFilesAll))|| (Convert.ToBoolean(Properties.Resources.strLogFilesError)))
                {
                    WriteFile(dtNow, Status);
                }

                if ((Convert.ToBoolean(Properties.Resources.strLogBDAll))||(Convert.ToBoolean(Properties.Resources.strLogBDError)))
                {
                    WriteBD(dtNow, Status);
                }
            }
            catch 
            {}
           
        }


        private void WriteBD(DateTime dtNow,string messageBD)
        {
            try
            {
                
                //System.Diagnostics.Debug.WriteLine("База данных: "+pathProg);

                //LiteDB new
                //using (var db = new LiteDatabase(pathProg))
                //{
                //    //TODO Найти в все точки и убрать их -> получившееся имя и будет названием таблицы 
                //    var col = db.GetCollection<PingHost>("Host");

                //    var host = new PingHost
                //    {
                //        HostIP = IP,
                //        dtHost = dtNow,
                //        RezultHost = messageBD
                //    };

                //    col.Insert(host);
                //}

                //LiteDb 0.6
                var PingNowHost = new clDataPing
                {
                    ID = Guid.NewGuid(),
                    dtPingData = dtNow,
                    strPingStatus = messageBD,
                    strPingIP = IP
                };

                using (var db = new LiteEngine(pathProg)) 
                {
                    var HostCollection = db.GetCollection<clDataPing>("PingHost");

                    //HostCollection.EnsureIndex((clDataPing x) => x.dtPingData,true);
                    //HostCollection.EnsureIndex((clDataPing x) => x.strPingStatus, true);

                    HostCollection.Insert(PingNowHost);
                    IndexIsHost(HostCollection);

                }

                                
                //System.Diagnostics.Debug.WriteLine(dtNow.ToString()+"-----"+messageBD);



            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("WriteBD - " + e.Message);
            }


        }

        private void IndexIsHost(Collection<clDataPing> hostCollection)
        {
            hostCollection.EnsureIndex(x => x.ID);
            hostCollection.EnsureIndex(x => x.dtPingData);
            hostCollection.EnsureIndex(x => x.strPingIP);
            hostCollection.EnsureIndex(x => x.strPingStatus);
        }
        //Заменил  на  
        //HostCollection.EnsureIndex((clDataPing x) => x.dtPingData,true);
        //HostCollection.EnsureIndex((clDataPing x) => x.strPingStatus, true);
        //при создании BD


        private void WriteFile(DateTime dtNow, string messageBD)
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

        public IList<clDataPing> GetAll()
        {
            var returnRezult = new List<clDataPing>();

            using (var db = new LiteEngine(pathProg))
            {
                var HostCollection = db.GetCollection<clDataPing>("PingHost");

                var results = HostCollection.All();
                foreach (clDataPing item in results)
                {
                    returnRezult.Add(item);  
                }

                return returnRezult;
            }
        }

        public IList<clDataPing> Get(string Status, DateTime dtSelect)
        {
            var returnResult = new List<clDataPing>();

            using (var db = new LiteEngine(pathProg))
            {
                var HostCollection = db.GetCollection<clDataPing>("PingHost");

                IEnumerable<clDataPing> filter;

                if (Status.Equals("All"))
                {
                    filter = HostCollection.All();
                }
                else if (Status.Equals("Failed All"))
                {
                    filter = HostCollection.Find(i => i.strPingStatus!= "Success");
                }
                else
                {
                    filter = HostCollection.Find(i => i.strPingStatus.Equals(Status));
                }

                foreach (clDataPing item in filter)
                {
                    returnResult.Add(item);
                }

                return returnResult.FindAll(i => i.dtPingData.Date == dtSelect.Date);
            }

        }
    }
}
