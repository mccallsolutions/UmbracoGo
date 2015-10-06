using Umbraco.Core.Models;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.DocumentTypes.WebPages;

namespace UmbracoGo.Web.Factories.Contracts
{
    public interface ICurrentPageMapperFactory
    {
        Website CreateWebsite(IPublishedContent currentPage);
        T CreateWebPage<T>(IPublishedContent currentPage) where T : WebPage, new();
    }
}
