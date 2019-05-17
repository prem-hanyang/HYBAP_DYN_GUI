using System.Collections.Generic;

namespace Module.Models
{
    public static class BearingTypes
    {
        public const string PlainJournal = "1:Plain journal bearing";
        public const string GroovedJournal = "2:Grooved journal bearing";
        public const string PlainThrustClosedEnd = "3:Plain thrust bearing with closed end";
        public const string GroovedThrustDonut = "4:Grooved thrust bearing with donut shape";
        public const string PlainThrustDonut = "5:Plain thrust bearing with donut shape";

        public static Dictionary<int, string> GetBearingTypes()
        {
            dic = new Dictionary<int, string>();
            dic.Add(1, PlainJournal);
            dic.Add(2, GroovedJournal);
            dic.Add(3, PlainThrustClosedEnd);
            dic.Add(4, GroovedThrustDonut);
            dic.Add(5, PlainThrustDonut);
            return dic;
        }

        public static Dictionary<int, string> dic;
    }
}
