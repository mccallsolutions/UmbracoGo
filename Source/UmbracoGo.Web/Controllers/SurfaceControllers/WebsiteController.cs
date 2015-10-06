using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;

namespace UmbracoGo.Web.Controllers.SurfaceControllers
{
    public partial class WebsiteController : SurfaceController
    {
        private readonly ICurrentPageMapperFactory _currentPageMapperFactory;

        public WebsiteController(ICurrentPageMapperFactory currentPageMapperFactory)
        {
            _currentPageMapperFactory = currentPageMapperFactory;
        }

        public virtual ActionResult SiteName()
        {
            Website website = _currentPageMapperFactory.MapWebsite(CurrentPage);
            return PartialView(MVC.Website.Views._SiteName, website.SiteName);
        }
    }
}