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

            //分析n个阶梯分别对应下标 0 到 n−1，楼层顶部对应下标 n，
            //问题等价于计算达到下标 n 的最小花费
            //创建长度为 n+1 的数组 dp，其中 dp[i] 表示达到下标 i 的最小花费。
            //由于可以选择下标 0 或 1 作为初始阶梯，因此有 dp[0] = dp[1] = 0。

            int[] dp = new int[len + 1];
            dp[0] = 0;
            dp[1] = 0;

            //dp[2] = min(10,15) = min(0+10, 0+15) = min(dp[0] + cost[0], dp[1] + cost[1]) = 10
            //dp[3] = min(0+15,10+20) = min(dp[1] + cost[i], dp[2] + cost[2])
            //dp[i] = min(dp[i-2] + cost[i-2], dp[i-1] + cost[i-1])

            for (int i = 2; i <= len; i++)
            {
                dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
            }

            return dp[len];
        }

        public int MinCostClimbingStair2(int[] cost)
        {
            int len = cost.Length;
            int prev = 0, cur = 0; // 初始化前两个状态

            // 从第 2 个台阶开始计算
            for (int i = 2; i <= len; i++)
            {
                int nextCost = Math.Min(prev + cost[i - 2], cur + cost[i - 1]);
                prev = cur;
                cur = nextCost;
            }
            return cur;
        }

        public void Run()
        {
            var array = new int[] { 10, 15, 20 };
            int cost = MinCostClimbingStairs(array);
            Console.WriteLine($"最小花费为{cost}");
        }
    }
}
