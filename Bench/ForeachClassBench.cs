using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Loggers;

namespace Bench
{
    [CoreJob, LegacyJitX86Job]
    [DisassemblyDiagnoser]
    public class ForeachClassBench
    {
        private List<ForeachClass> _list;
        private ForeachClass[] _array;
        private IList<ForeachClass> _listAsIList;
        private IEnumerable<ForeachClass> _listAsIEnumerable;
        private IList<ForeachClass> _arrayAsIList;
        private IEnumerable<ForeachClass> _arrayAsIEnumerable;


        [Params(1000)]
        public int Count;

        public const string VALUE = "VALUE";

        [GlobalSetup]
        public void Setup()
        {
            var producer = Enumerable.Repeat("", Count).Select(i => new ForeachClass());
            _listAsIEnumerable = _listAsIList = _list = producer.ToList();
            _arrayAsIEnumerable = _arrayAsIList = _array = producer.ToArray();
        }

        #region List

        [Benchmark]
        public void ForList()
        {
            for (int i = 0; i < _list.Count; i++)
            {
                _list[i].Value = VALUE;
            }
        }

        [Benchmark]
        public void ForListWithCountProp()
        {
            int count = _list.Count;
            for (int i = 0; i < count; i++)
            {
                _list[i].Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachList()
        {
            foreach (var item in _list)
            {
                item.Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachListAsIList()
        {
            foreach (var item in _listAsIList)
            {
                item.Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachListAsIEnumerable()
        {
            foreach (var item in _listAsIEnumerable)
            {
                item.Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachFuncList()
        {
            _list.ForEach(i => i.Value = VALUE);
        }

        #endregion

        #region Array

        [Benchmark]
        public void ForArray()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _list[i].Value = VALUE;
            }
        }

        [Benchmark]
        public void ForArrayWithCountProp()
        {
            int count = _array.Length;
            for (int i = 0; i < count; i++)
            {
                _list[i].Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachArray()
        {
            foreach (var item in _array)
            {
                item.Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachArrayAsIList()
        {
            foreach (var item in _arrayAsIList)
            {
                item.Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachArrayAsIEnumerable()
        {
            foreach (var item in _arrayAsIEnumerable)
            {
                item.Value = VALUE;
            }
        }

        [Benchmark]
        public void ForeachFuncArray()
        {
            Array.ForEach(_array, i => i.Value = VALUE);
        }

        #endregion

        class ForeachClass
        {
            public string Value { get; set; }
        }
    }
}
