using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

/**
 * Конфигурационный класс монитора SNMP Vilcom
 * 
 */
namespace VilcomNetworkMonitor
{
    public class VilcomExcludes
    {
        public string iplist;

        public string filename = "excludes.xml";

        public string oidlist;

        public string valuelist;

        public VilcomExcludes loadFromFile()
        {
            VilcomExcludes self;

            try
            {
                //try to read from file
                XmlSerializer deserializer = new XmlSerializer(typeof(VilcomExcludes));
                TextReader textReader = new StreamReader(@filename);

                self = (VilcomExcludes)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception e)
            {    
                //set do default value
                self = new VilcomExcludes();
                self.iplist = "";
                self.oidlist = "";
                self.valuelist = "";
            }
           
            return self;            
        }

        public void saveToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VilcomExcludes));
            TextWriter textWriter = new StreamWriter(@filename);
            serializer.Serialize(textWriter, this);
            textWriter.Close();
            
        }
        
    }
}
