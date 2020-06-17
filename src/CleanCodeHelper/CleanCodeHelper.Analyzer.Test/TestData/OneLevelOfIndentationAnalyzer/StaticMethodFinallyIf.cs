using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod) }, Line = 9, Column = 28)]
    public class StaticMethodFinallyIf
    {
        public static void SomeMethod()
        {
            try
            {
            }
            finally
            {
                if (new Random().Next() % 2 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}