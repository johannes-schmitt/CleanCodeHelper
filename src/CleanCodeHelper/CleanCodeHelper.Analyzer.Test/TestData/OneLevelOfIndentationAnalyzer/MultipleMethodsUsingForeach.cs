using System;
using System.Linq;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod1) }, Line = 11, Column = 21)]
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod2) }, Line = 22, Column = 21)]
    public class MultipleMethodsUsingForeach
    {
        public void SomeMethod1()
        {
            using (var _ = new SomeDisposable())
            {
                foreach (var __ in Enumerable.Range(0, 10))
                {
                    Console.WriteLine();
                }
            }
        }

        public void SomeMethod2()
        {
            using (var _ = new SomeDisposable())
            {
                foreach (var __ in Enumerable.Range(0, 10))
                {
                    Console.WriteLine();
                }
            }
        }

        public class SomeDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}