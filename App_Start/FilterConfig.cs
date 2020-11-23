using System.Web;
using System.Web.Mvc;

namespace Bookish
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute()); // to Authorize globally
            filters.Add(new RequireHttpsAttribute()); //to allow https only
        }
    }
}
