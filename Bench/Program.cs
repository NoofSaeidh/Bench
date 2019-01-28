using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1000000;
            {
                new ForeachBenchRunner(count, 5, 20).Bench();
            }
            {
                new ForBenchRunner(count, 5, 20).Bench();
            }
            Console.ReadKey();
            //var result = BenchmarkRunner.Run<ForeachClassBench>();
        }
    }

    class ArrayElement
    {
        public string Value { get; set; }
    }

    class ForeachBenchRunner : ManualBenchRunnerBase
    {
        ArrayElement[] _array;
        int _arrayCount;

        public ForeachBenchRunner(int arrayCount, int warmUpCount, int count) : base("Foreach", warmUpCount, count)
        {
            _arrayCount = arrayCount;
            _array = Enumerable.Repeat(1, _arrayCount).Select(i => new ArrayElement()).ToArray();
        }

        protected override void Action()
        {
            foreach (var item in _array)
            {
                item.Value = "VALUE";
            }
        }
    }

    class ForBenchRunner : ManualBenchRunnerBase
    {
        ArrayElement[] _array;
        int _arrayCount;

        public ForBenchRunner(int arrayCount, int warmUpCount, int count) : base("For", warmUpCount, count)
        {
            _arrayCount = arrayCount;
            _array = Enumerable.Repeat(1, _arrayCount).Select(i => new ArrayElement()).ToArray();
        }

        protected override void Action()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i].Value = "VALUE";
            }
        }
    }
}
