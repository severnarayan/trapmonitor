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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using SnmpSharpNet;

namespace VilcomNetworkMonitor
{
    [Serializable]
    public class TrapList
    {
        public List<Trap> dataList = new List<Trap>();

        public string filename = "state.data";

        //добавляет трап в список
        public void addTrap(Trap trapObject)
        {
            dataList.Add(trapObject);
        }

        //возвращает трап из списка по его айди
        public Trap getTrapById(string tid)
        {
            
            foreach (Trap tmpTrap in dataList)
            {
                if (tmpTrap.trapID == tid)
                {
                    return tmpTrap;
                }
            }
                    

            return dataList[0];
           
        }

        public void saveToFile()
        {
            FileStream fs = new FileStream(@filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();

            //сериализация
            bf.Serialize(fs, dataList);
            fs.Close();
        }

        public void loadFromFile()
        {
            FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter bf = new BinaryFormatter();
            dataList = (List<Trap>)bf.Deserialize(fs);
            fs.Close();

            //loadedParser = (Parser)deserializer.Deserialize(textReader);
            //ruleList = loadedParser.ruleList;
            //textReader.Close();
        }




    }
}
