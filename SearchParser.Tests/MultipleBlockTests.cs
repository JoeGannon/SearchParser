using SearchParser.Parser;
using Shouldly;
using System.Linq;

namespace SearchParser.Tests
{
    public class MultipleBlockTests
    {
        private HtmlDocument _htmlDocument = new();

        public MultipleBlockTests()
        {
            _htmlDocument.LoadHtml("<div id='IdOne' class='TestClass'> Child One </div>" +
                                   "<div id='IdTwo' class='TestClass'> Child Two </div>");
        }

        public void HasMultipleNodes()
        {
            _htmlDocument.HtmlNodes.Count().ShouldBe(2);
        }

        public void ChildOneSetCorrectly()
        {
            var node = _htmlDocument.GetNodeById("IdOne");
            
            node.InnerText.ShouldBe("Child One");
            node.InnerNode.ShouldBeNull();
        }

        public void ChildTwoSetCorrectly()
        {
            var node = _htmlDocument.GetNodeById("IdTwo");
            
            node.InnerText.ShouldBe("Child Two");
            node.InnerNode.ShouldBeNull();
        }

        public void GetsMultipleNodesByClass()
        {
            var nodes = _htmlDocument.GetNodesBy("class", "TestClass");

            nodes.Count().ShouldBe(2);
        }
    }
}
