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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TrapGrid = new System.Windows.Forms.DataGridView();
            this.GridHostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cellTrapID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCommunity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CompanyInfoLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonParser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonExportCSV = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TrapGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrapGrid
            // 
            this.TrapGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TrapGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridHostname,
            this.cellTrapID,
            this.GridTime,
            this.GridCommunity});
            this.TrapGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrapGrid.Location = new System.Drawing.Point(0, 140);
            this.TrapGrid.Name = "TrapGrid";
            this.TrapGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TrapGrid.Size = new System.Drawing.Size(989, 331);
            this.TrapGrid.TabIndex = 0;
            this.TrapGrid.DoubleClick += new System.EventHandler(this.TrapGrid_DoubleClick);
            this.TrapGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TrapGrid_CellContentClick);
            // 
            // GridHostname
            // 
            this.GridHostname.FillWeight = 150F;
            this.GridHostname.HeaderText = "IP-адрес сервера";
            this.GridHostname.Name = "GridHostname";
            this.GridHostname.Width = 150;
            // 
            // cellTrapID
            // 
            this.cellTrapID.HeaderText = "Trap ID";
            this.cellTrapID.Name = "cellTrapID";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Запустить мониторинг";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextLog
            // 
            this.TextLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextLog.Location = new System.Drawing.Point(0, 51);
            this.TextLog.Name = "TextLog";
            this.TextLog.Size = new System.Drawing.Size(989, 89);
            this.TextLog.TabIndex = 4;
            this.TextLog.Text = "Сервис успешно запущен";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(585, 385);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "Настройки";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(429, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(154, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "О программе";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 26);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openListToolStripMenuItem,
            this.saveListToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openListToolStripMenuItem
            // 
            this.openListToolStripMenuItem.Name = "openListToolStripMenuItem";
            this.openListToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.openListToolStripMenuItem.Text = "Открыть список";
            this.openListToolStripMenuItem.Click += new System.EventHandler(this.openListToolStripMenuItem_Click);
            // 
            // saveListToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Name = "saveListToolStripMenuItem";
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.saveListToolStripMenuItem.Text = "Сохранить список";
            this.saveListToolStripMenuItem.Click += new System.EventHandler(this.saveListToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(77, 22);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.HelpToolStripMenuItem.Text = "Краткая справка";
            this.HelpToolStripMenuItem.Click += new System.EventHandler(this.HelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CompanyInfoLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 471);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 37);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(919, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(66, 44);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "© 1999-2013 «Вилком»";
            // 
            // CompanyInfoLabel
            // 
            this.CompanyInfoLabel.AutoSize = true;
            this.CompanyInfoLabel.Location = new System.Drawing.Point(207, 3);
            this.CompanyInfoLabel.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.CompanyInfoLabel.Name = "CompanyInfoLabel";
            this.CompanyInfoLabel.Size = new System.Drawing.Size(170, 13);
            this.CompanyInfoLabel.TabIndex = 5;
            this.CompanyInfoLabel.Text = "+7(495)9613443     info@vilcom.ru";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(989, 38);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonStop,
            this.toolStripSeparator1,
            this.toolStripButtonSettings,
            this.toolStripButton1,
            this.toolStripButtonParser,
            this.toolStripSeparator2,
            this.toolStripButtonExportCSV,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 26);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(989, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStart.Text = "toolStripButton1";
            this.toolStripButtonStart.ToolTipText = "Запустить мониторинг";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonStop.Enabled = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonStop.Text = "toolStripButton2";
            this.toolStripButtonStop.ToolTipText = "Остановить мониторинг";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSettings.Image")));
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSettings.Text = "toolStripButton3";
            this.toolStripButtonSettings.ToolTipText = "Настройки";
            this.toolStripButtonSettings.Click += new System.EventHandler(this.toolStripButtonSettings_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Правила исключений";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripButtonParser
            // 
            this.toolStripButtonParser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonParser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonParser.Image")));
            this.toolStripButtonParser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonParser.Name = "toolStripButtonParser";
            this.toolStripButtonParser.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonParser.Text = "toolStripButton4";
            this.toolStripButtonParser.ToolTipText = "Управление парсером";
            this.toolStripButtonParser.Click += new System.EventHandler(this.toolStripButtonParser_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonExportCSV
            // 
            this.toolStripButtonExportCSV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExportCSV.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExportCSV.Image")));
            this.toolStripButtonExportCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExportCSV.Name = "toolStripButtonExportCSV";
            this.toolStripButtonExportCSV.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExportCSV.Text = "toolStripButton5";
            this.toolStripButtonExportCSV.ToolTipText = "Экспорт данных в Excel";
            this.toolStripButtonExportCSV.Click += new System.EventHandler(this.toolStripButtonExportCSV_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 508);
            this.Controls.Add(this.TrapGrid);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Vilcom Network SNMP Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TrapGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TrapGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.ToolStripButton toolStripButtonParser;
        private System.Windows.Forms.ToolStripButton toolStripButtonExportCSV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label CompanyInfoLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridHostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cellTrapID;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCommunity;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Timer timer1;
    }
}

