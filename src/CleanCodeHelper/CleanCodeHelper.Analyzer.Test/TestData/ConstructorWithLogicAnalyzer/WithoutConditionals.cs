using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
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