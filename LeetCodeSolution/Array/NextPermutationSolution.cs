using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    //下一个排列
    public class NextPermutationSolution
    {
        public void NextPermutation(int[] nums)
        {
            //从后往前找，寻找第一个非降序的元素 i
            //[1,5,8,4,7,6,5,3,1]
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }

            //从后往前找，寻找第一个大于元素i的元素j
            if (i > 0)
            {
                int j = nums.Length - 1;
                while (j >= 0 && nums[i] >= nums[j])
                {
                    j--;
                }

                //交换 i 跟 j 的位置
                Swap(nums, i, j);
            }

            //Reverse(nums, i + 1);
            Array.Reverse(nums, i + 1, nums.Length - (i + 1));
        }

        private void Reverse(int[] nums, int index)
        {
            int left = index;
            int right = nums.Length - 1;
            while (left < right)
            {
                Swap(nums, left, right);
                left++;
                right--;
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void Run()
        {
            int[] nums = { 1, 5, 8, 4, 7, 6, 5, 3, 1 };
            NextPermutation(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + " ");
            }
        }
    }
}
