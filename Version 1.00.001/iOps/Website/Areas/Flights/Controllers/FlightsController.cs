using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using iOps.Service;
using iOps.Core.Model;
using System.Data.Entity.Infrastructure;
using Omu.Encrypto;

namespace iOps.Website.Areas.Flights.Controllers
{
    public class FlightsController : Controller
    {
        private iOPCOmanDBEntities db = new iOPCOmanDBEntities();

        // GET: Flights/Flights
        public async Task<ActionResult> Index(string sortingOrder)
        {
            DateTime dtPriorday = DateTime.Today.AddDays(-1).Date;
            ViewBag.SortingName = String.IsNullOrEmpty(sortingOrder) ? "OnBoardScheduledTime" : "";
            ViewBag.PageSize = 20;
            var flights = db.Flights.Where(f => f.OnBoardScheduledTime > dtPriorday );

            switch (sortingOrder)
            {
                case "OnBoardEstimatedTime":
                    flights = flights.OrderByDescending(f => f.OnBoardEstimatedTime);
                    break;
                default:
                    flights = flights.OrderBy(f => f.OnBoardScheduledTime);
                    break;
            }
            
            return View(await flights.ToListAsync());
        }

        // GET: Flights/Flights/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Flights/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flights/Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AircraftType,AircraftSubType,Airline,FlightNumber,ArrivalAirport,DepartureAirport,OnBoardActualTime,OnBoardScheduledTime,OnBoardEstimatedTime,OnBoardTouchDownTime,PassengerGate,ParkingPosition,BridgeUpdateDateTime,DoorPosition,AC_Door_AVG_HT,AC_DRIVE_COL_HT,RTUOnIndicator,RTURemoteCntrl")] Flight flight)
        {
            DateTime dtInsertTime = DateTime.Now;
            
            Flight flightToInsert = new Flight() 
            {
                TimeStamp = dtInsertTime,
                AircraftType = flight.AircraftType,
                AircraftSubType = flight.AircraftSubType,
                Airline = flight.Airline,
                FlightNumber = flight.FlightNumber,
                ArrivalAirport = flight.ArrivalAirport,
                DepartureAirport = flight.DepartureAirport,
                OnBoardActualTime = flight.OnBoardActualTime,
                OnBoardScheduledTime = flight.OnBoardScheduledTime,
                OnBoardEstimatedTime = flight.OnBoardEstimatedTime,
                OnBoardTouchDownTime = flight.OnBoardTouchDownTime,
                PassengerGate = flight.PassengerGate,
                ParkingPosition = flight.ParkingPosition,
                BridgeUpdateDateTime = dtInsertTime,
                DoorPosition = flight.DoorPosition,
                AC_Door_AVG_HT = flight.AC_Door_AVG_HT,
                AC_DRIVE_COL_HT = flight.AC_DRIVE_COL_HT,
                RTUOnIndicator = flight.RTUOnIndicator,
                RTURemoteCntrl = flight.RTURemoteCntrl
            };
            try
            {
               
                db.Flights.Add(flightToInsert);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Flights", new { area = "Flights" });
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(flight);
        }

        // GET: Flights/Flights/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TimeStamp,AircraftType,AircraftSubType,Airline,FlightNumber,ArrivalAirport,DepartureAirport,OnBoardActualTime,OnBoardScheduledTime,OnBoardEstimatedTime,OnBoardTouchDownTime,PassengerGate,ParkingPosition,BridgeUpdateDateTime,DoorPosition,AC_Door_AVG_HT,AC_DRIVE_COL_HT,RTUOnIndicator,RTURemoteCntrl")] Flight flight)
        {
            DateTime dtEditTime = DateTime.Now;
            Flight flightToUpdate = await db.Flights.FindAsync(flight.Id);
            try
            {
                flightToUpdate.TimeStamp = flight.TimeStamp;
                flightToUpdate.AircraftType = flight.AircraftType;
                flightToUpdate.AircraftSubType = flight.AircraftSubType;
                flightToUpdate.Airline = flight.Airline;
                flightToUpdate.FlightNumber = flight.FlightNumber;
                flightToUpdate.ArrivalAirport = flight.ArrivalAirport;
                flightToUpdate.DepartureAirport = flight.DepartureAirport;
                flightToUpdate.OnBoardActualTime = flight.OnBoardActualTime;
                flightToUpdate.OnBoardScheduledTime = flight.OnBoardScheduledTime;
                flightToUpdate.OnBoardEstimatedTime = flight.OnBoardEstimatedTime;
                flightToUpdate.OnBoardTouchDownTime = flight.OnBoardTouchDownTime;
                flightToUpdate.PassengerGate = flight.PassengerGate;
                flightToUpdate.ParkingPosition = flight.ParkingPosition;
                flightToUpdate.BridgeUpdateDateTime = dtEditTime;
                flightToUpdate.DoorPosition = flight.DoorPosition;
                flightToUpdate.AC_Door_AVG_HT = flight.AC_Door_AVG_HT;
                flightToUpdate.AC_DRIVE_COL_HT = flight.AC_DRIVE_COL_HT;
                flightToUpdate.RTUOnIndicator = flight.RTUOnIndicator;
                flightToUpdate.RTURemoteCntrl = flight.RTURemoteCntrl;

                db.Entry(flightToUpdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return View(flight);
        }

        // GET: Flights/Flights/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Flight flight = await db.Flights.FindAsync(id);
            db.Flights.Remove(flight);
            db.Entry(flight).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Flights/Flights/Destroy/5
        public async Task<ActionResult> Destroy(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = await db.Flights.FindAsync(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Flights/Destroy/5
        [HttpPost, ActionName("Destroy")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DestroyConfirmed(int id)
        {
            Flight flight = await db.Flights.FindAsync(id);
            db.Flights.Remove(flight);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // FlightsList_Read
        public ActionResult FlightsList_Read([DataSourceRequest(Prefix = "Grid")] DataSourceRequest request)
        {
            
            DateTime dtPriorday = DateTime.Today.AddDays(-1).Date;
            IQueryable<iOps.Core.Model.Flight> flights = db.Flights.Where(f => f.OnBoardScheduledTime > dtPriorday);
            DataSourceResult result = flights.ToDataSourceResult(request);
            return Json(result);
        }

        // FlightsList_Destroy
        public ActionResult FlightsList_Destroy([DataSourceRequest]DataSourceRequest request, Flight flight)
        {
            if (ModelState.IsValid)
            {
                this.Delete(flight.Id);
            }
            // Return the removed product. Also return any validation errors.
            return Json(new[] { flight }.ToDataSourceResult(request, ModelState));
        }
                
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
