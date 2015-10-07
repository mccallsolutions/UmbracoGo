using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.DocumentTypes.SiteData;
using UmbracoGo.Web.Models.ViewModels;

namespace UmbracoGo.Web.Controllers.SurfaceControllers
{
    public partial class WebsiteController : SurfaceController
    {
        private readonly ICurrentPageMapperFactory _currentPageMapperFactory;
        private readonly INavigationViewModelFactory _navigationViewModelFactory;

        public WebsiteController(
            ICurrentPageMapperFactory currentPageMapperFactory, 
            INavigationViewModelFactory navigationViewModelFactory)
        {
            _currentPageMapperFactory = currentPageMapperFactory;
            _navigationViewModelFactory = navigationViewModelFactory;            
        }

        public virtual ActionResult DocType()
        {
            Website website = _currentPageMapperFactory.CreateWebsite(CurrentPage);
            IEnumerable<IDomain> domains = Services.DomainService.GetAll(false);
            IDomain selecteDomain = domains.First(x => x.RootContentId == website.Id);

            return PartialView(MVC.Website.Views._LanguageIsoCode, selecteDomain.LanguageIsoCode);
        }

        public virtual ActionResult SiteName()
        {
            Website website = _currentPageMapperFactory.CreateWebsite(CurrentPage);
            return PartialView(MVC.Website.Views._SiteName, website.SiteName);
        }

        public virtual ActionResult MainNavigation()
        {
            Website website = _currentPageMapperFactory.CreateWebsite(CurrentPage);
            return PartialView(MVC.Website.Views._MainNavigation, website.MainNavigation);
        }

        public virtual ActionResult LanguageSelector()
        {
            Website website = _currentPageMapperFactory.CreateWebsite(CurrentPage);
            IEnumerable<IDomain> domains = Services.DomainService.GetAll(false);
            List<NavigationItemViewModel> domainItems = _navigationViewModelFactory.Create(website, domains, Request.Url);

            var model = new LanguageSelectorViewModel
            {
                DomainItems = domainItems,
                SelectedDomainItem = domainItems.First(x => x.IsSelected)
            };

            return PartialView(MVC.Website.Views._LanguageSelector, model);
        }
    }
}