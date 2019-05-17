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
    public class DAFULData
    {
        public DAFULData()
        {
            RotatingSpeedOfLower = 0;
            RotatingSpeedOfUpper = 0;
            RotatingSpeedOfStep = 1;

            EccentricityOfLower = 0;
            EccentricityOfUpper = 0;
            EccentricityOfStep = 1;

        }

        public double RotatingSpeedOfLower
        {
            get;
            set;
        }
        public double RotatingSpeedOfUpper
        {
            get;
            set;
        }
        public int RotatingSpeedOfStep
        {
            get;
            set;
        }

        public double EccentricityOfLower
        {
            get;
            set;
        }
        public double EccentricityOfUpper
        {
            get;
            set;
        }
        public int EccentricityOfStep
        {
            get;
            set;
        }
    }
}
