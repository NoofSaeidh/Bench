using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Loggers;

namespace Bench
{
    [ClrJob, CoreJob]
    public class ForeachBench
    {
        private List<int> _list;
        private int[] _array;
        private IList<int> _listAsIList;
        private IEnumerable<int> _listAsIEnumerable;
        private IList<int> _arrayAsIList;
        private IEnumerable<int> _arrayAsIEnumerable;


        [Params(10000)]
        public int Count;

        [GlobalSetup]
        public void Setup()
        {
            _listAsIEnumerable = _listAsIList = _list = Enumerable.Repeat(1, Count).ToList();
            _arrayAsIEnumerable = _arrayAsIList = _array = Enumerable.Repeat(1, Count).ToArray();
        }

        #region List

        [Benchmark]
        public int ForList()
        {
            int result = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                result += _list[i];
            }

            return result;
        }

        [Benchmark]
        public int ForListWithCountProp()
        {
            int result = 0;
            int count = _list.Count;
            for (int i = 0; i < count; i++)
            {
                result += _list[i];
            }

            return result;
        }

        [Benchmark]
        public int ForeachList()
        {
            int result = 0;
            foreach (var item in _list)
            {
                result += item;
            }

            return result;
        }

        [Benchmark]
        public int ForeachListAsIList()
        {
            int result = 0;
            foreach (var item in _listAsIList)
            {
                result += item;
            }

            return result;
        }

        [Benchmark]
        public int ForeachListAsIEnumerable()
        {
            int result = 0;
            foreach (var item in _listAsIEnumerable)
            {
                result += item;
            }

            return result;
        }

        [Benchmark]
        public int ForeachFuncList()
        {
            int result = 0;
            _list.ForEach(i => result += i);
            return result;
        }

        #endregion

        #region Array

        [Benchmark]
        public int ForArray()
        {
            int result = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                result += _array[i];
            }

            return result;
        }

        [Benchmark]
        public int ForArrayWithCountProp()
        {
            int result = 0;
            int count = _array.Length;
            for (int i = 0; i < count; i++)
            {
                result += _array[i];
            }

            return result;
        }

        [Benchmark]
        public int ForeachArray()
        {
            int result = 0;
            foreach (var item in _array)
            {
                result += item;
            }

            return result;
        }

        [Benchmark]
        public int ForeachArrayAsIList()
        {
            int result = 0;
            foreach (var item in _arrayAsIList)
            {
                result += item;
            }

            return result;
        }

        [Benchmark]
        public int ForeachArrayAsIEnumerable()
        {
            int result = 0;
            foreach (var item in _arrayAsIEnumerable)
            {
                result += item;
            }

            return result;
        }

        [Benchmark]
        public int ForeachFuncArray()
        {
            int result = 0;
            Array.ForEach(_array, i => result += i);
            return result;
        }

        #endregion

    }
}
