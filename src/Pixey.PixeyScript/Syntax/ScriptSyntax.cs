using System.Collections.Generic;

namespace Pixey.PixeyScript.Syntax
{
    public class ScriptSyntax
    {
        public IReadOnlyList<FunctionDeclarationSyntax> Functions { get; }

        public ScriptSyntax(IReadOnlyList<FunctionDeclarationSyntax> functions)
        {
            Functions = functions;
        }
    }
}