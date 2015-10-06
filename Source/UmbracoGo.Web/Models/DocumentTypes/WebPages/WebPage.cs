using Zone.UmbracoMapper;

namespace UmbracoGo.Web.Models.DocumentTypes.WebPages
{
    public class WebPage : BaseNodeViewModel 
    {
        // Content tab
        public string PageTitle { get; set; }
        public string MenuTitle { get; set; }
        // SEO tab
        public string MetaTitle { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        // Generic tab
        public bool HideInNavigation { get; set; }
        public bool ExcludeFromSearch { get; set; }
        public string UrlAlias { get; set; }
    }
}