﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat_WEB.Controllers
{
    public class PocetniController : Controller
    {
        // GET: Pocetni
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult DodajKorisnika(string korisnickoime,string lozinka,string uloga)
        //{

        //    return View("Index");
        //}

    }
}