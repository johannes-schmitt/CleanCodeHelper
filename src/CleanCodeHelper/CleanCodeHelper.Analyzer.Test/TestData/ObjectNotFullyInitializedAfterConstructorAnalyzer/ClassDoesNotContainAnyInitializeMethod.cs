using System;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.ObjectNotFullyInitializedAfterConstructorAnalyzer
{
    [NoExpectedDiagnostic]
    public class ClassDoesNotContainAnyInitializeMethod
    {
        private readonly int _someValue;

        public ClassDoesNotContainAnyInitializeMethod(int someValue)
        {
            _someValue = someValue;
        }

        public void SomeMethod()
        {
            Console.WriteLine(_someValue);
        }

        public bool IsInitialized()
        {
            return new Random().Next() % 2 == 0;
        }
    }
}