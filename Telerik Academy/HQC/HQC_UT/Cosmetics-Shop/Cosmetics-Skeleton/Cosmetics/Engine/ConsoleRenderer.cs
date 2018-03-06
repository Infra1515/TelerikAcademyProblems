using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;

namespace Cosmetics.Engine
{
    public class ConsoleRenderer : IConsoleRenderer
    {

        public IEnumerable<string> Input()
        {

            var currentLine = Console.ReadLine();

            while (!string.IsNullOrEmpty(currentLine))
            {
                yield return currentLine;

                currentLine = Console.ReadLine();

            }
        }

        public void Output(IEnumerable<string> reports)
        {
            var output = new StringBuilder();

            foreach (var report in reports)
            {
                output.AppendLine(report);
            }

            Console.Write(output.ToString());
        }
    }
}
