using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bench
{
    public class ManualBenchRunnerDelegate : ManualBenchRunnerBase
    {
        private readonly Action _action;

        public ManualBenchRunnerDelegate(string benchName, int warmUpCount, int count, Action action)
            : base(benchName, warmUpCount, count)
        {
            _action = action;
        }

        protected override void Action()
        {
            _action();
        }
    }
}
