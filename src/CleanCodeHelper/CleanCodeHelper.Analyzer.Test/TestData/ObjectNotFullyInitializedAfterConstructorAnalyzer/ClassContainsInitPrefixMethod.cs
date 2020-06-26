using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ObjectNotFullyInitializedAfterConstructorAnalyzer
{
    [ExpectedDiagnostic("CC0006", Arguments = new object[] { nameof(InitSomething) }, Line = 8, Column = 21)]
    public class ClassContainsInitPrefixMethod
    {
        public void InitSomething()
        {
        }
    }
}