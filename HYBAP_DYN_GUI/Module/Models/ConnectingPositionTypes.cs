using System.Collections.Generic;

namespace Module.Models
{
    public static class ConnectingPositionTypes
    {
        public const string NoContactAndNoBC = "-1:No contact and no BC";
        public const string AtmosphericPressure = "0:Atmospheric pressure";
        public const string InnerOrLowerBoundary = "1:Inner or lower boundary";
        public const string OuterOrUpperBoundary = "2:Outer or upper boundary";

        public const string YES = "1:Yes";
        public const string No = "2:No";

        public static Dictionary<int, string> GetConnectingPositionTypes()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(-1, NoContactAndNoBC);
            dic.Add(0, AtmosphericPressure);
            dic.Add(1, InnerOrLowerBoundary);
            dic.Add(2, OuterOrUpperBoundary);
            return dic;
        }
        public static Dictionary<int, string> GetRecirculationChannelExistence()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, YES);
            dic.Add(2, No);
            return dic;
        }
    }
 
}
