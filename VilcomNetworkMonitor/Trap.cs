using System;
using System.Collections;
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
    public class Trap
    {
        public string tIPAddress;
        public string tTime;
        public string tCommunity;
        public string tSeverity = "";
        public string tEventDescription = "";
        public string trapData = "";
        public string trapSource = "";

        public string[] vars;

        public string severityOID = "";
        public string eventdescrOID = "";

        public Dictionary<string, string> fields = new Dictionary<string, string>();


        public Trap(string ip, SnmpV2Packet pckt)
        {
            tIPAddress = ip;
            tTime =  getTime();
            tCommunity = pckt.Community.ToString();
            trapSource = pckt.Pdu.ToString();

            Parser parseMe = new Parser();
            //загрузим парсер
            parseMe.loadFromFile();

            foreach (ParserRule rls in parseMe.ruleList)
            {
                //попытаемся добавить каждый оид из указанных в парсере
                fields[rls.param] = getTrapByOID(pckt, rls.oid);
               // MessageBox.Show("add to trap: " + rls.name + " " + rls.oid + "--" + fields[rls.param]);
            }
           
            //MessageBox.Show(trapSource);

        }

        private string getTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt");
        }

        private string getTrapByOID(SnmpV2Packet packet,string oidPattern)
        {

                foreach (Vb trapOidObj in  packet.Pdu.VbList)
                {
                    if (trapOidObj.Oid.ToString().Contains(oidPattern))
                    {
                        return trapOidObj.Value.ToString();
                    }
                }

                return "";

        }





    }
}
