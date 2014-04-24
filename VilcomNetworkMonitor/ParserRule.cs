using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VilcomNetworkMonitor
{
    [Serializable]
    public class ParserRule
    {
        public string oid = "";
        public string name = "";
        public string param = "";
        public string textPattern = "";

        public ParserRule(string oidValue, string nameValue, string nameParam, string nameTextPattern)
        {
            oid = oidValue;
            name = nameValue;
            param = nameParam;
            textPattern = nameTextPattern;
        }
    }
}
