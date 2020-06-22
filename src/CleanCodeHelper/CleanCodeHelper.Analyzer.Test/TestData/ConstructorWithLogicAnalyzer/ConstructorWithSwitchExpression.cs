using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(ConstructorWithSwitchExpression) }, Line = 9, Column = 16)]
    public class ConstructorWithSwitchExpression
    {
        public ConstructorWithSwitchExpression()
        {
            var value = (new Random().Next() % 2 == 0) switch
            {
                true => "some value",
                false => "some other value"
            };

            Console.WriteLine(value);
        }
    }
}