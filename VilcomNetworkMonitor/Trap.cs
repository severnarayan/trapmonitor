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
using System.Security.Cryptography;


namespace VilcomNetworkMonitor
{
    [Serializable]
    public class Trap
    {
        public string tIPAddress;
        public string trapID;
        public string tTime;
        public string tCommunity;
        public string tSeverity = "";
        public string tEventDescription = "";
        public string trapData = "";
        public string trapSource = "";

        [NonSerialized]
        public SnmpV2Packet sourcePacket;

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
            trapID = getMD5Hash(trapSource);
           sourcePacket = pckt;

            Parser parseMe = new Parser();
            //загрузим парсер
            parseMe.loadFromFile();

            foreach (ParserRule rls in parseMe.ruleList)
            {
                //попытаемся добавить каждый оид из указанных в парсере
                fields[rls.param] = getTrapByOID(pckt, rls.oid,rls.textPattern);
               // MessageBox.Show("add to trap: " + rls.name + " " + rls.oid + "--" + fields[rls.param]);
            }
           
            //MessageBox.Show(trapSource);

        }

        private string getTime()
        {
            return DateTime.Now.ToString("MM/dd/yyyy  h:mm  tt");
        }

        private string getTrapByOID(SnmpV2Packet packet,string oidPattern, string textPattern)
        {

            //MessageBox.Show(packet.Pdu.ToString());
                foreach (Vb trapOidObj in  packet.Pdu.VbList)
                {

                    //MessageBox.Show("trap: " + trapOidObj.Oid.ToString() + " pattern:" + oidPattern);
                    if (trapOidObj.Oid.ToString().Contains(oidPattern))
                    {
                        string trapString = trapOidObj.Value.ToString();
                        string customData = parseDataByContent(trapString,textPattern);

                        //MessageBox.Show(trapString + "." + customData);

                        //если мы нашли специальное значение внутри - то вернем его
                        if (customData != "")
                        { 
                            return customData; 
                        }
                        else{  
                            //иначе вернем все данные трапа
                            return trapString;
                        }

                    }
                }

                return "";

        }


        //пытается найти значение параметра в общей строке параметров
        private string parseDataByContent(string word,string pattern)
        {
            //string word = "internalKey=253167|name=test1|lastMarkerDistanceM=1095.803|firstMarkerDistanceM=80.665|displayOrder=1|seveity=5|det.acqDurationSec=10|det.pulseNs=3|det.rangeKm=2.046|det.resolution";

            string[] split = word.Split(new Char[] { '|' });
            string result = "";

            foreach (string s in split)
            {
                result = "";

                //пройдемся по всем параметрам и если нашли нужный
                if (s.Contains(pattern))
                {
                    //MessageBox.Show("severity found!");

                    string[] svrx = s.Split(new Char[] { '=' });                    

                    //попытаемся вытянуть его значение после символа =
                    try
                    {
                        result = svrx[1];

                        //хардкод для второй железки - разбираем северити.
                        /*

                        */


                    }
                    catch (Exception ex)
                    {
                        result = "";
                    }

                    break;
                }

            }

            if (pattern == "severity")
            {
                if (result == "7") result = "INF";
                else if (result == "6") result = "CLR";
                else if (result == "5") result = "WARN";
                else if (result == "4") result = "MIN";
                else if (result == "3") result = "MAJ";
                else if (result == "2") result = "CRT";
                else if (result == "1") result = "ALL";
            }

            return result;
        }

        public string getMD5Hash(string pckt)
        {
            MD5 md5Hasher = MD5.Create();
 
            // Преобразуем входную строку в массив байт и вычисляем хэш
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pckt));
             
            // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
            StringBuilder sBuilder = new StringBuilder();
             
            // Преобразуем каждый байт хэша в шестнадцатеричную строку
            for (int i = 0; i < data.Length; i++)
            {
                //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }





    }
}
