using BenchmarkDotNet.Running;
using System;

namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run<ForeachBench>();
        }
    }
}
