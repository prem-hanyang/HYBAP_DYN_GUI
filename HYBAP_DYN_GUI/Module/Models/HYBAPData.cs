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
    public class HYBAPData
    {
        public HYBAPData()
        {
            Main = new MainData();
        }

        public MainData Main
        {
            get;
            set;
        }
    }
}
