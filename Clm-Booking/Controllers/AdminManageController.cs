using Clm_Booking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clm_Booking.Controllers
{
    public class AdminManageController : Controller
    {        
        
        IBookingRepository repository;
        ClmEntity db = new ClmEntity();

        public AdminManageController()
        {
            repository = new BookRepository(new ClmEntity());
        }

        // GET: AdminManage
        [HttpGet]
        public ActionResult Bookings()
        {
            var bookings = from c in repository.GetClients()
                           where c.status.Contains("Awaiting")
                           select c;

            return View(bookings);
        }
        
        /// <summary>
        /// This a Button for Accept Booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public ActionResult CompleteBooking(int id)
        {
            ClientClm client = new ClientClm();
            client = db.ClientClms.Find(id);

            if (client != null)
            {
                client.status = "Appointment Done";
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
            }           
                
            
            return RedirectToAction("Bookings");
        }

        public ActionResult PreviousBooking()
        {
            var previousBooking = from p in repository.GetClients() 
                                  where p.status.Contains("Appointment Done")
                                  select p;
            return View(previousBooking);
        }
    }
}