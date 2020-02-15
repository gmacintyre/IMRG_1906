﻿using System.Web;
using System.Web.Optimization;

namespace imrg_web
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

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                "~/Scripts/fullcalendar/core/main.js",
                      "~/Scripts/fullcalendar/interaction/main.js",
                      "~/Scripts/fullcalendar/daygrid/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css, ",
                      "~/Content/Custom/css/",
                      "~/Content/Custom/font/",
                      "~/Content/Custom/ico/",
                      "~/Content/Custom/img/",
                      "~/Content/Custom/js/",
                      "~/Content/Custom/skins/red.css",
                      "~/Content/site.css",
                      "~/Scripts/fullcalendar/core/main.css",
                      "~/Scripts/fullcalendar/daygrid/main.css"));
        }
    }
}
