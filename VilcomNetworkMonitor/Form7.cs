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
    public partial class Form7 : Form
    {
        Form1 parent;

        public Form7(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                        
            parent.excludes.iplist = stringsConcat(listBox1);
            parent.excludes.oidlist = stringsConcat(listBox2);
            parent.excludes.valuelist = stringsConcat(listBox3);
            parent.excludes.saveToFile();
            MessageBox.Show("Изменения успешно сохранены.");
            this.Close();
        }

        /**
         * склеивает строки листбокса в единую строку с разделителем ,
         **/
        private string stringsConcat(ListBox lstBox)
        {
            string result = "";
            int cnt = 0;

            foreach(string str in lstBox.Items)
            {
                result = result + str;
                cnt++;
                if(cnt != lstBox.Items.Count)
                {
                    result = result + ",";
                }
            }

            return result;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Изменения не были сохранены.");
            this.Close();
        }

        private void Form7_Shown(object sender, EventArgs e)
        {
       

            comboBox1.SelectedIndex = 0;

            foreach (string ips in parent.excludes.iplist.Split(new Char[] { ',' }))
            {
                listBox1.Items.Add(ips);
            }

            foreach (string oids in parent.excludes.oidlist.Split(new Char[] { ',' }))
            {
                listBox2.Items.Add(oids);
            }

            foreach (string values in parent.excludes.valuelist.Split(new Char[] { ',' }))
            {
                listBox3.Items.Add(values);
            }



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string tmpval = comboBox1.Items[comboBox1.SelectedIndex].ToString();
 
            if (tmpval == "IP_FILTER")
            {
                listBox1.Items.Add(textBox4.Text);
            }
            if (tmpval == "OID_FILTER")
            {
                listBox2.Items.Add(textBox4.Text);
            }
            if (tmpval == "VALUE_FILTER")
            {
                listBox3.Items.Add(textBox4.Text);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox3.Items.RemoveAt(listBox3.SelectedIndex);
        }
    }
}
