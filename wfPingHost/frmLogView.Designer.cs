namespace wfPingHost
{
    partial class frmLogView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GridHostRezult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.GridHostRezult)).BeginInit();
            this.SuspendLayout();
            // 
            // GridHostRezult
            // 
            this.GridHostRezult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHostRezult.Location = new System.Drawing.Point(12, 12);
            this.GridHostRezult.Name = "GridHostRezult";
            this.GridHostRezult.Size = new System.Drawing.Size(776, 330);
            this.GridHostRezult.TabIndex = 0;
            // 
            // frmLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridHostRezult);
            this.Name = "frmLogView";
            this.ShowIcon = false;
            this.Text = "Просмотр лога пинга хоста";
            this.Load += new System.EventHandler(this.frmLogView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridHostRezult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridHostRezult;
    }
}