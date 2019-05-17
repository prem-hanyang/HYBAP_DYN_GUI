using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Module.Models
{
    [Serializable]
    public class MainData
    {
        public MainData()
        {
            PartList = new List<Part>();
            DesignParameter = new DesignParameter();
            ResultData = null;
        }

        public int PartCount
        {
            get;
            set;
        }

        public List<Part> PartList
        {
            get;
            set;
        }

        public DesignParameter DesignParameter
        {
            get;
            set;
        }
        
        [XmlIgnore]
        public ResultData ResultData
        {
            get;
            set;
        }
    }
}
