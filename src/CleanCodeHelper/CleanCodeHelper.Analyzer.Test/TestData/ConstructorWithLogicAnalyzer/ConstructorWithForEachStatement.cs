using System;
using System.Linq;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithForEachStatement) }, Line = 10, Column = 16)]
    public class ConstructorWithForEachStatement
    {
        public ConstructorWithForEachStatement()
        {
            foreach (var _ in Enumerable.Range(0, 10))
            {
                Console.WriteLine();
            }
        }
    }
}