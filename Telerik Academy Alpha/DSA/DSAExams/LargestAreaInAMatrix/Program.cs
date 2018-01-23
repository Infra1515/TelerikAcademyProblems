using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInAMatrix
{
    struct Point
    {
        private readonly int x;
        private readonly int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; }
        public int Y { get => y; }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = sizes[0];
            int col = sizes[1];
            var matrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            Console.WriteLine(LargestAreaInAMatrixBFS(matrix));

        }
        static int LargestAreaInAMatrixBFS(int[,] matrix)
        {
            int[] rowNum = { -1, 0, 0, 1 };
            int[] colNum = { 0, -1, 1, 0 };
            var area = 0;
            var largestArea = 0;
            //var path = new List<string>();
            //List<string> pathMax = new List<string>();

            var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            var q = new Queue<Point>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }
                    //var visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];
                    var startingPoint = new Point(i, j);
                    q.Enqueue(startingPoint);
                    visited[i, j] = true;
                    area = 0;

                    while (q.Count != 0)
                    {
                        var currentCell = q.Dequeue();
                        //visited[currentCell.X, currentCell.Y] = true;
                        area++;

                        for (int z = 0; z < 4; z++)
                        {
                            var row = currentCell.X + rowNum[z];
                            var col = currentCell.Y + colNum[z];
                            if (IsValid(row, col, matrix.GetLength(0), matrix.GetLength(1))
                                && !visited[row, col])
                            {
                                if (matrix[row, col] == matrix[startingPoint.X, startingPoint.Y])
                                {
                                    var adjacentCell = new Point(row, col);
                                    q.Enqueue(adjacentCell);
                                    visited[row, col] = true;
                                    //path.Add(string.Format("{0}:{1} ", row, col));

                                }
                            }
                        }
                    }

                    if (area > largestArea)
                    {
                        largestArea = area;
                        //pathMax = new List<string>(path);
                    }
                    //path.Clear();

                }

            }
            //foreach (var item in pathMax)
            //{
            //    //Console.Write(item + " ");
            //}
            return largestArea;
        }
        static bool IsValid(int currentRow, int currentCol, int matrixRowSize, int matrixColSize)
        {
            return (currentRow >= 0) && (currentRow < matrixRowSize) &&
                    (currentCol >= 0) && (currentCol < matrixColSize);
        }

        static void PrintMatrix<T>(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }

}
