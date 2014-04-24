namespace VilcomNetworkMonitor
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.ParserGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.addRowButton = new System.Windows.Forms.Button();
            this.oidPattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namePattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParseParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textPattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ParserGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParserGrid
            // 
            this.ParserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParserGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oidPattern,
            this.namePattern,
            this.ParseParam,
            this.textPattern});
            this.ParserGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParserGrid.Location = new System.Drawing.Point(0, 44);
            this.ParserGrid.Name = "ParserGrid";
            this.ParserGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ParserGrid.Size = new System.Drawing.Size(904, 432);
            this.ParserGrid.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 476);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(904, 41);
            this.panel1.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveButton.Location = new System.Drawing.Point(752, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(146, 30);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить всё";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.removeButton);
            this.panel2.Controls.Add(this.addRowButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(904, 44);
            this.panel2.TabIndex = 2;
            // 
            // removeButton
            // 
            this.removeButton.Image = ((System.Drawing.Image)(resources.GetObject("removeButton.Image")));
            this.removeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.removeButton.Location = new System.Drawing.Point(211, 6);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(153, 30);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "  Удалить выделенный";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addRowButton
            // 
            this.addRowButton.Image = ((System.Drawing.Image)(resources.GetObject("addRowButton.Image")));
            this.addRowButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addRowButton.Location = new System.Drawing.Point(12, 6);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(193, 30);
            this.addRowButton.TabIndex = 0;
            this.addRowButton.Text = "Добавить OID ";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.addRowButton_Click);
            // 
            // oidPattern
            // 
            this.oidPattern.HeaderText = "OID";
            this.oidPattern.Name = "oidPattern";
            this.oidPattern.Width = 290;
            // 
            // namePattern
            // 
            this.namePattern.HeaderText = "Название поля";
            this.namePattern.Name = "namePattern";
            this.namePattern.Width = 240;
            // 
            // ParseParam
            // 
            this.ParseParam.HeaderText = "OID name";
            this.ParseParam.Name = "ParseParam";
            this.ParseParam.Width = 130;
            // 
            // textPattern
            // 
            this.textPattern.HeaderText = "textPattern";
            this.textPattern.Name = "textPattern";
            this.textPattern.Width = 200;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 517);
            this.Controls.Add(this.ParserGrid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form5";
            this.Text = "Настройки парсера трапов";
            ((System.ComponentModel.ISupportInitialize)(this.ParserGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ParserGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn oidPattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParseParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn textPattern;
    }
}