using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class SetZeroSolution
    {
        public void SetZero(int[][] array)
        {
            int rows = array.Length;
            int cols = array[0].Length;

            bool[] r = new bool[rows];
            bool[] c = new bool[cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i][j] == 0)
                    {
                        //标记所在的行&列 需要置零
                        r[i] = true;
                        c[i] = true;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (r[i] || c[j])
                    {
                        array[i][j] = 0;
                    }
                }
            }
        }

        public void Run()
        {
            int[][] matrix =
            {
                new int[]{ 0, 1, 2, 0},
                new int[]{ 3, 4, 5, 2},
                new int[]{ 1, 3, 1, 5}
            };

            SetZero(matrix);
        }
    }
}
