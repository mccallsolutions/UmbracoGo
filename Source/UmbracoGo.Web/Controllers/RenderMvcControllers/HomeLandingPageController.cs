using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.WebPages.LandingPages;

namespace UmbracoGo.Web.Controllers.RenderMvcControllers
{
    public partial class HomeLandingPageController : RenderMvcController
    {
        private readonly ICurrentPageMapperFactory _currentPageMapperFactory;

        public HomeLandingPageController(ICurrentPageMapperFactory currentPageMapperFactory)
        {
            _currentPageMapperFactory = currentPageMapperFactory;
        }

        public override ActionResult Index(RenderModel model)
        {
            var homeLandingPage = _currentPageMapperFactory.CreateWebPage<HomeLandingPage>(CurrentPage);
            return CurrentTemplate(homeLandingPage);
        }
    }
}