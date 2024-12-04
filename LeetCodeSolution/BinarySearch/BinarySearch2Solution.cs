using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    public class BinarySearch2Solution
    {
        /*
         * 给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。
         * 如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
         */

        public int SearchInsertIndex(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (target == array[mid])
                {
                    return mid;  // 找到目标值，返回索引
                }
                else if (target > array[mid])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            // 最终 left 是插入位置
            return left;
        }

        public void Run()
        {
            int[] array = new int[] { 1, 3, 5, 6 };
            int result = SearchInsertIndex(array, 5); //2
            Console.WriteLine(result);

            result = SearchInsertIndex(array, 2);
            Console.WriteLine(result); //1

            result = SearchInsertIndex(array, 7);
            Console.WriteLine(result); //4

            result = SearchInsertIndex(array, 4);
            Console.WriteLine(result); //4
        }
    }
}
