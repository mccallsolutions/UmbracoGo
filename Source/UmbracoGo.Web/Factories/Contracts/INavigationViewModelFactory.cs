using System;
using System.Collections.Generic;
using RJP.MultiUrlPicker.Models;
using Umbraco.Core.Models;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.ViewModels;

namespace UmbracoGo.Web.Factories.Contracts
{
    public interface INavigationViewModelFactory
    {
        NavigationViewModel Create(MultiUrls multiUrls, IPublishedContent currentPage);
        List<NavigationItemViewModel> Create(Website website, IEnumerable<IDomain> domains, Uri requestUrl);
    }
}
