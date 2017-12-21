using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models.System.Resources
{
    public class PresentationResource : Resource
    {
        public PresentationResource(string name, string url) 
            : base(ResourceType.PresentationResource , name, url)
        {

        }
    }
}
