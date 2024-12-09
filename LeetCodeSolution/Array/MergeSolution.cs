using System;
using System.Collections.Generic;

namespace LeetCodeSolution
{
    class IntervalComparer : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            return x[0] - y[0];
        }
    }
    public class MergeSolution
    {
        /*
         * 以数组 intervals 表示若干个区间的集合，其中单个区间为 intervals[i] = [starti, endi] 。
         * 请你合并所有重叠的区间，并返回 一个不重叠的区间数组，该数组需恰好覆盖输入中的所有区间 。
         * 
         * 输入：intervals = [[1,4],[4,5]]
            输出：[[1,5]]
            解释：区间 [1,4] 和 [4,5] 可被视为重叠区间。
         */

        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return new int[0][];
            }

            //二维数组排序
            Array.Sort(intervals, new IntervalComparer());

            var merged = new List<int[]>();
            for (int i = 0; i < intervals.Length; i++)
            {
                int L = intervals[i][0];
                int R = intervals[i][1];

                if (merged.Count == 0 || merged[merged.Count - 1][1] < L)
                {
                    //如果L大于merged中最后一个区间的右端点
                    merged.Add(new int[] { L, R });
                }
                else
                {
                    merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1], R);
                }
            }

            return merged.ToArray();
        }

        public void Run()
        {
            //交错数组
            //int[][] intervals = new int[][] { 
            //        new int[] { 1, 3 },
            //        new int[] { 2, 6 },
            //        new int[] { 8, 10 },
            //        new int[] { 15, 18 },
            //};

            //简化的初始化
            int[][] intervals = {
                new int[]{ 1, 4},
                new int[]{ 4, 5},
            };

          

            int[][] merged = Merge(intervals);
        }
    }
}
