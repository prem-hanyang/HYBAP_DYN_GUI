using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class RecirculationChannelTypeThrustViewModel : RecirculationChannelTypePropertyViewModel
    {
        public RecirculationChannelTypeThrustViewModel(RecirculationChannelTypePropertyThrust data)
            : base()
        {
            m_Data = data;
        }

        public RecirculationChannelTypePropertyThrust Data
        {
            get { return m_Data as RecirculationChannelTypePropertyThrust; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("PartNumber");
                base.RaisePropertyChanged("AngularPosition");
                base.RaisePropertyChanged("Dtheta");
                base.RaisePropertyChanged("InnerRadius");
                base.RaisePropertyChanged("OuterRadius");
            }
        }

        public double InnerRadius
        {
            get
            {
                if (null != m_Data as RecirculationChannelTypePropertyThrust)
                    return (m_Data as RecirculationChannelTypePropertyThrust).InnerRadius;

                return 0.0;
            }
            set
            {
                if (null == m_Data as RecirculationChannelTypePropertyThrust)
                    return;

                if (value == (m_Data as RecirculationChannelTypePropertyThrust).InnerRadius)
                    return;

                (m_Data as RecirculationChannelTypePropertyThrust).InnerRadius = value;

                base.RaisePropertyChanged("InnerRadius");
            }
        }

        public double OuterRadius
        {
            get
            {
                if (null != m_Data as RecirculationChannelTypePropertyThrust)
                    return (m_Data as RecirculationChannelTypePropertyThrust).OuterRadius;

                return 0.0;
            }
            set
            {
                if (null == m_Data as RecirculationChannelTypePropertyThrust)
                    return;

                if (value == (m_Data as RecirculationChannelTypePropertyThrust).OuterRadius)
                    return;

                (m_Data as RecirculationChannelTypePropertyThrust).OuterRadius = value;

                base.RaisePropertyChanged("OuterRadius");
            }
        }
    }
}