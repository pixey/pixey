using System.Collections.Generic;

namespace Pixey.PixeyScript.Syntax
{
    public class FunctionDeclarationSyntax
    {
        public FunctionDeclarationSyntax(string name, BlockSyntax body)
        {
            Name = name;
            Body = body;
        }

        public string Name { get; }

        public BlockSyntax Body { get; }
    }

    public class BlockSyntax
    {
        public BlockSyntax(IReadOnlyList<StatementSyntax> statementDeclarations)
        {
            StatementDeclarations = statementDeclarations;
        }

        public IReadOnlyList<StatementSyntax> StatementDeclarations { get; }
    }

    public abstract class StatementSyntax
    {

    }

    public class ConstantAssignmentSyntax : StatementSyntax
    {
        public string VariableName { get; }

        public IEnumerable<char> Value { get; }

        public ConstantAssignmentSyntax(string variableName, IEnumerable<char> value)
        {
            VariableName = variableName;
            Value = value;
        }
    }
}