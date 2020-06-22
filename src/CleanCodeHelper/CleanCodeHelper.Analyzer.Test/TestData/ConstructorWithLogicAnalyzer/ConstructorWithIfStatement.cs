using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithIfStatement) }, Line = 9, Column = 16)]
    public class ConstructorWithIfStatement
    {
        public ConstructorWithIfStatement()
        {
            if (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }
        }
    }
}