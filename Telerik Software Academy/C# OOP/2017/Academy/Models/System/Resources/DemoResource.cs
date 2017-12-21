using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models.System.Resources
{
    public class DemoResource : Resource
    {
        public DemoResource(string name, string url) 
            : base(ResourceType.DemoResource, name, url)
        {
        }
    }
}
