using System;
using System.Linq;
using CleanCodeHelper.Analyzer.Test.Helper;

namespace CleanCodeHelper.Analyzer.Test.TestData.OneLevelOfIndentationAnalyzer
{
    [NoExpectedDiagnostic]
    public class MethodAndConstructorWithOneIndentationOnly
    {
        public MethodAndConstructorWithOneIndentationOnly()
        {
            if (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }

            try
            {
                Console.WriteLine();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine();
            }
            finally
            {
                Console.WriteLine();
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }

            foreach (var _ in Enumerable.Range(0, 10))
            {
                Console.WriteLine();
            }

            do
            {
                Console.WriteLine();
            } while (new Random().Next() % 2 == 0);

            while (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }

            lock (new object())
            {
                Console.WriteLine();
            }

            using (var _ = new SomeDisposable())
            {
                Console.WriteLine();
            }

            switch (new Random().Next() % 2 == 0)
            {
                case true:
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

            SomeLocalFunction();

            static void SomeLocalFunction()
            {
                Console.WriteLine();
            }
        }

        public void SomeMethod()
        {
            if (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }

            try
            {
                Console.WriteLine();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine();
            }
            finally
            {
                Console.WriteLine();
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }

            foreach (var _ in Enumerable.Range(0, 10))
            {
                Console.WriteLine();
            }

            do
            {
                Console.WriteLine();
            } while (new Random().Next() % 2 == 0);

            while (new Random().Next() % 2 == 0)
            {
                Console.WriteLine();
            }

            lock (new object())
            {
                Console.WriteLine();
            }

            using (var _ = new SomeDisposable())
            {
                Console.WriteLine();
            }

            switch (new Random().Next() % 2 == 0)
            {
                case true:
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine();
                    break;
            }

            SomeLocalFunction();

            static void SomeLocalFunction()
            {
                Console.WriteLine();
            }
        }

        public class SomeDisposable : IDisposable
        {
            public void Dispose()
            {
            }
        }
    }
}