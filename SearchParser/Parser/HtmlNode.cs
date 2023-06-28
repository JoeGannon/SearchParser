using System.Collections.Generic;

namespace SearchParser.Parser
{
    public class HtmlNode
    {   
        public string InnerText { get; set; }
        public HtmlNode InnerNode { get; set; }
        public Dictionary<string, string> HtmlAttributes { get; set; }
    }
}
