using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Utils
{
    public static class Utilities
    {
        public static string DateParser(DateTime date)
        {
            return date.ToString(@"MM/dd/yyyy hh:mm:ss tt", CultureInfo.GetCultureInfo("en-US"));
        }

    }
}
