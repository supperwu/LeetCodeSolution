using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    /*
     * 给定一个整数数组 nums，将数组中的元素向右轮转 k 个位置，其中 k 是非负数。
        示例 1:
        输入: nums = [1,2,3,4,5,6,7], k = 3
        输出: [5,6,7,1,2,3,4]
        解释:
        向右轮转 1 步: [7,1,2,3,4,5,6]
        向右轮转 2 步: [6,7,1,2,3,4,5]
        向右轮转 3 步: [5,6,7,1,2,3,4]
    */
    public class RotateSolution
    {
        public void Rotate(int[] nums, int k)
        {
            //step1 reverse all elements [7,6,5,4,3,2,1]
            Reverse(nums, 0, nums.Length);
            //step2 reverse the elements in range [0, k-1]
            Reverse(nums, 0, k);
            //step3 reverse the elements in range [k, len-1]
            Reverse(nums, k, nums.Length - k);
        }

        private void Reverse(int[] nums, int start, int length)
        {
            int end = start + length - 1;
            while (end > start)
            {
                //swap
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        public void Run()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(nums, 3);

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }

            Console.WriteLine();
            int[] nums2 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Rotate(nums2, 3);

            for (int i = 0; i < nums2.Length; i++)
            {
                Console.Write(nums2[i] + " ");
            }
        }
    }
}
