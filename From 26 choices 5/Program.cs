using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From_26_choices_5
{

    class Program
    {
        static void Main(string[] args)
        {;
            List<int> num = new List<int>();
            Random ran = new Random();
            while (true)
            {
                int times;
                Console.WriteLine("输入生成数字个数，按0退出");
                try
                {
                    times = Convert.ToInt32(Console.ReadLine());//ReadLine返回字符串，用类型转化为Int
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("请输入正确的数字!");
                    continue;
                }
                if (times == 0)
                    break;
                

                for (int i = 0; i < times; i++)
                {
                    num.Clear();//清除List
                    while (true)
                    {
                        if (num.Count == 5)//判断是否已有5个元素，有则退出循环
                            break;
                        int temp = ran.Next(26) + 1;//生成1 到 26的随机数

                        if (!num.Contains(temp))//判断是否重复，不重复则加入
                            num.Add(temp);
                    }
                    for (int j = 0; j < num.Count; j++)
                        Console.Write("{0:d2} ", num[j]);
                    Console.WriteLine();
                }
            }


        }
    }
}
