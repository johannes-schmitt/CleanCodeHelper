using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CleanCodeHelper.Analyzer
{
    [DiagnosticAnalyzer((LanguageNames.CSharp))]
    public class ConstructorWithLogicAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CC0005";

        private static readonly LocalizableString Title = @"Constructors should not contain any conditional logic.";
        private static readonly LocalizableString MessageFormat = @"'{0}' is containing conditional logic.";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Categories.Maintainability, DiagnosticSeverity.Warning, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "context is never null")]
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(AnalyzeConstructor, SyntaxKind.ConstructorDeclaration);
        }

        private static void AnalyzeConstructor(SyntaxNodeAnalysisContext context)
        {
            var conditionals = new[]
            {
                SyntaxKind.IfStatement,
                SyntaxKind.DoStatement,
                SyntaxKind.ForEachStatement,
                SyntaxKind.ForStatement,
                SyntaxKind.IfStatement,
                SyntaxKind.SwitchStatement,
                SyntaxKind.WhileStatement,
                SyntaxKind.ConditionalExpression,
                SyntaxKind.SwitchExpression
            };

            var constructor = (ConstructorDeclarationSyntax)context.Node;

            if (SyntaxKindFinder.Find(constructor, conditionals).Any())
            {
                var location = constructor.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, constructor.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }
}