using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class PartResultViewModel : BindableBase
    {
        private ResultData m_Data;

        public PartResultViewModel(ResultData data)
            : base()
        {
            m_Data = data;
        }
        public ResultData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("Friction");
                base.RaisePropertyChanged("LoadCapacity");
                base.RaisePropertyChanged("Stiffness");
                base.RaisePropertyChanged("Damping");
            }
        }

        public double Friction
        {
            get
            {
                if (null != m_Data)
                    return m_Data.Friction;

                return double.NaN;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.Friction)
                    return;

                m_Data.Friction = value;

                base.RaisePropertyChanged("Friction");
            }
        }

        public double LoadCapacity
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LoadCapacity;

                return double.NaN;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LoadCapacity)
                    return;

                m_Data.LoadCapacity = value;

                base.RaisePropertyChanged("LoadCapacity");
            }
        }

        public double[] Stiffness
        {
            get
            {
                if (null != m_Data)
                    return m_Data.Stiffness;

                return null;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.Stiffness)
                    return;

                m_Data.Stiffness = value;

                base.RaisePropertyChanged("Stiffness");
            }
        }

        public double[] Damping
        {
            get
            {
                if (null != m_Data)
                    return m_Data.Damping;

                return null;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.Damping)
                    return;

                m_Data.Damping = value;

                base.RaisePropertyChanged("Damping");
            }
        }
    }
}
