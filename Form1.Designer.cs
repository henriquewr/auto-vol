namespace Auto_VOL
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_changeOnOff = new System.Windows.Forms.Button();
            this.btn_exitApp = new System.Windows.Forms.Button();
            this.btn_defaultSettings = new System.Windows.Forms.Button();
            this.tb_processName = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tb_onOpenVol = new System.Windows.Forms.TextBox();
            this.tb_onCloseVol = new System.Windows.Forms.TextBox();
            this.btn_startWithOS = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_changeOnOff
            // 
            this.btn_changeOnOff.Location = new System.Drawing.Point(15, 12);
            this.btn_changeOnOff.Name = "btn_changeOnOff";
            this.btn_changeOnOff.Size = new System.Drawing.Size(206, 46);
            this.btn_changeOnOff.TabIndex = 0;
            this.btn_changeOnOff.Text = "Start/Stop";
            this.btn_changeOnOff.UseVisualStyleBackColor = true;
            this.btn_changeOnOff.Click += new System.EventHandler(this.btn_changeOnOff_Click);
            // 
            // btn_exitApp
            // 
            this.btn_exitApp.Location = new System.Drawing.Point(15, 181);
            this.btn_exitApp.Name = "btn_exitApp";
            this.btn_exitApp.Size = new System.Drawing.Size(206, 23);
            this.btn_exitApp.TabIndex = 1;
            this.btn_exitApp.Text = "Exit application";
            this.btn_exitApp.UseVisualStyleBackColor = true;
            this.btn_exitApp.Click += new System.EventHandler(this.btn_exitApp_Click);
            // 
            // btn_defaultSettings
            // 
            this.btn_defaultSettings.Location = new System.Drawing.Point(15, 210);
            this.btn_defaultSettings.Name = "btn_defaultSettings";
            this.btn_defaultSettings.Size = new System.Drawing.Size(206, 23);
            this.btn_defaultSettings.TabIndex = 2;
            this.btn_defaultSettings.Text = "Default settings";
            this.btn_defaultSettings.UseVisualStyleBackColor = true;
            this.btn_defaultSettings.Click += new System.EventHandler(this.btn_defaultSettings_Click);
            // 
            // tb_processName
            // 
            this.tb_processName.Location = new System.Drawing.Point(15, 88);
            this.tb_processName.Name = "tb_processName";
            this.tb_processName.Size = new System.Drawing.Size(206, 20);
            this.tb_processName.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Auto_VOL";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // tb_onOpenVol
            // 
            this.tb_onOpenVol.Location = new System.Drawing.Point(15, 146);
            this.tb_onOpenVol.Name = "tb_onOpenVol";
            this.tb_onOpenVol.Size = new System.Drawing.Size(100, 20);
            this.tb_onOpenVol.TabIndex = 4;
            this.tb_onOpenVol.Text = "Open vol";
            // 
            // tb_onCloseVol
            // 
            this.tb_onCloseVol.Location = new System.Drawing.Point(121, 146);
            this.tb_onCloseVol.Name = "tb_onCloseVol";
            this.tb_onCloseVol.Size = new System.Drawing.Size(100, 20);
            this.tb_onCloseVol.TabIndex = 5;
            this.tb_onCloseVol.Text = "Close vol";
            // 
            // btn_startWithOS
            // 
            this.btn_startWithOS.Location = new System.Drawing.Point(15, 249);
            this.btn_startWithOS.Name = "btn_startWithOS";
            this.btn_startWithOS.Size = new System.Drawing.Size(206, 37);
            this.btn_startWithOS.TabIndex = 12;
            this.btn_startWithOS.Text = "Enable/disable start with OS";
            this.btn_startWithOS.UseVisualStyleBackColor = true;
            this.btn_startWithOS.Click += new System.EventHandler(this.btn_startWithOS_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Volume on open:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Volume on close:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Process name:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 301);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startWithOS);
            this.Controls.Add(this.tb_onCloseVol);
            this.Controls.Add(this.tb_onOpenVol);
            this.Controls.Add(this.tb_processName);
            this.Controls.Add(this.btn_defaultSettings);
            this.Controls.Add(this.btn_exitApp);
            this.Controls.Add(this.btn_changeOnOff);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto_VOL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_changeOnOff;
        private System.Windows.Forms.Button btn_exitApp;
        private System.Windows.Forms.Button btn_defaultSettings;
        private System.Windows.Forms.TextBox tb_processName;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TextBox tb_onOpenVol;
        private System.Windows.Forms.TextBox tb_onCloseVol;
        private System.Windows.Forms.Button btn_startWithOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

