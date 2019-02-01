using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalimskyDayPlanner
{
    public static class Utils
    {
        public static string GetDateCode(DateTime d)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(d.Year);
            sb.Append("_");
            sb.Append(d.Month);
            sb.Append("_");
            sb.Append(d.Day);
            return sb.ToString();
        }
    }
}
