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

        public Form4(string trapID, TrapList tList, Parser tParser)
        {
            InitializeComponent();

            Trap tmpTrap = tList.getTrapById(trapID);

            textBox6.Text = tmpTrap.tTime;
            textBox5.Text = tmpTrap.tIPAddress;

            foreach (ParserRule rls in tParser.ruleList)
            {
                richTextBox1.AppendText(rls.name + " = " + tmpTrap.fields[rls.param] + Environment.NewLine);
            }

            richTextBox1.AppendText(Environment.NewLine + "Исходный трап:" + Environment.NewLine);
            
            try
            {
  
            }
            catch (Exception e)
            {
                MessageBox.Show("Нет данных для отображения.");                
            }

            richTextBox1.AppendText(tmpTrap.trapSource.ToString());


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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
