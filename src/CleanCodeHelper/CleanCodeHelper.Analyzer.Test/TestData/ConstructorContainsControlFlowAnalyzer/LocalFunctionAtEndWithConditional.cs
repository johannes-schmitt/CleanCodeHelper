using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorContainsControlFlowAnalyzer
{
    [ExpectedDiagnostic("CC0005", Arguments = new object[] { nameof(LocalFunctionAtEndWithConditional) }, Line = 9, Column = 16)]
    public class LocalFunctionAtEndWithConditional
    {
        public LocalFunctionAtEndWithConditional()
        {
            static void LocalFunction()
            {
                do
                {
                    Console.WriteLine();
                } while (new Random().Next() % 2 == 0);
            }

            LocalFunction();
        }
    }
}