using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CleanCodeHelper.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class TooManyParametersAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CC0006";

        private static readonly LocalizableString Title = @"Method contains too many parameters.";
        private static readonly LocalizableString MessageFormat = @"'{0}' contains more than 3 parameters.";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Categories.CleanCode, DiagnosticSeverity.Warning, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "context is never null")]
        [SuppressMessage("CleanCode", "CC0006:Classes should use the constructor for initialization code.", Justification = "method comes from base class")]
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.MethodDeclaration, SyntaxKind.LocalFunctionStatement);
        }

        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            switch (context.Node)
            {
                case MethodDeclarationSyntax method:
                    AnalyzeMethod(method, context);
                    break;
                case LocalFunctionStatementSyntax localFunction:
                    AnalyzeLocalFunction(localFunction, context);
                    break;
            }
        }

        private static void AnalyzeMethod(MethodDeclarationSyntax method, SyntaxNodeAnalysisContext context)
        {
            if (HasTooManyParameters(method))
            {
                var location = method.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, method.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static void AnalyzeLocalFunction(LocalFunctionStatementSyntax localFunction, SyntaxNodeAnalysisContext context)
        {
            if (HasTooManyParameters(localFunction))
            {
                var location = localFunction.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, localFunction.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static bool HasTooManyParameters(BaseMethodDeclarationSyntax method)
        {
            return IsTooLong(method.ParameterList);
        }

        private static bool HasTooManyParameters(LocalFunctionStatementSyntax localFunction)
        {
            return IsTooLong(localFunction.ParameterList);
        }

        private static bool IsTooLong(BaseParameterListSyntax parameterListSyntax)
        {
            return parameterListSyntax.Parameters.Count > 3;
        }
    }
}