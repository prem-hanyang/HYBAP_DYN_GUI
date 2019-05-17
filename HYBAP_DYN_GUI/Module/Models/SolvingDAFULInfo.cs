using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Models
{
    [Serializable]
    public class DAFULInfo
    {
        public DAFULInfo()
        {
            DLLInterface = false;
            RPM = 0.0;
            NodeCount = new List<int>();
            ElementCount = new List<int>();
            FilmThickness = new List<List<double>>();
            Force = new List<List<double>>();
            Friction = new List<List<double>>();
        }

        public bool DLLInterface
        {
            get;
            set;
        }

        public double RPM
        {
            get;
            set;
        }

        // 1 차원 [PartCount + 1]
        public List<int> NodeCount
        {
            get;
            set;
        }

        // 1 차원 [PartCount + 1]
        public List<int> ElementCount
        {
            get;
            set;
        }

        // FilmThickness -> [part number][node nomber]
        public List<List<double>> FilmThickness
        {
            get;
            set;
        }

        // Force -> [part number][element nomber]
        public List<List<double>> Force
        {
            get;
            set;
        }

        // Friction -> [part number][element nomber]
        public List<List<double>> Friction
        {
            get;
            set;
        }
    }
}
