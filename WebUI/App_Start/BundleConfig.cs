using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new Bundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"
                      ));

            bundles.Add(new Bundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new Bundle("~/bundles/VicodinComponents").Include(
                      "~/Content/css/Icons.css",
                      "~/Content/css/Plugins.css",
                      "~/Content/css/VicodinComponents.css",
                      "~/Content/css/VicodinResponsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/ControlAcciones").Include(
                      "~/Assets/Scripts/ControlAcciones.js"));


            bundles.Add(new Bundle("~/bundles/VicodinScripts").Include(
                    "~/Scripts/PluginsVicodinComponents.js",
                      "~/Scripts/MainVicodinComponents.js"
                      ));

            bundles.Add(new Bundle("~/bundles/Dashboard").Include(
                    "~/Content/CssDashboard/iconly.css",
                    "~/Content/CssDashboard/dashboard.css"));
        }
    }
}
