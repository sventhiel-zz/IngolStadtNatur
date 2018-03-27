using System.Web.Optimization;

namespace IngolStadtNatur.Web.Shell
{
    public class BundleConfig
    {
        // Weitere Informationen zu Bundling finden Sie unter "http://go.microsoft.com/fwlink/?LinkId=301862"
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.*",
                "~/Scripts/mvcfoolproof.unobtrusive.min.js"));

            // Verwenden Sie die Entwicklungsversion von Modernizr zum Entwickeln und Erweitern Ihrer Kenntnisse. Wenn Sie dann
            // für die Produktion bereit sind, verwenden Sie das Buildtool unter "http://modernizr.com", um nur die benötigten Tests auszuwählen.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/lightgallery").Include(
                "~/Scripts/lightgallery-all.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/lightslider.min.js",
                "~/Scripts/bootstrap3-typeahead.min.js",
                "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/leaflet").Include(
                "~/Scripts/leaflet.js",
                "~/Scripts/leaflet.interactive.js",
                "~/Scripts/leaflet.observational.js",
                "~/Scripts/leaflet.geojsoncss.min.js",
                "~/Scripts/habitats.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment-with-locales.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/lightslider.min.css",
                "~/Content/bootstrap-datetimepicker.min.css",
                "~/Content/leaflet.css",
                "~/Content/font-awesome.min.css",

                "~/Content/lightgallery.min.css",
                "~/Content/lg-transitions.min.css",
                "~/Content/lg-fb-comment-box.min.css",

                "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}