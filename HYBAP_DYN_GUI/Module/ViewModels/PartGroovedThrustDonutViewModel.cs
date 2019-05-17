using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartGroovedThrustDonutViewModel : PartPropertyViewModel
    {
        private PartPropertyGroovedThrustDonut m_Data;

        public PartGroovedThrustDonutViewModel(PartPropertyGroovedThrustDonut data)
            : base()
        {
            m_Data = data;
        }
        public PartPropertyGroovedThrustDonut Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("InnerRadiusOfThrust");
                base.RaisePropertyChanged("CenterRadiusOfThrust");
                base.RaisePropertyChanged("OuterRadiusOfThrust");
                base.RaisePropertyChanged("ClearanceOfThrust");
                base.RaisePropertyChanged("ZCoordinate");
                base.RaisePropertyChanged("NumberOfGrooves");
                base.RaisePropertyChanged("GrooveAngle");
                base.RaisePropertyChanged("GrooveDepth");
                base.RaisePropertyChanged("ReservoirDepth");
                base.RaisePropertyChanged("RatioOfGrooveToRidge");
                base.RaisePropertyChanged("NumberOfRDivisionOfInnerGroove");
                base.RaisePropertyChanged("NumberOfRDivisionOfOuterGroove");
                base.RaisePropertyChanged("NumberOfThetaDivisionOfGroove");
                base.RaisePropertyChanged("NumberOfThetaDivisionOfRidge");

                base.RaisePropertyChanged("WidthOfInnerPlain");
                base.RaisePropertyChanged("WidthOfOuterPlain");
                base.RaisePropertyChanged("NumberOfRDivisionOfInnerPlain");
                base.RaisePropertyChanged("NumberOfRDivisionOfOuterPlain");
                base.RaisePropertyChanged("DepthOfInnerPlain");
                base.RaisePropertyChanged("DepthOfOuterPlain");

                base.RaisePropertyChanged("ConnectingPartOfUpper");
                base.RaisePropertyChanged("ConnectingPartOfLower");

                base.RaisePropertyChanged("ConnectingPositionOfUpper");
                base.RaisePropertyChanged("ConnectingPositionOfLower");

                base.RaisePropertyChanged("RoughnessOfRotatingPart");
                base.RaisePropertyChanged("RoughnessOfStationaryPart");
                base.RaisePropertyChanged("RoughnessPattern");
            }
        }
                   
        public double InnerRadiusOfThrust
        {
            get
            {
                if (null != m_Data)
                    return m_Data.InnerRadiusOfThrust;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.InnerRadiusOfThrust)
                    return;

                m_Data.InnerRadiusOfThrust = value;

                base.RaisePropertyChanged("InnerRadiusOfThrust");
            }
        }
        public double CenterRadiusOfThrust
        {
            get
            {
                if (null != m_Data)
                    return m_Data.CenterRadiusOfThrust;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.CenterRadiusOfThrust)
                    return;

                m_Data.CenterRadiusOfThrust = value;

                base.RaisePropertyChanged("CenterRadiusOfThrust");
            }
        }
        public double OuterRadiusOfThrust
        {
            get
            {
                if (null != m_Data)
                    return m_Data.OuterRadiusOfThrust;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.OuterRadiusOfThrust)
                    return;

                m_Data.OuterRadiusOfThrust = value;

                base.RaisePropertyChanged("OuterRadiusOfThrust");
            }
        }
        public double ClearanceOfThrust
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ClearanceOfThrust;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ClearanceOfThrust)
                    return;

                m_Data.ClearanceOfThrust = value;

                base.RaisePropertyChanged("ClearanceOfThrust");
            }
        }
        public double ZCoordinate
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ZCoordinate;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ZCoordinate)
                    return;

                m_Data.ZCoordinate = value;

                base.RaisePropertyChanged("ZCoordinate");
            }
        }
        public int NumberOfGrooves
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfGrooves;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfGrooves)
                    return;

                m_Data.NumberOfGrooves = value;

                base.RaisePropertyChanged("NumberOfGrooves");
            }
        }
        public double GrooveAngle
        {
            get
            {
                if (null != m_Data)
                    return m_Data.GrooveAngle;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.GrooveAngle)
                    return;

                m_Data.GrooveAngle = value;

                base.RaisePropertyChanged("GrooveAngle");
            }
        }
        public double GrooveDepth
        {
            get
            {
                if (null != m_Data)
                    return m_Data.GrooveDepth;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.GrooveDepth)
                    return;

                m_Data.GrooveDepth = value;

                base.RaisePropertyChanged("GrooveDepth");
            }
        }
        public double ReservoirDepth
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ReservoirDepth;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ReservoirDepth)
                    return;

                m_Data.ReservoirDepth = value;

                base.RaisePropertyChanged("ReservoirDepth");
            }
        }
        public double RatioOfGrooveToRidge
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RatioOfGrooveToRidge;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RatioOfGrooveToRidge)
                    return;

                m_Data.RatioOfGrooveToRidge = value;

                base.RaisePropertyChanged("RatioOfGrooveToRidge");
            }
        }
        public int NumberOfRDivisionOfInnerGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfRDivisionOfInnerGroove;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfRDivisionOfInnerGroove)
                    return;

                m_Data.NumberOfRDivisionOfInnerGroove = value;

                base.RaisePropertyChanged("NumberOfRDivisionOfInnerGroove");
            }
        }
        public int NumberOfRDivisionOfOuterGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfRDivisionOfOuterGroove;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfRDivisionOfOuterGroove)
                    return;

                m_Data.NumberOfRDivisionOfOuterGroove = value;

                base.RaisePropertyChanged("NumberOfRDivisionOfOuterGroove");
            }
        }
        public int NumberOfThetaDivisionOfGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfThetaDivisionOfGroove;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfThetaDivisionOfGroove)
                    return;

                m_Data.NumberOfThetaDivisionOfGroove = value;

                base.RaisePropertyChanged("NumberOfThetaDivisionOfGroove");
            }
        }
        public int NumberOfThetaDivisionOfRidge
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfThetaDivisionOfRidge;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfThetaDivisionOfRidge)
                    return;

                m_Data.NumberOfThetaDivisionOfRidge = value;

                base.RaisePropertyChanged("NumberOfThetaDivisionOfRidge");
            }
        }

        public double WidthOfInnerPlain
        {
            get
            {
                if (null != m_Data)
                    return m_Data.WidthOfInnerPlain;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.WidthOfInnerPlain)
                    return;

                m_Data.WidthOfInnerPlain = value;

                base.RaisePropertyChanged("WidthOfInnerPlain");
            }
        }
        public double WidthOfOuterPlain
        {
            get
            {
                if (null != m_Data)
                    return m_Data.WidthOfOuterPlain;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.WidthOfOuterPlain)
                    return;

                m_Data.WidthOfOuterPlain = value;

                base.RaisePropertyChanged("WidthOfOuterPlain");
            }
        }        
        public double DepthOfInnerPlain
        {
            get
            {
                if (null != m_Data)
                    return m_Data.DepthOfInnerPlain;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.DepthOfInnerPlain)
                    return;

                m_Data.DepthOfInnerPlain = value;

                base.RaisePropertyChanged("DepthOfInnerPlain");
            }
        }
        public double DepthOfOuterPlain
        {
            get
            {
                if (null != m_Data)
                    return m_Data.DepthOfOuterPlain;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.DepthOfOuterPlain)
                    return;

                m_Data.DepthOfOuterPlain = value;

                base.RaisePropertyChanged("DepthOfOuterPlain");
            }
        }
        public int NumberOfRDivisionOfInnerPlain
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfRDivisionOfInnerPlain;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfRDivisionOfInnerPlain)
                    return;

                m_Data.NumberOfRDivisionOfInnerPlain = value;

                base.RaisePropertyChanged("NumberOfRDivisionOfInnerPlain");
            }
        }
        public int NumberOfRDivisionOfOuterPlain
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfRDivisionOfOuterPlain;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfRDivisionOfOuterPlain)
                    return;

                m_Data.NumberOfRDivisionOfOuterPlain = value;

                base.RaisePropertyChanged("NumberOfRDivisionOfOuterPlain");
            }
        }

        public int ConnectingPartOfUpper
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ConnectingPartOfUpper;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ConnectingPartOfUpper)
                    return;

                m_Data.ConnectingPartOfUpper = value;

                base.RaisePropertyChanged("ConnectingPartOfUpper");
            }
        }
        public int ConnectingPartOfLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ConnectingPartOfLower;

                return 1;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ConnectingPartOfLower)
                    return;

                m_Data.ConnectingPartOfLower = value;

                base.RaisePropertyChanged("ConnectingPartOfLower");
            }
        }
        public int ConnectingPositionOfUpper
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ConnectingPositionOfUpper;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ConnectingPositionOfUpper)
                    return;

                m_Data.ConnectingPositionOfUpper = value;

                base.RaisePropertyChanged("ConnectingPositionOfUpper");
            }
        }
        public int ConnectingPositionOfLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ConnectingPositionOfLower;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ConnectingPositionOfLower)
                    return;

                m_Data.ConnectingPositionOfLower = value;

                base.RaisePropertyChanged("ConnectingPositionOfLower");
            }
        }
        public double RoughnessOfRotatingPart
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RoughnessOfRotatingPart;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RoughnessOfRotatingPart)
                    return;

                m_Data.RoughnessOfRotatingPart = value;

                base.RaisePropertyChanged("RoughnessOfRotatingPart");
            }
        }
        public double RoughnessOfStationaryPart
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RoughnessOfStationaryPart;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RoughnessOfStationaryPart)
                    return;

                m_Data.RoughnessOfStationaryPart = value;

                base.RaisePropertyChanged("RoughnessOfStationaryPart");
            }
        }
        public double RoughnessPattern
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RoughnessPattern;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RoughnessPattern)
                    return;

                m_Data.RoughnessPattern = value;

                base.RaisePropertyChanged("RoughnessPattern");
            }
        }
    }
}
