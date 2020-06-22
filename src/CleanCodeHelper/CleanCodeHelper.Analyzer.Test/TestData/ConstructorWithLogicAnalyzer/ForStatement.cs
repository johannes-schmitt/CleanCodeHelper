using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ForStatement) }, Line = 9, Column = 16)]
    public class ForStatement
    {
        public ForStatement()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }
        }
    }
}