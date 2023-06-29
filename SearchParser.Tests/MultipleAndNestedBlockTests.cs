using SearchParser.Parser;
using Shouldly;

namespace SearchParser.Tests
{
    public class MultipleAndNestedBlockTests
    {
        private HtmlDocument _htmlDocument = new();

        public MultipleAndNestedBlockTests()
        {
            _htmlDocument.LoadHtml("<div> Child One </div>" +
                                   "<div> Child Two </div>" +
                                   "<div id='ParentId'> Parent <div id='ChildId'> Child Div </div> </div>");
        }

        public void HasFourNodes()
        {
            _htmlDocument.HtmlNodes.Count.ShouldBe(4);
        }

        public void GetNestedChild()
        {
            var node = _htmlDocument.GetNodeById("ParentId");

            node.ShouldNotBeNull();

            node.InnerNode.ShouldNotBeNull();
            node.InnerNode.HtmlAttributes["id"].ShouldBe("ChildId");
            node.InnerNode.InnerText.ShouldBe("Child Div");
        }
    }
}
