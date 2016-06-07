using System;
using System.Collections.Generic;

namespace ExtensionMethod
{
    public static class MyStringExtensions
    {        
        public static IEnumerable<string> StartsWith(this List<string> list, string prefix)
        {
            foreach (var item in list)
            {
                if (item.StartsWith(prefix))
                {
                    yield return item;
                }
            }
        }
        public static string GetStringsAfter(this string value, string searchFor)
        {
            if (value != null)
            {
                var i = value.IndexOf(searchFor);
                if (i >= 0)
                {
                    i += searchFor.Length;
                    if (i < value.Length)
                    {
                        return value.Substring(i);
                    }
                }
            }
            return null;
        }
    }
}
