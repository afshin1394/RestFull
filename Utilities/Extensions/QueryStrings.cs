using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Extensions
{
    public static class QueryStrings
    {

        public static List<int> getInts(this object values)
        {
            string[] str = values.ToString().Split(",");
            List<int> intValues = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                intValues.Add(int.Parse(str[i]));
            }
            return intValues;
        }
    }
}
