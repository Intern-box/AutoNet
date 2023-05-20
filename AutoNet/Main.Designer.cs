namespace AutoNet
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.AdaptersList = new System.Windows.Forms.ComboBox();
            this.LAdaptersList = new System.Windows.Forms.Label();
            this.LWorkstationsList = new System.Windows.Forms.Label();
            this.WorkstationsList = new System.Windows.Forms.ComboBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.LNow = new System.Windows.Forms.Label();
            this.LWillBe = new System.Windows.Forms.Label();
            this.LIP = new System.Windows.Forms.Label();
            this.LMask = new System.Windows.Forms.Label();
            this.LGW = new System.Windows.Forms.Label();
            this.CheckIP = new System.Windows.Forms.Button();
            this.Workstation = new System.Windows.Forms.ComboBox();
            this.LWorkstation = new System.Windows.Forms.Label();
            this.PingIP = new System.Windows.Forms.Button();
            this.PingHostname = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.WillBeGW = new System.Windows.Forms.TextBox();
            this.WillBeMask = new System.Windows.Forms.TextBox();
            this.WillBeIP = new System.Windows.Forms.TextBox();
            this.NowGW = new System.Windows.Forms.ComboBox();
            this.NowMask = new System.Windows.Forms.ComboBox();
            this.NowIP = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.EquIP = new System.Windows.Forms.Button();
            this.WorkstationIP = new System.Windows.Forms.TextBox();
            this.Errors = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AdaptersList
            // 
            this.AdaptersList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdaptersList.FormattingEnabled = true;
            this.AdaptersList.Location = new System.Drawing.Point(92, 19);
            this.AdaptersList.Name = "AdaptersList";
            this.AdaptersList.Size = new System.Drawing.Size(411, 24);
            this.AdaptersList.TabIndex = 0;
            this.AdaptersList.SelectedIndexChanged += new System.EventHandler(this.AdaptersList_SelectedIndexChanged);
            // 
            // LAdaptersList
            // 
            this.LAdaptersList.AutoSize = true;
            this.LAdaptersList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LAdaptersList.Location = new System.Drawing.Point(8, 22);
            this.LAdaptersList.Name = "LAdaptersList";
            this.LAdaptersList.Size = new System.Drawing.Size(78, 16);
            this.LAdaptersList.TabIndex = 1;
            this.LAdaptersList.Text = "Адаптеры:";
            // 
            // LWorkstationsList
            // 
            this.LWorkstationsList.AutoSize = true;
            this.LWorkstationsList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LWorkstationsList.Location = new System.Drawing.Point(13, 52);
            this.LWorkstationsList.Name = "LWorkstationsList";
            this.LWorkstationsList.Size = new System.Drawing.Size(73, 16);
            this.LWorkstationsList.TabIndex = 2;
            this.LWorkstationsList.Text = "Касса №:";
            // 
            // WorkstationsList
            // 
            this.WorkstationsList.Enabled = false;
            this.WorkstationsList.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkstationsList.FormattingEnabled = true;
            this.WorkstationsList.Location = new System.Drawing.Point(92, 49);
            this.WorkstationsList.Name = "WorkstationsList";
            this.WorkstationsList.Size = new System.Drawing.Size(58, 24);
            this.WorkstationsList.TabIndex = 2;
            this.WorkstationsList.SelectedIndexChanged += new System.EventHandler(this.WorkstationsList_SelectedIndexChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyButton.Location = new System.Drawing.Point(230, 92);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(135, 24);
            this.ApplyButton.TabIndex = 3;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // LNow
            // 
            this.LNow.AutoSize = true;
            this.LNow.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LNow.Location = new System.Drawing.Point(24, 37);
            this.LNow.Name = "LNow";
            this.LNow.Size = new System.Drawing.Size(62, 16);
            this.LNow.TabIndex = 5;
            this.LNow.Text = "Сейчас:";
            // 
            // LWillBe
            // 
            this.LWillBe.AutoSize = true;
            this.LWillBe.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LWillBe.Location = new System.Drawing.Point(26, 66);
            this.LWillBe.Name = "LWillBe";
            this.LWillBe.Size = new System.Drawing.Size(60, 16);
            this.LWillBe.TabIndex = 9;
            this.LWillBe.Text = "Станет:";
            // 
            // LIP
            // 
            this.LIP.AutoSize = true;
            this.LIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LIP.Location = new System.Drawing.Point(151, 15);
            this.LIP.Name = "LIP";
            this.LIP.Size = new System.Drawing.Size(20, 16);
            this.LIP.TabIndex = 13;
            this.LIP.Text = "IP";
            // 
            // LMask
            // 
            this.LMask.AutoSize = true;
            this.LMask.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LMask.Location = new System.Drawing.Point(278, 15);
            this.LMask.Name = "LMask";
            this.LMask.Size = new System.Drawing.Size(40, 16);
            this.LMask.TabIndex = 14;
            this.LMask.Text = "Mask";
            // 
            // LGW
            // 
            this.LGW.AutoSize = true;
            this.LGW.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LGW.Location = new System.Drawing.Point(421, 15);
            this.LGW.Name = "LGW";
            this.LGW.Size = new System.Drawing.Size(29, 16);
            this.LGW.TabIndex = 15;
            this.LGW.Text = "GW";
            // 
            // CheckIP
            // 
            this.CheckIP.Enabled = false;
            this.CheckIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckIP.Location = new System.Drawing.Point(91, 92);
            this.CheckIP.Name = "CheckIP";
            this.CheckIP.Size = new System.Drawing.Size(135, 24);
            this.CheckIP.TabIndex = 4;
            this.CheckIP.Text = "Проверить IP";
            this.CheckIP.UseVisualStyleBackColor = true;
            this.CheckIP.Click += new System.EventHandler(this.CheckIP_Click);
            // 
            // Workstation
            // 
            this.Workstation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Workstation.FormattingEnabled = true;
            this.Workstation.Location = new System.Drawing.Point(92, 18);
            this.Workstation.Name = "Workstation";
            this.Workstation.Size = new System.Drawing.Size(58, 24);
            this.Workstation.TabIndex = 5;
            // 
            // LWorkstation
            // 
            this.LWorkstation.AutoSize = true;
            this.LWorkstation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LWorkstation.Location = new System.Drawing.Point(13, 21);
            this.LWorkstation.Name = "LWorkstation";
            this.LWorkstation.Size = new System.Drawing.Size(73, 16);
            this.LWorkstation.TabIndex = 17;
            this.LWorkstation.Text = "Касса №:";
            // 
            // PingIP
            // 
            this.PingIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PingIP.Location = new System.Drawing.Point(456, 19);
            this.PingIP.Name = "PingIP";
            this.PingIP.Size = new System.Drawing.Size(48, 24);
            this.PingIP.TabIndex = 6;
            this.PingIP.Text = "Ping";
            this.PingIP.UseVisualStyleBackColor = true;
            this.PingIP.Click += new System.EventHandler(this.PingIP_Click);
            // 
            // PingHostname
            // 
            this.PingHostname.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PingHostname.Location = new System.Drawing.Point(156, 18);
            this.PingHostname.Name = "PingHostname";
            this.PingHostname.Size = new System.Drawing.Size(156, 24);
            this.PingHostname.TabIndex = 7;
            this.PingHostname.Text = "Проверка по имени";
            this.PingHostname.UseVisualStyleBackColor = true;
            this.PingHostname.Click += new System.EventHandler(this.PingHostname_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AdaptersList);
            this.groupBox1.Controls.Add(this.LAdaptersList);
            this.groupBox1.Controls.Add(this.LWorkstationsList);
            this.groupBox1.Controls.Add(this.WorkstationsList);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 87);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.WillBeGW);
            this.groupBox2.Controls.Add(this.WillBeMask);
            this.groupBox2.Controls.Add(this.WillBeIP);
            this.groupBox2.Controls.Add(this.NowGW);
            this.groupBox2.Controls.Add(this.NowMask);
            this.groupBox2.Controls.Add(this.NowIP);
            this.groupBox2.Controls.Add(this.ApplyButton);
            this.groupBox2.Controls.Add(this.LNow);
            this.groupBox2.Controls.Add(this.LWillBe);
            this.groupBox2.Controls.Add(this.LIP);
            this.groupBox2.Controls.Add(this.LMask);
            this.groupBox2.Controls.Add(this.LGW);
            this.groupBox2.Controls.Add(this.CheckIP);
            this.groupBox2.Location = new System.Drawing.Point(12, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(519, 125);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // WillBeGW
            // 
            this.WillBeGW.Enabled = false;
            this.WillBeGW.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WillBeGW.Location = new System.Drawing.Point(370, 63);
            this.WillBeGW.Name = "WillBeGW";
            this.WillBeGW.Size = new System.Drawing.Size(133, 23);
            this.WillBeGW.TabIndex = 11;
            // 
            // WillBeMask
            // 
            this.WillBeMask.Enabled = false;
            this.WillBeMask.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WillBeMask.Location = new System.Drawing.Point(231, 63);
            this.WillBeMask.Name = "WillBeMask";
            this.WillBeMask.Size = new System.Drawing.Size(133, 23);
            this.WillBeMask.TabIndex = 10;
            // 
            // WillBeIP
            // 
            this.WillBeIP.Enabled = false;
            this.WillBeIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WillBeIP.Location = new System.Drawing.Point(92, 63);
            this.WillBeIP.Name = "WillBeIP";
            this.WillBeIP.Size = new System.Drawing.Size(133, 23);
            this.WillBeIP.TabIndex = 9;
            // 
            // NowGW
            // 
            this.NowGW.Enabled = false;
            this.NowGW.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NowGW.FormattingEnabled = true;
            this.NowGW.Location = new System.Drawing.Point(370, 34);
            this.NowGW.Name = "NowGW";
            this.NowGW.Size = new System.Drawing.Size(133, 24);
            this.NowGW.TabIndex = 14;
            // 
            // NowMask
            // 
            this.NowMask.Enabled = false;
            this.NowMask.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NowMask.FormattingEnabled = true;
            this.NowMask.Location = new System.Drawing.Point(231, 34);
            this.NowMask.Name = "NowMask";
            this.NowMask.Size = new System.Drawing.Size(133, 24);
            this.NowMask.TabIndex = 13;
            // 
            // NowIP
            // 
            this.NowIP.Enabled = false;
            this.NowIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NowIP.FormattingEnabled = true;
            this.NowIP.Location = new System.Drawing.Point(92, 34);
            this.NowIP.Name = "NowIP";
            this.NowIP.Size = new System.Drawing.Size(133, 24);
            this.NowIP.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.EquIP);
            this.groupBox3.Controls.Add(this.WorkstationIP);
            this.groupBox3.Controls.Add(this.PingHostname);
            this.groupBox3.Controls.Add(this.LWorkstation);
            this.groupBox3.Controls.Add(this.Workstation);
            this.groupBox3.Controls.Add(this.PingIP);
            this.groupBox3.Location = new System.Drawing.Point(12, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(519, 88);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            // 
            // EquIP
            // 
            this.EquIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EquIP.Location = new System.Drawing.Point(316, 48);
            this.EquIP.Name = "EquIP";
            this.EquIP.Size = new System.Drawing.Size(188, 24);
            this.EquIP.TabIndex = 18;
            this.EquIP.Text = "Как IP сейчас";
            this.EquIP.UseVisualStyleBackColor = true;
            this.EquIP.Click += new System.EventHandler(this.EquIP_Click);
            // 
            // WorkstationIP
            // 
            this.WorkstationIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkstationIP.Location = new System.Drawing.Point(317, 19);
            this.WorkstationIP.Name = "WorkstationIP";
            this.WorkstationIP.Size = new System.Drawing.Size(133, 23);
            this.WorkstationIP.TabIndex = 16;
            this.WorkstationIP.Text = "192.168.133.2";
            // 
            // Errors
            // 
            this.Errors.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Errors.Location = new System.Drawing.Point(0, 330);
            this.Errors.Name = "Errors";
            this.Errors.Size = new System.Drawing.Size(544, 22);
            this.Errors.SizingGrip = false;
            this.Errors.TabIndex = 31;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(544, 352);
            this.Controls.Add(this.Errors);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoNet 0.9";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox AdaptersList;
        private System.Windows.Forms.Label LAdaptersList;
        private System.Windows.Forms.Label LWorkstationsList;
        private System.Windows.Forms.ComboBox WorkstationsList;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label LNow;
        private System.Windows.Forms.Label LWillBe;
        private System.Windows.Forms.Label LIP;
        private System.Windows.Forms.Label LMask;
        private System.Windows.Forms.Label LGW;
        private System.Windows.Forms.Button CheckIP;
        private System.Windows.Forms.ComboBox Workstation;
        private System.Windows.Forms.Label LWorkstation;
        private System.Windows.Forms.Button PingIP;
        private System.Windows.Forms.Button PingHostname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox NowGW;
        private System.Windows.Forms.ComboBox NowMask;
        private System.Windows.Forms.ComboBox NowIP;
        private System.Windows.Forms.TextBox WillBeGW;
        private System.Windows.Forms.TextBox WillBeMask;
        private System.Windows.Forms.TextBox WillBeIP;
        private System.Windows.Forms.StatusStrip Errors;
        private System.Windows.Forms.TextBox WorkstationIP;
        private System.Windows.Forms.Button EquIP;
    }
}

