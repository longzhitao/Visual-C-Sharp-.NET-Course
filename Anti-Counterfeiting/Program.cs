using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace Anti_Counterfeiting
{

    public class Code
    {

        private const string strTableChar = "0123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
        private static Hashtable hashtable = new Hashtable();
        /// <summary>
        /// 生成num个长度为length的防伪码
        /// </summary>
        /// <param name="length">防伪码的长度</param>
        /// <param name="num">生成个数</param>
        public static void GenerateCode(int length, int num)
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < num; i++)
            {
                while (true)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int j = 0; j < length; j++)
                    {
                        stringBuilder.Append(strTableChar[rd.Next(0, strTableChar.Length - 1)]);
                    }
                    if (!hashtable.ContainsKey(stringBuilder))
                    {
                        hashtable.Add(stringBuilder, 1);
                        Console.WriteLine(stringBuilder);
                        break;
                    }
                }
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer1 = new Stopwatch();//计时器类
            timer1.Start();//开始计时
            Code.GenerateCode(10, 10000);
            timer1.Stop();//停止计时
            double dMilliseconds = timer1.Elapsed.TotalMilliseconds;

            timer1.Start();//开始计时
            Code.GenerateCode(20, 1000000);
            timer1.Stop();//停止计时
            double dMilliseconds1 = timer1.Elapsed.TotalMilliseconds;

            timer1.Start();//开始计时
            Code.GenerateCode(50, 1000000);
            timer1.Stop();//停止计时
            double dMilliseconds2 = timer1.Elapsed.TotalMilliseconds;

            Console.WriteLine("生成个数为：{0}，运行时间为：{1}", 10000, dMilliseconds / 1000);
            Console.WriteLine("生成个数为：{0}，运行时间为：{1}", 1000000, dMilliseconds1 / 1000);
            Console.WriteLine("生成个数为：{0}，运行时间为：{1}", 1000000, dMilliseconds2 / 1000);


            Console.ReadKey();



            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
