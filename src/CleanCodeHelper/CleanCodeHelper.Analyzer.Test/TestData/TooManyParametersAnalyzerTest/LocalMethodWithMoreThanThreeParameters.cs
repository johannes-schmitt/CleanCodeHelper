using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.TooManyParametersAnalyzerTest
{
    [ExpectedDiagnostic("CC0007", Arguments = new object[] { "SomeLocalFunction" }, Line = 14, Column = 25)]
    [ExpectedDiagnostic("CC0007", Arguments = new object[] { "SomeLocalFunction" }, Line = 25, Column = 25)]
    public class LocalMethodWithMoreThanThreeParameters
    {
        public void SomeMethod4()
        {
            SomeLocalFunction(1, 2, 3, 4);

            static void SomeLocalFunction(int first, int second, int third, int fourth)
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
                Console.WriteLine(third);
                Console.WriteLine(fourth);
            }
        }

        public void SomeMethod5()
        {
            static void SomeLocalFunction(int first, int second, int third, int fourth, int fifth)
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
                Console.WriteLine(third);
                Console.WriteLine(fourth);
                Console.WriteLine(fifth);
            }

            SomeLocalFunction(1, 2, 3, 4, 5);
        }
    }
}