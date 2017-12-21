using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using Academy.Models.Utils;

namespace Academy.Models.System.Resources
{
    public class VideoResource : Resource
    {
        private readonly DateTime uploadedDate;
        public VideoResource(string name, string url, DateTime uploadDate) 
            : base(ResourceType.VideoResource , name, url)
        {
            this.uploadedDate = uploadDate;

        }

        public DateTime UploadedDate => uploadedDate;

        public override string ToString()
        {
            return base.ToString() + $"- Uploaded on: {Utilities.DateParser(this.UploadedDate)}";
        }
    }
}
