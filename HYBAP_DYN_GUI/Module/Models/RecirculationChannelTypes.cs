using System.Collections.Generic;

namespace Module.Models
{
    public static class RecirculationChannelTypes
    {
        public const string Thrust = "1:Thrust bearing";
        public const string Journal = "2:Journal bearing";

        //public static Dictionary<int, string> GetRecirculationChannelTypes()
        //{
        //    Dictionary<int, string> dic = new Dictionary<int, string>();
        //    dic.Add(1, Thrust);
        //    dic.Add(2, Journal);
        //    return dic;
        //}
        public static Dictionary<int, string> GetSelectBearingTypeOfUpper()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, Thrust);
            dic.Add(2, Journal);
            return dic;
        }
        public static Dictionary<int, string> GetSelectBearingTypeOfLower()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, Thrust);
            dic.Add(2, Journal);
            return dic;
        }
    }
}
