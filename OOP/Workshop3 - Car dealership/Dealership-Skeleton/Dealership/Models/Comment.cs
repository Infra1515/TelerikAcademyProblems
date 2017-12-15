using Bytes2you.Validation;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        private string content;
        private string author;
        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                Guard.WhenArgument(value, "content").IsNullOrEmpty().Throw();
                this.content = value;
            }
        }

        public string Author { get => author; set => author = value; }

        public override string ToString()
        {
            return $"   { this.Content}\r\n " +
                   $"      User: {this.Author}\r\n" +
                   $"      ----------\r\n" +
                   $"      ----------\r\n   ";
        }
    }
}
