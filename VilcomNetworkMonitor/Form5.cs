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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            try
            {

                Parser pars = new Parser();
                pars.loadFromFile();

                for (int i = 0; i < pars.ruleList.Count; i++)
                {
                    ParserRule rls = pars.ruleList[i];
                    ParserGrid.Rows.Add(rls.oid, rls.name,rls.param);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Файл парсера не был найден. необходимо создать парсер заново.");
            }

        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            ParserGrid.Rows.Add();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ParserGrid.Rows.RemoveAt(ParserGrid.SelectedRows[0].Index);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Parser pars = new Parser();

            for (int i = 0; i < ParserGrid.Rows.Count; i++)
            {
                DataGridViewRow currentRow = ParserGrid.Rows[i];
                try
                {
                    pars.addRule(currentRow.Cells[0].Value.ToString(), currentRow.Cells[1].Value.ToString(), currentRow.Cells[2].Value.ToString());
                }
                catch(Exception exp)
                {
                }
                

            }
            pars.saveToFile();
            MessageBox.Show("Внимание! После изменения настроек парсера необходимо перезапустить программу.");
            Close();
        }


    }
}
