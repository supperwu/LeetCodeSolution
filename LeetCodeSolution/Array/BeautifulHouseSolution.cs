using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    /*
     * Question:

        The city authorities are examingning the houses in a residential area for a city planning scheme.
        The area is depicted in an aerial view and divided into an N x M grid.
        If a grid cell contains some part of a house roof, it is assigned a value 1;
        if not, then the cell represents a vacant plot and is assigned the value 0.

        Clusters of adjacent grid cells with value 1 represent a single house.
        Diagonally placed grids with value 1 do not represent a single house.
        "Beautiful house" is a special kind of house that is surrounded by vacant plots on all sides: horizontally,vertically and diagonally. 
        You may assume that all four boundaries of the given gird are surrouonded by vacant plots.

        Write an algorithm to determine the number of "Beautiful house"
    */
    public class BeautifulHouseSolution
    {
        public int CountBeautifulHouses(int[,] grid)
        {
            int answer = 0;
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 1 && IsBeautifulHouse(grid, i, j))
                    {
                        answer++;
                        MarkHouseAsVisited(grid, i, j);
                    }
                }
            }

            return answer;
        }

        private bool IsBeautifulHouse(int[,] grid, int row, int col)
        {
            //对角线的单元格为零
            int[] dr = { -1, 1, 1, -1 };
            int[] dc = { -1, -1, 1, 1 };

            for (int i = 0; i <= 3; i++)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];

                if (IsValidCell(grid, newRow, newCol) && grid[newRow, newCol] == 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsValidCell(int[,] grid, int row, int col)
        {
            return row >= 0 && row < grid.GetLength(0) && col >= 0 && col < grid.GetLength(1);
        }

        private void MarkHouseAsVisited(int[,] grid, int row, int col)
        {
            if (!IsValidCell(grid, row, col) || grid[row, col] == 0)
            {
                //超出边界 或者 单元格不是房屋
                return;
            }

            //标记单元格已经访问
            grid[row, col] = 0;

            //继续递归标记相邻的单元格为已经访问
            MarkHouseAsVisited(grid, row + 1, col); //右边
            MarkHouseAsVisited(grid, row - 1, col);  //左边
            MarkHouseAsVisited(grid, row, col + 1);  //上边
            MarkHouseAsVisited(grid, row, col - 1);
        }

        public void Run()
        {
            //初始化二维数组
            //string[] dimensions = Console.ReadLine().Split(' ');
            //int rows = int.Parse(dimensions[0]);
            //int cols = int.Parse(dimensions[1]);

            //int[,] grid = new int[rows, cols];
            //for (int i = 0; i < rows; i++)
            //{
            //    string[] row = Console.ReadLine().Split(' ');
            //    for (int j = 0; j < cols; j++)
            //    {
            //        grid[i, j] = int.Parse(row[j]);
            //    }
            //}

            int[,] grid2 =
             {
                { 1,0,1,0},
                { 0,0,0,0},
                { 1,0,1,0},
                { 1,0,0,1},
            };
            int count = CountBeautifulHouses(grid2);
            Console.WriteLine(count);
        }

        public void Run2()
        {
            //初始化二维数组
            string[] dimensions = Console.ReadLine().Split(' ');
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            int[][] grid = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                grid[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            }

            int[][] grid2 = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                grid2[i] = new int[cols];
                string[] row = Console.ReadLine().Split(' ');
                for (int j = 0; j < cols; j++)
                {
                    grid2[i][j] = int.Parse(row[j]);
                }
            }
        }
    }


}
