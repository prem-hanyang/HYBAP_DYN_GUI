using System.Collections.Generic;

namespace Module.Models
{
    public static class StaticAndDunamicAnalysisTypes
    {
        public const string RynoldsBC = "1:Reynolds boundary condition";
        public const string FullBC = "2:Full-Sommerfeld boundary condition";
        public const string HalfBC = "3:Half-Sommerfeld boundary condition";


        public const string Static = "1:Static analysis";
        public const string StaticAndDynamic = "2:Static and dynamic analysis";

        public static Dictionary<int, string> GetInternalBoundaryCondition()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, RynoldsBC);
            dic.Add(2, FullBC);
            dic.Add(3, HalfBC);
            return dic;
        }
        public static Dictionary<int, string> GetSelectAnalysisCase()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, Static);
            dic.Add(2, StaticAndDynamic);
            return dic;
        }
  
    }
}
