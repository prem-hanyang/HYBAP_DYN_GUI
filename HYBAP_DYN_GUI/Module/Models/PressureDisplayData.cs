using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Module.Models
{
    public class PressureDisplayData
    {
        public PressureDisplayData()
        {
            max = double.NegativeInfinity;
            min = double.PositiveInfinity;
        }

        public double[] p
        {
            get;
            set;
        }

        public double max
        {
            get;
            set;
        }

        public double min
        {
            get;
            set;
        }
    }
}
