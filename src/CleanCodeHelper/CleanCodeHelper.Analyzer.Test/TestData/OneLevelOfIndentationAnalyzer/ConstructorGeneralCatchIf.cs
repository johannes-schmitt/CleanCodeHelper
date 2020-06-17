using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0002", Arguments = new object[] { nameof(ConstructorGeneralCatchIf) }, Line = 9, Column = 16)]
    public class ConstructorGeneralCatchIf
    {
        public ConstructorGeneralCatchIf()
        {
            try
            {
            }
            catch
            {
                if (new Random().Next() % 2 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}