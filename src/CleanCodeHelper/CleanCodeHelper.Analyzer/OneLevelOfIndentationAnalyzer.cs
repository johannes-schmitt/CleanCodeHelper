using System.Collections.Generic;
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
    public class OneLevelOfIndentationAnalyzer : DiagnosticAnalyzer
    {
        public const string MethodDiagnosticId = "CC0001";
        public const string ConstructorDiagnosticId = "CC0002";
        public const string LocalFunctionDiagnosticId = "CC0003";

        private static readonly LocalizableString MethodTitle = @"Use one level of indentation per method.";
        private static readonly LocalizableString ConstructorTitle = @"Use one level of indentation per constructor.";
        private static readonly LocalizableString LocalFunctionTitle = @"Use one level of indentation per local function.";
        private static readonly LocalizableString MessageFormat = @"'{0}' contains more than 1 level of indentation.";

        private static readonly DiagnosticDescriptor MethodRule = new DiagnosticDescriptor(MethodDiagnosticId, MethodTitle, MessageFormat, Categories.Maintainability, DiagnosticSeverity.Warning, isEnabledByDefault: true);
        private static readonly DiagnosticDescriptor ConstructorRule = new DiagnosticDescriptor(ConstructorDiagnosticId, ConstructorTitle, MessageFormat, Categories.Maintainability, DiagnosticSeverity.Warning, isEnabledByDefault: true);
        private static readonly DiagnosticDescriptor LocalFunctionRule = new DiagnosticDescriptor(LocalFunctionDiagnosticId, LocalFunctionTitle, MessageFormat, Categories.Maintainability, DiagnosticSeverity.Warning, isEnabledByDefault: true);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(MethodRule, ConstructorRule, LocalFunctionRule);

        [SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "context is never null")]
        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxTreeAction(AnalyzeSyntaxTree);
        }

        private static void AnalyzeSyntaxTree(SyntaxTreeAnalysisContext context)
        {
            var compilationUnit = context.Tree.GetCompilationUnitRoot();

            var violationsFinder = new ViolationsFinder();
            violationsFinder.Visit(compilationUnit);
            foreach (var violation in violationsFinder.MethodViolations)
            {
                var location = violation.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(MethodRule, location, violation.Identifier);
                context.ReportDiagnostic(diagnostic);
            }

            foreach (var violation in violationsFinder.ConstructorViolations)
            {
                var location = violation.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(ConstructorRule, location, violation.Identifier);
                context.ReportDiagnostic(diagnostic);
            }

            foreach (var violation in violationsFinder.LocalFunctionViolations)
            {
                var location = violation.Identifier.GetLocation();
                var diagnostic = Diagnostic.Create(LocalFunctionRule, location, violation.Identifier);
                context.ReportDiagnostic(diagnostic);
            }
        }

        private class ViolationsFinder : CSharpSyntaxWalker
        {
            private readonly List<MethodDeclarationSyntax> _methodViolations = new List<MethodDeclarationSyntax>();
            private readonly List<ConstructorDeclarationSyntax> _constructorViolations = new List<ConstructorDeclarationSyntax>();
            private readonly List<LocalFunctionStatementSyntax> _localFunctionViolations = new List<LocalFunctionStatementSyntax>();

            public IEnumerable<MethodDeclarationSyntax> MethodViolations => _methodViolations;
            public IEnumerable<ConstructorDeclarationSyntax> ConstructorViolations => _constructorViolations;
            public IEnumerable<LocalFunctionStatementSyntax> LocalFunctionViolations => _localFunctionViolations;

            public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
            {
                if (ViolatesRule(node))
                {
                    _methodViolations.Add(node);
                }

                base.VisitMethodDeclaration(node);
            }

            public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
            {
                if (ViolatesRule(node))
                {
                    _constructorViolations.Add(node);
                }

                base.VisitConstructorDeclaration(node);
            }

            public override void VisitLocalFunctionStatement(LocalFunctionStatementSyntax node)
            {
                if (ViolatesRule(node))
                {
                    _localFunctionViolations.Add(node);
                }

                base.VisitLocalFunctionStatement(node);
            }

            private static bool ViolatesRule(SyntaxNode node)
            {
                var statementWalker = new StatementWalker();
                statementWalker.Visit(node);

                return statementWalker.NestingStatements.SelectMany(syntaxNode => syntaxNode.ChildNodes()).Any(ContainsNestedStatements);
            }

            private static bool ContainsNestedStatements(SyntaxNode node)
            {
                var childStatementWalker = new StatementWalker();
                childStatementWalker.Visit(node);
                if (childStatementWalker.NestingStatements.Any())
                {
                    return true;
                }

                return false;
            }
        }

        private class StatementWalker : CSharpSyntaxWalker
        {
            private SyntaxNode _root;

            private readonly SyntaxKind[] _statements =
            {
                SyntaxKind.IfStatement,
                SyntaxKind.ForStatement,
                SyntaxKind.ForEachStatement,
                SyntaxKind.DoStatement,
                SyntaxKind.WhileStatement,
                SyntaxKind.UsingStatement,
                SyntaxKind.ForEachStatement,
                SyntaxKind.TryStatement,
                SyntaxKind.LockStatement,
                SyntaxKind.SwitchStatement
            };

            private readonly List<SyntaxNode> _nestingStatements = new List<SyntaxNode>();

            public IEnumerable<SyntaxNode> NestingStatements => _nestingStatements;

            public override void Visit(SyntaxNode node)
            {
                if (_root == null)
                {
                    _root = node;
                }

                if (node.Kind() == SyntaxKind.LocalFunctionStatement &&
                    node != _root)
                {
                    // local functions are analyzed separately
                    return;
                }

                if (_statements.Contains(node.Kind()))
                {
                    _nestingStatements.Add(node);
                }

                base.Visit(node);
            }
        }
    }
}