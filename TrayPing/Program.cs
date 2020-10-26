using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrayPing
{
    class Program
    {
        public static ContextMenu menu;
        public static MenuItem menuStart;
        public static MenuItem menuExit;
        public static MenuItem menuViewLog;
        public static MenuItem menuSetting;
        public static NotifyIcon notificationIcon;
        


        static void Main(string[] args)
        {
            Thread notifyThread = new Thread(
                delegate ()
                {
                    menu = new ContextMenu();

                    menuStart = new MenuItem("Старт");
                    menu.MenuItems.Add(0, menuStart);

                    menuViewLog = new MenuItem("Просмотр Лога");
                    menu.MenuItems.Add(1, menuViewLog);

                    menuSetting = new MenuItem("Настройка программы");
                    menu.MenuItems.Add(2, menuSetting);

                    menuExit = new MenuItem("Exit");
                    menu.MenuItems.Add(3, menuExit);

                    notificationIcon = new NotifyIcon()
                    {
                        Icon = Properties.Resources.Red,
                        ContextMenu = menu,
                        Text = "Main"
                    };

                    menuStart.Click += new EventHandler(NenuStart_Click);
                    menuExit.Click += new EventHandler(MenuExit_Click);
                    menuViewLog.Click += new EventHandler(MenuViewLog_Click);
                    menuSetting.Click += new EventHandler(MenuSetting_Click);
                    //notificationIcon.Click += new EventHandler(MenuViewLog_Click);


                    notificationIcon.Visible = true;
                    Application.Run();
                }
              
            );
            notifyThread.Start();

            Console.ReadLine();
        }




        private static void MenuSetting_Click(object sender, EventArgs e)
        {
            Setting setSetiing = new Setting();
            setSetiing.Show();
        }

        private static void MenuViewLog_Click(object sender, EventArgs e)
        {
            ViewLog vl = new ViewLog();
            vl.Show();
        }

        private static void MenuExit_Click(object sender, EventArgs e)
        {
            notificationIcon.Dispose();
            Application.Exit();
        }

        

        private static void NenuStart_Click(object sender, EventArgs e)
        {
            Thread PingingHost = new Thread(PingHost);
            PingingHost.Start();
        }

        #region Пинг компьютера 
        private static void PingHost()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now);
            }
        }
        #endregion
    }
}
