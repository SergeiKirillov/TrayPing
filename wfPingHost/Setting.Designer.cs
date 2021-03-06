﻿namespace wfPingHost
{
    partial class Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.chkBD = new System.Windows.Forms.CheckBox();
            this.chkFiles = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkFileError = new System.Windows.Forms.CheckBox();
            this.chkBDError = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP адрес";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(57, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 20);
            this.txtIP.TabIndex = 1;
            // 
            // chkBD
            // 
            this.chkBD.AutoSize = true;
            this.chkBD.Location = new System.Drawing.Point(357, 30);
            this.chkBD.Name = "chkBD";
            this.chkBD.Size = new System.Drawing.Size(202, 17);
            this.chkBD.TabIndex = 2;
            this.chkBD.Text = "Сохранение результата в БД (Всё)";
            this.chkBD.UseVisualStyleBackColor = true;
            // 
            // chkFiles
            // 
            this.chkFiles.AutoSize = true;
            this.chkFiles.Location = new System.Drawing.Point(357, 54);
            this.chkFiles.Name = "chkFiles";
            this.chkFiles.Size = new System.Drawing.Size(267, 17);
            this.chkFiles.TabIndex = 3;
            this.chkFiles.Text = "Сохранение результата в текстовой файл (Всё)";
            this.chkFiles.UseVisualStyleBackColor = true;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(12, 125);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(96, 17);
            this.chkAutoStart.TabIndex = 4;
            this.chkAutoStart.Text = "Автозагрузка";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // chkFileError
            // 
            this.chkFileError.AutoSize = true;
            this.chkFileError.Location = new System.Drawing.Point(4, 54);
            this.chkFileError.Name = "chkFileError";
            this.chkFileError.Size = new System.Drawing.Size(326, 17);
            this.chkFileError.TabIndex = 6;
            this.chkFileError.Text = "Сохранение результата в текстовой файл (только Ошибки)";
            this.chkFileError.UseVisualStyleBackColor = true;
            // 
            // chkBDError
            // 
            this.chkBDError.AutoSize = true;
            this.chkBDError.Location = new System.Drawing.Point(4, 30);
            this.chkBDError.Name = "chkBDError";
            this.chkBDError.Size = new System.Drawing.Size(261, 17);
            this.chkBDError.TabIndex = 5;
            this.chkBDError.Text = "Сохранение результата в БД (только Ошибки)";
            this.chkBDError.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 307);
            this.Controls.Add(this.chkFileError);
            this.Controls.Add(this.chkBDError);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.chkFiles);
            this.Controls.Add(this.chkBD);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "Setting";
            this.Text = "Настройка программы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.CheckBox chkBD;
        private System.Windows.Forms.CheckBox chkFiles;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkFileError;
        private System.Windows.Forms.CheckBox chkBDError;
    }
}