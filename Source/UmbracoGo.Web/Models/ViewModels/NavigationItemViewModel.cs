namespace UmbracoGo.Web.Models.ViewModels
{
    public class NavigationItemViewModel
    {
        public string Url { get; set; }
        public string Text { get; set; }
        public string Target { get; set; }
        public bool IsSelected { get; set; }
        public string Rel { get; set; }
    }
}