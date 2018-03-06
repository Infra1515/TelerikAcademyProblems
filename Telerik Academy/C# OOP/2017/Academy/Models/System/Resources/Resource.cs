using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.System.Resources
{
    public abstract class Resource : ILectureResource
    {
        private readonly ResourceType type;
        private string name;
        private string url;
        public Resource(ResourceType type, string name, string url)
        {
            this.type = type;
            this.Name = name;
            this.Url = url;

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                if(value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
                }
                this.name = value;
            }
        }
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                if (value.Length < 5 || value.Length > 150)
                {
                    throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
                }
                this.url = value;
            }
        }

        public ResourceType Type { get => type;}

        public override string ToString()
        {
            return $"    * Resource:\r\n     - Name: {this.Name}\r\n     - Url: {this.Url}\r\n     " +
                $"- Type: {this.Type}\r\n     "; 
        }


    }

}
