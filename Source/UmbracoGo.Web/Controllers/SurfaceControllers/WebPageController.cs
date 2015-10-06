using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.WebPages;

namespace UmbracoGo.Web.Controllers.SurfaceControllers
{
    public partial class WebPageController : SurfaceController
    {
        private readonly ICurrentPageMapperFactory _currentPageMapperFactory;

        public WebPageController(ICurrentPageMapperFactory currentPageMapperFactory)
        {
            _currentPageMapperFactory = currentPageMapperFactory;
        }

        public virtual ActionResult MetaTitle()
        {
            var webPage = _currentPageMapperFactory.CreateWebPage<WebPage>(CurrentPage);
            return PartialView(MVC.WebPage.Views._MetaTitle, webPage.MetaTitle);
        }

        public virtual ActionResult MetaElements()
        {
            var webPage = _currentPageMapperFactory.CreateWebPage<WebPage>(CurrentPage);
            return PartialView(MVC.WebPage.Views._MetaElements, webPage);
        }
    }
}