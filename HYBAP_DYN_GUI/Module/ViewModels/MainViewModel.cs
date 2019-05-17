using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private static MainViewModel g_this;
        public static MainViewModel This
        {
            get { return g_this; }
        }

        private MainData m_Data;

        public MainViewModel()
            : base()
        {
            g_this = this;
        }

        public MainData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("PartCount");
                base.RaisePropertyChanged("Parts");
                base.RaisePropertyChanged("RotatingSpeed");
                base.RaisePropertyChanged("Viscosity");
                base.RaisePropertyChanged("MisalignmentAngleXaxis");
                base.RaisePropertyChanged("MisalignmentAngleYaxis");
                base.RaisePropertyChanged("NumberOfTotalDivision");
                base.RaisePropertyChanged("CavitationPressure");
                base.RaisePropertyChanged("RecirculationChannelFlag");
            }
        }

        public string HeaderInfo
        {
            get { return "Main"; }
        }
        public int PartCount
        {
            get
            {
                if (null != Data)
                    return Data.PartCount;

                return -1; //초기값
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.PartCount)
                    return;

                Data.PartCount = value;
                int Value = value;
                bool Changed = false;
                while (Data.PartList.Count > Value)
                {
                    Data.PartList.RemoveAt(Data.PartList.Count - 1);
                    Changed = true;
                }
                while (Data.PartList.Count < Value)
                {
                    Data.PartList.Add(new Part() { PartNo = Data.PartList.Count + 1, BearingType = 1, GrooveLocation = 1, PumpingDirection = 1, GrooveType = 1 });
                    Changed = true;
                }

                base.RaisePropertyChanged("PartCount");

                if (Changed)
                    UpdatedPart();
            }
        }
        public void UpdatedPart()
        {
            base.RaisePropertyChanged("Parts");
            PartViewModel.This.RaisePartChanged();
            StaticAndDynamicAnalysisResultViewModel.This.RaisePartChanged();
        }

        public ObservableCollection<Part> Parts
        {
            get
            {
                if (null != Data)
                    return new ObservableCollection<Part>(Data.PartList);

                return null;
            }
        }

        public double RotatingSpeed
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.RotatingSpeed;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.RotatingSpeed)
                    return;

                Data.DesignParameter.RotatingSpeed = value;

                base.RaisePropertyChanged("RotatingSpeed");
            }
        }
        public double Viscosity
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.Viscosity;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.Viscosity)
                    return;

                Data.DesignParameter.Viscosity = value;

                base.RaisePropertyChanged("Viscosity");
            }
        }
        public double MisalignmentAngleXaxis
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.MisalignmentAngleXaxis;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.MisalignmentAngleXaxis)
                    return;

                Data.DesignParameter.MisalignmentAngleXaxis = value;

                base.RaisePropertyChanged("MisalignmentAngleXaxis");
            }
        }
        public double MisalignmentAngleYaxis
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.MisalignmentAngleYaxis;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.MisalignmentAngleYaxis)
                    return;

                Data.DesignParameter.MisalignmentAngleYaxis = value;

                base.RaisePropertyChanged("MisalignmentAngleYaxis");
            }
        }
        public int NumberOfTotalDivision
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.NumberOfTotalDivision;

                return 0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.NumberOfTotalDivision)
                    return;

                Data.DesignParameter.NumberOfTotalDivision = value;

                base.RaisePropertyChanged("NumberOfTotalDivision");
            }
        }
        public double CavitationPressure
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.CavitationPressure;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.CavitationPressure)
                    return;

                Data.DesignParameter.CavitationPressure = value;

                base.RaisePropertyChanged("CavitationPressure");
            }
        }
        public int RecirculationChannelFlag
        {
            get
            {
                if (null != Data)
                    return Data.DesignParameter.RecirculationChannelFlag;

                return 0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.DesignParameter.RecirculationChannelFlag)
                    return;

                Data.DesignParameter.RecirculationChannelFlag = value;

                base.RaisePropertyChanged("RecirculationChannelFlag");
            }
        }
    }
}
