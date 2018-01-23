using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork.Delegates
{
    public delegate string StringDelagate(string item);
    //Funct<string, string> predefinedDelegate == same as above but no need to declare it;
    public class DelagateTest
    {
        public string StringFunction(string item)
        {
            return item.Substring(5);
        }
    }
}
