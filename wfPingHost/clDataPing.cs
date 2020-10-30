using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

public class clDataPing
{
    [BsonId]

    public Guid ID { get; set; }
    public DateTime dtPingData { get; set; } 
    public string strPingStatus { get; set; }
    public string strPingIP { get; set; } 

}



