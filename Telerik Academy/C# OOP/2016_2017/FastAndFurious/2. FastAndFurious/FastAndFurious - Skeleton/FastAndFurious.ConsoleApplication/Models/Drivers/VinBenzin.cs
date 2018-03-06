using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class VinBenzin : Driver
    {
        private const string name = "VinBenzin";
        private const GenderType gender = GenderType.Male;
        public VinBenzin() : base(name, gender)
        {

        }
    }
}
