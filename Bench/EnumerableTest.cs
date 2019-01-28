using BenchmarkDotNet.Attributes;
using System;
using System.Collections;

namespace Bench
{
    [ClrJob, CoreJob]
    [HtmlExporter, MarkdownExporter, CsvExporter]
    public class EnumerableTest
    {
        [Benchmark]
        public object StructuralForeach()
        {
            int i = 0;
            foreach(var item in new StructuralEnumerableTestClass())
            {
                if(i == 7)
                    return item;
                i++;
            }
            return null;
        }

        [Benchmark]
        public object SimpleForeach()
        {
            int i = 0;
            foreach (var item in new EnumerableTestClass())
            {
                if (i == 7)
                    return item;
                i++;
            }
            return null;
        }

        [Benchmark]
        public object ExplicitForeach()
        {
            int i = 0;
            foreach (var item in new ExplicitEnumerableTestClass())
            {
                if (i == 7)
                    return item;
                i++;
            }
            return null;
        }
    }

    public class StructuralEnumerableTestClass
    {
        public IEnumerator GetEnumerator()
        {
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
        }
    }

    public class EnumerableTestClass : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
        }
    }

    public class ExplicitEnumerableTestClass : IEnumerable
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
            yield return "a";
        }
    }
}