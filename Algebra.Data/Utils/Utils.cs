using Algebra.Data.Repositories;
using Algebra.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

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
                string var = objectName + i.ToString();
                str[i] = o[var].ToString();
            }
            return str;
        }

        public static List<T> GetObjectList<T>(string _str, char c)
        {
            List<T> list = new List<T>();
            string[] _strObjects = UnWrapObjects(JObject.Parse(_str), c);
            for (int i = 0; i < _strObjects.Length; i++)
            {
                T d = JsonConvert.DeserializeObject<T>(_strObjects[i]);
                list.Add(d);
            }

            return list;
        }

        public static IEnumerable<SelectListItem> GetEnumSelectList<T>(short _selected = 0)
        {
            return (Enum.GetValues(typeof(T)).Cast<T>().Select(
                enu => new SelectListItem() {
                    Text = enu.ToString(),
                    Value = enu.ToString(),
                    Selected = _selected.ToString() == enu.ToString()
                })).ToList();
        }

    }
}
