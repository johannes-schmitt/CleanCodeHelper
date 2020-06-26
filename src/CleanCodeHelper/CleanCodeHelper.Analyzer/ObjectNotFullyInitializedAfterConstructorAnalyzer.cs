using System;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CleanCodeHelper.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ObjectNotFullyInitializedAfterConstructorAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CC0006";

        private static readonly LocalizableString Title = @"Classes should use the constructor for initialization code.";
        private static readonly LocalizableString MessageFormat = @"'{0}' indicates that the class is not fully initialized after the constructor finished.";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Categories.CleanCode, DiagnosticSeverity.Warning, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "context is never null")]
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            var method = (MethodDeclarationSyntax)context.Node;

            if (ViolatesRule(method))
            {
                var location = method.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, method.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static bool ViolatesRule(MethodDeclarationSyntax method)
        {
            var disallowedWords = new[]
            {
                "Initialize",
                "Initialise",
                "Init"
            };

            var methodName = method.Identifier.ToString();
            return disallowedWords.Any(n => methodName.StartsWith(n, StringComparison.InvariantCulture));
        }
    }
}