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
    public class DYNAnalysisData
    {
        public DYNAnalysisData()
        {
            AxialDistanceGasForceFromMC = 0;
            CycleNumber = 0;
            AngleDivision = 0;
            InitialConditionX = 0;
            InitialConditionY = 0;
            InitialConditionTX = 0;
            InitialConditionTY = 0;
            InitialConditionDX = 0;
            InitialConditionDY = 0;
            InitialConditionDTX = 0;
            InitialConditionDTY = 0;
        }

        public double AxialDistanceGasForceFromMC
        {
            get;
            set;
        }
        public double CycleNumber
        {
            get;
            set;
        }
        public double AngleDivision
        {
            get;
            set;
        }
        public double InitialConditionX
        {
            get;
            set;
        }
        public double InitialConditionY
        {
            get;
            set;
        }
        public double InitialConditionTX
        {
            get;
            set;
        }
        public double InitialConditionTY
        {
            get;
            set;
        }
        public double InitialConditionDX
        {
            get;
            set;
        }
        public double InitialConditionDY
        {
            get;
            set;
        }
        public double InitialConditionDTX
        {
            get;
            set;
        }
        public double InitialConditionDTY
        {
            get;
            set;
        }
    }
}
