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
    public class RecirculationChannelData
    {
        public RecirculationChannelData()
        {
            Density = 1000.0;
            NumberOfRecirculationChannel = 0;
            SelectRecirculationChannel = -1;
            RecirculationChannelInfoList = new List<RecirculationChannelInfo>();
        }

        public double Density
        {
            get;
            set;
        }
        
        public int NumberOfRecirculationChannel
        {
            get;
            set;
        }
        
        public int SelectRecirculationChannel
        {
            get;
            set;
        }
        
        public List<RecirculationChannelInfo> RecirculationChannelInfoList
        {
            get;
            set;
        }
    }
}
