using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ChapterLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var tasks = new List<Task>();
            for (var i = 0; i < 12; i++)
            {
                var threadId = i;
                var task = Task.Run(() => Calculate(threadId));
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            stopwatch.Stop();
            Console.WriteLine($"Time elapsed: {stopwatch.ElapsedMilliseconds} ms.");
            Console.ReadKey();
        }

        private static void Calculate(int threadId)
        {
            Console.WriteLine($"Starting thread #{threadId}");
            var random = new Random();
            for (var i = 0; i < 1049760000; i++)
            {
               random.Next(5);
            }
            Console.WriteLine($"Stopping thread #{threadId}");
        }
    }
}
