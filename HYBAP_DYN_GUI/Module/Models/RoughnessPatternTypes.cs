using System.Collections.Generic;

namespace Module.Models
{
    public static class RoughnessPatternTypes
    {
        public const string RoughnessPattern1 = "1/9";
        public const string RoughnessPattern2 = "1/6";
        public const string RoughnessPattern3 = "1/3";
        public const string RoughnessPattern4 = "1";
        public const string RoughnessPattern5 = "3";
        public const string RoughnessPattern6 = "6";
        public const string RoughnessPattern7 = "9";

        public static Dictionary<double, string> GetRoughnessPatternTypes()
        {
            Dictionary<double, string> dic = new Dictionary<double, string>();
            dic.Add(0.1111, RoughnessPattern1);
            dic.Add(0.1667, RoughnessPattern2);
            dic.Add(0.3333, RoughnessPattern3);
            dic.Add(1, RoughnessPattern4);
            dic.Add(3, RoughnessPattern5);
            dic.Add(6, RoughnessPattern6);
            dic.Add(9, RoughnessPattern7);
            return dic;
        }       
    }
}