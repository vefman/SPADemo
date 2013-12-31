using System.Web;
using System.Web.Optimization;

namespace HomeSecurity.Internet
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Reference/jQuery/jquery-{version}.js",
                        "~/Scripts/Reference/jQuery/jquery.activity-indicator-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/Reference/jQuery/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Reference/jQuery/jquery.unobtrusive*",
                        "~/Scripts/Reference/jQuery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ko").Include(
                        "~/Scripts/Reference/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/amplify").Include(
                        "~/Scripts/Reference/amplify.js"));

            bundles.Add(new ScriptBundle("~/bundles/sammy").Include(
                        "~/Scripts/Reference/sammy-{version}.js",
                        "~/Scripts/Reference/sammy.title.js"));

            bundles.Add(new ScriptBundle("~/bundles/hsapp").IncludeDirectory("~/Scripts/App/", "*.js", true));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Reference/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            #region Foundation Bundles
            bundles.Add(new StyleBundle("~/Content/foundation/css").Include(
                       "~/Content/foundation/foundation.css",
                       "~/Content/foundation/app.css"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Scripts/foundation/jquery.*",
                      "~/Scripts/foundation/app.js"));
            #endregion

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}