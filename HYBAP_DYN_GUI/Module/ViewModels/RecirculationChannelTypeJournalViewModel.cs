using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class RecirculationChannelTypeJournalViewModel : RecirculationChannelTypePropertyViewModel
    {
        public RecirculationChannelTypeJournalViewModel(RecirculationChannelTypePropertyJournal data)
            : base()
        {
            m_Data = data;
        }

        public RecirculationChannelTypePropertyJournal Data
        {
            get { return m_Data as RecirculationChannelTypePropertyJournal; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("PartNumber");
                base.RaisePropertyChanged("AngularPosition");
                base.RaisePropertyChanged("Dtheta");
                base.RaisePropertyChanged("ZCoordinateOfLower");
                base.RaisePropertyChanged("ZCoordinateOfUpper");
            }
        }

        public double ZCoordinateOfLower
        {
            get
            {
                if (null != m_Data as RecirculationChannelTypePropertyJournal)
                    return (m_Data as RecirculationChannelTypePropertyJournal).ZCoordinateOfLower;

                return 0.0;
            }
            set
            {
                if (null == m_Data as RecirculationChannelTypePropertyJournal)
                    return;

                if (value == (m_Data as RecirculationChannelTypePropertyJournal).ZCoordinateOfLower)
                    return;

                (m_Data as RecirculationChannelTypePropertyJournal).ZCoordinateOfLower = value;

                base.RaisePropertyChanged("ZCoordinateOfLower");
            }
        }

        public double ZCoordinateOfUpper
        {
            get
            {
                if (null != m_Data as RecirculationChannelTypePropertyJournal)
                    return (m_Data as RecirculationChannelTypePropertyJournal).ZCoordinateOfUpper;

                return 0.0;
            }
            set
            {
                if (null == m_Data as RecirculationChannelTypePropertyJournal)
                    return;

                if (value == (m_Data as RecirculationChannelTypePropertyJournal).ZCoordinateOfUpper)
                    return;

                (m_Data as RecirculationChannelTypePropertyJournal).ZCoordinateOfUpper = value;

                base.RaisePropertyChanged("ZCoordinateOfUpper");
            }
        }
    }
}