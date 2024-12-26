using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class MajorityElementSolution
    {
        //给定一个大小为 n 的整数数组，找出其中所有出现超过 ⌊ n/3 ⌋ 次的元素。

        public IList<int> MajorityElement(int[] nums)
        {
            int n = nums.Length;
            var result = new List<int>();
            int count1 = 0, count2 = 0;
            int candidate1 = int.MinValue, candidate2 = int.MinValue;

            // 第一步：找到两个候选元素
            foreach (int i in nums)
            {
                if (i == candidate1)
                {
                    count1++;
                }
                else if (i == candidate2)
                {
                    count2++;
                }
                else if (count1 == 0)
                {
                    candidate1 = i;
                    count1 = 1;
                }
                else if (count2 == 0)
                {
                    candidate2 = i;
                    count2 = 1;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }


            // 第二步：确认这两个候选元素的计数
            count1 = 0;
            count2 = 0;
            foreach (int num in nums)
            {
                if (num == candidate1)
                {
                    count1++;
                }
                else if (num == candidate2)
                {
                    count2++;
                }
            }

            if (count1 > n / 3) result.Add(candidate1);
            if (count2 > n / 3) result.Add(candidate2);

            return result;
        }

        public void Run()
        {
            int[] nums = { 3, 2, 3 };
            var result = MajorityElement(nums);
            Console.WriteLine(string.Join(", ", result)); // 输出: 3

            nums = new int[] { 4, 1, 1, 1, 1, 3, 3, 2, 2, 2 };
            result = MajorityElement(nums);
            Console.WriteLine(string.Join(", ", result)); // 输出: 1, 2
        }
    }
}
