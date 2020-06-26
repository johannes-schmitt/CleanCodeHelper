using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorContainsLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(TernaryConditionalOperator) }, Line = 9, Column = 16)]
    public class TernaryConditionalOperator
    {
        public TernaryConditionalOperator()
        {
            var value = new Random().Next() % 2 == 0 ? "some value" : "some other value";

            Console.WriteLine(value);
        }
    }
}