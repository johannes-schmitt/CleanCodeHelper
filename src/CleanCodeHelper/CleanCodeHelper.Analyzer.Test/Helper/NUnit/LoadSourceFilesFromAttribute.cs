using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Builders;

namespace CleanCodeHelper.Analyzer.Test.Helper.NUnit
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class LoadSourceFilesFromAttribute : Attribute, ITestBuilder
    {
        public string Path { get; }
        public SearchOption SearchOption { get; set; } = SearchOption.AllDirectories;

        public string SearchPattern { get; set; } = "*.cs";

        public LoadSourceFilesFromAttribute(string relativePath, [CallerFilePath] string? callerTestFile = null)
        {
            Path = callerTestFile != null
                ? System.IO.Path.Combine(System.IO.Path.GetDirectoryName(callerTestFile)!, relativePath)
                : relativePath;
        }

        public IEnumerable<TestMethod> BuildFrom(IMethodInfo method, global::NUnit.Framework.Internal.Test suite)
        {
            var builder = new NUnitTestCaseBuilder();
            foreach (var sourceFilePath in Directory.EnumerateFiles(Path, SearchPattern, SearchOption))
            {
                yield return builder.BuildTestMethod(
                    method,
                    suite,
                    new TestCaseParameters(new object[] { new AnnotatedSourceFile(sourceFilePath) }));
            }
        }
    }
}