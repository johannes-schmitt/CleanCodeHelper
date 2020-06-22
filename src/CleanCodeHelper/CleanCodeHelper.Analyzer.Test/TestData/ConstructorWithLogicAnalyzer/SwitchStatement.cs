using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(SwitchStatement) }, Line = 9, Column = 16)]
    public class SwitchStatement
    {
        public SwitchStatement()
        {

            switch (new Random().Next() % 2 == 0)
            {
                case true:
                    {
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
}