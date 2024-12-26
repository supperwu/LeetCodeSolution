using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class MaxDistinctElementsSolution
    {
        public int MaxDistinctElements(int[] nums, int k)
        {
            Array.Sort(nums);  // 排序
            int ans = 0;
            int pre = int.MinValue;  // 记录前一个元素的位置

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Math.Min(Math.Max(nums[i] - k, pre + 1), nums[i] + k);  // 计算当前元素的位置
                if (nums[i] > pre)
                {
                    ans++;  // 如果当前元素位置大于前一个元素，计数器加一
                    pre = nums[i];  // 更新前一个元素的位置
                }
            }
            return ans;
        }

        public void Run()
        {
            int[] nums = { 1, 2, 2, 3, 3, 4 };
            int k = 2;
            Console.WriteLine(MaxDistinctElements(nums, k)); // 输出 6
        }
    }
}
