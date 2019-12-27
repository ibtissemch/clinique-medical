using Newtonsoft.Json;
using Projetcliniquemedical.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projetcliniquemedical.Controllers
{
    public class RdvController : Controller
    {
        // GET: Rdv
        OurDbContext db = new OurDbContext ();

        /*public ActionResult RendezVous()
        {
            ViewBag.Userid = Session["UserID"];


            var data = db.rdv.ToList();
            return View(data);
        }*/

        public ActionResult RendezVous2()
        {

            IEnumerable<Rdv> rdvs = null;
            
                using (var client = new HttpClient())
                {
                    String id = Session["UserID"].ToString();
                    client.BaseAddress = new Uri("https://localhost:44345/");
                    //HTTP GET
                    var responseTask = client.GetAsync("api/Rdvs/Medecin/"+id);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Rdv>>();
                        readTask.Wait();

                        rdvs = readTask.Result;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        rdvs = Enumerable.Empty<Rdv>();

                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            return View(rdvs);
        }
           
           
    }

 }

