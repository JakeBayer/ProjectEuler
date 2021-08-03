using System;
using System.Diagnostics;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var problem = new Problem100();

            Console.WriteLine(problem.Run());
            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("===========================");
            Console.WriteLine("Execution took:");
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}
