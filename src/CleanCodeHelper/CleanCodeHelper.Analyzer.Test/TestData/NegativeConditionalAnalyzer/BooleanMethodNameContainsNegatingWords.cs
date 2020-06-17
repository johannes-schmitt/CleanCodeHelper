using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.NegativeConditionalAnalyzer
{
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(ShouldNotDoSomething) }, Line = 13, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(DoesNotDoSomething) }, Line = 18, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(IsNotSomething) }, Line = 23, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(IsNotSomeNotepad) }, Line = 28, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(IsNotarizedNot) }, Line = 33, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(HasNoGoodName) }, Line = 38, Column = 21)]
    public class BooleanMethodNameContainsNegatingWords
    {
        public bool ShouldNotDoSomething()
        {
            return default;
        }

        public bool DoesNotDoSomething()
        {
            return default;
        }

        public bool IsNotSomething()
        {
            return default;
        }

        public bool IsNotSomeNotepad()
        {
            return default;
        }

        public bool IsNotarizedNot()
        {
            return default;
        }

        public bool HasNoGoodName()
        {
            return default;
        }
    }
}