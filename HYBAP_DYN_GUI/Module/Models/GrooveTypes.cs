using System.Collections.Generic;

namespace Module.Models
{
    public static class GrooveTypes
    {
        
        public const string Herringbone = "Herringbone";
        public const string Spiral = "Spiral";

        public static Dictionary<int, string> GetGrooveTypes()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, Herringbone);
            dic.Add(2, Spiral);
            return dic;
        }
    }
}
