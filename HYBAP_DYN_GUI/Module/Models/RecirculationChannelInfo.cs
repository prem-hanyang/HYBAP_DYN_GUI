using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Module.Models
{
    [Serializable]
    public class RecirculationChannelInfo
    {
        private int m_nSelectBearingTypeOfUpper;
        private int m_nSelectBearingTypeOfLower;

        public RecirculationChannelInfo()
        {
        }

        public RecirculationChannelInfo(int nRecirculationChannelInfoNo)
        {
            RecirculationChannelInfoNo = nRecirculationChannelInfoNo;

            RadiusOfRecirculationChannel = 0.0;
            LengthOfRecirculationChannel = 0.0;
            HeightOfRecirculationChannel = 0.0;

            SelectBearingTypeOfUpper = 1;
            SelectBearingTypeOfLower = 1;
        }

        public int RecirculationChannelInfoNo
        {
            get;
            set;
        }

        public double RadiusOfRecirculationChannel
        {
            get;
            set;
        }
        public double LengthOfRecirculationChannel
        {
            get;
            set;
        }
        public double HeightOfRecirculationChannel
        {
            get;
            set;
        }

        public int SelectBearingTypeOfUpper
        {
            get { return m_nSelectBearingTypeOfUpper; }
            set
            {
                if (m_nSelectBearingTypeOfUpper == value)
                    return;
                m_nSelectBearingTypeOfUpper = value;
                switch (m_nSelectBearingTypeOfUpper)
                {
                    case 1:
                        Upper = new RecirculationChannelTypePropertyThrust();
                        break;
                    case 2:
                        Upper = new RecirculationChannelTypePropertyJournal();
                        break;
                }
            }
        }

        public RecirculationChannelTypePropertyBase Upper
        {
            get;
            set;
        }

        public int SelectBearingTypeOfLower
        {
            get { return m_nSelectBearingTypeOfLower; }
            set
            {
                if (m_nSelectBearingTypeOfLower == value)
                    return;
                m_nSelectBearingTypeOfLower = value;
                switch (m_nSelectBearingTypeOfLower)
                {
                    case 1:
                        Lower  = new RecirculationChannelTypePropertyThrust();
                        break;
                    case 2:
                        Lower = new RecirculationChannelTypePropertyJournal();
                        break;
                }
            }
        }

        public RecirculationChannelTypePropertyBase Lower
        {
            get;
            set;
        }
    }
}
