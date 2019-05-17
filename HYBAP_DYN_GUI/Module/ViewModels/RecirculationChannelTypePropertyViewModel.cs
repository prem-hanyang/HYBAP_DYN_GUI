using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public abstract class RecirculationChannelTypePropertyViewModel : BindableBase
    {
        protected RecirculationChannelTypePropertyBase m_Data;

        public RecirculationChannelTypePropertyViewModel()
            : base()
        {
        }

        public int PartNumber
        {
            get
            {
                if (null != m_Data)
                    return m_Data.PartNumber;

                return -1;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.PartNumber)
                    return;

                m_Data.PartNumber = value;

                base.RaisePropertyChanged("PartNumber");
            }
        }

        public double AngularPosition
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AngularPosition;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AngularPosition)
                    return;

                m_Data.AngularPosition = value;

                base.RaisePropertyChanged("AngularPosition");
            }
        }

        public double Dtheta
        {
            get
            {
                if (null != m_Data)
                    return m_Data.Dtheta;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.Dtheta)
                    return;

                m_Data.Dtheta = value;

                base.RaisePropertyChanged("Dtheta");
            }
        }
    }
}
