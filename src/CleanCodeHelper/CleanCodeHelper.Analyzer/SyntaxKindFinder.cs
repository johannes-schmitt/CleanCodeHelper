using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace CleanCodeHelper.Analyzer
{
    public static class SyntaxKindFinder
    {
        public static IEnumerable<SyntaxNode> Find(SyntaxNode node, params SyntaxKind[] syntaxKinds)
        {
            var syntaxWalker = new SyntaxWalker(syntaxKinds);
            syntaxWalker.Visit(node);

            return syntaxWalker.FoundNodes;
        }

        private class SyntaxWalker : CSharpSyntaxWalker
        {
            private SyntaxNode _root;

            private readonly SyntaxKind[] _syntaxKinds;

            public SyntaxWalker(SyntaxKind[] syntaxKinds)
            {
                _syntaxKinds = syntaxKinds;
            }

            private readonly List<SyntaxNode> _foundNodes = new List<SyntaxNode>();

            public IEnumerable<SyntaxNode> FoundNodes => _foundNodes;

            public override void Visit(SyntaxNode node)
            {
                _root ??= node;

                if ((IsRoot(node) || !IsInLocalFunction(node)) && _syntaxKinds.Contains(node.Kind()))
                {
                    _foundNodes.Add(node);
                }

                base.Visit(node);
            }

            private bool IsInLocalFunction(SyntaxNode node)
            {
                var parent = node.Parent;
                if (parent == null)
                {
                    return false;
                }

                if (IsRoot(parent))
                {
                    return false;
                }

                if (parent.Kind() == SyntaxKind.LocalFunctionStatement)
                {
                    return true;
                }

                return IsInLocalFunction(parent);
            }

            private bool IsRoot(SyntaxNode node)
            {
                return node == _root;
            }
        }
    }
}