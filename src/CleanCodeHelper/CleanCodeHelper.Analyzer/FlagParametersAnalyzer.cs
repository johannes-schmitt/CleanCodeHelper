using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CleanCodeHelper.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class FlagParametersAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CC0009";

        private static readonly LocalizableString Title = @"Method contains flag parameters.";
        private static readonly LocalizableString MessageFormat = @"'{0}' is a flag parameter.";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Categories.CleanCode, DiagnosticSeverity.Warning, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "context is never null")]
        [SuppressMessage("CleanCode", "CC0006:Classes should use the constructor for initialization code.", Justification = "method comes from base class")]
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.MethodDeclaration, SyntaxKind.PropertyDeclaration);
        }

        private void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            switch (context.Node)
            {
                case MethodDeclarationSyntax method:
                    AnalyzeMethod(method, context);
                    break;
            }
        }

        private static void AnalyzeMethod(MethodDeclarationSyntax method, SyntaxNodeAnalysisContext context)
        {
            foreach (var parameter in method.ParameterList.Parameters)
            {
                AnalyzeParameter(parameter, context);
            }
        }

        private static void AnalyzeParameter(ParameterSyntax parameter, SyntaxNodeAnalysisContext context)
        {
            if (IsBoolean(parameter.Type))
            {
                var location = parameter.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, parameter.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static bool IsBoolean(TypeSyntax type)
        {
            return type is PredefinedTypeSyntax pts &&
                   pts.Keyword.Kind() == SyntaxKind.BoolKeyword;
        }
    }
}