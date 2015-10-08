using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using RJP.MultiUrlPicker.Models;
using Umbraco.Core.Models;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.ViewModels;

namespace UmbracoGo.Web.Factories
{
    public class NavigationViewModelFactory : INavigationViewModelFactory
    {
        public NavigationViewModel Create(MultiUrls multiUrls, IPublishedContent currentPage)
        {
            var model = new NavigationViewModel {Items = new List<NavigationItemViewModel>()};

            if (multiUrls == null || !multiUrls.Any())
            {
                return model;
            }

            model.Items = multiUrls
                .Select(x => new NavigationItemViewModel
                {
                    Url = x.Url,
                    Text = x.Name,
                    Target = x.Target,
                    IsSelected = currentPage.Id == x.Id
                })
                .ToList();

            return model;
        }

        public List<NavigationItemViewModel> Create(Website website, IEnumerable<IDomain> domains, Uri requestUrl)
        {
            var items = new List<NavigationItemViewModel>();

            if (website == null || domains == null)
            {
                return items;
            }

            items = domains
                .Select(x => new NavigationItemViewModel
                {
                    Url = string.Format("{0}://{1}", requestUrl.Scheme, x.DomainName),
                    Text = new CultureInfo(x.LanguageIsoCode).NativeName,
                    IsSelected = website.Id == x.RootContentId,
                    LanguageIsoCode = x.LanguageIsoCode,
                    Target = "_self"
                })
                .OrderBy(x => x.Text)
                .ToList();

            return items;
        }
    }
}