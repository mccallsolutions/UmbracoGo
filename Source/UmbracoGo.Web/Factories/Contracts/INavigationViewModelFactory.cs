using RJP.MultiUrlPicker.Models;
using UmbracoGo.Web.Models.ViewModels;

namespace UmbracoGo.Web.Factories.Contracts
{
    public interface INavigationViewModelFactory
    {
        NavigationViewModel Create(MultiUrls multiUrls);
    }
}
