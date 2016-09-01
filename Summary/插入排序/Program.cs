using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 插入排序
{
    class Program
    {

        static void Main(string[] args)
        {
            int[] nums = RandomHelper.GenerateNums(100, 1, 999);
            Console.WriteLine("生成的数组：");
            nums.ToList().ForEach((e) =>
            {
                Console.Write(e + ",");
            });
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Sort(nums);

            watch.Stop();
            Console.WriteLine("\r\n使用插入排序(升序)后：");
            nums.ToList().ForEach((e) =>
            {
                Console.Write(e + ",");
            });
            Console.WriteLine("\r\n用时:" + watch.Elapsed.ToString());
            Console.ReadKey();
        }

        private static void Sort(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (nums[j] > nums[j - 1])
                    {
                        temp = nums[j];
                        nums[j] = nums[j - 1];
                        nums[j - 1] = temp;
                    }

                }

            }



        }

    }
}
