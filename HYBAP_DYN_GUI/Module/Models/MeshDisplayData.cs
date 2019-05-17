using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Module.Models
{
    public class MeshDisplayData
    {
        public MeshDisplayData()
        {
        }

        public double[] x
        {
            get;
            set;
        }

        public double[] y
        {
            get;
            set;
        }

        public double[] z
        {
            get;
            set;
        }

        public double[] ind
        {
            get;
            set;
        }

        public int Row
        {
            get;
            set;
        }

        public int Column
        {
            get;
            set;
        }
    }
}
