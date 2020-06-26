using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorContainsControlFlowAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(IfStatement) }, Line = 9, Column = 16)]
    public class IfStatement
    {
        public IfStatement()
        {
            if (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}