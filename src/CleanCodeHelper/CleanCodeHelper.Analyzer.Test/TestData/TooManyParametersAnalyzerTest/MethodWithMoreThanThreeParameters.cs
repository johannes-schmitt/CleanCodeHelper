using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.TooManyParametersAnalyzerTest
{
    [ExpectedDiagnostic("CC0006", Arguments = new object[] { nameof(SomeMethod4) }, Line = 10, Column = 21)]
    [ExpectedDiagnostic("CC0006", Arguments = new object[] { nameof(SomeMethod5) }, Line = 18, Column = 21)]
    public class MethodWithMoreThanThreeParameters
    {
        public void SomeMethod4(int first, int second, int third, int fourth)
        {
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
        }

        public void SomeMethod5(int first, int second, int third, int fourth, int fifth)
        {
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
            Console.WriteLine(fourth);
            Console.WriteLine(fifth);
        }
    }
}