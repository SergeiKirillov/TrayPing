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
            this.dtSelect = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbFiltrStatus = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridHostRezult)).BeginInit();
            this.SuspendLayout();
            // 
            // GridHostRezult
            // 
            this.GridHostRezult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridHostRezult.Location = new System.Drawing.Point(12, 108);
            this.GridHostRezult.Name = "GridHostRezult";
            this.GridHostRezult.Size = new System.Drawing.Size(776, 330);
            this.GridHostRezult.TabIndex = 0;
            // 
            // dtSelect
            // 
            this.dtSelect.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSelect.Location = new System.Drawing.Point(139, 81);
            this.dtSelect.Name = "dtSelect";
            this.dtSelect.Size = new System.Drawing.Size(226, 21);
            this.dtSelect.TabIndex = 13;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(370, 79);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(156, 23);
            this.btnFilter.TabIndex = 12;
            this.btnFilter.Text = "Применить Фильтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cmbFiltrStatus
            // 
            this.cmbFiltrStatus.FormattingEnabled = true;
            this.cmbFiltrStatus.Location = new System.Drawing.Point(12, 81);
            this.cmbFiltrStatus.Name = "cmbFiltrStatus";
            this.cmbFiltrStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltrStatus.TabIndex = 11;
            // 
            // frmLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtSelect);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbFiltrStatus);
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
        private System.Windows.Forms.DateTimePicker dtSelect;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ComboBox cmbFiltrStatus;
    }
}