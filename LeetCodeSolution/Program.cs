using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            int[,] array3 = new int[,] { { 1, 2 }, { 2, 3 }, { 5, 6 } };
            int[,] array4 = { { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7} };

            int[,] array5 = new int[3, 2];
            int rows = array5.GetLength(0);
            int cols = array5.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array5[i, j] = i * j;
                }
            }

            //交错数组 jagged array.
            //直接初始化
            int[][] array1 = new int[][] {
                new int[]{ 1, 2},
                new int[]{ 2, 3, 4},
                new int[]{ 3, 4, 5, 6}
            };

            int columns = 0;
            foreach (int[] row in array1)
            {
                if (row.Length > columns)
                {
                    columns = row.Length;
                }
            }

            Console.WriteLine($"The jagged array's columns is:{columns}");

            //简化初始化
            int[][] array2 = {
                new int[] { 1, 2 },
                new int[] { 2, 3, 4},
                new int[] { 3, 4, 5 ,6}
            };

            //循环初始化
            int[][] array = new int[3][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[i + 2];
                for (int j = 0; j < i + 2; j++)
                {
                    array[i][j] = i * 2 + j + 1;
                }
            }
            */

            new MajorityElementSolution().Run();
            Console.ReadLine();
        }
    }
}
