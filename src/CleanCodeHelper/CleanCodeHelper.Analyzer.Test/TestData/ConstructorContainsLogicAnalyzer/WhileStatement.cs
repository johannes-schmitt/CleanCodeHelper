using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorContainsLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(WhileStatement) }, Line = 9, Column = 16)]
    public class WhileStatement
    {
        public WhileStatement()
        {
            while (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}