using System.Linq;
using iOps.Data;
using System.Web.Mvc;
using System;

namespace iOps.Website.Controllers
{
    public class WeatherController : Controller
    {
        private iopsWeatherEntities db = new iopsWeatherEntities();

        [HttpGet]
        public PartialViewResult GetWeatherData(string clientName)
        {
            DateTime oldTime = DateTime.Now.AddMinutes(-35);
            Weather weather;
            switch (clientName)
            {
                case "SLL":
                    weather = db.Weathers.FirstOrDefault(a => (a.CityName == "Salalah") && (a.InsertDate.Value > oldTime));
                    if (weather == null)
                        goto default;
                    break;
                case "CID":
                    weather = db.Weathers.FirstOrDefault(a => (a.CityName == "Cedar Rapids" || a.CityName == "Marion") && (a.InsertDate.Value > oldTime));
                    if (weather == null)
                        goto default;
                    break;
                default:
                    weather = new Weather();
                    break;
            }
            return PartialView("_Weather",weather);
        }
    }
}
