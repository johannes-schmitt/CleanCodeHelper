using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.TooManyParametersAnalyzerTest
{
    [NoExpectedDiagnostic]
    public class LocalMethodWithLessThanOrEqualToThreeParameters
    {
        public void SomeMethod3()
        {
            SomeLocalFunction(1, 2, 3);

            static void SomeLocalFunction(int first, int second, int third)
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
                Console.WriteLine(third);
            }
        }

        public void SomeMethod2()
        {
            SomeLocalFunction(1, 2);

            static void SomeLocalFunction(int first, int second)
            {
                Console.WriteLine(first);
                Console.WriteLine(second);
            }
        }

        public void SomeMethod1()
        {
            SomeLocalFunction(1);

            static void SomeLocalFunction(int first)
            {
                Console.WriteLine(first);
            }
        }

        public void SomeMethod0()
        {
            SomeLocalFunction();

            static void SomeLocalFunction()
            {
                Console.WriteLine();
            }
        }
    }
}