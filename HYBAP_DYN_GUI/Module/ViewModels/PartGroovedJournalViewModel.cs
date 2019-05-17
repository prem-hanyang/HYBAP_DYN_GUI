using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartGroovedJournalViewModel : PartPropertyViewModel
    {
        private PartPropertyGroovedJournal m_Data;

        public PartGroovedJournalViewModel(PartPropertyGroovedJournal data)
            : base()
        {
            m_Data = data;
        }
        public PartPropertyGroovedJournal Data
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
                base.RaisePropertyChanged("NumberOfGrooves");
                base.RaisePropertyChanged("GrooveAngle");
                base.RaisePropertyChanged("GrooveDepth");
                base.RaisePropertyChanged("RatioOfGrooveToRidge");
                base.RaisePropertyChanged("EccentricityRatio");
                base.RaisePropertyChanged("NumberOfZDivisionOfLower");
                base.RaisePropertyChanged("NumberOfZDivisionOfUpper");
                base.RaisePropertyChanged("NumberOfXDivisionOfGroove");
                base.RaisePropertyChanged("NumberOfXDivisionOfRidge");

                base.RaisePropertyChanged("NumberOfAdditionalGrooves");
                base.RaisePropertyChanged("LengthOfAdditionalGroove");
                base.RaisePropertyChanged("RatioOfGrooveToRidgeInAdditionalGroove");
                base.RaisePropertyChanged("NumberOfZDivisionOfAdditionalGroove");
                base.RaisePropertyChanged("NumberOfXDivisionOfAdditionalGroove");
                base.RaisePropertyChanged("NumberOfXDivisionOfAdditionalRidge");

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
        public int NumberOfXDivisionOfGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfXDivisionOfGroove;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfXDivisionOfGroove)
                    return;

                m_Data.NumberOfXDivisionOfGroove = value;

                base.RaisePropertyChanged("NumberOfXDivisionOfGroove");
            }
        }
        public int NumberOfXDivisionOfRidge
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfXDivisionOfRidge;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfXDivisionOfRidge)
                    return;

                m_Data.NumberOfXDivisionOfRidge = value;

                base.RaisePropertyChanged("NumberOfXDivisionOfRidge");
            }
        }

        public int NumberOfAdditionalGrooves
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfAdditionalGrooves;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfAdditionalGrooves)
                    return;

                m_Data.NumberOfAdditionalGrooves = value;

                base.RaisePropertyChanged("NumberOfAdditionalGrooves");
            }
        }
        public double LengthOfAdditionalGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthOfAdditionalGroove;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthOfAdditionalGroove)
                    return;

                m_Data.LengthOfAdditionalGroove = value;

                base.RaisePropertyChanged("LengthOfAdditionalGroove");
            }
        }
        public double RatioOfGrooveToRidgeInAdditionalGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RatioOfGrooveToRidgeInAdditionalGroove;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RatioOfGrooveToRidgeInAdditionalGroove)
                    return;

                m_Data.RatioOfGrooveToRidgeInAdditionalGroove = value;

                base.RaisePropertyChanged("RatioOfGrooveToRidgeInAdditionalGroove");
            }
        }
        public int NumberOfZDivisionOfAdditionalGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfZDivisionOfAdditionalGroove;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfZDivisionOfAdditionalGroove)
                    return;

                m_Data.NumberOfZDivisionOfAdditionalGroove = value;

                base.RaisePropertyChanged("NumberOfZDivisionOfAdditionalGroove");
            }
        }
        public int NumberOfXDivisionOfAdditionalGroove
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfXDivisionOfAdditionalGroove;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfXDivisionOfAdditionalGroove)
                    return;

                m_Data.NumberOfXDivisionOfAdditionalGroove = value;

                base.RaisePropertyChanged("NumberOfXDivisionOfAdditionalGroove");
            }
        }
        public int NumberOfXDivisionOfAdditionalRidge
        {
            get
            {
                if (null != m_Data)
                    return m_Data.NumberOfXDivisionOfAdditionalRidge;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.NumberOfXDivisionOfAdditionalRidge)
                    return;

                m_Data.NumberOfXDivisionOfAdditionalRidge = value;

                base.RaisePropertyChanged("NumberOfXDivisionOfAdditionalRidge");
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
