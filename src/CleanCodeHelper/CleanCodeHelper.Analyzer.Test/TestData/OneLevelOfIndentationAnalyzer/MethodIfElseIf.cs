using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [NoExpectedDiagnostic]
    public class MethodIfElseIf
    {
        public void SomeMethod()
        {
            if (new Random().Next() % 2 == 0)
            {
            }
            else if (new Random().Next() % 3 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}