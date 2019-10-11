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
                           orderby c.bookdate
                           select c;

            return View(bookings);
        }


        //public ActionResult PreviousBooking()
        //{

        //    //from p in repository.GetClients()
        //    //where p.status.Contains("Appointment Done")
        //    //select p;

           
        //}

        [HttpGet]
        public ActionResult PreviousBooking(string searchClient)
        {
            if (String.IsNullOrEmpty(searchClient))
            {
                var previousBooking = db.ClientClms.Where(c => c.status.Contains("Appointment Done"));
                return View(previousBooking);
            }
            else {
                List<ClientClm> SearchedClients = repository.SearchClients(searchClient);
                return View(SearchedClients);
            }
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

        
      
    }
}