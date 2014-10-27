using System.Web;
using System.Web.Optimization;

namespace SeraFood
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                    "~/Scripts/webfont.js",
                     "~/Scripts/tinynav.min.js",
                       "~/Scripts/tinynav.js",
                         "~/Scripts/retina.js",
                           "~/Scripts/modernizr.custom.js",
                            "~/Scripts/main.js",
                             "~/Scripts/jquery.js",
                             "~/Scripts/jquery.viewport.mini.js",
                               "~/Scripts/jquery.hoverPanel.js",
                                 "~/Scripts/jquery.fitvids.js",
                                 "~/Scripts/jquery.easing.1.3.js",
                                 "~/Scripts/jquery.carousel.js",
                                  "~/Scripts/jquery-ui.js",
                                  "~/Scripts/jquery-2.1.1.min.js",
                                   "~/Scripts/ajax-cateringform/ajax-email.js",
                                  "~/Scripts/ajax-contact/ajax-catering-form.js",
                                  "~/Scripts/ajax-eventform/ajax-event-form.js.js",
                                    "~/Scripts/countdown/ajax-catering-form.js",
                                    "~/Scripts/easypiechart/jquery.easypiechart.min.js",
                                    "~/Scripts/flexisel/jquery.flexisel.js",
                                   "~/Scripts/flexslider/jquery.flexslider-min.js",
                                   "~/Scripts/flexslider/jquery.flexslider.js",
                                     "~/Scripts/iris/color.min.js",
                                    "~/Scripts/iris/iris.js",
                                    "~/Scripts/iris/iris.min.js",
                                    "~/Scripts/isotope/jquery.isotope.min.js",
                                       "~/Scripts/mobilemenu/jquery.dlmenu.js",
                                         "~/Scripts/mobilemenu/modernizr.custom.js",
                                         "~/Scripts/owl-carousel/owl.carousel.min.js",
                                          "~/Scripts/prettyphoto/js/jquery.prettyPhoto.js",
                                         "~/Scripts/prettyphoto/js/jquery.prettyPhoto2.js",
                                            "~/Scripts/pulse/jquery.PMSlider.js",
                                           "~/Scripts/pulse/modernizr.custom.js",
                                            "~/Scripts/responsive-nav/responsive-nav.min.js",
                                            "~/Scripts/scrollpane/jquery.jscrollpane.min.js",
                                            "~/Scripts/scrollpane/jquery.mousewheel.js",
                                            "~/Scripts/scrollpane/mwheelIntent.js",
                                            "~/Scripts/stellar/jquery.stellar.js",
                                            "~/Scripts/stellar/scrollability.js",
                                            "~/Scripts/superfish/hoverIntent.js",
                                             "~/Scripts/superfish/superfish.js",
                                             "~/Scripts/wow/wow.min.js"

                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css",
                     "~/Content/PagedList.css",
                     "~/Content/btn.css",
                     "~/Content/carousel.css",
                     "~/Content/comments.css",
                     "~/Content/flickrfeed.css",
                     "~/Content/font-awesome.css",
                     "~/Content/font-awesome.min.css",
                     "~/Content/forms.css",
                     "~/Content/main.css",
                     "~/Content/main.css",
                     "~/Content/pulse-carousel.css",
                     "~/Content/responsive.css",
                     "~/Content/twitterfeed.css",
                     "~/Content/woocommerce-custom.css",
                     "~/Content/jasny-bootstrap.min.css",
                     "~/Scripts/flexisel/flexisel.css",
                     "~/Scripts/flexslider/flexslider-post.css",
                      "~/Scripts/flexslider/flexslider.css",
                      "~/Scripts/iris/iris.css",
                       "~/Scripts/iris/iris.min.css",
                          "~/Scripts/isotope/isotope.css",
                          "~/Scripts/mobilemenu/mobilemenu.css",
                           "~/Scripts/owl-carousel/owl.carousel.css",
                            "~/Scripts/owl-carousel/owl.theme.css",
                             "~/Scripts/owl-carousel/owl.transitions.css",
                             "~/Scripts/prettyphoto/css/prettyPhoto.css",
                             "~/Scripts/responsive-nav/responsive-nav.css",
                              "~/Scripts/scrollpane/jquery.jscrollpane.css",
                               "~/Scripts/wow/css/site.css"
                     

                     ));
        }
    }
}
