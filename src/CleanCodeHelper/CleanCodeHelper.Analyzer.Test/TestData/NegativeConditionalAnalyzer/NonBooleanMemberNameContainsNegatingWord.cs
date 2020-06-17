using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.NegativeConditionalAnalyzer
{
    [NoExpectedDiagnostic]
    public class NonBooleanMemberNameContainsNegatingWord
    {
        public void ShouldNotDoSomething()
        {
        }

        public int DoesNotDoSomething()
        {
            return default;
        }

        public string IsNotSomething()
        {
            return string.Empty;
        }

        public int NoNoNo { get; set; }
    }
}