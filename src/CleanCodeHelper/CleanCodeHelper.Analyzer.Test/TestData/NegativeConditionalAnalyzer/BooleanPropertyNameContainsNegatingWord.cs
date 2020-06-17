using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.NegativeConditionalAnalyzer
{
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(ShouldNotDoSomething) }, Line = 14, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(DoesNotDoSomething) }, Line = 27, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(IsNotSomething) }, Line = 29, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(IsNotSomeNotepad) }, Line = 31, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(IsNotarizedNot) }, Line = 33, Column = 21)]
    [ExpectedDiagnostic("CC0004", Arguments = new object[] { nameof(HasNoGoodName) }, Line = 35, Column = 21)]
    public class BooleanPropertyNameContainsNegatingWord
    {
        private bool _shouldNotDoSomething = false;
        public bool ShouldNotDoSomething
        {

            get
            {
                return _shouldNotDoSomething;
            }
            set
            {
                _shouldNotDoSomething = value;
            }
        }

        public bool DoesNotDoSomething => true;

        public bool IsNotSomething { get; set; }

        public bool IsNotSomeNotepad { get; set; }

        public bool IsNotarizedNot { get; set; }

        public bool HasNoGoodName { get; set; }
    }
}