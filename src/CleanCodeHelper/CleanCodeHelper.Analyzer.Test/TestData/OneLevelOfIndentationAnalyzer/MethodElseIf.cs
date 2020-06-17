using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod) }, Line = 9, Column = 21)]
    public class MethodElseIf
    {
        public void SomeMethod()
        {
            if (new Random().Next() % 2 == 0)
            {
            }
            else
            {
                if (new Random().Next() % 3 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}

