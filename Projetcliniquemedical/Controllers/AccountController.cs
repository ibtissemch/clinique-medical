using Projetcliniquemedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projetcliniquemedical.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using(OurDbContext db =new OurDbContext())
            {
                var usr = db.userAccount.Single(u => u.Email == user.Email && u.Password == user.Password && u.Type==user.Type);
                if(usr != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Email"] = usr.Email.ToString();
                    if(usr.Type.ToString()== "medecin")
                    {
                        return RedirectToAction("Dentiste");
                    }
                    if (usr.Type.ToString() == "admin")
                    {
                        return RedirectToAction("Admin");
                    }
                    if (usr.Type.ToString() == "patient")
                    {
                        return RedirectToAction("Patient");
                    }
                    else
                    {
                        return RedirectToAction("LoggedIn");
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Email ou mot de pass erronée");

                }
            }
            return View();
        }
       public ActionResult LoggedIn()
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Dentiste()
        {
                return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Patient()
        {
            return View();
        }
    }
}