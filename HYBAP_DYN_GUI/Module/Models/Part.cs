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
    public class Part
    {
        private int m_nBearingType;

        public Part()
        {
        }

        public Part(int nPartNo, int nBearingType, int sGrooveLocation, int nPumpingDirection, int nGrooveType)
        {
            PartNo = nPartNo;
            m_nBearingType = nBearingType;
            GrooveLocation = sGrooveLocation;
            PumpingDirection = nPumpingDirection;
            GrooveType = nGrooveType;
        }

        public int PartNo
        {
            get;
            set;
        }

        public int BearingType
        {
            get { return m_nBearingType; }
            set
            {
                if (m_nBearingType == value)
                    return;
                m_nBearingType = value;
                switch (m_nBearingType)
                {
                    case 1:
                        Property = new PartPropertyPlainJournal();
                        break;
                    case 2:
                        Property = new PartPropertyGroovedJournal();
                        break;
                    case 3:
                        Property = new PartPropertyPlainThrustClosedEnd();
                        break;
                    case 4:
                        Property = new PartPropertyGroovedThrustDonut();
                        break;
                    case 5:
                        Property = new PartPropertyPlainThrustDonut();
                        break;
                }
            }
        }

        public int GrooveLocation
        {
            get;
            set;
        }

        public int PumpingDirection
        {
            get;
            set;
        }

        public int GrooveType
        {
            get;
            set;
        }

        public PartPropertyBase Property
        {
            get;
            set;
        }

        [XmlIgnore]
        public MeshDisplayData MeshDisplayData
        {
            get;
            set;
        }

        [XmlIgnore]
        public PressureDisplayData PressureDisplayData
        {
            get;
            set;
        }

        [XmlIgnore]
        public ResultData ResultData
        {
            get;
            set;
        }
    }
}
