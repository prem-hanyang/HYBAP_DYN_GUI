using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Module
{
    [Serializable]
    public class RecirculationChannelTypePropertyJournal : RecirculationChannelTypePropertyBase
    {
        public RecirculationChannelTypePropertyJournal()
            : base()
        {
            ZCoordinateOfLower = 0.0;
            ZCoordinateOfUpper = 0.0;
        }

        public double ZCoordinateOfLower
        {
            get;
            set;
        }

        public double ZCoordinateOfUpper
        {
            get;
            set;
        }
    }
}
