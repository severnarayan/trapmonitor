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
    public partial class Form4 : Form
    {
        public Form4(DataGridViewCellCollection data)
        {
            InitializeComponent();
            //richTextBox1.AppendText(data[5].Value.ToString());
            textBox5.Text = data[0].Value.ToString();
            textBox3.Text = data[3].Value.ToString();
            textBox2.Text = data[4].Value.ToString();
            textBox6.Text = data[1].Value.ToString();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
