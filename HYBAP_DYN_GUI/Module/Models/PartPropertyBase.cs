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
    [XmlInclude(typeof(PartPropertyPlainJournal))]
    [XmlInclude(typeof(PartPropertyGroovedJournal))]
    [XmlInclude(typeof(PartPropertyPlainThrustClosedEnd))]
    [XmlInclude(typeof(PartPropertyGroovedThrustDonut))]
    [XmlInclude(typeof(PartPropertyPlainThrustDonut))]
    public abstract class PartPropertyBase
    {
        public PartPropertyBase()
        {
        }
    }
}
