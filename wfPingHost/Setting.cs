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

            //string HostIP = Properties.Resources.strIP;

            //bool blWriteDbAll = Convert.ToBoolean(Properties.Resources.strLogBDAll);
            //bool blWriteFileAll = Convert.ToBoolean(Properties.Resources.strLogFilesAll);
            //bool blAutoStart = Convert.ToBoolean(Properties.Resources.strAutoStart);
            //bool blWriteDbError = Convert.ToBoolean(Properties.Resources.strLogBDError);
            //bool blWriteFileError = Convert.ToBoolean(Properties.Resources.strLogFilesError);


            
            chkBD.Checked = Properties.Settings.Default.blDbAll;
            chkFiles.Checked = Properties.Settings.Default.blFileAll;
            chkBDError.Checked = Properties.Settings.Default.blDbError;
            chkFileError.Checked = Properties.Settings.Default.blFileError;
            chkAutoStart.Checked = Properties.Settings.Default.blAutoStart;
        }

        private void chkBDError_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.blDbError = chkBDError.Checked;
            Properties.Settings.Default.Save();

            if (chkBDError.Checked)
            {
                System.Diagnostics.Debug.WriteLine("DB error write");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DB error no write");
            }
        }

        private void chkFileError_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.blFileError = chkFileError.Checked;
            Properties.Settings.Default.Save();

            if (chkFileError.Checked)
            {
                System.Diagnostics.Debug.WriteLine("File error write");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File error no write");
            }
       
        }

        private void chkBD_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.blDbAll = chkBD.Checked;
            Properties.Settings.Default.Save();

            if (chkBD.Checked)
            {
                System.Diagnostics.Debug.WriteLine("DB All write");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("DB All no write");
            }
        }

        private void chkFiles_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.blFileAll = chkFiles.Checked;
            Properties.Settings.Default.Save();

            if (chkFiles.Checked)
            {
                System.Diagnostics.Debug.WriteLine("File All write");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File All no write");
            }
        }
    }
}
