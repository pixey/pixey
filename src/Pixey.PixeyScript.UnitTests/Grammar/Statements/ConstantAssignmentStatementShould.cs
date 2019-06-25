using Sprache;
using Xunit;

namespace Pixey.PixeyScript.UnitTests.Grammar.Statements
{
    public class ConstantAssignmentStatementShould
    {
        private readonly PixeyScript.Grammar.PixeyScriptGrammar _grammar = new PixeyScript.Grammar.PixeyScriptGrammar();

        [Fact]
        public void ParseStatement()
        {
            var code = "const varName = \"value\"";

            var parsed = _grammar.ConstantAssignmentStatement.Parse(code);

            Assert.Equal("varName", parsed.VariableName);
            Assert.Equal("value", parsed.Value);
        }
    }
}
