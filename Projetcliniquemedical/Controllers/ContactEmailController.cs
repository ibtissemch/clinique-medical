using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projetcliniquemedical.Controllers
{
    public class ContactEmailController : Controller
    {
        // GET: ContactEmail
        public ActionResult Form()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Form(string receiverEmail, string subject, string message, string namePatient)
        {
            try
            {
                using (MailMessage mm = new MailMessage())
                {
                    SmtpClient sc = new SmtpClient();
                    mm.From = new MailAddress("meriem919@gmail.com", "Contact Form");
                    mm.To.Add(new MailAddress(receiverEmail));
                    mm.IsBodyHtml = true;
                    mm.Subject = subject;
                    mm.Body = message + namePatient;
                    mm.BodyEncoding = System.Text.Encoding.UTF8;
                    mm.SubjectEncoding = System.Text.Encoding.UTF8;
                    NetworkCredential su = new NetworkCredential(mm.From.Address, "mimitadsl :D5");
                    sc.Host = "smtp.gmail.com";
                    sc.Port = 587;
                    sc.EnableSsl = true;
                    sc.UseDefaultCredentials = false;
                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.Credentials = su;
                    sc.Send(mm);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "there are some problems in sending Email";
            }
            return View();
        }
    }
}