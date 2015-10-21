# UmbracoGo

**In development check back soon**

A base Umbraco 7.3.0 Visual Studio 2013 solution ready for team development, best practices, and continuous integration.

I use a SQL CE database with a single admin user:

- Username = UmbracoGo
- Password = goUmbraco

You can change all of these settings to suit your setup. I explain customising the solution below. It takes 5 minutes!

## What's in the box?
I have tried to implement the most useful things in Umbraco that I use all the time.

### Strongly typed document types and views
I make use of strongly typed document types from Umbraco's CurrentPage so our view models are clean and I don't have any logic within the Razor views. All mapping from CurrentPage to strongly typed document types is done using a factory pattern and [UmbracoMapper](https://github.com/AndyButland/UmbracoMapper).

I provide some starting document types for best practice (see  Base Document Types below).

### Nuget based
The solution is built on a empty MVC solution with Umbraco 7.3.0 on top and some other useful NuGet packages. 

Here are some of the packages included that are worth mentioning:

- [Umbraco](https://github.com/umbraco/Umbraco-CMS/) (I think we might need this)
- [uSync](https://github.com/KevinJump/jumps.umbraco.usync) (Auto syncing of Umbraco types to different environments)
- [UmbracoMapper](https://github.com/AndyButland/UmbracoMapper) (AutoMapper for Umbraco - great package)
- [ClientDependency](https://github.com/Shazwazza/ClientDependency) (Minified JavaScript and CSS)
- [T4MVC](https://github.com/T4MVC/T4MVC) (Strongly types controller and views)
- [Bootstrap](http://getbootstrap.com/) (Responsive layout framework)
- [Ninject](https://github.com/ninject/ninject) (Dependency injection)
- [Multi URL Picker](https://www.nuget.org/packages/RJP.UmbracoMultiUrlPicker) (Generic navigation)

### Umbraco packages
I try to use Nuget packages whenever possible but sometimes you have to install Umbraco packages. This is a pain in source control as you need to manually include the files that are installed. Package dlls are stored in the Lib and copied to the bin on build. Here are the packages I use:

- [Cultiv.DynamicRobots](https://our.umbraco.org/projects/website-utilities/cultiv-dynamicrobots/)  (Awesome tool for multilingual robotos.txt)
- [Cultiv Search Engine Sitemap (Razor edition)](https://our.umbraco.org/projects/website-utilities/cultiv-search-engine-sitemap/) (Search engine sitemap generator)

### Source safe friendly
This Visual Studio solution is built to be source safe (Git) friendly so I don't store anything unnecessary in our repositories. Everything I require is automatically pulled in using NuGet packages.

### Responsive layout
I provide out the box Boostrap so you can immeidately start building responsive sites, but if you don't want to use this it is easy to remove the Nuget package (see Customize the Solution below).

### Accessiblity
I follow good accessibility standards WCAG 2 AA.

### Multilingual sites
I provide multilingual site setup in Umbraco with related langauge nodes. This does mean setting up some host names (uk.umbracogo.local and us.umbracogo.local) to run the site but this is easily done and can be customized in the Customize the Solution section below.

## Customize the Solution
So you want this solution to be yours?

## Base Document Types
I have a few simple document types to get you started. They allow for multilingual sites and basic SEO. Its the best way to organise (I've found) common site document types.

- **Site Data** (Empty - used as folder)
  - **Website** (Root node for each culture/domain with common site settings.)
    - *[Generic]* `Redirect To Node` (Redirects a user to the selected node instead of this node.)
    - *[Settings]* `Site Name` (The name of the site.)
    - *[Navigation]* 'Main Navigation' (The main navigation items.)
- **Web Pages** (Root for all web pages and contains common page settings.)
  - *[Generic]* `Hide In Navigation` (If ticked this content won't be displayed in any navigation.)
  - *[Generic]* `Redirect To Node` (Redirects a user to the selected node instead of this node.)
  - *[Generic]* `Exclude From Search` (If ticked then this content will not be displayed in the search results.)
  - *[Generic]* `Url Alias` (Will enable you to provide multiple URLs for a content node. For example if I were to enter "anotherpage,test/this-is-a-test", this would resolve the following URLs to the same page. /anotherpage.aspx, /test/this-is-a-test.aspx. Please note that the values you use must be lowercase, not use a leading slash and not use a trailing ".aspx".)
  - *[Content]* `Page Title` (This is the header title (H1) on the page. If empty name of the node is used.)
  - *[Content]* `Menu Title` (This is the title used in menus if you want to restrict the length. If empty page title is used.)
  - *[SEO]* `Meta Title` (This is used as the SEO meta page title in search engines. If empty the node name is used.)
  - *[SEO]* `Meta Author` (The author of this content used by search engines. If empty the site name (Website) is used.)
  - *[SEO]* `Meta Description` (The description of the content used by search engines.)
  - *[SEO]* `Meta Keywords` (The keywords describing this content used by search engines. If empty the meta description is converted into keywords.)
  - **Content Pages** (Empty - used as folder)
    - **Content Web Page** (Example content page with image)
  - **Landing Pages** (Empty - used as folder)
    - **Home Landing Page** (Example landing page.)

## Models, Views and Controllers
I want to have a consistent way of accessing Umbraco content and displaying this to the user, but also follow common MVC conventions. In order to achive this goal I come up with the following architecture which I feel uses Umbraco and MVC within Visual Studio in a consistent and easy to use way.

### Models
There are two types of Models: 
	
- **DocumentTypes** (POCOs representing Umbraco document types)
- **ViewModels** (POCOs for various partial views or wrappers for DocumentType view models)

Both are view models but just categorized differently. A DocumentType model might be the view model for a page or we might need to create a ViewModel to pull in certain DocumentType properties. It all depends on the view requirements. The generation of these models is done using factories. These are explained below:

#### CurrentPageMapperFactory
This is the main factory that interacts with Umbraco. Umbraco content from _IPublishedContent_ is mapped using _CurrentPageMapperFactory_ and _UmbracoMapper_ to strongly typed view models that we can use in our views. 

_CurrentPageMapperFactory_ provides a consistent way to generate POCO view models from document types. Its gives us the chance to parse Umbraco property values and allow for fall over values or generation of custom view models. This stops logic appearing in our Razor views.

#### NavigationViewModelFactory
This factory generates generic navigation view models (text, url, open in new window).

### Views
Standard CSHTML Razor views.

### Controllers
I have two types of controllers as specified by Umbraco:

- **RenderMvcControllers** (These controllers are used to display Umbraco URLs and override the default Index view. Used for displaying current template.)
- **SurfaceControllers** (These controllers are usually for partial views and things like forms.)

On all our controllers we will inject _CurrentPageMapperFactory_ or any other factory interface to get a nice POCO view models. 