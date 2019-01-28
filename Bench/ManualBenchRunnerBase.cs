using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bench
{
    public abstract class ManualBenchRunnerBase
    {
        private readonly string _benchName;
        private readonly Action _action;
        private readonly int _warmUpCount;
        private readonly int _count;

        public ManualBenchRunnerBase(string benchName, int warmUpCount, int count)
        {
            _benchName = benchName;
            _warmUpCount = warmUpCount;
            _count = count;
        }

        protected abstract void Action();

        public void Bench()
        {
            WarmUpRun();
            ActualRun();
        }

        private void ActualRun()
        {
            decimal result = 0;
            for (int i = 0; i < _count; i++)
            {
                var time = SingleRun();
                WriteInfo("ACTUAL", time);
                result += (decimal)time.Ticks / _count;
            }
            WriteInfo("RESULT (AVG.)", new TimeSpan((long)result));
        }

        private void WarmUpRun()
        {
            for (int i = 0; i < _warmUpCount; i++)
            {
                WriteInfo("WARMUP", SingleRun());
            }
        }

        private TimeSpan SingleRun()
        {
            var watch = new Stopwatch();
            watch.Start();
            Action();
            watch.Stop();
            return watch.Elapsed;
        }

        private void WriteInfo(string type, TimeSpan time)
        {
            Console.WriteLine($"{type} | {_benchName}. Time: {time}");
        }
    }
}
