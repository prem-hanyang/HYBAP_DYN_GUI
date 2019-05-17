using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Module.Models
{
    [Serializable]
    public class DesignParameter
    {
        public DesignParameter()
        {
            RotatingSpeed = 1000.0;
            Viscosity = 0.001;
            MisalignmentAngleXaxis=0.0;
            MisalignmentAngleYaxis=0.0;
            NumberOfTotalDivision=100;
            CavitationPressure = 0.0;
            RecirculationChannelFlag = 2;
        }

        public double RotatingSpeed
        {
            get;
            set;
        }

        public double Viscosity
        {
            get;
            set;
        }
        public double MisalignmentAngleXaxis
        {
            get;
            set;
        }
        public double MisalignmentAngleYaxis
        {
            get;
            set;
        }
        public int NumberOfTotalDivision
        {
            get;
            set;
        }
        public double CavitationPressure
        {
            get;
            set;
        }
        public int RecirculationChannelFlag
        {
            get;
            set;
        }
    }
}
