using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 插入排序
{
    public class RandomHelper
    {
        public static int[] GenerateNums(int top=10,int minNum=0,int maxNum=100)
        {
            int[] nums = new int[top];
            Random random = new Random();
            for (int i = 0; i < top; i++)
            {
                nums[i] = random.Next(minNum, maxNum);
            }
            return nums;
        }
    }
}
