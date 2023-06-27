using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchParser.Parser
{
    public class HtmlDocument
    {
        private Dictionary<string, HtmlNode> NodesById { get; set; } = new();
        private Dictionary<string, HtmlNode> NodesByClass { get; set; } = new();

        private List<HtmlNode> HtmlNodes { get; set; } = new();

        public void LoadHtml(string html)
        {
            
        }
    }

    public class HtmlNode
    {        
        public string NodeType { get; set; }
        public string InnerText { get; set; }
        public HtmlNode InnerHtml { get; set; }
    }
}
