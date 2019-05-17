using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Module.Models;

namespace Module.ViewModels
{
    public class DYNViewModel : BindableBase
    {
        private static DYNViewModel g_this;
        public static DYNViewModel This
        {
            get { return g_this; }
        }

        private DYNData m_Data;

        public DYNViewModel()
            : base()
        {
            g_this = this;

        }
        public DYNData Data
        {
            get { return m_Data; }
            set
            {
                m_Data = value;
                base.RaisePropertyChanged("MassMBW");
                base.RaisePropertyChanged("RadialDistanceMBWFromCenterLine");
                base.RaisePropertyChanged("AxialDistanceMBWFromMC");
                base.RaisePropertyChanged("AxialDistanceMBWFromRotorBottom");
                base.RaisePropertyChanged("MassSBW");
                base.RaisePropertyChanged("RadialDistanceSBWFromCenterLine");
                base.RaisePropertyChanged("AxialDistanceSBWFromMC");
                base.RaisePropertyChanged("AxialDistanceSBWFromRotorTop");

                base.RaisePropertyChanged("MassRotor");
                base.RaisePropertyChanged("DensityOfShaft");
                base.RaisePropertyChanged("ElasticModulusPart1");
                base.RaisePropertyChanged("ElasticModulusPart2");
                base.RaisePropertyChanged("ElasticModulusPart3");
                base.RaisePropertyChanged("ElasticModulusPart4");
                base.RaisePropertyChanged("ElasticModulusRotor");
                base.RaisePropertyChanged("PoissonRatioOfShaft");
                base.RaisePropertyChanged("ShearModulusOfRotor");
                base.RaisePropertyChanged("RadiusPart1");
                base.RaisePropertyChanged("RadiusPart2");
                base.RaisePropertyChanged("RadiusPart3");
                base.RaisePropertyChanged("RadiusPart4");
                base.RaisePropertyChanged("RadiusRotor");
                base.RaisePropertyChanged("LengthPart1");
                base.RaisePropertyChanged("LengthPart2");
                base.RaisePropertyChanged("LengthPart3");
                base.RaisePropertyChanged("LengthPart4");
                base.RaisePropertyChanged("AxialDistanceMCFromShaftBottom");
                base.RaisePropertyChanged("AxialDistanceMCFromShaftTop");
                base.RaisePropertyChanged("ECCFromCenterToPart2");
                base.RaisePropertyChanged("MassMomentInertiaX");
                base.RaisePropertyChanged("MassMomentInertiaY");
                base.RaisePropertyChanged("MassMomentInertiaZ");
            }
        }

        public string HeaderInfo
        {
            get { return "DYN"; }
        }

        public double MassMBW
        {
            get
            {
                if (null != m_Data)
                    return m_Data.MassMBW;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.MassMBW)
                    return;

                m_Data.MassMBW = value;

                base.RaisePropertyChanged("MassMBW");
            }
        }
        public double RadialDistanceMBWFromCenterLine
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadialDistanceMBWFromCenterLine;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadialDistanceMBWFromCenterLine)
                    return;

                m_Data.RadialDistanceMBWFromCenterLine = value;

                base.RaisePropertyChanged("RadialDistanceMBWFromCenterLine");
            }
        }
        public double AxialDistanceMBWFromMC
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceMBWFromMC;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceMBWFromMC)
                    return;

                m_Data.AxialDistanceMBWFromMC = value;

                base.RaisePropertyChanged("AxialDistanceMBWFromMC");
            }
        }
        public double AxialDistanceMBWFromRotorBottom
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceMBWFromRotorBottom;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceMBWFromRotorBottom)
                    return;

                m_Data.AxialDistanceMBWFromRotorBottom = value;

                base.RaisePropertyChanged("AxialDistanceMBWFromRotorBottom");
            }
        }
        public double MassSBW
        {
            get
            {
                if (null != m_Data)
                    return m_Data.MassSBW;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.MassSBW)
                    return;

                m_Data.MassSBW = value;

                base.RaisePropertyChanged("MassSBW");
            }
        }
        public double RadialDistanceSBWFromCenterLine
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadialDistanceSBWFromCenterLine;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadialDistanceSBWFromCenterLine)
                    return;

                m_Data.RadialDistanceSBWFromCenterLine = value;

                base.RaisePropertyChanged("RadialDistanceSBWFromCenterLine");
            }
        }
        public double AxialDistanceSBWFromMC
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceSBWFromMC;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceSBWFromMC)
                    return;

                m_Data.AxialDistanceSBWFromMC = value;

                base.RaisePropertyChanged("AxialDistanceSBWFromMC");
            }
        }
        public double AxialDistanceSBWFromRotorTop
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceSBWFromRotorTop;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceSBWFromRotorTop)
                    return;

                m_Data.AxialDistanceSBWFromRotorTop = value;

                base.RaisePropertyChanged("AxialDistanceSBWFromRotorTop");
            }
        }
        public double MassRotor
        {
            get
            {
                if (null != m_Data)
                    return m_Data.MassRotor;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.MassRotor)
                    return;

                m_Data.MassRotor = value;

                base.RaisePropertyChanged("MassRotor");
            }
        }
        public double DensityOfShaft
        {
            get
            {
                if (null != m_Data)
                    return m_Data.DensityOfShaft;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.DensityOfShaft)
                    return;

                m_Data.DensityOfShaft = value;

                base.RaisePropertyChanged("DensityOfShaft");
            }
        }
        public double ElasticModulusPart1
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ElasticModulusPart1;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ElasticModulusPart1)
                    return;

                m_Data.ElasticModulusPart1 = value;

                base.RaisePropertyChanged("ElasticModulusPart1");
            }
        }
        public double ElasticModulusPart2
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ElasticModulusPart2;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ElasticModulusPart2)
                    return;

                m_Data.ElasticModulusPart2 = value;

                base.RaisePropertyChanged("ElasticModulusPart2");
            }
        }
        public double ElasticModulusPart3
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ElasticModulusPart3;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ElasticModulusPart3)
                    return;

                m_Data.ElasticModulusPart3 = value;

                base.RaisePropertyChanged("ElasticModulusPart3");
            }
        }
        public double ElasticModulusPart4
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ElasticModulusPart4;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ElasticModulusPart4)
                    return;

                m_Data.ElasticModulusPart4 = value;

                base.RaisePropertyChanged("ElasticModulusPart4");
            }
        }
        public double ElasticModulusRotor
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ElasticModulusRotor;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ElasticModulusRotor)
                    return;

                m_Data.ElasticModulusRotor = value;

                base.RaisePropertyChanged("ElasticModulusRotor");
            }
        }
        public double PoissonRatioOfShaft
        {
            get
            {
                if (null != m_Data)
                    return m_Data.PoissonRatioOfShaft;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.PoissonRatioOfShaft)
                    return;

                m_Data.PoissonRatioOfShaft = value;

                base.RaisePropertyChanged("PoissonRatioOfShaft");
            }
        }
        public double ShearModulusOfRotor
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ShearModulusOfRotor;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ShearModulusOfRotor)
                    return;

                m_Data.ShearModulusOfRotor = value;

                base.RaisePropertyChanged("ShearModulusOfRotor");
            }
        }
        public double RadiusPart1
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadiusPart1;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadiusPart1)
                    return;

                m_Data.RadiusPart1 = value;

                base.RaisePropertyChanged("RadiusPart1");
            }
        }
        public double RadiusPart2
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadiusPart2;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadiusPart2)
                    return;

                m_Data.RadiusPart2 = value;

                base.RaisePropertyChanged("RadiusPart2");
            }
        }
        public double RadiusPart3
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadiusPart3;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadiusPart3)
                    return;

                m_Data.RadiusPart3 = value;

                base.RaisePropertyChanged("RadiusPart3");
            }
        }
        public double RadiusPart4
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadiusPart4;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadiusPart4)
                    return;

                m_Data.RadiusPart4 = value;

                base.RaisePropertyChanged("RadiusPart4");
            }
        }
        public double RadiusRotor
        {
            get
            {
                if (null != m_Data)
                    return m_Data.RadiusRotor;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.RadiusRotor)
                    return;

                m_Data.RadiusRotor = value;

                base.RaisePropertyChanged("RadiusRotor");
            }
        }
        public double LengthPart1
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthPart1;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthPart1)
                    return;

                m_Data.LengthPart1 = value;

                base.RaisePropertyChanged("LengthPart1");
            }
        }
        public double LengthPart2
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthPart2;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthPart2)
                    return;

                m_Data.LengthPart2 = value;

                base.RaisePropertyChanged("LengthPart2");
            }
        }
        public double LengthPart3
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthPart3;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthPart3)
                    return;

                m_Data.LengthPart3 = value;

                base.RaisePropertyChanged("LengthPart3");
            }
        }
        public double LengthPart4
        {
            get
            {
                if (null != m_Data)
                    return m_Data.LengthPart4;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.LengthPart4)
                    return;

                m_Data.LengthPart4 = value;

                base.RaisePropertyChanged("LengthPart4");
            }
        }
        public double AxialDistanceMCFromShaftBottom
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceMCFromShaftBottom;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceMCFromShaftBottom)
                    return;

                m_Data.AxialDistanceMCFromShaftBottom = value;

                base.RaisePropertyChanged("AxialDistanceMCFromShaftBottom");
            }
        }
        public double AxialDistanceMCFromShaftTop
        {
            get
            {
                if (null != m_Data)
                    return m_Data.AxialDistanceMCFromShaftTop;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.AxialDistanceMCFromShaftTop)
                    return;

                m_Data.AxialDistanceMCFromShaftTop = value;

                base.RaisePropertyChanged("AxialDistanceMCFromShaftTop");
            }
        }
        public double ECCFromCenterToPart2
        {
            get
            {
                if (null != m_Data)
                    return m_Data.ECCFromCenterToPart2;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.ECCFromCenterToPart2)
                    return;

                m_Data.ECCFromCenterToPart2 = value;

                base.RaisePropertyChanged("ECCFromCenterToPart2");
            }
        }
        public double MassMomentInertiaX
        {
            get
            {
                if (null != m_Data)
                    return m_Data.MassMomentInertiaX;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.MassMomentInertiaX)
                    return;

                m_Data.MassMomentInertiaX = value;

                base.RaisePropertyChanged("MassMomentInertiaX");
            }
        }
        public double MassMomentInertiaY
        {
            get
            {
                if (null != m_Data)
                    return m_Data.MassMomentInertiaY;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.MassMomentInertiaY)
                    return;

                m_Data.MassMomentInertiaY = value;

                base.RaisePropertyChanged("MassMomentInertiaY");
            }
        }
        public double MassMomentInertiaZ
        {
            get
            {
                if (null != m_Data)
                    return m_Data.MassMomentInertiaZ;

                return 0.0;
            }
            set
            {
                if (null == m_Data)
                    return;

                if (value == m_Data.MassMomentInertiaZ)
                    return;

                m_Data.MassMomentInertiaZ = value;

                base.RaisePropertyChanged("MassMomentInertiaZ");
            }
        }

    }
}
