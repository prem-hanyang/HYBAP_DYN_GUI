using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class StaticAndDynamicAnalysisViewModel : BindableBase
    {
        private static StaticAndDynamicAnalysisViewModel g_this;
        public static StaticAndDynamicAnalysisViewModel This
        {
            get { return g_this; }
        }

        private InputData m_Data;

        public StaticAndDynamicAnalysisViewModel()
            : base()
        {
            g_this = this;
            IsBusy = false;
        }

        public InputData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("InternalBoundaryCondition");
                base.RaisePropertyChanged("ToleranceOfReynoldsBC");
                base.RaisePropertyChanged("SelectAnalysisCase");
            }
        }

        public string HeaderInfo
        {
            get { return "Analysis"; }
        }

        public string RootDirectory
        {
            get;
            set;
        }

        private bool m_IsBusy;
        public bool IsBusy
        {
            get { return m_IsBusy; }
            set
            {
                m_IsBusy = value;
                base.RaisePropertyChanged("IsBusy");
            }
        }

        public int InternalBoundaryCondition
        {
            get
            {
                if (null != m_Data)
                    return m_Data.StaticAndDynamicAnalysisData.InternalBoundaryCondition;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.StaticAndDynamicAnalysisData.InternalBoundaryCondition)
                    return;

                m_Data.StaticAndDynamicAnalysisData.InternalBoundaryCondition = value;

                base.RaisePropertyChanged("InternalBoundaryCondition");
            }
        }
        public double ToleranceOfReynoldsBC
        {
            get
            {
                if (null != m_Data)
                    return m_Data.StaticAndDynamicAnalysisData.ToleranceOfReynoldsBC;

                return 1E-12; 
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.StaticAndDynamicAnalysisData.ToleranceOfReynoldsBC)
                    return;

                m_Data.StaticAndDynamicAnalysisData.ToleranceOfReynoldsBC = value;

                base.RaisePropertyChanged("ToleranceOfReynoldsBC");
            }
        }
        public int SelectAnalysisCase
        {
            get
            {
                if (null != m_Data)
                    return m_Data.StaticAndDynamicAnalysisData.SelectAnalysisCase;

                return 0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.StaticAndDynamicAnalysisData.SelectAnalysisCase)
                    return;

                m_Data.StaticAndDynamicAnalysisData.SelectAnalysisCase = value;

                base.RaisePropertyChanged("SelectAnalysisCase");
            }
        }
    }
}