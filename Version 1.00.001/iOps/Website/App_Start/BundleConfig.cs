using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace iOps.Website
{
    /// <summary>
    /// BundleConfig: Class for managing the Bundels Collection
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        /// <summary>
        /// RegisterBundles:  Used for adding Javascript and Style Sheets to bundles for optimization
        /// </summary>
        /// <param name="bundles"></param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Bundle basic Add-Ons
            bundles.Add(new ScriptBundle("~/bundles/Add-Ons/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jqueryUI.1.11.2.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/additional-methods.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/modernizr-*",
                "~/Scripts/jquery.fileupload-ui.js",
                "~/Scripts/angular.min.js",
                "~/Scripts/respond.min.js",
                "~/Scripts/JSON2.js"
            ));
            bundles.Add(new StyleBundle("~/Content/Add-Ons/css").Include(
                "~/Content/bootstrap.min.css"
            ));

            // Bundle Telerik Kendo     
            /************************************************************************************************************** 
             * NOTE:  Add the following script to bundle if using the Kendo Scheduler
             * "~/Scripts/kendo/kendo.timezones.min.js"
             **************************************************************************************************************/
            //bundles.Add(new ScriptBundle("~/bundles/kendo/js").Include("~/Scripts/Kendo/angular.min.js", "~/Scripts/kendo/kendo.all.min.js", "~/Scripts/kendo/kendo.aspnetmvc.min.js", "~/Scripts/kendo.web.min.js"));
            bundles.Add(
                new ScriptBundle("~/bundles/kendo/js").Include(
                    "~/Scripts/Kendo/2014.3.1411/kendo.core.min.js",
                    "~/Scripts/Kendo/2014.3.1411/kendo.all.min.js",
                    "~/Scripts/Kendo/2014.3.1411/kendo.menu.min.js", 
                    "~/Scripts/Kendo/2014.3.1411/kendo.window.min.js", 
                    "~/Scripts/Kendo/2014.3.1411/kendo.splitter.min.js",
                    "~/Scripts/Kendo/2014.3.1411/kendo.aspnetmvc.min.js"
                )
            );
            
            bundles.Add(
                new ScriptBundle("~/bundles/OPCHTML/js").Include(
                    "~/OPCHTML/js/opc-lib-min.js",
                    "~/OPCHTML/js/lib/jquery.numberformatter-1.2.3.min.js",
                    "~/OPCHTML/js/datatables/js/jquery.dataTables.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Site/js").Include("~/Scripts/Site.js"
            ));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include("~/Content/Kendo/2014.3.1411/kendo.common.min.css","~/Content/Kendo/2014.3.1411/kendo.default.min.css"));
            bundles.Add(new StyleBundle("~/Content/kendo/dataviz/css").Include("~/Content/Kendo/2014.3.1411/kendo.dataviz.min.css","~/Content/Kendo/2014.3.1411/kendo.dataviz.default.min.css"));
            
            // Bundle Fonts
            bundles.Add(new StyleBundle("~/Content/Fonts/Digital7/css").Include("~/Content/Fonts/Digital7/digital-7.css"));
            
            // Bundle Themes
            bundles.Add(new StyleBundle("~/Content/Themes/css").Include("~/Content/Themes/*.css"));
            AddThemesToBundle(bundles);

            // Bundle OPC Systems Styles and Scripts
            bundles.Add(new StyleBundle("~/bundles/OPCHTML/css").Include(
                "~/OPCHTML/css/opc-style.css","~/OPCHTML/css/opc-alarm-style.css","~/OPCHTML/css/font-awesome.min.css","~/OPCHTML/js/datatables/css/jquery.dataTables.css"
            ));

            // Bundle Site Styles and Scripts
            bundles.Add(new StyleBundle("~/bundles/Site/css").Include(
                "~/Content/Common.css","~/OPCHTML/css/opc-style.css","~/OPCHTML/css/opc-alarm-style.css","~/OPCHTML/css/font-awesome.min.css","~/OPCHTML/css/jquery.dataTables.css"
            ));

            bundles.IgnoreList.Clear(); //by default, the ignoreList will ignore all minified scripts

        }

        /// <summary>
        /// AddThemesToBundle: Loop through the default Content\Themes folder and bundles all the CSS files
        /// </summary>
        /// <param name="bundles"></param>
        /// <remarks>
        /// This routine creates THEME bundles recursively for each subfolder in the Content\Themes foolder.  This allows developers to create new themes
        /// and have them bundled automatically.  This also allows for Theme Versioning which can be useful for identifying users who are not using the 
        /// correct version of the code.  Multiple css files can be used for themeing, which helps keep code maintainable and organized, and all the seperate 
        /// css files will be bundled correctly.
        /// 
        /// To access a THEME you simply need to access it from the bundle using the same path as you normally would except
        /// using the /css instead of the actual [Filename].css.
        /// </remarks>
        public static void AddThemesToBundle(BundleCollection bundles)
        {
            string themesFolderName = @"Content\Themes"; 

            string themesPath = HttpContext.Current.Server.MapPath("~").MakeBackSlashes().AppendBackSlash() + themesFolderName;
            if (System.IO.Directory.Exists(themesPath))
            {
                IEnumerable<string> themeFolders = System.IO.Directory.GetDirectories(themesPath);
                foreach (string folder in themeFolders)
                {
                    string folderName = new System.IO.DirectoryInfo(folder).Name;
                    string bundleName = String.Format("~/{0}/{1}/css", themesFolderName, folderName).MakeForwardSlashes();
                    string bundleVirtualPath = String.Format("~/{0}/{1}/*.css", themesFolderName, folderName).MakeForwardSlashes();
                    string bundleNameJS = "";
                    string bundleVirtualPathJS = "";

                    bundles.Add(new StyleBundle(bundleName).Include(bundleVirtualPath));

                    if (System.IO.Directory.Exists(String.Format("{0}\\scripts", folder)))
                    {
                        bundleNameJS = String.Format("~/{0}/{1}/js", themesFolderName, folderName).MakeForwardSlashes();
                        bundleVirtualPathJS = String.Format("~/{0}/{1}/scripts/*.js", themesFolderName, folderName).MakeForwardSlashes();
                        bundles.Add(new ScriptBundle(bundleNameJS).Include(bundleVirtualPathJS));
                    }
                    IEnumerable<string> themeSubFolders = System.IO.Directory.GetDirectories(folder);
                    foreach (string subfolder in themeSubFolders)
                    {
                        string subFolderName = new System.IO.DirectoryInfo(subfolder).Name;
                        bundleName = String.Format("~/{0}/{1}/{2}/css", themesFolderName, folderName, subFolderName).MakeForwardSlashes();
                        bundleVirtualPath = String.Format("~/{0}/{1}/{2}/*.css", themesFolderName, folderName, subFolderName).MakeForwardSlashes();

                        bundles.Add(new StyleBundle(bundleName).Include(bundleVirtualPath));

                        if (System.IO.Directory.Exists(String.Format("{0}\\scripts", subfolder)))
                        {
                            bundleNameJS = String.Format("~/{0}/{1}/{2}/js", themesFolderName, folderName, subFolderName).MakeForwardSlashes();
                            bundleVirtualPathJS = String.Format("~/{0}/{1}/{2}/scripts/*.js", themesFolderName, folderName, subFolderName).MakeForwardSlashes();
                            bundles.Add(new ScriptBundle(bundleNameJS).Include(bundleVirtualPathJS));
                        }
                    
                    }
                }
            }

        }
    }
}