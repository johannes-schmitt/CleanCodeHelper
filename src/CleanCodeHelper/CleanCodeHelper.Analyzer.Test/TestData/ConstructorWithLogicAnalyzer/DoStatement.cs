using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(DoStatement) }, Line = 9, Column = 16)]
    public class DoStatement
    {
        public DoStatement()
        {
            do
            {
                Console.WriteLine();
            } while (new Random().Next() % 2 == 0);
        }
    }
}