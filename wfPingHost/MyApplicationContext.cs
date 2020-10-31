using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wfPingHost
{
    class MyApplicationContext: ApplicationContext
    {
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

        private void PingHost()
        {
            while (true)
            {
                
                Thread.Sleep(1000);

                try
                {
                    Ping myPing = new Ping();

                    //string IP = "192.168.1.1";
                    string IP = Properties.Resources.strIP;
                    PingReply reply = myPing.Send(IP, 1000);

                    

                    if (reply != null)
                    {
                        //Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                        //Console.WriteLine(reply.ToString());

                        if (((Convert.ToBoolean(Properties.Resources.strLogBDError))||(Convert.ToBoolean(Properties.Resources.strLogFilesError))) && (reply.Status != IPStatus.Success))
                        {
                            clWriteReadinBD wrbd = new clWriteReadinBD();
                            wrbd.Write(DateTime.Now, reply.Status.ToString());
                        }
                        else if ((Convert.ToBoolean(Properties.Resources.strLogBDAll)) || (Convert.ToBoolean(Properties.Resources.strLogFilesAll)))
                        {
                            clWriteReadinBD wrbd = new clWriteReadinBD();
                            wrbd.Write(DateTime.Now, reply.Status.ToString());
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
                    System.Diagnostics.Debug.WriteLine("PingHost - " + e.Message);
                    //Console.WriteLine("ERROR: You have Some TIMEOUT issue");
                }

            }
        }
    }
}
