using UmbracoGo.Web.Models.ViewModels;
using Zone.UmbracoMapper;

namespace UmbracoGo.Web.Models.DocumentTypes.SiteData
{
    public class Website : BaseNodeViewModel 
    {
        public string SiteName { get; set; }
        public NavigationViewModel MainNavigation { get; set; }
    }
}