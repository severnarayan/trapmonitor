using System;
using System.Collections.Generic;
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

        //public static ManualResetEvent allDone = new ManualResetEvent(false);

        public Form1()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            this.conf = new VilcomConfiguration();
            this.conf = this.conf.loadFromFile();
            Client = new UdpClient(conf.port);
        }        

        private void button1_Click(object sender, EventArgs e)
        {             
            //Client uses as receive udp client           

            try
            {
                 Client.BeginReceive(new AsyncCallback(recv), null);
                 MessageBox.Show("ok");
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

            MessageBox.Show(Encoding.UTF8.GetString(received));
            
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



            addTrapToGrid(RemoteIpEndPoint.ToString(), trapData, pkt);

            Client.BeginReceive(new AsyncCallback(recv), null);
        }

        public void _debug(String msg)
        {
            TextLog.AppendText(Environment.NewLine + DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt") + msg);
        }

        private string getTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt");
        }

        private void addTrapToGrid(string addr, string trapData,SnmpV2Packet packet)
        {
            DataGridViewRow row = (DataGridViewRow)TrapGrid.Rows[0].Clone();
            row.Cells[0].Value = addr;
            row.Cells[1].Value = this.getTime();
            row.Cells[2].Value = packet.Community.ToString();

            MessageBox.Show("данные всего трапа:" + packet.Pdu.ToString());

            try
            {
                //row.Cells[3].Value = packet.Pdu.VbList["1.3.6.1.4.1.4100.4.1.2.2.5.1.1.4.1150"].Value.ToString();
                //MessageBox.Show("данные oid severity:" +packet.Pdu.VbList["1.3.6.1.4.1.4100.4.1.2.2.5.1.1.4.1150"].ToString());
                
                
            }
            catch(Exception e)
            {
                row.Cells[3].Value = "can't parse!";
            }

            //row.Cells[3].Value = "CLR";

            try
            {
                row.Cells[4].Value = packet.Pdu.VbList["1.3.6.1.4.1.4100.4.1.2.2.5.1.1.11.1150"].Value.ToString(); 
            }
            catch(Exception e)
            {
                row.Cells[4].Value = "can't parse!";
            }

            row.Cells[5].Value = trapData;

            TrapGrid.Rows.Add(row); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            
        }

        private void TrapGrid_DoubleClick(object sender, EventArgs e)
        {
            Form4 trapWindow = new Form4(TrapGrid.CurrentRow.Cells);
            trapWindow.Show();
        }

        public void listen()
        {
            _debug(" мониторинг успешно запущен");

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, conf.port);
            EndPoint ep = (EndPoint)ipep;
            socket.Bind(ep);
            // Disable timeout processing. Just block until packet is received 
            //socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 0);



            bool run = true;


           


            while (run)
            {


                //System.Threading.Thread.Sleep((0);
                byte[] indata = new byte[16 * 1024];
                // 16KB receive buffer int inlen = 0;
                IPEndPoint peer = new IPEndPoint(IPAddress.Any, 0);
                EndPoint inep = (EndPoint)peer;
                int inlen;
                try
                {
                    inlen = socket.ReceiveFrom(indata, ref inep);
                }
                catch (Exception ex)
                {
                    _debug("Ошибка " + ex.Message);
                    inlen = -1;
                    break;
                }
                if (inlen > 0)
                {
                    // Check protocol version int 
                    int ver;

                    ver = SnmpPacket.GetProtocolVersion(indata, inlen);


                    /*  
                    if (ver == (int)SnmpVersion.Ver1)
                    {
                        // Parse SNMP Version 1 TRAP packet 
                        SnmpV1TrapPacket pkt = new SnmpV1TrapPacket();
                        pkt.decode(indata, inlen);
                        _debug("** SNMP Version 1 TRAP received from {0}:"+ inep.ToString());
                       /* Console.WriteLine("*** Trap generic: {0}", pkt.Pdu.Generic);
                        Console.WriteLine("*** Trap specific: {0}", pkt.Pdu.Specific);
                        Console.WriteLine("*** Agent address: {0}", pkt.Pdu.AgentAddress.ToString());
                        Console.WriteLine("*** Timestamp: {0}", pkt.Pdu.TimeStamp.ToString());
                        Console.WriteLine("*** VarBind count: {0}", pkt.Pdu.VbList.Count);
                        Console.WriteLine("*** VarBind content:"); */
                    /*     foreach (Vb v in pkt.Pdu.VbList)
                         {
                             Console.WriteLine("**** {0} {1}: {2}", v.Oid.ToString(), SnmpConstants.GetTypeName(v.Value.Type), v.Value.ToString());
                         }
                         Console.WriteLine("** End of SNMP Version 1 TRAP data.");
                     }
                     else
                     { 
                     */

                    // Parse SNMP Version 2 TRAP packet 
                    SnmpV2Packet pkt = new SnmpV2Packet();
                    pkt.decode(indata, inlen);



                    _debug("Получен TRAP с адреса" + inep.ToString());

                    string trapData = "";

                    foreach (Vb v in pkt.Pdu.VbList)
                    {
                        trapData = String.Concat(trapData, "**** " +
                           v.Oid.ToString() + " " +
                           SnmpConstants.GetTypeName(v.Value.Type) + " " +
                           v.Value.ToString());
                    }


                    MessageBox.Show("111");



                    addTrapToGrid(inep.ToString(), trapData, pkt);
                   // break;


                    _debug("** TRAP успешно разобран.");

                    //continue;

                    /*  }  */

                    continue;
                }
                else
                {
                    if (inlen == 0)
                        _debug("Получен некорректный TRAP нулевой длины");

                }

                //while end:
            }

                       
        }


    }
}
