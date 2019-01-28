using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Bench
{
    [ClrJob, CoreJob]
    [HtmlExporter, MarkdownExporter, CsvExporter]
    public class ArrayInitialization
    {
        [Params(1000)]
        public int N;
        [Params(100)]
        public int M;

        [Benchmark]
        public Test[][] SingleInitialization()
        {
            return SingleInitialization_().ToArray();
        }

        public IEnumerable<Test[]> SingleInitialization_()
        {
            Test[] array;
            for (int i = 0; i < N; i++)
            {
                array = new Test[M];
                array[1] = new Test();
                array[2] = new Test();
                yield return array;
            }
        }

        [Benchmark]
        public Test[][] MultipleInitialization()
        {
            return MultipleInitialization_().ToArray();

        }

        public IEnumerable<Test[]> MultipleInitialization_()
        {
            for (int i = 0; i < N; i++)
            {
                var array = new Test[M];
                array[1] = new Test();
                array[2] = new Test();
                yield return array;
            }
        }
    }

    public class Test { }
}
