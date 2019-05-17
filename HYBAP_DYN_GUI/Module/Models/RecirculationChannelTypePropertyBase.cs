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
    [XmlInclude(typeof(RecirculationChannelTypePropertyThrust))]
    [XmlInclude(typeof(RecirculationChannelTypePropertyJournal))]
    public abstract class RecirculationChannelTypePropertyBase
    {
        public RecirculationChannelTypePropertyBase()
        {
            PartNumber = 0;
            AngularPosition = 0.0;
            Dtheta = 0.0;
        }

        public int PartNumber
        {
            get;
            set;
        }

        public double AngularPosition
        {
            get;
            set;
        }

        public double Dtheta
        {
            get;
            set;
        }
    }
}
