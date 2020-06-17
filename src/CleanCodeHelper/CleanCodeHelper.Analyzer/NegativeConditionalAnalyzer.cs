using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CleanCodeHelper.Analyzer
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class NegativeConditionalAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "CC0004";

        private static readonly LocalizableString Title = @"Conditionals should be expressed as positives.";
        private static readonly LocalizableString MessageFormat = @"'{0}' is expressing a negative conditional.";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Categories.Maintainability, DiagnosticSeverity.Warning, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            if (context == null)
            {
                return;
            }

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
                case PropertyDeclarationSyntax property:
                    AnalyzeProperty(property, context);
                    break;
            }
        }

        private static void AnalyzeProperty(PropertyDeclarationSyntax property, SyntaxNodeAnalysisContext context)
        {
            if (IsBoolean(property.Type) &&
                ViolatesRule(property.Identifier))
            {
                var location = property.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, property.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static void AnalyzeMethod(MethodDeclarationSyntax method, SyntaxNodeAnalysisContext context)
        {
            if (IsBoolean(method.ReturnType) &&
                ViolatesRule(method.Identifier))
            {
                var location = method.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(Rule, location, method.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private static bool IsBoolean(TypeSyntax type)
        {
            return type is PredefinedTypeSyntax pts &&
                   pts.Keyword.Kind() == SyntaxKind.BoolKeyword;
        }

        private static bool ViolatesRule(SyntaxToken identifier)
        {
            var name = identifier.ToString();

            var disallowedWords = new[] { "No", "Not" };

            return disallowedWords.Any(disallowedWord => ContainsWord(name, disallowedWord));
        }

        private static bool ContainsWord(string input, string word)
        {
            for (var idx = input.IndexOf(word, 0, StringComparison.OrdinalIgnoreCase);
                idx != -1;
                idx = input.IndexOf(word, idx + 1, StringComparison.OrdinalIgnoreCase))
            {
                var subString = input.Substring(idx);

                if (subString.Length == word.Length ||
                    subString.Length > word.Length && !char.IsLower(subString[word.Length]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}