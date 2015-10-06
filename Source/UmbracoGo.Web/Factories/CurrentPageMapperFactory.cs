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
    /// <summary>
    /// This factory creates strongly typed document type POCOs from the CurrentPage passed in. This helps create clean view models and fallover values 
    /// for certain properties.
    /// </summary>
    public class CurrentPageMapperFactory : ICurrentPageMapperFactory
    {
        private readonly IUmbracoMapper _umbracoMapper;
        private Website _website;

        public CurrentPageMapperFactory(IUmbracoMapper umbracoMapper)
        {
            _umbracoMapper = umbracoMapper;
        }

        public Website CreateWebsite(IPublishedContent currentPage)
        {
            if (_website != null)
            {
                return _website;
            }

            IPublishedContent websitePage = currentPage.AncestorsOrSelf("Website").FirstOrDefault();

            if (websitePage == null)
            {
                throw new NullReferenceException("No ancestor or self Website document type found.");
            }

            _website = new Website();
            _umbracoMapper.Map(websitePage, _website);

            return _website;
        }        

        public T CreateWebPage<T>(IPublishedContent currentPage) where T : WebPage, new()
        {
            if (!typeof(WebPage).IsSameOrSubclass(typeof(T)))
            {
                throw new Exception(string.Format("Type {0} is not of type {1}", typeof (T).Name, typeof (WebPage).Name));
            }

            try
            {
                var t = new T();
                _umbracoMapper.Map(currentPage, t);

                Website website = CreateWebsite(currentPage);

                t.SetFalloverValues(website);

                return t;
            }
            catch
            {
                return null;
            }
        }
    }
}