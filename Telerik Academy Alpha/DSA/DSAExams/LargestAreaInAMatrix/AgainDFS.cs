//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LargestAreaInAMatrix
//{
//    public class AgainDFS
//    {
//        static int[] rowNum = new int[4] { -1, 0, 0, 1 };
//        static int[] colNum = new int[4] { 0, -1, 1, 0 };
//        static void Main()
//        {
//            var matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
//            var rowSize = matrixSize[0];
//            var colSize = matrixSize[1];
//            var matrix = new int[rowSize, colSize];
//            var visited = new bool[rowSize, colSize];
//            var resultMax = 0;
//            var result = 0;
//            for(var i = 0; i < rowSize; i++)
//            {
//                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
//                for(var j = 0; j < colSize; j++)
//                {
//                    matrix[i, j] = input[j];
//                }
//            }

//            for(int row = 0; row < rowSize; row++)
//            {
//                for(int col = 0; col < colSize; col++)
//                {
//                    result = 0;
//                    result += LargestAreaInAMatrixDFS(matrix, row, col, visited, rowNum, colNum);
//                    if (result > resultMax)
//                    {
//                        resultMax = result;
//                    }
//                }

//            }
//            Console.WriteLine(resultMax);

//        }

//        static int LargestAreaInAMatrixDFS(int[,] matrix, int row, int col, bool[,] visited,
//            int [] rowNum, int[] colNum)
//        {
//            var result = 1;
//            visited[row, col] = true;

//            for (int i = 0; i < 4; i++)
//            {
//                var nextRow = row + rowNum[i];
//                var nextCol = col + colNum[i];
//                if (IsValid(nextRow, nextCol, matrix.GetLength(0), matrix.GetLength(1)) &&
//                    !visited[nextRow, nextCol] && matrix[row, col] == matrix[nextRow, nextCol])
//                {
//                    result += LargestAreaInAMatrixDFS(matrix, nextRow, nextCol, visited, rowNum, colNum);
//                }
//            }
//            return result;
//        }

//        static bool IsValid(int row, int col, int rowSize, int colSize)
//        {

//            return (row > -1) && (row < rowSize) &&
//                   (col > -1) && (col < colSize);
//        }
//    }
//}
