using BenchmarkDotNet.Attributes;

namespace Bench
{
    [ClrJob]
    [HtmlExporter, MarkdownExporter, CsvExporter]
    public class CallMethod
    {
        CallMethodClass _sut = new CallMethodClass();
        CallMethodClass _overrideSut = new OverrideCallMethodClass();
        ICallMethodClass _interfaceSut = new CallMethodClass();

        [Benchmark]
        public object GetStructuralValue()
        {
            return _sut.GetStructuralValue();
        }

        [Benchmark]
        public object GetInterfaceValue()
        {
            return _sut.GetInterfaceValue();
        }

        [Benchmark]
        public object GetExplicitInterfaceValue()
        {
            return _interfaceSut.GetInterfaceValue();
        }

        [Benchmark]
        public object GetExplicitDefinedInterfaceValue()
        {
            return _interfaceSut.GetExplicitDefinedInterfaceValue();
        }

        [Benchmark]
        public object GetVirtualValue()
        {
            return _sut.GetVirtualValue();
        }

        [Benchmark]
        public object GetOverriddenValue()
        {
            return _overrideSut.GetVirtualValue();
        }
    }

    public interface ICallMethodClass
    {
        object GetInterfaceValue();

        object GetExplicitDefinedInterfaceValue();
    }

    public class CallMethodClass : ICallMethodClass
    {
        private static readonly object _value = new object();

        public object GetStructuralValue() => _value;

        public virtual object GetVirtualValue() => _value;

        public object GetInterfaceValue() => _value;

        object ICallMethodClass.GetExplicitDefinedInterfaceValue() => _value;
    }

    public class OverrideCallMethodClass : CallMethodClass
    {
        private static readonly object _value = new object();

        public override object GetVirtualValue() => _value;
    }
}