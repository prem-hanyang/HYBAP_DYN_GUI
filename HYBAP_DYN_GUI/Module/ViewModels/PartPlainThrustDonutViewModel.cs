using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartPlainThrustDonutViewModel : PartPropertyViewModel
    {
        private PartPropertyPlainThrustDonut m_Data;

        public PartPlainThrustDonutViewModel(PartPropertyPlainThrustDonut data)
            : base()
        {
            m_Data = data;
        }
        public PartPropertyPlainThrustDonut Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("InnerRadiusOfThrust");
                base.RaisePropertyChanged("OuterRadiusOfThrust");
                base.RaisePropertyChanged("ClearanceOfThrust");
                base.RaisePropertyChanged("ZCoordinate");
                base.RaisePropertyChanged("ReservoirDepth");
                base.RaisePropertyChanged("NumberOfRDivision");

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

        public int NumberOfRDivision
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfRDivision;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfRDivision)
                    return;

                m_Data.NumberOfRDivision = value;

                base.RaisePropertyChanged("NumberOfRDivision");
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

                return 0;
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
