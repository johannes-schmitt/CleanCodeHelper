using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithDoStatement) }, Line = 9, Column = 16)]
    public class ConstructorWithDoStatement
    {
        public ConstructorWithDoStatement()
        {
            do
            {
                Console.WriteLine();
            } while (new Random().Next() % 2 == 0);
        }
    }
}