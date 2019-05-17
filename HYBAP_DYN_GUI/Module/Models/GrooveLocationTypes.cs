using System.Collections.Generic;

namespace Module.Models
{
    public static class GrooveLocationTypes
    {
        public const string Stationary = "Stationary";
        public const string Rotating = "Rotating";

        public static Dictionary<int, string> GetGrooveLocationTypes()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, Stationary);
            dic.Add(2, Rotating);
            return dic;
        }
    }
}
