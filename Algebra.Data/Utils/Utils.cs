using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Newtonsoft.Json.Linq;
using System;

namespace Algebra.Data
{
    public static class Utils
    {
        public static string[] UnWrapObjects(JObject obj, char objectName)
        {
            JObject o = JObject.Parse(obj.ToString());

            string[] str = new string[o.Count];

            for (int i = 0; i < o.Count; i++)
            {
                string var = objectName + (i + 1).ToString();
                str[i] = o[var].ToString();
            }
            return str;
        }
    }
}
