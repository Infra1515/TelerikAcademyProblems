using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public static class Labyrinth_BFS
    {
        public static IDictionary<char, int> charInfo = new Dictionary<char, int>()
        {
            {'0', 0 },
            {'x', -1 },
            {'*', 1 }
        };

        public static string[] labyrinth = new string[]
        {
             "000x0x",
             "0x0x0x",
             "0*x0x0",
             "0x0000",
             "000xx0",
             "000x0x"
        };

        public static void BFSLabyrinth()
        {
            var parsedLabyrinth = new int[labyrinth.Length, labyrinth[0].Length];

            for (var i = 0; i < parsedLabyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < parsedLabyrinth.GetLength(0); j++)
                {
                    // TO-DO : make checks for x and *
                    parsedLabyrinth[i, j] = (int)char.GetNumericValue(labyrinth[i][j]);
                }
            }
        }
    }
}
