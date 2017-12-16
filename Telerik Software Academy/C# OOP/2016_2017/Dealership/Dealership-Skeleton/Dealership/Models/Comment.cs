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
        public Comment(string content)
        {
            this.Content = content;
        }

        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"    {this.Content}\r\n      User: {this.Author}\r\n";
        }

    }
}
