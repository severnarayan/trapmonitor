using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VilcomNetworkMonitor
{
    public partial class Form2 : Form
    {
        public Form1 parent;

        public Form2(Form1 parent)
        {            
            InitializeComponent();
            this.parent = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.conf.port = Convert.ToInt32(ConfPort.Text);
            parent.conf.community = ConfCommunity.Text;
            parent.conf.version = ConfVersion.Text;
            parent.conf.saveToFile();            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            ConfPort.Text = parent.conf.port.ToString();
            ConfVersion.Text = parent.conf.version;
            ConfCommunity.Text = parent.conf.community;
        }

        private void ConfCommunity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
