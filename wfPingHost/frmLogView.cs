using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace wfPingHost
{
    public partial class frmLogView : Form
    {
        private static string IP = Properties.Resources.strIP;
        private static string NameDB = IP.Replace(".", "");
        private static string pathProg = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + NameDB + ".db";

        public frmLogView()
        {
                                   
            InitializeComponent();

            var LibDb = new clWriteReadinBD();

            var StatusPing = GetListStatus();
            if (Convert.ToBoolean(Properties.Resources.strLogBDAll)||Convert.ToBoolean(Properties.Resources.strLogFilesAll))
            {
                StatusPing.Add("All");
            }

            
            StatusPing.Add("Failed All");
            cmbFiltrStatus.DataSource = StatusPing;
            cmbFiltrStatus.SelectedItem = 24;

            RefreshGridView(LibDb.GetAll());

            GridHostRezult.Columns[0].Visible = false;
            GridHostRezult.AllowUserToAddRows = false;
            GridHostRezult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridHostRezult.MultiSelect = false;

            var HostList = GetHostList();
            HostList.Add("All");
            cmbIP.DataSource = HostList;            
        }

        private List<string> GetHostList()
        {
            
            List<string> computersList = new List<string>();
            using (StreamReader sr = new StreamReader("computersList.txt", Encoding.Default))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    computersList.Add(line);
                }
            }
            return computersList;

           
        }

        private List<string> GetListStatus()
        {
            var PingStatus = new List<string>();
            
            PingStatus.Add("BadDestination");
            PingStatus.Add("BadHeader");
            PingStatus.Add("BadOption");
            PingStatus.Add("BadRoute");
            PingStatus.Add("DestinationHostUnreachable");
            PingStatus.Add("DestinationNetworkUnreachable");
            PingStatus.Add("DestinationPortUnreachable");
            PingStatus.Add("DestinationProhibited");
            PingStatus.Add("DestinationProtocolUnreachable");
            PingStatus.Add("DestinationScopeMismatch");
            PingStatus.Add("DestinationUnreachable");
            PingStatus.Add("HardwareError");
            PingStatus.Add("IcmpError");
            PingStatus.Add("NoResources");
            PingStatus.Add("PacketTooBig");
            PingStatus.Add("ParameterProblem");
            PingStatus.Add("SourceQuench");
            PingStatus.Add("Success");
            PingStatus.Add("TimedOut");
            PingStatus.Add("TimeExceeded");
            PingStatus.Add("TtlExpired");
            PingStatus.Add("TtlReassemblyTimeExceeded");
            PingStatus.Add("Unknown");
            PingStatus.Add("UnrecognizedNextHeader");
            return PingStatus;

        }

        private void frmLogView_Load(object sender, EventArgs e)
        {
            if ((Convert.ToBoolean(Properties.Resources.strLogBDAll))||(Convert.ToBoolean(Properties.Resources.strLogBDError)))
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



            
        }

        private void RefreshGridView(IList<clDataPing> PingRezult)
        {
            var bindList = new BindingList<clDataPing>(PingRezult);
            var source = new BindingSource(bindList, null);

            GridHostRezult.DataSource = source;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var FilterList = new clWriteReadinBD();

            var filterTypeStatus = FilterList.Get(cmbFiltrStatus.SelectedValue.ToString(), dtSelect.Value, cmbIP.SelectedValue.ToString());
            RefreshGridView(filterTypeStatus);

        }
    }
}
