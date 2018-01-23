//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LargestAreaInAMatrix
//{

//    struct Point
//    {
//        private readonly int x;
//        private readonly int y;
//        public Point(int x, int y)
//        {
//            this.x = x;
//            this.y = y;
//        }

//        public int X { get => x; }
//        public int Y { get => y; }
//    }

//    public class Program
//    {
//        static int[] rowNum = { -1, 0, 0, 1 };
//        static int[] colNum = { 0, -1, 1, 0 };
//        static void Main(string[] args)
//        {
//            var sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
//            int row = sizes[0];
//            int col = sizes[1];
//            var matrix = new int[row, col];
//            for (int i = 0; i < row; i++)
//            {
//                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
//                for (int j = 0; j < col; j++)
//                {
//                    matrix[i, j] = input[j];
//                }
//            }

//            var largestArea = 0;
//            var visited = new bool[row, col];
//            for (int i = 0; i < row; i++)
//            {
//                for (int j = 0; j < col; j++)
//                {
//                    if (!visited[i, j])
//                    {
//                        var area = DepthFirstSearch(matrix, i, j, visited);
//                        if (area > largestArea)
//                        {
//                            largestArea = area;
//                        }
//                    }
//                }

//            }
//            Console.WriteLine(largestArea);


//        }
//        static int DepthFirstSearch(int[,] array, int row, int col, bool[,] calc)
//        {
//            int result = 1;
//            calc[row, col] = true;
//            if ((row - 1 >= 0) && (array[row - 1, col] == array[row, col]) && !calc[row - 1, col])
//            {
//                result += DepthFirstSearch(array, row - 1, col, calc);
//            }
//            if ((row + 1 < array.GetLength(0)) && (array[row + 1, col] == array[row, col]) && !calc[row + 1, col])
//            {
//                result += DepthFirstSearch(array, row + 1, col, calc);
//            }
//            if ((col - 1 >= 0) && (array[row, col - 1] == array[row, col]) && !calc[row, col - 1])
//            {
//                result += DepthFirstSearch(array, row, col - 1, calc);
//            }
//            if ((col + 1 < array.GetLength(1)) && (array[row, col + 1] == array[row, col]) && !calc[row, col + 1])
//            {
//                result += DepthFirstSearch(array, row, col + 1, calc);
//            }
//            return result;
//        }
//        static int LargestAreaInAMatrixDFS(int[,] matrix, int row, int col, bool[,] visited)
//        {
//            var result = 1;
//            visited[row, col] = true;
//            //int[] rowNum = { -1, 0, 0, 1 };
//            //int[] colNum = { 0, -1, 1, 0 };

//            for (var i = 0; i < 4; i++)
//            {
//                var nextRow = row + rowNum[i];
//                var nextCol = col + colNum[i];
//                if (IsSafe(nextRow, nextCol, matrix.GetLength(0), matrix.GetLength(1), visited) &&
//                    matrix[row, col] == matrix[nextRow, nextCol])
//                {
//                    result += LargestAreaInAMatrixDFS(matrix, nextRow, nextCol, visited);
//                }
//            }

//            return result;
//        }
//        static bool IsSafe(int currentRow, int currentCol, int matrixRowSize, int matrixColSize,
//            bool[,] visited)
//        {
//            return (currentRow >= 0) && (currentRow < matrixRowSize) &&
//                    (currentCol >= 0) && (currentCol < matrixColSize) &&
//                    !visited[currentRow, currentCol];
//        }

//        static void PrintMatrix<T>(T[,] matrix)
//        {
//            for (int row = 0; row < matrix.GetLength(0); row++)
//            {
//                for (int col = 0; col < matrix.GetLength(1); col++)
//                {
//                    Console.Write(matrix[row, col] + " ");
//                }
//                Console.WriteLine();
//            }
//        }

//    }

//}
