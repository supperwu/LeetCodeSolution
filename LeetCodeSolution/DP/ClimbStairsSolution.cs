using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution.DP
{
    /*
     * 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。 1 <= n <= 45
       每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
     */
    public class ClimbStairsSolution
    {
        public void Run()
        {
            int count = ClimbStairs(3);
            Console.WriteLine($"爬楼梯的方式有{count}种。");
        }

        public int ClimbStairs(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            //考虑最后一步可能跨了一级台阶，也可能跨了两级台阶，所以我们可以列出如下式子：
            //dp[i] = dp[i−1] + dp[i−2]

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 2;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i-2];
            }
            return dp[n - 1];
        }

        public int ClimbStairs2(int n)
        {
            if (n <= 2) return n; // 如果台阶数是 1 或 2，直接返回 n

            int prev = 1, curr = 2; // 初始化 f(1) 和 f(2)

            for (int i = 3; i <= n; i++)
            {
                int next = prev + curr; // 状态转移方程
                prev = curr; // 更新前一个状态
                curr = next; // 更新当前状态
            }

            return curr; // 返回到达第 n 阶的方法数
        }
    }
}
