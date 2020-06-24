using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0003", Arguments = new object[] { "SomeLocalFunction" }, Line = 13, Column = 25)]
    public class LocalFunctionAtBeginningWhileFor
    {
        public void SomeMethod()
        {
            SomeLocalFunction();

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
        }
    }
}