using Clm_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Clm_Booking.Utils
{
    public class EmailService
    {
        public bool SendEmailToClient(ClientClm clientInfo) {
            bool flag;

            var time =clientInfo.booktime.ToString("hh:mm");



            var msgIntro = $"<p>Hi {clientInfo.firstname},</p>";
            var msgBody = $"<div style='font-size:20px; font-weight:500;'> </div><p>Your appointment is scheduled for <span style='color:red; font-weight:600;'> {clientInfo.bookdate.DayOfWeek} {clientInfo.bookdate.ToString("yyyy/MM/dd")}</span> and <span style='color:red; font-weight:600;'> {time}.</span><br/></p>";
            var footer = "Regards, <br/>See you later!! <br/><p>Covenant Life Ministries</p>";
            var finalEdit = $"<div style='border:1px solid gray; margin-left: auto; margin-right: auto; border-radius: 20px; width:600px; text-align:center;'> " +
                $"<h4> Clm Booking </h4>" +
                $"{msgBody}" +
                $"{footer}" +
                $"</div>";
            

            try
            {
                flag = true;
                using (SmtpClient client = new SmtpClient())
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.EnableSsl = true;
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("clmappointment@gmail.com", "Covenant95");

                    MailMessage mailMessage = new MailMessage();

                    mailMessage.From = new MailAddress("clmappointment@gmail.com", "Clm Booking");
                    mailMessage.To.Add(clientInfo.email);
                    mailMessage.Subject = "Clm Booking Receipt";
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = $"{msgIntro} " +  $"{finalEdit}";

                    client.Send(mailMessage);
                    client.Dispose();
                }
                return flag;    
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}