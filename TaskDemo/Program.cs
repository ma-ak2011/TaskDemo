using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1();
        }

        public static void Test1()
        {
            Console.WriteLine("処理開始");
            var task = Task.Factory
                .StartNew(() =>
                {
                    Thread.Sleep(5000);
                    return new Random().Next(0, 9).ToString();
                })
                .ContinueWith(t =>
                {
                    Console.WriteLine("終了！結果は？");
                    Console.WriteLine(t.Result);
                });

            Console.WriteLine("処理待ち");
            task.Wait();


        }
    }
}
