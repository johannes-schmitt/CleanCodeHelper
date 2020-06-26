using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorContainsControlFlowAnalyzer
{
    [NoExpectedDiagnostic]
    public class WithoutConditionals
    {
        private int _someValue;

        public WithoutConditionals(int someValue)
        {
            _someValue = someValue;
        }
    }
}