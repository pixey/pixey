using Sprache;
using Xunit;

namespace Pixey.PixeyScript.UnitTests.Grammar
{
    public class IdentifierShould
    {
        private readonly PixeyScript.Grammar.PixeyScriptGrammar _grammar = new PixeyScript.Grammar.PixeyScriptGrammar();

        [Fact]
        public void ReturnIdentifierName()
        {
            var code = "Hello";

            var parsed = _grammar.Identifier.Parse(code);

            Assert.Equal("Hello", parsed);
        }
    }
}
