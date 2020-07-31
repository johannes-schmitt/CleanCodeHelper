using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.FlagParametersAnalyzer
{
    [NoExpectedDiagnostic]
    public class MethodWithoutBooleanArguments
    {
        public void SomeMethod()
        {
            Console.WriteLine();
        }
    }
}