using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithForStatement) }, Line = 9, Column = 16)]
    public class ConstructorWithForStatement
    {
        public ConstructorWithForStatement()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }
        }
    }
}