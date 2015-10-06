using System.Collections.Generic;
using System.Linq;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.DocumentTypes.WebPages;

namespace UmbracoGo.Web.ExtensionMethods
{
    public static class WebPageFalloverExtensionMethods
    {
        public static void SetFalloverValues(this WebPage webPage, Website website)
        {
            webPage.MetaTitle = FalloverMetaTitle(webPage, website);
            webPage.MetaAuthor = FalloverMetaAuthor(webPage, website);
            webPage.MetaDescription = FalloverMetaDescription(webPage);
            webPage.MetaKeywords = FalloverMetaKeywords(webPage);          
        }

        private static string FalloverMetaTitle(WebPage webPage, Website website)
        {
            if (string.IsNullOrEmpty(webPage.MetaTitle))
            {
                webPage.MetaTitle = webPage.Name;
            }

            webPage.MetaTitle = string.Format("{0} | {1}", webPage.MetaTitle, website.SiteName);

            return webPage.MetaTitle;
        }

        private static string FalloverMetaAuthor(this WebPage webPage, Website website)
        {
            if (!string.IsNullOrEmpty(webPage.MetaAuthor))
            {
                return webPage.MetaAuthor;
            }

            return website.SiteName;
        }

        private static string FalloverMetaDescription(WebPage webPage)
        {
            if (string.IsNullOrEmpty(webPage.MetaDescription))
            {
                webPage.MetaDescription = webPage.Name;
            }

            return webPage.MetaDescription;
        }

        private static string FalloverMetaKeywords(this WebPage webPage)
        {
            if (!string.IsNullOrEmpty(webPage.MetaKeywords))
            {
                return webPage.MetaKeywords;
            }

            if (string.IsNullOrEmpty(webPage.MetaDescription))
            {
                return string.Empty;
            }

            var wordsToExclude = new List<string>
            {
                "a", "the", "an", "it", "is", "are", "when", "then", "i", "me", "my", "to", "if", "page", "this"
            };

            IEnumerable<string> keywords = webPage.MetaDescription.Split(' ')
                .Select(x => new string(x.Where(c => !char.IsPunctuation(c)).ToArray()).ToLower())
                .Where(x => !wordsToExclude.Contains(x));

            return string.Join(",", keywords).ToLower();
        }
    }
}