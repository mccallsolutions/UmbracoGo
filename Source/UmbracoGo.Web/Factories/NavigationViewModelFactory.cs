using System.Collections.Generic;
using System.Linq;
using RJP.MultiUrlPicker.Models;
using UmbracoGo.Web.Factories.Contracts;
using UmbracoGo.Web.Models.ViewModels;

namespace UmbracoGo.Web.Factories
{
    public class NavigationViewModelFactory : INavigationViewModelFactory
    {
        public NavigationViewModel Create(MultiUrls multiUrls)
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
                    Target = x.Target
                })
                .ToList();

            return model;
        }
    }
}