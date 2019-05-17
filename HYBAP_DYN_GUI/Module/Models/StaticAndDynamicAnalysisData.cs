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
    public class StaticAndDynamicAnalysisData
    {
        public StaticAndDynamicAnalysisData()
        {
            InternalBoundaryCondition = 1;
            ToleranceOfReynoldsBC = 1E-12;
            SelectAnalysisCase = 1;
        }

        public int InternalBoundaryCondition
        {
            get;
            set;
        }
        public double ToleranceOfReynoldsBC
        {
            get;
            set;
        }
        public int SelectAnalysisCase
        {
            get;
            set;
        }
    }
}
