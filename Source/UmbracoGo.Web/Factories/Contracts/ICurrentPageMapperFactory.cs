using Umbraco.Core.Models;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.DocumentTypes.WebPages;

namespace UmbracoGo.Web.Factories.Contracts
{
    public interface ICurrentPageMapperFactory
    {
        Website MapWebsite(IPublishedContent currentPage);
        WebPage MapWebPage(IPublishedContent currentPage);
    }
}
