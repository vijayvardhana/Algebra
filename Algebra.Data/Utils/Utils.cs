using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Data
{
    public static class Utils
    {
        public static string[] UnWrapObjects(JObject obj)
        {
            JObject o = JObject.Parse(obj.ToString());

            string[] str = new string[o.Count];

            for (int i = 0; i < o.Count; i++)
            {
                string var = "o" + (i + 1).ToString();
                str[i] = o[var].ToString();
            }
            return str;
        }
    }
}
