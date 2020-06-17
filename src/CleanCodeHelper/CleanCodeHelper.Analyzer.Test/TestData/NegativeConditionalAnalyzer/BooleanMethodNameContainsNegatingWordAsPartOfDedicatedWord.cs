using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.NegativeConditionalAnalyzer
{
    [NoExpectedDiagnostic]
    public class BooleanMethodNameContainsNegatingWordAsPartOfDedicatedWord
    {
        public bool Notarize()
        {
            return default;
        }

        public bool IsNotepad()
        {
            return default;
        }

        public bool IsNoble()
        {
            return default;
        }
    }
}