using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class StaticAndDynamicAnalysisResultViewModel : BindableBase
    {
        private static StaticAndDynamicAnalysisResultViewModel g_this;
        public static StaticAndDynamicAnalysisResultViewModel This
        {
            get { return g_this; }
        }

        private MainData m_Data;

        public StaticAndDynamicAnalysisResultViewModel()
            : base()
        {
            g_this = this;
            ShowTotalStiffness = true;
            ShowTotalDamping = true;
        }

        public MainData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("PartCount");
                base.RaisePropertyChanged("Parts");
            }
        }

        public string HeaderInfo
        {
            get { return "Result"; }
        }

        public int PartCount
        {
            get
            {
                if (null != Data)
                    return Data.PartCount;

                return -1;
            }
            set { }
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

        public void RaisePartChanged()
        {
            base.RaisePropertyChanged("PartCount");
            base.RaisePropertyChanged("Parts");
        }

        public void Refresh()
        {
            base.RaisePropertyChanged("Parts");
            base.RaisePropertyChanged("DynamicResultReady");
            if (false == DynamicResultReady)
            {
                ShowTotalStiffness = true;
                ShowTotalDamping = true;
            }
            ShowTotalStiffness = !m_bShowTotalStiffness;
            ShowTotalStiffness = !m_bShowTotalStiffness;
            ShowTotalDamping = !m_bShowTotalDamping;
            ShowTotalDamping = !m_bShowTotalDamping;
        }

        private bool m_bShowTotalStiffness;
        public bool ShowTotalStiffness
        {
            get { return m_bShowTotalStiffness; }
            set
            {
                m_bShowTotalStiffness = value;
                base.RaisePropertyChanged("ShowTotalStiffness");
            }
        }

        private bool m_bShowTotalDamping;
        public bool ShowTotalDamping
        {
            get { return m_bShowTotalDamping; }
            set
            {
                m_bShowTotalDamping = value;
                base.RaisePropertyChanged("ShowTotalDamping");
            }
        }

        public bool DynamicResultReady
        {
            get
            {
                if (null != Data)
                    return Data.ResultData.DynamicResultReady;
                return false;
            }
            set { }
        }
    }
}
