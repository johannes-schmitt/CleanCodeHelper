namespace CleanCodeHelper.Analyzer.Test.Helper
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    public class ExpectedDiagnosticAttribute : System.Attribute
    {
        public string DiagnosticId { get; }

        public ExpectedDiagnosticAttribute(string diagnosticId)
        {
            DiagnosticId = diagnosticId;
        }

        public int Line { get; set; }
        public int Column { get; set; }
        public object[] Arguments { get; set; } = { };
    }
}