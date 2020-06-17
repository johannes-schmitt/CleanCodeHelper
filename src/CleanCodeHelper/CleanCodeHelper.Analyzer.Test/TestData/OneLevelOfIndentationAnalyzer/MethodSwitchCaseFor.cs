using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod) }, Line = 9, Column = 21)]
    public class MethodSwitchCaseFor
    {
        public void SomeMethod()
        {
            switch (new Random().Next() % 2 == 0)
            {
                case true:
                    for (var i = 0; i < 10; i++)
                    {
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}