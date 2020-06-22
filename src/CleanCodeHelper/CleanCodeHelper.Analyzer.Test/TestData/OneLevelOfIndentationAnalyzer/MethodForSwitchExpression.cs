using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0001", Arguments = new object[] { nameof(SomeMethod) }, Line = 9, Column = 21)]
    public class MethodForSwitchExpression
    {
        public void SomeMethod()
        {
            for (var i = 0; i < 10; i++)
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
}