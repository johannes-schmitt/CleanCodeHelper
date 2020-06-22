using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithSwitchStatement) }, Line = 9, Column = 16)]
    public class ConstructorWithSwitchStatement
    {
        public ConstructorWithSwitchStatement()
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