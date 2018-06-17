using System.Web;
using System.Web.Optimization;

namespace Newbly
{
    // client-side assets gets bundled deducing the number of HTTP Requests needed for page to load
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Example client-slide optimization
            // Consolidate the scripts so less requests are needed.
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                            "~/Scripts/jquery-{version}.js",
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/bootbox.js",
                            "~/Scripts/datatables/jquery.datatables.js",
                            "~/Scripts/datatables/datatables.bootstrap.js",
                            "~/Scripts/typeahead.bundle.js",
                            "~/Scripts/toastr.js"
                        ));

            /* Client-Side Validation is not enabled by default
             * Ex. in _Layout,cs Scripts.Render() does not include this
             * Need to include it in the View
             **/
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
