using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace PingAServerUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Ping myPing = new Ping();
                PingReply reply = myPing.Send("192.168.1.1", 1000);
                if (reply != null)
                {
                    Console.WriteLine("Status :  " + reply.Status + " \n Time : " + reply.RoundtripTime.ToString() + " \n Address : " + reply.Address);
                    //Console.WriteLine(reply.ToString());

                }
            }
            catch
            {
                Console.WriteLine("ERROR: You have Some TIMEOUT issue");
            }
            Console.ReadKey();
        }
    
    }
}
