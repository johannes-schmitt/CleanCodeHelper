using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0002", Arguments = new object[] { nameof(ConstructorForFor) }, Line = 9, Column = 16)]
    public class ConstructorForFor
    {
        public ConstructorForFor()
        {
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}