using System;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using UmbracoGo.Web.ExtensionMethods;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.DocumentTypes.WebPages;
using Zone.UmbracoMapper;

namespace UmbracoGo.Web.Factories
{
    public class CurrentPageMapperFactory : ICurrentPageMapperFactory
    {
        private readonly IUmbracoMapper _umbracoMapper;

        public CurrentPageMapperFactory()
        {
            _umbracoMapper = new UmbracoMapper();
        }

        public Website MapWebsite(IPublishedContent currentPage)
        {
            IPublishedContent websitePage = currentPage.AncestorsOrSelf("Website").FirstOrDefault();

            if (websitePage == null)
            {
                throw new NullReferenceException("No ancestor or self Website document type found.");
            }

            var website = new Website();
            _umbracoMapper.Map(websitePage, website);

            return website;
        }

        public WebPage MapWebPage(IPublishedContent currentPage)
        {
            var webPage = new WebPage();
            _umbracoMapper.Map(currentPage, webPage);

            Website website = MapWebsite(currentPage);

            webPage.SetFalloverValues(website);          

            return webPage;
        }
    }
}