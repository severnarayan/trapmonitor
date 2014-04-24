using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using SnmpSharpNet;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Threading;
using CustomUIControls;




namespace VilcomNetworkMonitor
{
    public partial class Form1 : Form
    {
        public VilcomConfiguration conf;

        public VilcomExcludes excludes;

        public UdpClient Client;

        public ArrayList xtrapList = new ArrayList();

        public List<Trap> trapList = new List<Trap>();

        public TrapList tList = new TrapList();

        public int trapListNum = 0;

        public Parser parseConf;

        public TaskbarNotifier taskbarNotifier;

        public long timerTicks = 0;

        public Form1()
        {
                       

            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;            

            this.conf = new VilcomConfiguration();
            this.conf = this.conf.loadFromFile();

            this.excludes = new VilcomExcludes();
            this.excludes = this.excludes.loadFromFile();

            timer1.Enabled = true;

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
                //MessageBox.Show("Внимание! Файл конфигурации парсера не найден или был утерян"); 
            }

            //попытаемся подгрузить данные из трапа
            if (File.Exists("state.data"))
            {
                tList.loadFromFile();

                foreach (Trap trapTemp in tList.dataList)
                {
                    addTrapToGrid(trapTemp);
                }
            }

            taskbarNotifier = new TaskbarNotifier();
            taskbarNotifier.SetBackgroundBitmap("notifyback.bmp",
                               Color.FromArgb(255, 0, 255));
            taskbarNotifier.SetCloseBitmap("close.bmp",
                    Color.FromArgb(255, 0, 255), new Point(220, 8));
            taskbarNotifier.TitleRectangle = new Rectangle(20, 9, 70, 2);
            taskbarNotifier.ContentRectangle = new Rectangle(8, 20, 200, 68);
            taskbarNotifier.NormalContentFont = new Font("Arial",9);
            //taskbarNotifier.TitleClick += new EventHandler(TitleClick);
            //taskbarNotifier.ContentClick += new EventHandler(ContentClick);
            taskbarNotifier.CloseClick += new EventHandler(Close2Click);

        }


        public void Close2Click(object obj, EventArgs ea)
        {
            
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

            //NotifyIcon notifyObj = new NotifyIcon();
            
            //notifyObj.ShowBalloon(Convert.ToUInt32(ToolTipIcon.Info) ,"Сообщение", "Я свернулась:)",5000 );

            string trapData = "";

            foreach (Vb v in pkt.Pdu.VbList)
            {
                trapData = String.Concat(trapData, "**** " +
                   v.Oid.ToString() + " " +
                   SnmpConstants.GetTypeName(v.Value.Type) + " " +
                   v.Value.ToString());
            }

            Trap trp = new Trap(RemoteIpEndPoint.ToString(), pkt);

            if (checkForExcludes(trp))
            {

                //через анонимный делегат отправим данные трапа на грид, чтобы не подвисал интерфейс, т.к. шлем из другого потока
                this.Invoke((MethodInvoker)delegate
                {

                    //выведем нотификацию
                    taskbarNotifier.Show("", "Получен трап с адреса " + RemoteIpEndPoint.ToString() + Environment.NewLine +
                                            "Community:" + trp.tCommunity, 300, 3000, 300);

                    tList.addTrap(trp);
                    addTrapToGrid(trp); // runs on UI thread


                });

                tList.saveToFile();

            }
            Client.BeginReceive(new AsyncCallback(recv), null);
        }
        
        // проверяет, не содержит ли трап исключений 
        public bool checkForExcludes(Trap trp)
        {
            //проверим по IP
            string[] split = excludes.iplist.Split(new Char[] { ',' });
            foreach (string s in split)
            {

                if(trp.tIPAddress.Contains(s.Trim()))
                {
                    _debug("-> Отклонен TRAP с адреса " + trp.tIPAddress.ToString() + " исключение по IP=" + s);
                    //MessageBox.Show("ok!");
                    return false;
                }
                
            }

            string[] splitOID = excludes.oidlist.Split(new Char[] { ',' });
            foreach (string s in splitOID)
            {
                if(trp.trapID.ToString().Contains(s.Trim()))
                {
                    _debug("-> Отклонен TRAP с адреса " + trp.tIPAddress.ToString() + " исключение по TrapId=" + s);
                    return false;
                }
                foreach(Vb oidata in trp.sourcePacket.Pdu.VbList)
                if(oidata.Oid.ToString().Contains(s.Trim()))
                {
                    _debug("-> Отклонен TRAP с адреса " + trp.tIPAddress.ToString() + " исключение по содержимому OID=" + s);
                    //MessageBox.Show("ok trap!");
                    return false;
                }
               
            } 

           string[] splitValue = excludes.oidlist.Split(new Char[] { ',' });
            foreach (string s in splitOID)
            {

                foreach(Vb oidata in trp.sourcePacket.Pdu.VbList)
                if(oidata.Value.ToString().Contains(s.Trim()))
                {
                    _debug("-> Отклонен TRAP с адреса " + trp.tIPAddress.ToString() + " исключение по содержимому '" + s + "' в значении OID " + oidata.Oid.ToString());
                    //MessageBox.Show("ok val!!");
                    return false;
                }
                
            } 
            
            return true;

        }
        

        public void _debug(String msg)
        {
            this.Invoke((MethodInvoker)delegate
            {
            TextLog.AppendText(Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt") + msg);
            });
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
           // xtrapList
        }

        //вернуть текущее время в нормальном виде
        private string getTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt");
        }

        public void setRowColor(DataGridViewRow row, Color clrx)
        {
            //MessageBox.Show("color: "+clrx.ToString());

            for (int i = 0; i < row.Cells.Count; i++)
            {
                row.Cells[i].Style.ForeColor = clrx;
            }

        }

        //добавить трап в грид
        private void addTrapToGrid(Trap currentTrap)
        {
            DataGridViewRow row = (DataGridViewRow) TrapGrid.Rows[0].Clone();
            row.Cells[0].Value = currentTrap.tIPAddress;
            row.Cells[1].Value = currentTrap.trapID;
            row.Cells[2].Value = currentTrap.tTime;
            row.Cells[3].Value = currentTrap.tCommunity;

            int xx = 4;
            bool flag = false;
            foreach (ParserRule rls in parseConf.ruleList)
            {
               
                row.Cells[xx].Value = currentTrap.fields[rls.param];
                

                if (flag == true) { break; }
                setRowColor(row, Color.Black);

                //MessageBox.Show("here");

                if (row.Cells[xx].Value.ToString().Contains("CRT"))
                {
                    setRowColor(row,Color.Red);
                    flag = true;
                    
                }
                else if (row.Cells[xx].Value.ToString().Contains("MAJ"))
                {
                    setRowColor(row, Color.Orange);
                    flag = true;
                    //row.Cells[xx].Style.ForeColor = Color.Orange;
                }
                else if (row.Cells[xx].Value.ToString().Contains("MIN"))
                {
                    setRowColor(row, Color.Yellow);
                    flag = true;
                    //row.Cells[xx].Style.ForeColor = Color.Yellow;
                }
                else if (row.Cells[xx].Value.ToString().Contains("INF"))
                {
                    setRowColor(row, Color.Blue);
                    flag = true;
                    //row.Cells[xx].Style.ForeColor = Color.Blue;
                }
                else if (row.Cells[xx].Value.ToString().Contains("CLR"))
                {
                    setRowColor(row, Color.Green);
                    flag = true;
                    //row.Cells[xx].Style.ForeColor = Color.Green;
                }
                //else
                //{
                    
                  //  flag = true;
                    //row.Cells[xx].Style.ForeColor = Color.Black;
                //}

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
            if (TrapGrid.SelectedRows.Count > 0)
            {
                Form4 trapWindow = new Form4(TrapGrid.CurrentRow.Cells[1].Value.ToString(), tList, parseConf);
                trapWindow.Show();
            }
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

        //показать форму с парсером
        private void toolStripButtonParser_Click(object sender, EventArgs e)
        {
            Form5 parserForm = new Form5();
            parserForm.Show();
        }

        //выход из программы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        //показать окно о программе
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

        //экспорт данных в CSV формат
        private void toolStripButtonExportCSV_Click(object sender, EventArgs e)
        {

            var sb = new StringBuilder();

            var headers = TrapGrid.Columns.Cast<DataGridViewColumn>();
            sb.Append(string.Join(";", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));
            sb.AppendLine();

            foreach (DataGridViewRow row in TrapGrid.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.Append(string.Join(";", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                sb.AppendLine();
            }

            //Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                        sw.WriteLine(sb.ToString());

                    MessageBox.Show("Успешно сохранено.");
                }
                catch(Exception excp)
                {
                    MessageBox.Show("невозможно сохранить данные ввиду следующих причин:" + excp.Message);
                }
            }

        }

        private void openListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("в данной версии не поддерживается");

        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tList.saveToFile();

            MessageBox.Show("Сохранено.");

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tList.saveToFile();
        }

        private void TrapGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //this.Hide();

            /*

            //через анонимный делегат отправим данные трапа на грид, чтобы не подвисал интерфейс, т.к. шлем из другого потока
            this.Invoke((MethodInvoker)delegate
            {
                var fm6 = new Form6();
                fm6.Show();
                fm6.Activate();
            });


            this.Activate();
            this.Show(); */
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            Form7 excl = new Form7(this);
            excl.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerTicks = timerTicks + 1;
            TimeSpan span1 = TimeSpan.FromSeconds(timerTicks);
            string uptime = span1.Hours.ToString() + " ч. " + 
                            span1.Minutes.ToString() + " м. " +
                            span1.Seconds.ToString() + " с. ";

            toolStripLabel1.Text = "Uptime: " + uptime;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("К сожалению, справка не доступна в данной версии.");
        }


        
    }
}
