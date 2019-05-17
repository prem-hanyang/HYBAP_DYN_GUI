using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class RecirculationChannelInfoViewModel : BindableBase
    {
        private RecirculationChannelInfo m_Data;

        public RecirculationChannelInfoViewModel(RecirculationChannelInfo data)
            : base()
        {
            m_Data = data;
        }

        public RecirculationChannelInfo Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("RadiusOfRecirculationChannel");
                base.RaisePropertyChanged("LengthOfRecirculationChannel");
                base.RaisePropertyChanged("HeightOfRecirculationChannel");
                base.RaisePropertyChanged("SelectBearingTypeOfUpper");
                base.RaisePropertyChanged("SelectBearingTypeOfLower");
            }
        }   

        public string RecirculationChannelInfoNo
        {
            get
            {
                if (null != Data)
                    return string.Format("Channel{0:D2}", Data.RecirculationChannelInfoNo);

                return string.Empty;
            }
        }

        public double RadiusOfRecirculationChannel
        {
            get
            {
                if (null != Data)
                    return Data.RadiusOfRecirculationChannel;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.RadiusOfRecirculationChannel)
                    return;

                Data.RadiusOfRecirculationChannel = value;

                base.RaisePropertyChanged("RadiusOfRecirculationChannel");
            }
        }

        public double LengthOfRecirculationChannel
        {
            get
            {
                if (null != Data)
                    return Data.LengthOfRecirculationChannel;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.LengthOfRecirculationChannel)
                    return;

                Data.LengthOfRecirculationChannel = value;

                base.RaisePropertyChanged("LengthOfRecirculationChannel");
            }
        }

        public double HeightOfRecirculationChannel
        {
            get
            {
                if (null != Data)
                    return Data.HeightOfRecirculationChannel;

                return 0.0;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.HeightOfRecirculationChannel)
                    return;

                Data.HeightOfRecirculationChannel = value;

                base.RaisePropertyChanged("HeightOfRecirculationChannel");
            }
        }

        public int SelectBearingTypeOfUpper
        {
            get
            {
                if (null != Data)
                    return Data.SelectBearingTypeOfUpper;

                return 1;
            }
            set
            {
                if (null == Data)
                    return;

                if (value == Data.SelectBearingTypeOfUpper)
                    return;

                Data.SelectBearingTypeOfUpper = value;

                base.RaisePropertyChanged("Upper");
                base.RaisePropertyChanged("SelectBearingTypeOfUpper");
            }
        }

        public RecirculationChannelTypePropertyViewModel Upper
        {
            get
            {
                if (null != Data)
                {
                    if (1 == SelectBearingTypeOfUpper)
                        return new RecirculationChannelTypeThrustViewModel(Data.Upper as RecirculationChannelTypePropertyThrust);
                    else if (2 == SelectBearingTypeOfUpper)
                        return new RecirculationChannelTypeJournalViewModel(Data.Upper as RecirculationChannelTypePropertyJournal);
                }

                return null;
            }
        }

        public int SelectBearingTypeOfLower
        {
            get
            {
                if (null != m_Data)
                    return m_Data.SelectBearingTypeOfLower;

                return 1;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.SelectBearingTypeOfLower)
                    return;

                m_Data.SelectBearingTypeOfLower = value;

                base.RaisePropertyChanged("Lower");
                base.RaisePropertyChanged("SelectBearingTypeOfLower");
            }
        }

        public RecirculationChannelTypePropertyViewModel Lower
        {
            get
            {
                if (null != Data)
                {
                    if (1 == SelectBearingTypeOfLower)
                        return new RecirculationChannelTypeThrustViewModel(Data.Lower as RecirculationChannelTypePropertyThrust);
                    else if (2 == SelectBearingTypeOfLower)
                        return new RecirculationChannelTypeJournalViewModel(Data.Lower as RecirculationChannelTypePropertyJournal);
                }

                return null;
            }
        }
    }
}
