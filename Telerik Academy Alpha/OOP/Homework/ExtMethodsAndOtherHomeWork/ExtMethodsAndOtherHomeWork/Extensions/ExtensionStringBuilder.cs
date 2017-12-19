using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork.Extensions
{
    public static class ExtensionStringBuilder
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            string str = sb.ToString().Substring(index, length);
            var sbSubstring = new StringBuilder(str);
            return sbSubstring;
        }
    }

}
