using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [ExpectedDiagnostic("CC0002", Arguments = new object[] { nameof(ConstructorCatchIf) }, Line = 9, Column = 16)]
    public class ConstructorCatchIf
    {
        public ConstructorCatchIf()
        {
            try
            {
            }
            catch (InvalidOperationException)
            {
                if (new Random().Next() % 2 == 0)
                {
                    Console.WriteLine();
                }
            }
            catch
            {
                Console.WriteLine();
            }
        }
    }
}