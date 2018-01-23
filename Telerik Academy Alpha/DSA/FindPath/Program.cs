using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPath
{
    public class Program
    {
        static int position = 0;

        static void Main(string[] args)
        {
            var lab = new char[,]
            {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'E'},
            };
            var path = new char[lab.GetLength(0) * lab.GetLength(1)];

            FindPath(0, 0, lab, 'S', path);
        }

        static void FindPath(int row, int col, char[,] lab, char direction, char[] path)
        {

            if ( (col < 0) || (row < 0) ||
            (col >= lab.GetLength(1)) || (row >= lab.GetLength(0)))
            {
                return;
            }
            path[position] = direction;
            position++;
            if (lab[row,col] == 'E')
            {
                for(int i = 1; i < path.Length; i++)
                {
                    Console.Write(path[i].ToString());
                }
                Console.WriteLine();
            }

            if (lab[row,col] == ' ')
            {
                lab[row, col] = 's';


                FindPath(row, col - 1, lab, 'L', path); // left
                FindPath(row - 1, col, lab, 'U', path); // up
                FindPath(row, col + 1, lab, 'R', path);// right
                FindPath(row + 1, col, lab, 'D', path);// down

                lab[row, col] = ' ';
            }
            position--;
        }
    }
}
