using Pixey.PixeyScript.Syntax;
using Sprache;
using Xunit;

namespace Pixey.PixeyScript.UnitTests.Grammar
{
    public class BlockShould
    {
        private readonly PixeyScript.Grammar.PixeyScriptGrammar _grammar = new PixeyScript.Grammar.PixeyScriptGrammar();

        [Theory]
        [InlineData("{const a=\"A\";const b=\"B\";}")]
        [InlineData("{const a= \"A\"; const b= \"B\"; }")]
        public void ReturnAllStatements(string code)
        {
            var parsed = _grammar.Block.Parse(code);

            Assert.Equal(2, parsed.StatementDeclarations.Count);

            Assert.Equal("a", ((ConstantAssignmentSyntax)parsed.StatementDeclarations[0]).VariableName);
            Assert.Equal("b", ((ConstantAssignmentSyntax)parsed.StatementDeclarations[1]).VariableName);
        }
    }
}
