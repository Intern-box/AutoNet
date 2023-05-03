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
            this.CAdapters = new System.Windows.Forms.ComboBox();
            this.LAdapters = new System.Windows.Forms.Label();
            this.LWorkstation = new System.Windows.Forms.Label();
            this.CWorkstation = new System.Windows.Forms.ComboBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.TOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CAdapters
            // 
            this.CAdapters.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CAdapters.FormattingEnabled = true;
            this.CAdapters.Location = new System.Drawing.Point(96, 12);
            this.CAdapters.Name = "CAdapters";
            this.CAdapters.Size = new System.Drawing.Size(280, 24);
            this.CAdapters.TabIndex = 0;
            this.CAdapters.SelectedIndexChanged += new System.EventHandler(this.CAdapters_SelectedIndexChanged);
            // 
            // LAdapters
            // 
            this.LAdapters.AutoSize = true;
            this.LAdapters.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LAdapters.Location = new System.Drawing.Point(12, 15);
            this.LAdapters.Name = "LAdapters";
            this.LAdapters.Size = new System.Drawing.Size(78, 16);
            this.LAdapters.TabIndex = 1;
            this.LAdapters.Text = "Адаптеры:";
            // 
            // LWorkstation
            // 
            this.LWorkstation.AutoSize = true;
            this.LWorkstation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LWorkstation.Location = new System.Drawing.Point(17, 45);
            this.LWorkstation.Name = "LWorkstation";
            this.LWorkstation.Size = new System.Drawing.Size(73, 16);
            this.LWorkstation.TabIndex = 2;
            this.LWorkstation.Text = "Касса №:";
            // 
            // CWorkstation
            // 
            this.CWorkstation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CWorkstation.FormattingEnabled = true;
            this.CWorkstation.Location = new System.Drawing.Point(96, 42);
            this.CWorkstation.Name = "CWorkstation";
            this.CWorkstation.Size = new System.Drawing.Size(58, 24);
            this.CWorkstation.TabIndex = 3;
            this.CWorkstation.SelectedIndexChanged += new System.EventHandler(this.CWorkstation_SelectedIndexChanged);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyButton.Location = new System.Drawing.Point(160, 42);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(216, 24);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // TOutput
            // 
            this.TOutput.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TOutput.Location = new System.Drawing.Point(15, 72);
            this.TOutput.Multiline = true;
            this.TOutput.Name = "TOutput";
            this.TOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TOutput.Size = new System.Drawing.Size(361, 185);
            this.TOutput.TabIndex = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(391, 269);
            this.Controls.Add(this.TOutput);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CWorkstation);
            this.Controls.Add(this.LWorkstation);
            this.Controls.Add(this.LAdapters);
            this.Controls.Add(this.CAdapters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "AutoNet 0.6";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CAdapters;
        private System.Windows.Forms.Label LAdapters;
        private System.Windows.Forms.Label LWorkstation;
        private System.Windows.Forms.ComboBox CWorkstation;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.TextBox TOutput;
    }
}

