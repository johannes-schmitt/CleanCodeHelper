using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ObjectNotFullyInitializedAfterConstructorAnalyzer
{
    [ExpectedDiagnostic("CC0006", Arguments = new object[] { nameof(InitialiseSomething) }, Line = 8, Column = 21)]
    public class ClassContainsInitialisePrefixMethod
    {
        public void InitialiseSomething()
        {
        }
    }
}