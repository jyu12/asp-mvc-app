using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Newbly.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        /* Example of Output Caching in ASP.NET
         * Caching html markup..
         * [OutputCache] 
         * ActionFilter - Gets executed before/after the action
         *              - Can be set at the class level to apply to all actions
         * VaryByParam - Caches individual outputs based on input params
         *        example - It will cache different verisons of the page based on "genre" 
         *        Or "*" - Which means it will cache any combintations
         * 
         * Problems with stale data needs to be considered
         * Caching varies base on browser.
         * To disable caching on action, set Duration = 0, VarByParam = "*", and NoStore = true
         */
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "genre")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}