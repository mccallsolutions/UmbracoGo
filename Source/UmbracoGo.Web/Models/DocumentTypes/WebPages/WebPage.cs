using Zone.UmbracoMapper;

namespace UmbracoGo.Web.Models.DocumentTypes.WebPages
{
    public class WebPage : BaseNodeViewModel 
    {
        public string MetaTitle { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
    }
}