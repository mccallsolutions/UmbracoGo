using System.Collections.Generic;

namespace UmbracoGo.Web.Models.ViewModels
{
    public class LanguageSelectorViewModel
    {
        public List<NavigationItemViewModel> DomainItems { get; set; }
        public NavigationItemViewModel SelectedDomainItem { get; set; }        
    }
}