using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfPingHost
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();

            string HostIP = Properties.Resources.strIP;

            bool blWriteDb = Convert.ToBoolean(Properties.Resources.strLogBD);
            bool blWriteFile = Convert.ToBoolean(Properties.Resources.strLogFiles);
            bool blAutoStart = Convert.ToBoolean(Properties.Resources.strAutoStart);

            txtIP.Text = HostIP;
            chkBD.Checked = blWriteDb;
            chkFiles.Checked = blWriteFile;
            chkAutoStart.Checked = blAutoStart;
        }
    }
}
