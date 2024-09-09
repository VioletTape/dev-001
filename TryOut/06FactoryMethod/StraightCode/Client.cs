using TryOut.FactoryMethod.Refactored;

namespace TryOut.FactoryMethod.StraightCode {
    public class Client {
        public void Do() {
            var parser = new Parser();
            parser.StringNodeDecode = true;
            parser.RemoveEscapeCharacters = true;
            var result = parser.Parse("lalala");
        }
    }

    internal class Parser
    {
        private static readonly NodeFactory NodeFactory = new();
        public bool StringNodeDecode { get; set; }
        public bool RemoveEscapeCharacters { get; set; }

        public Node Parse(string url)
        {
            if (RemoveEscapeCharacters)
            {
                url = url.Replace("\t", "");
            }

            if (StringNodeDecode)
            {
                url = url.ToUpper();
            }

            return NodeFactory.Create(url);
        }
    }
}