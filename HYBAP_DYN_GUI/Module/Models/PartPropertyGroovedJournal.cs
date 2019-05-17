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
    public class PartPropertyGroovedJournal : PartPropertyBase
    {
        public PartPropertyGroovedJournal()
            : base()
        {
            RadiusOfJournal = 0.0;
            ClearanceOfJournal = 0.0;
            LengthCenterLower = 0.0;
            LengthCenterUpper = 0.0;
            ZCoordinate = 0.0;
            NumberOfGrooves = 0;
            GrooveAngle = 0.0;
            GrooveDepth = 0.0;
            RatioOfGrooveToRidge = 0.0;
            EccentricityRatio = 0.0;
            NumberOfZDivisionOfLower = 0;
            NumberOfZDivisionOfUpper = 0;
            NumberOfXDivisionOfGroove = 0;
            NumberOfXDivisionOfRidge = 0;

            NumberOfAdditionalGrooves = 0;
            LengthOfAdditionalGroove = 0.0;
            RatioOfGrooveToRidgeInAdditionalGroove = 0.0;
            NumberOfZDivisionOfAdditionalGroove = 0;
            NumberOfXDivisionOfAdditionalGroove = 0;
            NumberOfXDivisionOfAdditionalRidge = 0;

            ConnectingPartOfUpper = 0;
            ConnectingPositionOfUpper = 0;
            
            ConnectingPartOfLower = 0;
            ConnectingPositionOfLower = 0;
            
            RoughnessOfRotatingPart = 0;
            RoughnessOfStationaryPart = 0;
            RoughnessPattern = 1;
        }
        public double RadiusOfJournal
        {
            get;
            set;
        }
        public double ClearanceOfJournal
        {
            get;
            set;
        }
        public double LengthCenterLower
        {
            get;
            set;
        }
        public double LengthCenterUpper
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
        public double RatioOfGrooveToRidge
        {
            get;
            set;
        }
        public double EccentricityRatio
        {
            get;
            set;
        }
        public int NumberOfZDivisionOfLower
        {
            get;
            set;
        }
        public int NumberOfZDivisionOfUpper
        {
            get;
            set;
        }
        public int NumberOfXDivisionOfGroove
        {
            get;
            set;
        }
        public int NumberOfXDivisionOfRidge
        {
            get;
            set;
        }

        public int NumberOfAdditionalGrooves
        {
            get;
            set;
        }
        public double LengthOfAdditionalGroove
        {
            get;
            set;
        }
        public double RatioOfGrooveToRidgeInAdditionalGroove
        {
            get;
            set;
        }
        public int NumberOfZDivisionOfAdditionalGroove
        {
            get;
            set;
        }
        public int NumberOfXDivisionOfAdditionalGroove
        {
            get;
            set;
        }
        public int NumberOfXDivisionOfAdditionalRidge
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
