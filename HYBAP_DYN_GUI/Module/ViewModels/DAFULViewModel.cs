using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class DAFULViewModel : BindableBase
    {
        private static DAFULViewModel g_this;
        public static DAFULViewModel This
        {
            get { return g_this; }
        }

        private DAFULData m_Data;

        public DAFULViewModel()
            : base()
        {
            g_this = this;
            IsExportBasicInfo_Click = false;
            IsExportStiffnessMapInfo_Click = false;
            ExportBasicInfo_Click = null;
            ExportStiffnessMapInfo_Click = null;
        }

        public DAFULData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("RotatingSpeedOfLower");
                base.RaisePropertyChanged("RotatingSpeedOfUpper");
                base.RaisePropertyChanged("RotatingSpeedOfStep");
                base.RaisePropertyChanged("EccentricityOfLower");
                base.RaisePropertyChanged("EccentricityOfUpper");
                base.RaisePropertyChanged("EccentricityOfStep");
            }
        }

        public string HeaderInfo
        {
            get { return "DAFUL"; }
        }

        public double RotatingSpeedOfLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RotatingSpeedOfLower;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RotatingSpeedOfLower)
                    return;

                m_Data.RotatingSpeedOfLower = value;

                base.RaisePropertyChanged("RotatingSpeedOfLower");
            }
        }
        public double RotatingSpeedOfUpper
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RotatingSpeedOfUpper;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RotatingSpeedOfUpper)
                    return;

                m_Data.RotatingSpeedOfUpper = value;

                base.RaisePropertyChanged("RotatingSpeedOfUpper");
            }
        }
        public int RotatingSpeedOfStep
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RotatingSpeedOfStep;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RotatingSpeedOfStep)
                    return;

                m_Data.RotatingSpeedOfStep = value;

                base.RaisePropertyChanged("RotatingSpeedOfStep");
            }
        }

        public double EccentricityOfLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.EccentricityOfLower;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.EccentricityOfLower)
                    return;

                m_Data.EccentricityOfLower = value;

                base.RaisePropertyChanged("EccentricityOfLower");
            }
        }
        public double EccentricityOfUpper
        {
            get
            {
                if (null != m_Data)
                    return m_Data.EccentricityOfUpper;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.EccentricityOfUpper)
                    return;

                m_Data.EccentricityOfUpper = value;

                base.RaisePropertyChanged("EccentricityOfUpper");
            }
        }
        public int EccentricityOfStep
        {
            get
            {
                if (null != m_Data)
                    return m_Data.EccentricityOfStep;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.EccentricityOfStep)
                    return;

                m_Data.EccentricityOfStep = value;

                base.RaisePropertyChanged("EccentricityOfStep");
            }
        }

        public void OnExportBasicInfo()
        {
            if (null != ExportBasicInfo_Click)
                ExportBasicInfo_Click(null);
        }

        public void OnExportStiffnessMapInfo()
        {
            if (null != ExportStiffnessMapInfo_Click)
                ExportStiffnessMapInfo_Click(null);
        }

        public bool IsExportBasicInfo_Click
        {
            get;
            set;
        }

        public bool IsExportStiffnessMapInfo_Click
        {
            get;
            set;
        }

        public delegate void ButtonClickCommand(object obj);

        public event ButtonClickCommand ExportBasicInfo_Click;
        public event ButtonClickCommand ExportStiffnessMapInfo_Click;
    }
}
