namespace VilcomNetworkMonitor
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConfVersion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ConfPort = new System.Windows.Forms.ComboBox();
            this.ConfCommunity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ConfCommunity);
            this.groupBox1.Controls.Add(this.ConfPort);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ConfVersion);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 141);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки приема трапов";
            // 
            // ConfVersion
            // 
            this.ConfVersion.FormattingEnabled = true;
            this.ConfVersion.Items.AddRange(new object[] {
            "v1",
            "v2"});
            this.ConfVersion.Location = new System.Drawing.Point(126, 16);
            this.ConfVersion.Name = "ConfVersion";
            this.ConfVersion.Size = new System.Drawing.Size(71, 21);
            this.ConfVersion.TabIndex = 2;
            this.ConfVersion.Text = "v2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trap Receive Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SNMP Trap Version";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfPort
            // 
            this.ConfPort.FormattingEnabled = true;
            this.ConfPort.Items.AddRange(new object[] {
            "162"});
            this.ConfPort.Location = new System.Drawing.Point(126, 48);
            this.ConfPort.Name = "ConfPort";
            this.ConfPort.Size = new System.Drawing.Size(71, 21);
            this.ConfPort.TabIndex = 4;
            this.ConfPort.Text = "162";
            // 
            // ConfCommunity
            // 
            this.ConfCommunity.FormattingEnabled = true;
            this.ConfCommunity.Items.AddRange(new object[] {
            "public",
            "private"});
            this.ConfCommunity.Location = new System.Drawing.Point(126, 79);
            this.ConfCommunity.Name = "ConfCommunity";
            this.ConfCommunity.Size = new System.Drawing.Size(71, 21);
            this.ConfCommunity.TabIndex = 5;
            this.ConfCommunity.Text = "public";
            this.ConfCommunity.SelectedIndexChanged += new System.EventHandler(this.ConfCommunity_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "SNMP community";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 165);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Конфигурация";
            this.Shown += new System.EventHandler(this.Form2_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox ConfVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ConfPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ConfCommunity;

    }
}