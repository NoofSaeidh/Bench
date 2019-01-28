using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Bench
{
    [ClrJob, CoreJob]
    [HtmlExporter, MarkdownExporter, CsvExporter]
    public class TupleInitialization
    {
        private static readonly object _object = new object();
        private static readonly Guid _guid = Guid.NewGuid();
        private static readonly object[] _array = new object[] { "a", 5 };

        [Benchmark]
        public SimpleClass SimpleInitialization()
        {
            return new SimpleClass("a", 1, 1.1, _object);
        }

        [Benchmark]
        public ComplexClass ComplexInitialization()
        {
            return new ComplexClass("a", 1, 1.1, _object, 1.1M, _guid, _array, null);
        }

        [Benchmark]
        public SimpleClassTuple SimpleTupleInitialization()
        {
            return new SimpleClassTuple("a", 1, 1.1, _object);
        }

        [Benchmark]
        public ComplexClassTuple ComplexTupleInitialization()
        {
            return new ComplexClassTuple("a", 1, 1.1, _object, 1.1M, _guid, _array, null);
        }
    }

    public class SimpleClass
    {
        public SimpleClass(string a, int b, double c, object d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public string A { get; }
        public int B { get; }
        public double C { get; }
        public object D { get; }

    }

    public class ComplexClass : SimpleClass
    {
        public ComplexClass(string a, int b, double c, object d,
            decimal e, Guid? f, object[] g, SimpleClass h)
            : base(a, b, c, d)
        {
            E = e;
            F = f;
            G = g;
            H = h;
        }

        public decimal E { get; }
        public Guid? F { get; }
        public object[] G { get; }
        public SimpleClass H { get; }
    }

    public class SimpleClassTuple
    {
        public string A { get; }
        public int B { get; }
        public double C { get; }
        public object D { get; }

        public SimpleClassTuple(string a, int b, double c, object d) => (A, B, C, D) = (a, b, c, d);
    }

    public class ComplexClassTuple : SimpleClassTuple
    {
        public decimal E { get; }
        public Guid? F { get; }
        public object[] G { get; }
        public SimpleClassTuple H { get; }

        public ComplexClassTuple(string a, int b, double c, object d,
            decimal e, Guid? f, object[] g, SimpleClassTuple h)
            : base(a, b, c, d)
            => (E, F, G, H) = (e, f, g, h);
    }
}
