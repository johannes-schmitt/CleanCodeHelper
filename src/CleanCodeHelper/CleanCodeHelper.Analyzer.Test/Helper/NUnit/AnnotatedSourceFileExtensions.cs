using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Testing.NUnit;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace CleanCodeHelper.Analyzer.Test.Helper.NUnit
{
    public static class AnnotatedSourceFileExtensions
    {
        public static async Task VerifyAsync<TAnalyzer>(this AnnotatedSourceFile sourceFile)
            where TAnalyzer : DiagnosticAnalyzer, new()
        {
            var type = sourceFile.LoadType();

            var expectedDiagnostics = type.GetCustomAttributes<NoExpectedDiagnosticAttribute>().Any()
                ? Array.Empty<DiagnosticResult>()
                : type.GetCustomAttributes<ExpectedDiagnosticAttribute>()
                    .Select(d => AnalyzerVerifier<TAnalyzer>.Diagnostic(d.DiagnosticId)
                        .WithLocation(d.Line, d.Column)
                        .WithArguments(d.Arguments))
                    .ToArray();

            await AnalyzerVerifier<TAnalyzer>.VerifyAnalyzerAsync(sourceFile.Content, expectedDiagnostics);
        }
    }
}