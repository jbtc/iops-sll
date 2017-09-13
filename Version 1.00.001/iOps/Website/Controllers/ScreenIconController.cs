using System.Web.Mvc;
using iOps.Core.Model;
using iOps.Data;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;

namespace iOps.Website.Controllers
{
    public class ScreenIconController : BaseController
    {
        private iopsContext db_iops = new iopsContext();
        private iopsWeatherEntities db = new iopsWeatherEntities();

        // GET: ScreenIcon
        [HttpGet]
        public PartialViewResult GetScreenIcons(string clientName)
        {
            int screenNumber = db_iops.Screens.Where(s => s.Name.StartsWith(clientName) && !s.IsDeleted).OrderBy(s => s.DefaultDisplayOrder).Count();
            TempData["MaxScreens"] = screenNumber;
            TempData["ClientName"] = clientName;
            return PartialView("_ScreenIcons");
        }
        
        //public ActionResult WriteScreenAjaxCalls(string clientName, int numberOfScreens)
        //{
        //    var screens = db_iops.Screens.Where(s => s.Name.StartsWith(clientName) && !s.IsDeleted).OrderBy(s => s.DefaultDisplayOrder);

        //    string js = string.Empty;
            
        //    foreach(Screen screen in screens)
        //    {
        //        var a = 0;
        //        XDocument xmlData = XDocument.Load(new StringReader(screen.ScreenLayout));
        //        var ajaxUrl = xmlData.Element("Screen-Layout").Element("AjaxUrl").Value;
        //        var ajaxData = xmlData.Element("Screen-Layout").Element("AjaxData").Value;
        //        var tagPrefix = xmlData.Element("Screen-Layout").Element("TagPrefix").Value;
        //        dynamic parseData = JsonConvert.DeserializeObject(ajaxData.Replace("'", "\""));
        //        string gateNumber = parseData.gateNum;

        //        js += @"$('.screen-ajax" + screen.DefaultDisplayOrder + "').click(function (e) {"+
        //            "debugger;"+
        //            "$.ajax({url: '/Gate/Gate/ShowGates',"+
        //            "type: \"GET\","+
        //            "contentType: 'text/html',"+
        //            "data: {gateNum:" + parseData.gateNum + "},"+
        //            "success: function (data) {"+
        //               "CloseGateAlarmWindow();"+  
        //               "CloseGateWarningWindow();"+  
        //               "CloseKendoGate();"+
        //               "$('#main-body').html(data);"+
        //                "ChangeIcons(" + screen.DefaultDisplayOrder + ");"+
        //            "}});}); ";

        //    }
        //    return JavaScript(js);
        //}
    }
}