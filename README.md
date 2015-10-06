# UmbracoGo

**In development check back soon**

A base Umbraco 7.3.0 Visual Studio 2013 solution ready for team development, best practices, and continuous integration.

The solution is built on a empty MVC solution with Umbraco 7.3.0 on top. 

We use a SQL CE database with a single admin user:

- Username = UmbracoGo
- Password = goUmbraco

You can change all of these settings to suit your setup. We explain customising the solution below. It takes 5 minutes!

## What's in the box?
I have tried to install the most useful things in Umbraco that I use all the time.

- uSync 3.0.2
- Base Document Types
- UmbracoMapper 1.6.0
- ClientDependency MVC 5 1.8.0
- T4MVC
- Bootstrap 3.3.5
- Ninject for MVC 5

## Customize the Solution
So you want this solution to be yours?

## Base Document Types
We have a a few simple document types to get you started. They allow for multi-lingual sites and basic SEO. Its the best way to organise (I've found) common site document types.

- **Site Data** (Empty - used as folder)
  - **Website** (Root node for each culture/domain with common site settings.)
    - *[Generic]* `Redirect To Node` (Redirects a user to the selected node instead of this node.)
    - *[Settings]* `Site Name` (The name of the site.)
- **Web Pages** (Root for all web pages and contains common page settings.)
  - *[Generic]* `Hide In Navigation` (If ticked this content won't be displayed in any navigation.)
  - *[Generic]* `Redirect To Node` (Redirects a user to the selected node instead of this node.)
  - *[Generic]* `Exclude From Search` (If ticked then this content will not be displayed in the search results.)
  - *[Generic]* `Url Alias` (Will enable you to provide multiple URLs for a content node. For example if we were to enter "anotherpage,test/this-is-a-test", this would resolve the following URLs to the same page. /anotherpage.aspx, /test/this-is-a-test.aspx. Please note that the values you use must be lowercase, not use a leading slash and not use a trailing ".aspx".)
  - *[Content]* `Page Title` (This is the header title (H1) on the page. If empty meta title (SEO) is used.)
  - *[Content]* `Menu Title` (This is the title used in menus if you want to restrict the length. If empty page title is used.)
  - *[SEO]* `Meta Title` (This is used as the SEO meta page title in search engines. If empty the node name is used.)
  - *[SEO]* `Meta Author` (The author of this content used by search engines. If empty the site name (Website) is used.)
  - *[SEO]* `Meta Description` (The description of the content used by search engines.)
  - *[SEO]* `Meta Keywords` (The keywords describing this content used by search engines. If empty the meta description is converted into keywords.)
  - **Content Pages** (Empty - used as folder)
  - **Landing Pages** (Empty - used as folder)
    - **Home Landing Page** (Example landing page.)