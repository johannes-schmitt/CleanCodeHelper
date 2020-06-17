using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CleanCodeHelper.Analyzer.Test.Helper
{
    public class AnnotatedSourceFile
    {
        public FileInfo File { get; }
        public string Content { get; }

        public AnnotatedSourceFile(string filePath)
        {
            File = new FileInfo(filePath);
            Content = System.IO.File.ReadAllText(File.FullName) +
                      System.IO.File.ReadAllText(GetSourcePath<ExpectedDiagnosticAttribute>()) +
                      System.IO.File.ReadAllText(GetSourcePath<NoExpectedDiagnosticAttribute>());
        }

        public override string ToString()
        {
            return File.Name;
        }

        public Type LoadType()
        {
            var ns = GetNamespace();

            var sourceTypeName = $"{ns}.{Path.GetFileNameWithoutExtension(File.FullName)}";

            return Assembly.GetExecutingAssembly().GetType(sourceTypeName, true, true)!;
        }

        private string GetNamespace()
        {
            var relativePathToSource = Path.GetRelativePath(Path.GetDirectoryName(GetThisSourcePath())!, File.FullName);
            var currentNamespace = GetType().Namespace;

            for (var i = 0; relativePathToSource.IndexOf("..", i, StringComparison.Ordinal) != -1; i += 2)
            {
                currentNamespace = currentNamespace!.Substring(0, currentNamespace.LastIndexOf(".", StringComparison.Ordinal));
            }

            return $"{currentNamespace}.{Path.GetDirectoryName(relativePathToSource)!.TrimStart('.').TrimStart('\\').Replace('\\', '.')}";
        }

        private static string GetSourcePath<T>([CallerFilePath] string? callerFilePath = null)
        {
            if (callerFilePath == null)
            {
                throw new ArgumentNullException(nameof(callerFilePath));
            }

            return Path.Combine(Path.GetDirectoryName(callerFilePath)!, $"{typeof(T).Name}.cs");
        }

        private static string GetThisSourcePath([CallerFilePath] string? callerFilePath = null)
        {
            if (callerFilePath == null)
            {
                throw new ArgumentNullException(nameof(callerFilePath));
            }

            return callerFilePath;
        }
    }
}
