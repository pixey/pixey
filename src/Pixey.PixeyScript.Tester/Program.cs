using System.IO;

namespace Pixey.PixeyScript.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var content = File.ReadAllText("Example.pixey");

            var parsed = PixeyScriptParser.Parse(content);
        }
    }
}
