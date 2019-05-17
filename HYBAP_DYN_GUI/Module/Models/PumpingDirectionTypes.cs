using System.Collections.Generic;

namespace Module.Models
{
    public static class PumpingDirectionTypes
    {
        public const string Inward = "Inward";
        public const string Outward = "Outward";

        public static Dictionary<int, string> GetPumpingDirectionTypes()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, Inward);
            dic.Add(2, Outward);
            return dic;
        }
    }
}
