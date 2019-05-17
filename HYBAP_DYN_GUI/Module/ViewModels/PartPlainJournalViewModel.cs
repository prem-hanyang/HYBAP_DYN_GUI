using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartPlainJournalViewModel : PartPropertyViewModel
    {       

        private PartPropertyPlainJournal m_Data;

        public PartPlainJournalViewModel(PartPropertyPlainJournal data)
            : base()
        {
            m_Data = data;
        }

        public PartPropertyPlainJournal Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("RadiusOfJournal");
                base.RaisePropertyChanged("ClearanceOfJournal");
                base.RaisePropertyChanged("LengthCenterLower");
                base.RaisePropertyChanged("LengthCenterUpper");
                base.RaisePropertyChanged("ZCoordinate");
                base.RaisePropertyChanged("ReservoirDepth");
                base.RaisePropertyChanged("EccentricityRatio");
                base.RaisePropertyChanged("NumberOfZDivisionOfLower");
                base.RaisePropertyChanged("NumberOfZDivisionOfUpper");

                base.RaisePropertyChanged("ConnectingPartOfUpper");
                base.RaisePropertyChanged("ConnectingPartOfLower");

                base.RaisePropertyChanged("ConnectingPositionOfUpper");
                base.RaisePropertyChanged("ConnectingPositionOfLower");

                base.RaisePropertyChanged("RoughnessOfRotatingPart");
                base.RaisePropertyChanged("RoughnessOfStationaryPart");
                base.RaisePropertyChanged("RoughnessPattern");
            }
        }


        public double RadiusOfJournal
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadiusOfJournal;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadiusOfJournal)
                    return;

                m_Data.RadiusOfJournal = value;

                base.RaisePropertyChanged("RadiusOfJournal");
            }
        }
        public double ClearanceOfJournal
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ClearanceOfJournal;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ClearanceOfJournal)
                    return;

                m_Data.ClearanceOfJournal = value;

                base.RaisePropertyChanged("ClearanceOfJournal");
            }
        }
        public double LengthCenterLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthCenterLower;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthCenterLower)
                    return;

                m_Data.LengthCenterLower = value;

                base.RaisePropertyChanged("LengthCenterLower");
            }
        }
        public double LengthCenterUpper
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthCenterUpper;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthCenterUpper)
                    return;

                m_Data.LengthCenterUpper = value;

                base.RaisePropertyChanged("LengthCenterUpper");
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
        public double EccentricityRatio
        {
            get
            {
                if (null != m_Data)
                    return m_Data.EccentricityRatio;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.EccentricityRatio)
                    return;

                m_Data.EccentricityRatio = value;

                base.RaisePropertyChanged("EccentricityRatio");
            }
        }
        public int NumberOfZDivisionOfLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfZDivisionOfLower;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfZDivisionOfLower)
                    return;

                m_Data.NumberOfZDivisionOfLower = value;

                base.RaisePropertyChanged("NumberOfZDivisionOfLower");
            }
        }
        public int NumberOfZDivisionOfUpper
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfZDivisionOfUpper;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfZDivisionOfUpper)
                    return;

                m_Data.NumberOfZDivisionOfUpper = value;

                base.RaisePropertyChanged("NumberOfZDivisionOfUpper");
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








