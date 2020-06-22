using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ConstructorWithLogicAnalyzer
{
    [NoExpectedDiagnostic]
    public class ConstructorWithoutConditionals
    {
        private int _someValue;

        public ConstructorWithoutConditionals(int someValue)
        {
            _someValue = someValue;
        }
    }
}