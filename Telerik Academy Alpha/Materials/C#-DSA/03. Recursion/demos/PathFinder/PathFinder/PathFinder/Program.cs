using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PathFinder
{
    class Program
    {
        static char[,] maze =
        {
            {' ', ' ', ' ', ' ', ' ', 'x', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'}
        };

        static List<char> path = new List<char>();

        static StringBuilder paths = new StringBuilder();

        public static void Main()
        {
            FindExit(0, 0, ' ');
        }

        static void FindExit(int row, int col, char direction)
        {
            if ((col < 0) || (row < 0) || (col >= maze.GetLength(1))
                || (row >= maze.GetLength(0)))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Add only if not visited or it is the exit
            if (direction != ' ' && maze[row, col] == ' ')
            {
                path.Add(direction);
            }

            // Check if we have found the exit
            if (maze[row, col] == 'e')
            {
                paths.Append(string.Join(",", path) + "," + direction);
                paths.AppendLine(". Found a path!");
                //return;
            }

            if (maze[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            DrawMaze();

            // Temporary mark the current cell as visited
            maze[row, col] = 's';

            // Invoke recursion to explore all possible directions
            FindExit(row, col - 1, 'L'); // left
            FindExit(row - 1, col, 'U'); // up
            FindExit(row, col + 1, 'R'); // right
            FindExit(row + 1, col, 'D'); // down


            // Mark back the current cell as free
            maze[row, col] = ' ';

            if (path.Any())
            {
                path.RemoveAt(path.Count - 1);
            }
        }

        private static void DrawMaze()
        {
            Console.Clear();

            for (int currCol = 0; currCol < maze.GetLength(0); currCol++)
            {
                for (int currRow = 0; currRow < maze.GetLength(1); currRow++)
                {
                    switch (maze[currCol, currRow])
                    {
                        case ' ':
                            Console.Write("[ ]");
                            break;
                        case 'x':
                            Console.Write("[x]");
                            break;
                        case 'e':
                            Console.Write("[e]");
                            break;
                        case 's':
                            Console.Write("[o]");
                            break;
                    }
                }

                Console.WriteLine();
            }

            Console.Write(paths.ToString());
            Thread.Sleep(250);
        }
    }
}
