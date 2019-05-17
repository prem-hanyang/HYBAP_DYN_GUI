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
    public class DYNData
    {
        public DYNData()
        {
            MassMBW = 0;
            RadialDistanceMBWFromCenterLine = 0;
            AxialDistanceMBWFromMC = 0;
            AxialDistanceMBWFromRotorBottom = 0;
            MassSBW = 0;
            RadialDistanceSBWFromCenterLine = 0;
            AxialDistanceSBWFromMC = 0;
            AxialDistanceSBWFromRotorTop = 0;

            MassRotor = 0;
            DensityOfShaft = 0;
            ElasticModulusPart1 = 0;
            ElasticModulusPart2 = 0;
            ElasticModulusPart3 = 0;
            ElasticModulusPart4 = 0;
            ElasticModulusRotor = 0;
            PoissonRatioOfShaft = 0;
            ShearModulusOfRotor = 0;
            RadiusPart1 = 0;
            RadiusPart2 = 0;
            RadiusPart3 = 0;
            RadiusPart4 = 0;
            RadiusRotor = 0;
            LengthPart1 = 0;
            LengthPart2 = 0;
            LengthPart3 = 0;
            LengthPart4 = 0;
            AxialDistanceMCFromShaftBottom = 0;
            AxialDistanceMCFromShaftTop = 0;
            ECCFromCenterToPart2 = 0;
            MassMomentInertiaX = 0;
            MassMomentInertiaY = 0;
            MassMomentInertiaZ = 0;
        }

        public double MassMBW
        {
            get;
            set;
        }
        public double RadialDistanceMBWFromCenterLine
        {
            get;
            set;
        }
        public double AxialDistanceMBWFromMC
        {
            get;
            set;
        }
        public double AxialDistanceMBWFromRotorBottom
        {
            get;
            set;
        }
        public double MassSBW
        {
            get;
            set;
        }
        public double RadialDistanceSBWFromCenterLine
        {
            get;
            set;
        }
        public double AxialDistanceSBWFromMC
        {
            get;
            set;
        }
        public double AxialDistanceSBWFromRotorTop
        {
            get;
            set;
        }

        public double MassRotor
        {
            get;
            set;
        }
        public double DensityOfShaft
        {
            get;
            set;
        }
        public double ElasticModulusPart1
        {
            get;
            set;
        }
        public double ElasticModulusPart2
        {
            get;
            set;
        }
        public double ElasticModulusPart3
        {
            get;
            set;
        }
        public double ElasticModulusPart4
        {
            get;
            set;
        }
        public double ElasticModulusRotor
        {
            get;
            set;
        }
        public double PoissonRatioOfShaft
        {
            get;
            set;
        }
        public double ShearModulusOfRotor
        {
            get;
            set;
        }
        public double RadiusPart1
        {
            get;
            set;
        }
        public double RadiusPart2
        {
            get;
            set;
        }
        public double RadiusPart3
        {
            get;
            set;
        }
        public double RadiusPart4
        {
            get;
            set;
        }
        public double RadiusRotor
        {
            get;
            set;
        }
        public double LengthPart1
        {
            get;
            set;
        }
        public double LengthPart2
        {
            get;
            set;
        }
        public double LengthPart3
        {
            get;
            set;
        }
        public double LengthPart4
        {
            get;
            set;
        }
        public double AxialDistanceMCFromShaftBottom
        {
            get;
            set;
        }
        public double AxialDistanceMCFromShaftTop
        {
            get;
            set;
        }
        public double ECCFromCenterToPart2
        {
            get;
            set;
        }
        public double MassMomentInertiaX
        {
            get;
            set;
        }
        public double MassMomentInertiaY
        {
            get;
            set;
        }
        public double MassMomentInertiaZ
        {
            get;
            set;
        }

    }
}
