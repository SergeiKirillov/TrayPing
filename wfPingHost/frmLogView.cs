using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace wfPingHost
{
    public partial class frmLogView : Form
    {
        bool db = true; //показываем лог из файла или лог из db

        public frmLogView()
        {
            
            InitializeComponent();
        }

        private void frmLogView_Load(object sender, EventArgs e)
        {
            if (db)
            {
                frmLogView_dbLoad();
            }
            else
            {
                frmLogView_FileLoad();
            }
        }

        private void frmLogView_FileLoad()
        {
            string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "Log.txt";
            System.Diagnostics.Debug.WriteLine("File log :" + pathProg);
        }

        private void frmLogView_dbLoad()
        {
            //docs.microsoft.com/en-us/dotnet/framework/data/adonet/creating-a-datatable-from-a-query-linq-to-dataset
            //metanit.com/sharp/adonet/3.8.php
            //www.codecompiled.com/query-datatable-using-linq-in-csharp/

            string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "MyData.db";
            System.Diagnostics.Debug.WriteLine("File BD :"+pathProg);

            //using(var db = new LiteDatabase(pathProg))
            //{
            //    var col = db.GetCollection<PingHost>("Host");

            //    col.EnsureIndex(x => x.HostIP);

            //    var results = col.Query()
            //        .Where(x => x.HostIP.Equals("192.168.1.1"))
            //        .Select(x => new { x.dtHost, x.RezultHost })
            //        .ToList();

            //    GridHostRezult.DataSource = results.ToList();
            //    //GridHostRezult.DataBindings();

            //}



            //// Use LINQ to query documents (filter, sort, transform)
            //var results = col.Query()
            //    .Where(x => x.Name.StartsWith("J"))
            //    .OrderBy(x => x.Name)
            //    .Select(x => new { x.Name, NameUpper = x.Name.ToUpper() })
            //    .Limit(10)
            //    .ToList();

                //You should avoid ArrayLists. Use List instead.

                //List<Student> StudentList = new List<Student>(); /* ... */
                //            And you query should look like:

                //var query = from student in StudentList
                //            where student.FirstName == "Cesar"
                //            select student;
                //            Then bind your Grid:

                // GridView1.DataSource = query.ToList();
                //            GridView1.DataBind();
        }
    }
}
