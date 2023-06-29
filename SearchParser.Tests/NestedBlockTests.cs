using SearchParser.Parser;
using Shouldly;

namespace SearchParser.Tests
{
    public class NestedBlockTests
    {
        private HtmlDocument _htmlDocument = new();

        public NestedBlockTests()
        {
            _htmlDocument.LoadHtml("<div id='ParentId'> Parent <div id='ChildId'> Child Div </div> </div>");
        }

        public void GetNestedChild()
        {
            var node = _htmlDocument.GetNodeById("ChildId");

            node.ShouldNotBeNull();
        }

        public void HasNestedNode()
        {
            var node = _htmlDocument.GetNodeById("ParentId");

            node.InnerText.ShouldBe("Parent");
            node.InnerNode.ShouldNotBeNull();
            node.InnerNode.InnerText.ShouldBe("Child Div");
        }
    }
}
