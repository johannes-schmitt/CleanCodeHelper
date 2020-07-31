using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.FlagParametersAnalyzer
{
    [ExpectedDiagnostic("CC0009", Arguments = new object[] { "someArgument" }, Line = 11, Column = 32)]
    [ExpectedDiagnostic("CC0009", Arguments = new object[] { "someArgument" }, Line = 16, Column = 32)]
    [ExpectedDiagnostic("CC0009", Arguments = new object[] { "anotherArgument" }, Line = 16, Column = 51)]
    public class MethodWithBooleanArguments
    {
        public void SomeMethod(bool someArgument)
        {
            Console.WriteLine(someArgument);
        }

        public void SomeMethod(bool someArgument, bool anotherArgument)
        {
            Console.WriteLine(someArgument);
        }
    }
}