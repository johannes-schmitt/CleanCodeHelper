﻿using System.Threading.Tasks;
using CleanCodeHelper.Analyzer.Test.Helper;
using CleanCodeHelper.Analyzer.Test.Helper.NUnit;
using NUnit.Framework;

namespace CleanCodeHelper.Analyzer.Test
{
    public class ObjectNotFullyInitializedAfterConstructorAnalyzerTest
    {
        [Test, LoadSourceFilesFrom("TestData\\" + nameof(ObjectNotFullyInitializedAfterConstructorAnalyzer))]
        public async Task Verify(AnnotatedSourceFile sourceFile)
        {
            await sourceFile.VerifyAsync<ObjectNotFullyInitializedAfterConstructorAnalyzer>();
        }
    }
}