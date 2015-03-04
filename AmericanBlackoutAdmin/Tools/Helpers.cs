using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmericanBlackoutAdmin.Tools
{
    public static class Helpers
    {
        public static List<long> StringToList(string items)
        {
            if (!string.IsNullOrEmpty(items))
            {
                return items.Split(',').Select(x => Convert.ToInt64(x.Trim())).ToList();
            }

            return null;
        }

        public static string ListToStrint(List<long> list)
        {
            if (list != null)
            {
                return string.Join(",", list);
            }

            return null;
        }
    }
}