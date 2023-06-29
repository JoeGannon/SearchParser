using System.Collections.Generic;
using System.Linq;

namespace SearchParser.Parser
{
    public class HtmlDocument
    {
        private const int openDivLength = 4;
        private const int closeDivLength = 6;

        //todo should just capture all attributes
        private string[] _capturedAttributes = { "id", "class" };

        public List<HtmlNode> HtmlNodes { get; set; } = new();        

        public HtmlNode GetNodeById(string value) => GetNodesBy("id", value).FirstOrDefault();

        public IEnumerable<HtmlNode> GetNodesBy(string attribute, string value)
        {
            return HtmlNodes.Where(x =>
            {
                x.HtmlAttributes.TryGetValue(attribute, out string attributeValue);

                return attributeValue == value;
            }).ToList();
        }

        public void LoadHtml(string html)
        {
            LoadNodes(html, null);
        }

        //assumes proper html and standard spacing
        private void LoadNodes(string html, HtmlNode innerNode)
        {
            var closingTagIndex = html.IndexOf("</div>");

            var openDivIndex = html.IndexOf("<div", openDivLength);

            var hasNestedDiv = openDivIndex < closingTagIndex && openDivIndex != -1;

            if (hasNestedDiv)
            {
                var openingTagIndex = html.LastIndexOf("<div", closingTagIndex);

                var nestedDiv = html.Substring(openingTagIndex, closingTagIndex - openingTagIndex + closeDivLength);

                var node = GetHtmlNode(nestedDiv);
                
                HtmlNodes.Add(node);

                var outerNodeHtml = html.Replace(nestedDiv, "");

                LoadNodes(outerNodeHtml, node);
            }
            else
            {
                var htmlNode = html.Substring(html.IndexOf("<div"), closingTagIndex + closeDivLength);

                var node = GetHtmlNode(htmlNode);

                node.InnerNode = innerNode;

                HtmlNodes.Add(node);

                var slice = html.Substring(closingTagIndex + closeDivLength);

                if (!string.IsNullOrWhiteSpace(slice))
                    LoadNodes(slice, null);
            }
        }

        private HtmlNode GetHtmlNode(string htmlNode)
        {
            var startIndex = htmlNode.IndexOf(">") + 1;
            var endIndex = htmlNode.IndexOf("</div>");

            var innerText = htmlNode.Substring(startIndex, endIndex - startIndex).Trim();

            var openingTag = htmlNode.Substring(0, htmlNode.IndexOf(">"));
            var attributes = ReadAttributes(openingTag);

            return new HtmlNode
            {
                InnerText = innerText,
                HtmlAttributes = attributes
            };
        }

        private Dictionary<string, string> ReadAttributes(string openingTag)
        {
            var attributes = new Dictionary<string, string>();

            foreach (var attribute in _capturedAttributes)
            {
                if (openingTag.Contains(" " + attribute + "="))
                {
                    var enclosingQuote = openingTag.Split(attribute + "=")[1][0];

                    var value = openingTag.Split(attribute + $"={enclosingQuote}")[1];

                    value = value.Substring(0, value.IndexOf(enclosingQuote));

                    attributes.Add(attribute, value);
                }
            }

            return attributes;
        }
    }
}