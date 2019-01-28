using BenchmarkDotNet.Attributes;
using System;

namespace Bench
{
    [ClrJob]
    [HtmlExporter, MarkdownExporter, CsvExporter]
    public class DisposeTest
    {
        [Benchmark]
        public bool StructuralDispose()
        {
            using (var dispose = new DisposeTestClass())
            {
                return true;
            }
        }

        [Benchmark]
        public bool ExplicitDispose()
        {
            using (var dispose = new ExplicitImplementDisposeTestClass())
            {
                return true;
            }
        }
    }

    public class DisposeTestClass : IDisposable
    {
        private object _forDispose = new object();

        public void Dispose()
        {
            _forDispose = null;
        }
    }

    public class ExplicitImplementDisposeTestClass : IDisposable
    {
        private object _forDispose = new object();

        void IDisposable.Dispose()
        {
            _forDispose = null;
        }
    }
}