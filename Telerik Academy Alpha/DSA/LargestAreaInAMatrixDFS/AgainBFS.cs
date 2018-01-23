using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestAreaInAMatrixDFS
{
    public class AgainBFS
    {
        static int[] rowNum = new int[4] { -1, 0, 0, 1 };
        static int[] colNum = new int[4] { 0, -1, 1, 0 };
        static void Main()
        {
            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rowSize = matrixSize[0];
            var colSize = matrixSize[1];
            var filledMatrix = MatrixFiller(rowSize, colSize);
            var result = 0;
            var resultMax = 0;
            var visited = new bool[rowSize, colSize];
            for(int i = 0; i < rowSize; i++)
            {
                for(int j = 0; j < colSize; j++)
                {
                    if (!visited[i, j])
                    {
                        visited[i, j] = true;
                        var startingPoint = new Point(i, j);
                        result = LargestAreaInAMatrixBFS(filledMatrix, startingPoint, visited);
                        if (result > resultMax)
                        {
                            resultMax = result;
                        }

                        result = 0;
                    }
                }
            }
            Console.WriteLine(resultMax);
        }

        static int LargestAreaInAMatrixBFS(int[,] matrix, Point startingPoint, bool[,] visited)
        {
            var rowSize = matrix.GetLength(0);
            var colSize = matrix.GetLength(1);
            //var visited = new bool[rowSize, colSize];
            var result = 1;

            var q = new Queue<Point>();
            q.Enqueue(startingPoint);
            
            while(q.Count != 0)
            {
                var pt = q.Dequeue();

                var row = pt.X;
                var col = pt.Y;
                //visited[row, col] = true;

                for (int i = 0; i < 4; i++)
                {
                    var nextRow = row + rowNum[i];
                    var nextCol = col + colNum[i];

                    if (IsValid(nextRow, nextCol, rowSize, colSize) &&
                        !visited[nextRow, nextCol] &&
                        matrix[row, col] == matrix[nextRow, nextCol])
                    {
                        result++;
                        visited[nextRow, nextCol] = true;
                        q.Enqueue(new Point(nextRow, nextCol));
                    }
                }
            }

            return result;
        }
        public static int[,] MatrixFiller(int rowSize, int colSize)
        {
            var matrix = new int[rowSize, colSize];
            for (int i = 0; i < rowSize; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < colSize; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            return matrix;
        }

        public static bool IsValid(int row, int col, int rowSize, int colSize)
        {
            return (row > -1) && (row < rowSize) &&
                   (col > -1) && (col < colSize);
        }
    }
    struct Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
