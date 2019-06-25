using System.Collections.Generic;
using System.Linq;
using Pixey.PixeyScript.Syntax;
using Sprache;

namespace Pixey.PixeyScript.Grammar
{
    internal partial class PixeyScriptGrammar
    {
        public PixeyScriptGrammar()
        {
            CommentParser = new CommentParser();
        }

        private IComment CommentParser { get; }

        private static readonly IReadOnlyList<string> ReservedKeywords = new[]
        {
            "print"
        };

        protected internal virtual Parser<string> RawIdentifier =>
            from identifier in Parse.Identifier(Parse.Letter, Parse.LetterOrDigit.Or(Parse.Char('_')))
             where !ReservedKeywords.Contains(identifier)
            select identifier;

        protected internal virtual Parser<string> Identifier =>
            RawIdentifier.Token().Named("Identifier");

        protected internal virtual Parser<string> Keyword(string text) =>
            Parse.IgnoreCase(text).Then(n => Parse.Not(Parse.LetterOrDigit.Or(Parse.Char('_')))).Return(text);

        protected internal virtual Parser<StatementSyntax> Statement =>
            from statement in ConstantAssignmentStatement
            from semicolon in Parse.Char(';').Token() 
            select statement;

        protected internal virtual Parser<ConstantAssignmentSyntax> ConstantAssignmentStatement =>
            from keyword in Keyword("const")
            from whitespace1 in Parse.WhiteSpace.Many()
            from varName in Identifier
            from whitespace2 in Parse.WhiteSpace.Many()
            from assignmentSign in Keyword("=")
            from whitespace3 in Parse.WhiteSpace.Many()
            from literal in StringLiteral
            select new ConstantAssignmentSyntax(varName, literal);

        protected internal virtual Parser<BlockSyntax> Block =>
            from comments in CommentParser.AnyComment.Token().Many()
            from openBrace in Parse.Char('{').Token()
            from statements in Statement.Many()
            from closeBrace in Parse.Char('}').Token()
            select new BlockSyntax(statements.ToList());

        protected internal virtual Parser<FunctionDeclarationSyntax> Function =>
            //from whitespace in Parse.WhiteSpace.Many()
            //from comments in CommentParser.AnyComment
            from keyword in Keyword(PixeyScriptKeywords.Function)
            from identifier in Identifier
            from parenthesis in Keyword("()")
            from block in Block
            select new FunctionDeclarationSyntax(identifier, block);

        protected internal virtual Parser<ScriptSyntax> Script =>
            from functions in Function.Many()
            select new ScriptSyntax(functions.ToList());
    }
}