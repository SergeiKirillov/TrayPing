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
        Thread ph;
        bool flagPing = false;
        //Configuration configWindow = new Configuration();

        public MyApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Конфигурация", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Выход", new EventHandler(Exit));

            ni.Icon = wfPingHost.Properties.Resources.red_circle_64;

           
            
            ni.DoubleClick += new EventHandler(ShowMessage);
            ni.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem, exitMenuItem });
            ni.Visible = true;

            ph = new Thread(PingHost);
            ph.Start();
            
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
                    PingReply reply = myPing.Send("192.168.1.1", 1000);

                    System.Diagnostics.Debug.WriteLine(reply.Status);

                    if (reply != null)
                    {
                        //Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                        //Console.WriteLine(reply.ToString());
                        ni.Icon = wfPingHost.Properties.Resources.green_circle_64;
                    }
                    else
                    {
                        ni.Icon = wfPingHost.Properties.Resources.red_circle_64;
                    }

                    
                }
                catch
                {
                    Console.WriteLine("ERROR: You have Some TIMEOUT issue");
                }

            }
        }
    }
}
