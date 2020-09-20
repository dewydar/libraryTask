using System.Web;
using System.Web.Optimization;

namespace libraryTask
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/Content/chosenJavaScript").Include(
         "~/Scripts/MultipleChosen/chosen.jquery.js",
         "~/Scripts/MultipleChosen/docsupport/prism.js"
     ));
            bundles.Add(new StyleBundle("~/Content/jquery").Include(
           "~/Content/jquery-ui.css"
       //new 
       // "~/Content/jquery-ui-1.10.4.custom.css"

       ));

            bundles.Add(new StyleBundle("~/Content/chosenCSS").Include(
                "~/Scripts/MultipleChosen/docsupport/style.css",
                "~/Scripts/MultipleChosen/docsupport/prism.cs",
                "~/Scripts/MultipleChosen/chosen.css"
            ));
        }
    }
}
