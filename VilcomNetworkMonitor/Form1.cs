using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SnmpSharpNet;




namespace VilcomNetworkMonitor
{
    public partial class Form1 : Form
    {
        public VilcomConfiguration conf;

        public UdpClient Client;

        public ArrayList trapList = new ArrayList();

        public int trapListNum = 0;

        public Parser parseConf;

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            this.conf = new VilcomConfiguration();
            this.conf = this.conf.loadFromFile();
            Client = new UdpClient(conf.port);    
            
            //загрузим парсер
            try
            {

                parseConf = new Parser();

                parseConf.loadFromFile();
                foreach (ParserRule ruleConf in parseConf.ruleList)
                {                  
                    TrapGrid.Columns.Add(ruleConf.param, ruleConf.name);                    
                }
                _debug("Конфигурация парсера загружена!");
            }
            catch (Exception excp)
            {
                MessageBox.Show("Внимание! Файл конфигурации парсера не найден или был утерян"); 
            }
                                   

        }        

        private void button1_Click(object sender, EventArgs e)
        {             
            //Client uses as receive udp client           

            try
            {
                 Client.BeginReceive(new AsyncCallback(recv), null);                 
            }
            catch(Exception ex)
            {
                 MessageBox.Show(ex.ToString());
            }
            //CallBack
            
        }

        private void recv(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] received = Client.EndReceive(res, ref RemoteIpEndPoint);

            //Process codes

           // MessageBox.Show(Encoding.UTF8.GetString(received));
            
            SnmpV2Packet pkt = new SnmpV2Packet();
            pkt.decode(received, received.Length);

            _debug("Получен TRAP с адреса " + RemoteIpEndPoint.ToString());

            string trapData = "";

            foreach (Vb v in pkt.Pdu.VbList)
            {
                trapData = String.Concat(trapData, "**** " +
                   v.Oid.ToString() + " " +
                   SnmpConstants.GetTypeName(v.Value.Type) + " " +
                   v.Value.ToString());
            }

            Trap trp = new Trap(RemoteIpEndPoint.ToString(), pkt);               
            //addTrapToList(trp);
            addTrapToGrid(trp);
                     
            Client.BeginReceive(new AsyncCallback(recv), null);
        }

        public void _debug(String msg)
        {
            TextLog.AppendText(Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt") + msg);
        }

        //обновим весь грид с трапами
        public void reloadGridView()
        {
            TrapGrid.Rows.Clear();
            
            for (int i = 0; i < trapListNum; i++)
            {
                addTrapToGrid((Trap) trapList[i]);
            }
        }

        //добавить трап во внутренний список трапов
        private void addTrapToList(Trap currentTrap)
        {
            trapList.Add(currentTrap);
            trapListNum++;
        }

        //вернуть текущее время в нормальном виде
        private string getTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt");
        }

        //добавить трап в грид
        private void addTrapToGrid(Trap currentTrap)
        {
            DataGridViewRow row = (DataGridViewRow) TrapGrid.Rows[0].Clone();
            row.Cells[0].Value = currentTrap.tIPAddress;
            row.Cells[1].Value = currentTrap.tTime;
            row.Cells[2].Value = currentTrap.tCommunity;


            int xx = 3;
            foreach (ParserRule rls in parseConf.ruleList)
            {
               
                row.Cells[xx].Value = currentTrap.fields[rls.param];

                if (row.Cells[xx].Value.ToString().Contains("MAJ"))
                {
                    row.Cells[xx].Style.ForeColor = Color.Red;
                }                
                else
                {
                    row.Cells[xx].Style.ForeColor = Color.Black;
                }

                xx++;
            }                            

            TrapGrid.Rows.Add(row); 
        }

        //показать форму настроек
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
        }

        //открыть форму с подробной инфой о трапе
        private void TrapGrid_DoubleClick(object sender, EventArgs e)
        {
            Form4 trapWindow = new Form4(TrapGrid.CurrentRow.Cells);
            trapWindow.Show();
        }

        /** запуск мониторинга **/
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButtonStop.Enabled = true;
            toolStripButtonStart.Enabled = false;

            //Client uses as receive udp client           

            try
            {
                Client.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //CallBack
        }

        //остановка мониторинга
        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            toolStripButtonStart.Enabled = true;
            toolStripButtonStop.Enabled = false;
        }

        //показать форму с настройками
        private void toolStripButtonSettings_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show(); 
        }

        private void toolStripButtonParser_Click(object sender, EventArgs e)
        {
            Form5 parserForm = new Form5();
            parserForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        
    }
}
