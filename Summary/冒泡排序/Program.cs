using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 冒泡排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = RandomHelper.GenerateNums(100,1,999);
            Console.WriteLine("生成的数组：");
            nums.ToList().ForEach((e) =>
            {
                Console.Write(e + ",");
            });
            Stopwatch watch = new Stopwatch();
            watch.Start();

            Sort(nums);

            watch.Stop();
            nums.ToList().ForEach((e) =>
            {
                Console.Write(e + ",");
            });
            
            Console.WriteLine("\r\n用时:" + watch.Elapsed.ToString());
            Console.ReadKey();
        }
        /// <summary>
        /// 冒泡排序算法
        /// </summary>
        /// <remarks>
        /// 挨个和后面的数比较。满足条件则交换位置
        /// </remarks>
        /// <param name="nums"></param>
        static void Sort(int[] nums)
        {
            int temp;
            Console.WriteLine("\r\n使用冒泡排序(升序)后：");
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])//前一个比后一个大则交换位置，小的在前->升序
                    {
                        temp = nums[j];
                        nums[j] = nums[i];
                        nums[i] = temp;
                    }
                }
            }
            nums.ToList().ForEach((e) =>
            {
                Console.Write(e + ",");
            });

            Console.WriteLine("\r\n使用冒泡排序(降序)后：");
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])//前一个比后一个小则交换位置，大的在前->降序
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
        }
    }
}
