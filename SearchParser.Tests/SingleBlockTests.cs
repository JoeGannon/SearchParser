
using SearchParser.Parser;
using Shouldly;
using System.Linq;

namespace SearchParser.Tests
{
    public class SingleBlockTests
    {
        private HtmlDocument _htmlDocument = new();

        public SingleBlockTests()
        {
            _htmlDocument.LoadHtml("<div id='Id' class='Class'> test </div>");
        }

        public void HasSingleNode()
        {
            _htmlDocument.HtmlNodes.Count().ShouldBe(1);
        }

        public void SetInnerText()
        {
            var htmlNode = _htmlDocument.HtmlNodes.Single();

            htmlNode.InnerText.ShouldBe("test");
        }

        public void SetAttributes()
        {
            var htmlNode = _htmlDocument.HtmlNodes.Single();

            htmlNode.HtmlAttributes["id"].ShouldBe("Id");
            htmlNode.HtmlAttributes["class"].ShouldBe("Class");
        }

        public void GetById()
        {
            var htmlNode = _htmlDocument.GetNodeById("Id");

            htmlNode.ShouldNotBeNull();
        }

        public void HasNullNodeIfNotFound()
        {
            var htmlNode = _htmlDocument.GetNodeById("NullId");

            htmlNode.ShouldBeNull();
        }

        public void HasNullInnerNode()
        {
            var htmlNode = _htmlDocument.HtmlNodes.Single();

            htmlNode.InnerNode.ShouldBeNull();
        }
    }
}
