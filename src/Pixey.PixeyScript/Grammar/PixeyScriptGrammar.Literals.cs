using System.Collections.Generic;
using Sprache;

namespace Pixey.PixeyScript.Grammar
{
    internal partial class PixeyScriptGrammar
    {
        protected internal virtual Parser<IEnumerable<char>> StringLiteral =>
            from openQuote in Parse.Char('"').Token()
            from value in Parse.LetterOrDigit.Many()
            from closeQuote in Parse.Char('"').Token()
            select value;
    }
}
