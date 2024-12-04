using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class SearchRotatedSortedArraySolution
    {
        //search-in-rotated-sorted-array

        /*
         * 给你 旋转后 的数组 nums 和一个整数 target 
         * 如果 nums 中存在这个目标值 target ，则返回它的下标，否则返回 -1 。
         * 
         * 
         * 输入：nums = [4,5,6,7,0,1,2], target = 0
         * 输出：4
         */

        public int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > nums[left])
                {
                    //[left, mid] 为升序
                    if (target >= nums[left] && target < nums[mid])
                    {
                        //target在[left, mid-1]中间
                        right = mid - 1;
                    }
                    else
                    {
                        //target在[mid+1, right]中间
                        left = mid + 1;
                    }
                }
                else
                {
                    //[mid, right] 为升序
                    if (target > nums[mid] && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }


            return -1;
        }

        public void Run()
        {
            int result = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0);
            Console.WriteLine(result); //4

            result = Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3);
            Console.WriteLine(result); //-1

            result = Search(new int[] { 4, 5, 6, 7, 0, 1, 2, 3 }, 3);
            Console.WriteLine(result); // 7

            result = Search(new int[] { 4, 5, 6, 7, 0, 1, 2, 3 }, 4);
            Console.WriteLine(result); // 0
        }
    }
}
