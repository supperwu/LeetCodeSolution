using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    //二分查找搜索排序数组, 找得到目标元素，返回其下标，否则返回-1
    public class BinarySearchSolution
    {
        public int Search(int[] array, int target)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                int mid = (left + right) / 2;
                if (target == array[mid])
                {
                    return mid;
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

            return -1;
        }

        public void Run()
        {
            int[] array = new int[] { 1, 3, 5, 7, 9 };
            int result = Search(array, 0); //-1
            Console.WriteLine(result);

            result = Search(array, 1);
            Console.WriteLine(result); //0

            result = Search(new int[] { 1, 3, 5, 7 }, 3);
            Console.WriteLine(result); //1

            result = Search(new int[] { 1, 3, 5, 7 }, 5);
            Console.WriteLine(result); //2
        }
    }
}
