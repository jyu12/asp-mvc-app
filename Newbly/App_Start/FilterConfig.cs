using System.Web;
using System.Web.Mvc;

namespace Newbly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            /*
             * Configures global filtering
             * 
             * filter can get executed before and after an action
             * 
             * Default redirection when errors are thrown
             * */
            filters.Add(new HandleErrorAttribute());

            /*
             * [Authorize] is more or less a filter so it's configured here
             * 
             * */
            filters.Add(new AuthorizeAttribute());

            /*
             * For setting SSL
             * */
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
