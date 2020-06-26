using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.TooManyParametersAnalyzerTest
{
    [NoExpectedDiagnostic]
    public class MethodWithLessThanOrEqualToThreeParameters
    {
        public void SomeMethod3(int first, int second, int third)
        {
            Console.WriteLine(first);
            Console.WriteLine(second);
            Console.WriteLine(third);
        }

        public void SomeMethod2(int first, int second)
        {
            Console.WriteLine(first);
            Console.WriteLine(second);
        }

        public void SomeMethod1(int first)
        {
            Console.WriteLine(first);
        }

        public void SomeMethod0()
        {
            Console.WriteLine();
        }
    }
}