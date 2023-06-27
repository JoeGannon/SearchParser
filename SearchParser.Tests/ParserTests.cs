
using SearchParser.Parser;

namespace SearchParser.Tests
{
    public class ParserTests
    {
        public void ReadSingleNode()
        {
            var document = new HtmlDocument();

            document.LoadHtml("<div> test </div>");

        }
    }
}
