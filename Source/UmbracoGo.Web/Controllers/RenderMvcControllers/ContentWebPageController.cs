using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.WebPages.ContentPages;

namespace UmbracoGo.Web.Controllers.RenderMvcControllers
{
    public partial class ContentWebPageController : RenderMvcController
    {
        private readonly ICurrentPageMapperFactory _currentPageMapperFactory;

        public ContentWebPageController(ICurrentPageMapperFactory currentPageMapperFactory)
        {
            _currentPageMapperFactory = currentPageMapperFactory;
        }

        public override ActionResult Index(RenderModel model)
        {
            var contentWebPage = _currentPageMapperFactory.CreateWebPage<ContentWebPage>(CurrentPage);
            return CurrentTemplate(contentWebPage);
        }
    }
}