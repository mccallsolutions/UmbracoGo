using System;

namespace UmbracoGo.Web.ExtensionMethods
{
    public static class TypeExtensionMethods
    {
        public static bool IsSameOrSubclass(this Type potentialBase, Type potentialDescendant)
        {
            return potentialDescendant.IsSubclassOf(potentialBase)
                   || potentialDescendant == potentialBase;
        }
    }
}