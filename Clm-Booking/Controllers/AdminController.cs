using Clm_Booking.Models;
using Clm_Booking.Models.Hash;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Clm_Booking.Controllers
{
    public class AdminController : Controller
    {
        private IBookingRepository bookingRepository;
        private ClmEntity db = new ClmEntity();

        public AdminController()
        {
            bookingRepository = new BookRepository(new ClmEntity());
        }

        // GET: Admin
        public ActionResult AdminRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegistration(AdminClm adminClm)
        {
                    if (ModelState.IsValid)
                    {
                        if (db.AdminClms.Any(a => a.firstname.Equals(adminClm.firstname) || a.email.Equals(adminClm.email)))
                        {
                            ViewBag.Text = string.Format("User Account already available");
                        }
                        else
                        {                            
                            adminClm.securedpassword = Security.Hash(adminClm.securedpassword);
                            bookingRepository.RegisterAdmin(adminClm);
                            bookingRepository.Save();

                            return RedirectToAction("Login","Admin");                    
                        }

                    }           
            return View();           
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {             
             var checkLogin = bookingRepository.GetAdmins().SingleOrDefault(m => m.email.Equals(model.email));
                if (checkLogin != null)
                {
                    if (Security.VerifyPassword(model.Password,checkLogin.securedpassword))
                    {
                        Session.Add("email", model.email);
                        return RedirectToAction("Bookings", "AdminManage");
                    }
                    else
                    {
                        ViewBag.Msg = "Invalid Password";                        
                    }
                }
                else
                {
                    ViewBag.Msg = "Invalid Email or Password";
                }                
            }           
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                AdminClm userEmail = bookingRepository.GetAdmins().SingleOrDefault(m => m.email.Equals(model.Email));
                if (userEmail !=null)
                {
                    userEmail.securedpassword = Security.Hash(model.ConfirmPassword);
                    bookingRepository.UpdateAdmin(userEmail);
                    TempData["Worked"] = "Password Changed";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("email");
            return RedirectToAction("Login", "Admin");
        }
    }
}