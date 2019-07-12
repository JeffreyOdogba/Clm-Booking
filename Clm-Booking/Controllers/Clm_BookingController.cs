using Clm_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                if (bookingRepository.GetClients().Any(c => c.bookdate == client.bookdate && c.booktime == client.booktime))
                {
                    ViewBag.Success = "Booking Not Availble";
                }
                else
                {
                    client.status = "Awaiting";
                    bookingRepository.AddBooking(client);
                    bookingRepository.Save();

                    ViewBag.Success = "Booking added.";
                }          
            }
            else
            {
                ViewBag.Success = "Sorry add an input";
            }
            
            return View();
        }
    }
}