using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class MinOperationsSolution
    {
        //给你一个整数数组 nums，你需要确保数组中的元素 互不相同 。为此，你可以执行以下操作任意次：
        //从数组的开头移除 3 个元素。如果数组中元素少于 3 个，则移除所有剩余元素。
        //注意：空数组也视作为数组元素互不相同。返回使数组元素互不相同所需的 最少操作次数 。

        //示例 1：
        //输入： nums = [1,2,3,4,2,3,3,5,7]
        //输出： 2

        public void Run()
        {
            int[] nums = { 1, 2, 3, 4, 2, 3, 3, 5, 7 };
            int[] nums2 = { 1, 1, 1, 1 };
            int[] nums3 = { 1, 2, 3, 4 };
            Console.WriteLine(MinOperations(nums2)); // 输出 2
        }

        public int MinOperations(int[] nums)
        {
            //// 使用 HashSet 去重，得到唯一元素的个数
            //HashSet<int> uniqueElements = new HashSet<int>(nums);
            //int uniqueCount = uniqueElements.Count;

            //// 计算需要移除的元素个数
            //int removeCount = nums.Length - uniqueCount;

            //// 每次移除 3 个元素，计算最少操作次数
            //return (removeCount + 2) / 3;  // 通过加 2 实现向上取整

            HashSet<int> seen = new HashSet<int>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (!seen.Add(nums[i]))
                {
                    return i / 3 + 1;
                }
            }

            return 0;
        }
    }
}
