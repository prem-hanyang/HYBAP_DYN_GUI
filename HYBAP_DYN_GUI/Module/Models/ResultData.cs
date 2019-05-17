using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Module.Models
{
    public class ResultData
    {
        public ResultData()
        {
            Friction = double.NaN;
            LoadCapacity = double.NaN;
            Stiffness = new double[25];
            Damping = new double[25];
            for (int i = 0; i < 25; ++i)
            {
                Stiffness[i] = double.NaN;
                Damping[i] = double.NaN;
            }
            DynamicResultReady = false;
        }

        public double Friction
        {
            get;
            set;
        }

        public string Friction_string
        {
            get { return Friction.ToString("0.0000e+00"); }
            set { }
        }

        public double LoadCapacity
        {
            get;
            set;
        }

        public string LoadCapacity_string
        {
            get { return LoadCapacity.ToString("0.0000e+00"); }
            set { }
        }

        public double[] Stiffness
        {
            get;
            set;
        }

        public double[] Damping
        {
            get;
            set;
        }

        public bool DynamicResultReady
        {
            get;
            set;
        }
    }
}
