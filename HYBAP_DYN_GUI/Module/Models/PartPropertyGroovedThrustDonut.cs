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
    public class PartPropertyGroovedThrustDonut : PartPropertyBase
    {
        public PartPropertyGroovedThrustDonut()
            : base()
        {
            InnerRadiusOfThrust = 0.0;
            CenterRadiusOfThrust = 0.0;
            OuterRadiusOfThrust = 0.0;
            ClearanceOfThrust = 0.0;
            ZCoordinate = 0.0;
            NumberOfGrooves = 0;
            GrooveAngle = 0.0;
            GrooveDepth = 0.0;
            ReservoirDepth = 0.0;
            RatioOfGrooveToRidge = 0.0;
            NumberOfRDivisionOfInnerGroove = 0;
            NumberOfRDivisionOfOuterGroove = 0;
            NumberOfThetaDivisionOfGroove = 0;
            NumberOfThetaDivisionOfRidge = 0;

            WidthOfInnerPlain = 0.0;
            WidthOfOuterPlain = 0.0;
            DepthOfInnerPlain = 0.0;
            DepthOfOuterPlain = 0.0;
            NumberOfRDivisionOfInnerPlain = 0;
            NumberOfRDivisionOfOuterPlain = 0;

            ConnectingPartOfUpper = 0;
            ConnectingPositionOfUpper = 0;

            ConnectingPartOfLower = 0;
            ConnectingPositionOfLower = 0;

            RoughnessOfRotatingPart = 0;
            RoughnessOfStationaryPart = 0;
            RoughnessPattern = 1;
        }
        public double InnerRadiusOfThrust
        {
            get;
            set;
        }
        public double CenterRadiusOfThrust
        {
            get;
            set;
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
        public int NumberOfGrooves
        {
            get;
            set;
        }
        public double GrooveAngle
        {
            get;
            set;
        }
        public double GrooveDepth
        {
            get;
            set;
        }
        public double ReservoirDepth
        {
            get;
            set;
        }
        public double RatioOfGrooveToRidge
        {
            get;
            set;
        }
        public int NumberOfRDivisionOfInnerGroove
        {
            get;
            set;
        }
        public int NumberOfRDivisionOfOuterGroove
        {
            get;
            set;
        }
        public int NumberOfThetaDivisionOfGroove
        {
            get;
            set;
        }
        public int NumberOfThetaDivisionOfRidge
        {
            get;
            set;
        }
        public double WidthOfInnerPlain
        {
            get;
            set;
        }
        public double WidthOfOuterPlain
        {
            get;
            set;
        }
        public double DepthOfInnerPlain
        {
            get;
            set;
        }
        public double DepthOfOuterPlain
        {
            get;
            set;
        }
        public int NumberOfRDivisionOfInnerPlain
        {
            get;
            set;
        }
        public int NumberOfRDivisionOfOuterPlain
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
