using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projetcliniquemedical.Controllers
{
    public class DemandeRdvController : Controller
    {
        // GET: DemandeRdv
        public ActionResult DemandeForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DemandeForm(string nometprenom, string numcnss, string date, string heure)
        {
            try
            {
                using (MailMessage mm = new MailMessage())
                {
                    SmtpClient sc = new SmtpClient();
                    mm.From = new MailAddress("meriem919@gmail.com", "Demande Rendez-Vous");
                    mm.To.Add(new MailAddress("meriem.amri.tn@gmail.com"));
                    mm.IsBodyHtml = true;
                    mm.Subject = numcnss;
                    mm.Body = "je suis le patient " + nometprenom + " je veux prendre un rendez-vous le "+date+" à "+ heure;
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