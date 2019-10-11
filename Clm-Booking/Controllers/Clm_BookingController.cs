using Clm_Booking.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Clm_Booking.Controllers
{
    public class Clm_BookingController : Controller
    {
        private IBookingRepository bookingRepository;
        private ClmEntity db = new ClmEntity();
        
        public Clm_BookingController()
        {
            bookingRepository = new BookRepository(new ClmEntity());
        }

        // GET: Clm_Booking Show Home Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Open_Book()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Open_Book(ClientClm client)
        {
            if (client != null)
            {
               
                try
                {
                    if (bookingRepository.GetClients().Any(c => c.bookdate == client.bookdate && c.booktime == client.booktime))
                    {
                        ViewBag.Success = "Oops, Not available";
                    }
                    else
                    {
                        client.status = "Awaiting";
                        bookingRepository.AddBooking(client);
                        bookingRepository.Save();

                        ViewBag.Success = "Booking added.";
                    }
                }
                catch (Exception)
                {

                    ViewBag.Success = "Sorry, Can't be empty";

                }
            }
            else
            {
                ViewBag.Success = "Oops, something is wrong!!! Contact Admin";
                return RedirectToAction("Open_Book");
            }
            ModelState.Clear();
            return View();

        }

        [HttpGet]
        public JsonResult GetAvailableDate()
        {
            var dates = from d in bookingRepository.GetClients()
                       where d.status == "Awaiting"
                       select d.bookdate;
         
            return Json(new { dates }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllTime(DateTime? datetime)
        {          
            var times = from d in bookingRepository.GetClients()
                        where d.bookdate == datetime
                        select d.booktime;
            TempData["time"] = times;
            return Json(times, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllTimes()
        {
            var time = TempData["time"];

            return Json(new { time }, JsonRequestBehavior.AllowGet);
        }
    }
}