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

            bool blWriteDbAll = Convert.ToBoolean(Properties.Resources.strLogBDAll);
            bool blWriteFileAll = Convert.ToBoolean(Properties.Resources.strLogFilesAll);
            bool blAutoStart = Convert.ToBoolean(Properties.Resources.strAutoStart);
            bool blWriteDbError = Convert.ToBoolean(Properties.Resources.strLogBDError);
            bool blWriteFileError = Convert.ToBoolean(Properties.Resources.strLogFilesError);


            txtIP.Text = HostIP;
            chkBD.Checked = blWriteDbAll;
            chkFiles.Checked = blWriteFileAll;
            chkBDError.Checked = blWriteDbError;
            chkFileError.Checked = blWriteFileError;
            chkAutoStart.Checked = blAutoStart;
        }

        
    }
}
