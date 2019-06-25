using Sprache;
using Xunit;

namespace Pixey.PixeyScript.UnitTests.Grammar.Literals
{
    public class StringLiteralShould
    {
        private readonly PixeyScript.Grammar.PixeyScriptGrammar _grammar = new PixeyScript.Grammar.PixeyScriptGrammar();

        [Fact]
        public void ReturnStringValue()
        {
            var code = "\"Hello\"";

            var parsed = _grammar.StringLiteral.Parse(code);

            Assert.Equal("Hello", parsed);
        }
    }
}
