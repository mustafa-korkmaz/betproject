
using System.Linq;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;


namespace Business.WebApi.Parsers
{
    /// <summary>
    /// this class uses angleSharp for html document parsing operations
    /// </summary>
    public class BetSiteParser
    {
        private readonly HtmlParser _parser;

        public static BetSiteParser Instance { get; } = new BetSiteParser();

        BetSiteParser()
        {
            _parser = new HtmlParser();
        }

        public IHtmlDocument Parse(string text)
        {
            return _parser.Parse(text);
        }

        public IHtmlCollection<IElement> QuerySelectorAll(IHtmlDocument document, string selectors)
        {
            return document.QuerySelectorAll(selectors);
        }

        public IElement QuerySelector(IHtmlDocument document, string selectors)
        {
            return document.QuerySelector(selectors);
        }

    }
}

