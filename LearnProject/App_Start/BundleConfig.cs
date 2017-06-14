using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LearnProject
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap*"));
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css") /* не перепутайте порядок */
                .Include("~/Content/bootstrap*"));
        }
    }
}