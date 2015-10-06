using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoGo.Web.Controllers.RenderMvcControllers
{
    public partial class HomeLandingPageController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            return CurrentTemplate(model);
        }
    }
}