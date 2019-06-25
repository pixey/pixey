using Sprache;
using Xunit;

namespace Pixey.PixeyScript.UnitTests.Grammar.Procedures
{
    public class ProcedureShould
    {
        private readonly PixeyScript.Grammar.PixeyScriptGrammar _grammar = new PixeyScript.Grammar.PixeyScriptGrammar();

        [Fact]
        public void ReturnAllStatements()
        {
            var parsed = _grammar.Function.Parse(@"function Foo() { const A = ""Hello""; }");

            Assert.Equal("Foo", parsed.Name);

            Assert.Equal(1, parsed.Body.StatementDeclarations.Count);
        }
    }
}
