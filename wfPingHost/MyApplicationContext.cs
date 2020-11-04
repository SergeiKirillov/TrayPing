using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace wfPingHost
{
   

    class MyApplicationContext : ApplicationContext
    {
        public static List<string> hosts = new List<string>();

        NotifyIcon ni = new NotifyIcon();
        Setting configWindows = new Setting();
        frmLogView Logging = new frmLogView();
        Thread ph;
        //Configuration configWindow = new Configuration();

        public MyApplicationContext()
        {
            MenuItem viewLogMenuItem = new MenuItem("Просмотр Лога", new EventHandler(ShowViewLog));
            MenuItem configMenuItem = new MenuItem("Конфигурация", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Выход", new EventHandler(Exit));

            ni.Icon = wfPingHost.Properties.Resources.red_circle_64;

           
            
            ni.DoubleClick += new EventHandler(ShowMessage);
            ni.ContextMenu = new ContextMenu(new MenuItem[] { viewLogMenuItem, configMenuItem, exitMenuItem });
            ni.Visible = true;

            ph = new Thread(PingHost);
            ph.Start();
            
        }

        private void ShowViewLog(object sender, EventArgs e)
        {
            if (Logging.Visible)
            {
                Logging.Focus();
            }
            else
            {
                Logging.ShowDialog();
            }
        }

        private void ShowMessage(object sender, EventArgs e)
        {
            // Only show the message if the settings say we can.
            //if (wfPingHost.Properties.Settings.Default.ShowMessage)
            //    MessageBox.Show("Hello World");

        }

        private void Exit(object sender, EventArgs e)
        {
            ni.Visible = false;
            ph.Abort();
            Application.Exit();
        }

        private void ShowConfig(object sender, EventArgs e)
        {
            if (configWindows.Visible)
            {
                configWindows.Focus();
            }
            else
            {
                configWindows.ShowDialog();
            }
        }

        public List<string> getComputersListFromTxtFile(string pathToFile)
        {
            List<string> computersList = new List<string>();
            using (StreamReader sr = new StreamReader(pathToFile, Encoding.Default))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    computersList.Add(line);
                }
            }
            return computersList;
        }

        private void PingHost()
        {
            while (true)
            {
                
                Thread.Sleep(1000);
                
                Ping myPing = new Ping();

               
                //string IP = "192.168.1.1";

                //string IP = Properties.Resources.strIP;
                //PingReply reply = myPing.Send(IP, 1000);

                
                
                hosts = getComputersListFromTxtFile(@"computersList.txt");


                foreach (string item in hosts)
                {
                    try
                    {
                        //Console.WriteLine("{0} - ",item);
                        
                        PingReply reply = myPing.Send(IPAddress.Parse(item), 100); //100 - An Int32 value that specifies the maximum number of milliseconds (after sending the echo message) to wait for the ICMP echo reply message.

                        //Console.WriteLine("{0} - {1}",item, reply.Status);

                        if (reply != null)
                        {
                            //Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                            //Console.WriteLine(reply.ToString());

                            if ((Properties.Settings.Default.blDbError||Properties.Settings.Default.blFileError) && (reply.Status != IPStatus.Success))
                            {
                                clWriteReadinBD wrbd = new clWriteReadinBD();
                                wrbd.Write(item, DateTime.Now, reply.Status.ToString());
                            }
                            else if (Properties.Settings.Default.blDbAll||Properties.Settings.Default.blFileAll)
                            {
                                clWriteReadinBD wrbd = new clWriteReadinBD();
                                wrbd.Write(item, DateTime.Now, reply.Status.ToString());
                            }



                            if (reply.Status == IPStatus.Success) //https://docs.microsoft.com/ru-ru/dotnet/api/system.net.networkinformation.ipstatus?view=netcore-3.1
                            {
                                ni.Icon = wfPingHost.Properties.Resources.green_circle_64;
                            }
                            else
                            {
                                ni.Icon = wfPingHost.Properties.Resources.red_circle_64;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //System.Diagnostics.Debug.WriteLine("PingHost - " + e.Message);
                        //Console.WriteLine(e.Message);
                        //clWriteReadinBD fileError = new clWriteReadinBD();
                        //fileError.WriteFile("Error-" + item, DateTime.Now, e.Message);

                        clWriteReadinBD wrbd = new clWriteReadinBD();
                        wrbd.Write(item, DateTime.Now, e.Message);

                    }
                }
 
                   

            }

        }
    }
}
