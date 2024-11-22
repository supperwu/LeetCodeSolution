using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class MinCostClimbingStairsSolution
    {
        public int MinCostClimbingStairs(int[] cost)
        {
            int len = cost.Length;

            int[] dp = new int[len + 1];
            dp[0] = 0;
            dp[1] = 0;

            for (int i = 2; i <= len; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1],  dp[i - 2] + cost[i - 2]);
            }

            return dp[len];
        }

        public void Run()
        {
            var array = new int[] { 10, 15, 20 };
            int cost = MinCostClimbingStairs(array);
            Console.WriteLine($"最小花费为{cost}");
        }
    }
}
