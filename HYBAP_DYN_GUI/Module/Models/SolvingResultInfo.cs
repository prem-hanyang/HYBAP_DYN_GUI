using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Models
{
    [Serializable]
    public class Matrix5X5
    {
        public Matrix5X5()
        {
            value = new double[25];
            for (int i = 0; i < 25; ++i)
                value[i] = 0.0;
        }

        public double[] value;
    };

    [Serializable]
    public class ResultInfo
    {
        public ResultInfo()
        {
            Friction = new List<double>();
            LoadCapacity = new List<double>();
            Stiffness = new List<Matrix5X5>();
            Damping = new List<Matrix5X5>();
            Total_Stiffness = new Matrix5X5();
            Total_Damping = new Matrix5X5();
            Total_Friction = 0.0;
        }

        public List<double> Friction
        {
            get;
            set;
        }

        public List<double> LoadCapacity
        {
            get;
            set;
        }

        public List<Matrix5X5> Stiffness
        {
            get;
            set;
        }

        public List<Matrix5X5> Damping
        {
            get;
            set;
        }

        public Matrix5X5 Total_Stiffness
        {
            get;
            set;
        }

        public Matrix5X5 Total_Damping
        {
            get;
            set;
        }

        public double Total_Friction
        {
            get;
            set;
        }
    }
}
