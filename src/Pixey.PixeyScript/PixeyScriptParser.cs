using Pixey.PixeyScript.Grammar;
using Pixey.PixeyScript.Syntax;
using Sprache;

namespace Pixey.PixeyScript
{
    public class PixeyScriptParser
    {
        private static PixeyScriptGrammar Grammar { get; } = new PixeyScriptGrammar();

        public static ScriptSyntax Parse(string script)
        {
            return Grammar.Script.Parse(script);
        }
    }
}
