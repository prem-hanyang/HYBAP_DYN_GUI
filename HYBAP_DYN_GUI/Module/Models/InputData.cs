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
    public class InputData
    {
        public InputData()
        {
            MainData = new MainData();
            RecirculationChannelData = new RecirculationChannelData();
            DYNData = new DYNData();
            DYNAnalysisData = new DYNAnalysisData();
            StaticAndDynamicAnalysisData = new StaticAndDynamicAnalysisData();
            DAFULData = new DAFULData();
        }

        public MainData MainData
        {
            get;
            set;
        }

        public RecirculationChannelData RecirculationChannelData
        {
            get;
            set;
        }

        public DYNData DYNData
        {
            get;
            set;
        }

        public DYNAnalysisData DYNAnalysisData
        {
            get;
            set;
        }
                
        public StaticAndDynamicAnalysisData StaticAndDynamicAnalysisData
        {
            get;
            set;
        }

        public DAFULData DAFULData
        {
            get;
            set;
        }
    }
}
