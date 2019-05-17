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
    public class RecirculationChannelTypePropertyThrust : RecirculationChannelTypePropertyBase
    {
        public RecirculationChannelTypePropertyThrust()
            : base()
        {
            InnerRadius = 0.0;
            OuterRadius = 0.0;
        }

        public double InnerRadius
        {
            get;
            set;
        }

        public double OuterRadius
        {
            get;
            set;
        }
    }
}
