namespace VilcomNetworkMonitor
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TrapGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.GridHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCommunity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EventDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TrapGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TrapGrid
            // 
            this.TrapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrapGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridHostname,
            this.GridTime,
            this.GridCommunity,
            this.GridSeverity,
            this.EventDescr,
            this.Data});
            this.TrapGrid.Location = new System.Drawing.Point(12, 154);
            this.TrapGrid.Name = "TrapGrid";
            this.TrapGrid.Size = new System.Drawing.Size(772, 397);
            this.TrapGrid.TabIndex = 0;
            this.TrapGrid.DoubleClick += new System.EventHandler(this.TrapGrid_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(630, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запустить мониторинг";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(797, 38);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // TextLog
            // 
            this.TextLog.Location = new System.Drawing.Point(12, 47);
            this.TextLog.Name = "TextLog";
            this.TextLog.Size = new System.Drawing.Size(612, 101);
            this.TextLog.TabIndex = 4;
            this.TextLog.Text = "Сервис успешно запущен";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(630, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Настройки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(630, 119);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "О программе";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GridHostname
            // 
            this.GridHostname.FillWeight = 150F;
            this.GridHostname.HeaderText = "IP-адрес сервера";
            this.GridHostname.Name = "GridHostname";
            this.GridHostname.Width = 150;
            // 
            // GridTime
            // 
            this.GridTime.HeaderText = "Время";
            this.GridTime.Name = "GridTime";
            this.GridTime.Width = 120;
            // 
            // GridCommunity
            // 
            this.GridCommunity.HeaderText = "Community";
            this.GridCommunity.Name = "GridCommunity";
            // 
            // GridSeverity
            // 
            this.GridSeverity.HeaderText = "Severity";
            this.GridSeverity.Name = "GridSeverity";
            // 
            // EventDescr
            // 
            this.EventDescr.HeaderText = "EventDescr";
            this.EventDescr.Name = "EventDescr";
            this.EventDescr.Width = 150;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 561);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TrapGrid);
            this.Name = "Form1";
            this.Text = "Vilcom Network SNMP Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.TrapGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TrapGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridHostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCommunity;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridSeverity;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
    }
}

