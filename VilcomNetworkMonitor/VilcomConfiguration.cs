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
    public class VilcomConfiguration
    {
        public int port;

        public string filename = "config.xml";

        public string version;

        public string community;

        public VilcomConfiguration loadFromFile()
        {
            VilcomConfiguration self;

            try
            {
                //try to read from file
                XmlSerializer deserializer = new XmlSerializer(typeof(VilcomConfiguration));
                TextReader textReader = new StreamReader(@filename);

                self = (VilcomConfiguration)deserializer.Deserialize(textReader);
                textReader.Close();
            }
            catch (Exception e)
            {    
                //set do default value
                self = new VilcomConfiguration();
                self.port = 162;
                self.version = "v2";
                self.community = "public";
            }
           
            return self;            
        }

        public void saveToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(VilcomConfiguration));
            TextWriter textWriter = new StreamWriter(@filename);
            serializer.Serialize(textWriter, this);
            textWriter.Close();
            
        }
        
    }
}
