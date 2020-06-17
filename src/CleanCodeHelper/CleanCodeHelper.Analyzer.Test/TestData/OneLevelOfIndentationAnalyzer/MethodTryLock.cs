using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod) }, Line = 9, Column = 21)]
    public class MethodTryLock
    {
        public void SomeMethod()
        {
            try
            {
                lock (new object())
                {
                    Console.WriteLine();
                }
            }
            catch
            {
            }
        }
    }
}