using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0003", Arguments = new object[] { "SomeLocalFunction" }, Line = 11, Column = 25)]
    public class LocalFunctionAtEndWhileFor
    {
        public void SomeMethod()
        {
            static void SomeLocalFunction()
            {
                while (true)
                {
                    for (var i = 0; i < 10; i++)
                    {
                        Console.WriteLine();
                    }
                }
            }

            SomeLocalFunction();
        }
    }
}