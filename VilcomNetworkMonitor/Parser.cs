using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace VilcomNetworkMonitor
{
    [Serializable]
    public class Parser
    {

        public Parser()
        {

        }

        public Parser loadedParser;

        
        public List<ParserRule> ruleList = new List<ParserRule>();

        public string filename = "parser.data";

        public void addRule(ParserRule rule)
        {
            ruleList.Add(rule);
        }

        public void addRule(string oidValue, string nameValue,string paramValue)
        {            
            ParserRule rule = new ParserRule(oidValue, nameValue,paramValue);
            addRule(rule);
        }

        public void saveToFile()
        {
            FileStream fs = new FileStream(@filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();

            //сериализация
            bf.Serialize(fs, ruleList);
            fs.Close();
        }

        public void loadFromFile()
        {
            FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter bf = new BinaryFormatter();
            ruleList = (List<ParserRule>) bf.Deserialize(fs);
            fs.Close();

            //loadedParser = (Parser)deserializer.Deserialize(textReader);
            //ruleList = loadedParser.ruleList;
            //textReader.Close();
        }
        
    }
}
