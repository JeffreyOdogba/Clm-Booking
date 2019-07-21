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
            return View();

        }

        [HttpGet]
        public JsonResult GetAvailableDate()
        {
          var dates =  bookingRepository.GetClients().ToList().Select(d => d.bookdate);

            JavaScriptSerializer js = new JavaScriptSerializer();
            return Json(new { dates = js.Serialize(dates) }, JsonRequestBehavior.AllowGet);
        }
    }
}