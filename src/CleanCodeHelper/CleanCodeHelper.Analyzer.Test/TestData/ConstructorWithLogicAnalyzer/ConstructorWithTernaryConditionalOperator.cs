using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithTernaryConditionalOperator) }, Line = 9, Column = 16)]
    public class ConstructorWithTernaryConditionalOperator
    {
        public ConstructorWithTernaryConditionalOperator()
        {
            var value = new Random().Next() % 2 == 0 ? "some value" : "some other value";

            Console.WriteLine(value);
        }
    }
}