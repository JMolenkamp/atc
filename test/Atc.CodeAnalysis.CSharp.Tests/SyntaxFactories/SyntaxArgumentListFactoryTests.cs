using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Xunit;

namespace Atc.CodeAnalysis.CSharp.Tests.SyntaxFactories
{
    public class SyntaxArgumentListFactoryTests
    {
        [Fact]
        public void CreateWithOneItem()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.Argument(
                        SyntaxFactory.IdentifierName("hallo"))));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithOneItem("hallo");

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithTwoItems()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("bar")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithTwoItems("foo", "bar");

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithOneArgumentItem()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithOneArgumentItem(
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("foo")));

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithTwoArgumentItems()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("bar")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithTwoArgumentItems(
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("foo")),
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("bar")));

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithThreeArgumentItems()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("bar")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("baz")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithThreeArgumentItems(
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("foo")),
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("bar")),
                SyntaxFactory.Argument(
                    SyntaxFactory.IdentifierName("baz")));

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithOneExpressionItem()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithOneExpressionItem(
                SyntaxFactory.IdentifierName("foo"));

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithTwoExpressionItems()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("bar")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithTwoExpressionItems(
                SyntaxFactory.IdentifierName("foo"),
                SyntaxFactory.IdentifierName("bar"));

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }

        [Fact]
        public void CreateWithThreeExpressionItems()
        {
            // Arrange
            var expected = SyntaxFactory.ArgumentList(
                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                    new SyntaxNodeOrToken[]
                    {
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("foo")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("bar")),
                        SyntaxFactory.Token(SyntaxTriviaList.Empty, SyntaxKind.CommaToken,  new SyntaxTriviaList(SyntaxFactory.Space)),
                        SyntaxFactory.Argument(
                            SyntaxFactory.IdentifierName("baz")),
                    }));

            // Act
            var actual = SyntaxArgumentListFactory.CreateWithThreeExpressionItems(
                SyntaxFactory.IdentifierName("foo"),
                SyntaxFactory.IdentifierName("bar"),
                SyntaxFactory.IdentifierName("baz"));

            // Assert
            Assert.Equal(expected.ToFullString(), actual.ToFullString());
        }
    }
}