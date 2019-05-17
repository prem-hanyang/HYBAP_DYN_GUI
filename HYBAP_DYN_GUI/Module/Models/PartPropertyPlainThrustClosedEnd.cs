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
    public class PartPropertyPlainThrustClosedEnd : PartPropertyBase
    {
        public PartPropertyPlainThrustClosedEnd()
            : base()
        {
            OuterRadiusOfThrust = 0.0;
            ClearanceOfThrust = 0.0;
            ZCoordinate = 0.0;
            ReservoirDepth = 0.0;
            NumberOfRDivision = 0;

            ConnectingPartOfUpper = 0;
            ConnectingPositionOfUpper = 0;

            ConnectingPartOfLower = 0;
            ConnectingPositionOfLower = 0;

            RoughnessOfRotatingPart = 0;
            RoughnessOfStationaryPart = 0;
            RoughnessPattern = 1;
        }
        public double OuterRadiusOfThrust
        {
            get;
            set;
        }
        public double ClearanceOfThrust
        {
            get;
            set;
        }
        public double ZCoordinate
        {
            get;
            set;
        }
        public double ReservoirDepth
        {
            get;
            set;
        }
        public int NumberOfRDivision
        {
            get;
            set;
        }

        public int ConnectingPartOfUpper
        {
            get;
            set;
        }
        public int ConnectingPositionOfUpper
        {
            get;
            set;
        }
        public int ConnectingPartOfLower
        {
            get;
            set;
        }        
        public int ConnectingPositionOfLower
        {
            get;
            set;
        }

        public double RoughnessOfRotatingPart
        {
            get;
            set;
        }
        public double RoughnessOfStationaryPart
        {
            get;
            set;
        }
        public double RoughnessPattern
        {
            get;
            set;
        }
    }
}
