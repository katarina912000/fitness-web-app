using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;


namespace Projekat_WEB.Controllers
{
    public class SortiranjaController : Controller
    {
        // GET: Sortiranja
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RastuceGodine()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];



            var sortedList = fitnesCentri2.OrderBy(x => x.GodinaOtvaranja).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }

        [HttpPost]
        public ActionResult RastuceNaziv()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            

            var sortedList = fitnesCentri2.OrderBy(x=>x.Ime).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult RastuceAdrese()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            

            var sortedList = fitnesCentri2.OrderBy(x => x.NazivUlice).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceAdrese()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

          

            var sortedList = fitnesCentri2.OrderByDescending(x => x.NazivUlice).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceGodine()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];



            var sortedList = fitnesCentri2.OrderByDescending(x => x.GodinaOtvaranja).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }

        [HttpPost]
        public ActionResult OpadajuceNaziv()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            
            
            
            var sortedList=fitnesCentri2.OrderByDescending(x=>x.Ime).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml",sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceNazivTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik k = (Korisnik)Session["logedIn"];
           

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                        {
                            gt1.Add(item);
                        }
                    }
                }
             
            }
            var sortedList = gt1.OrderByDescending(x => x.Id).ToList();

            ViewBag.GtsTrenerZavrseni = sortedList;
            
            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {

                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                        {
                            gt2.Add(item);
                        }
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;
            return View("~/Views/Trener/Index.cshtml");
        }

        [HttpPost]
        public ActionResult RastuceNazivTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik k = (Korisnik)Session["logedIn"];


            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                        {
                            gt1.Add(item);
                        }
                    }
                }
            }

            var sortedList = gt1.OrderBy(x => x.Id).ToList();

            ViewBag.GtsTrenerZavrseni = sortedList;

            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {

                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                        {
                            gt2.Add(item);
                        }
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;
            return View("~/Views/Trener/Index.cshtml");
        }


        [HttpPost]
        public ActionResult OpadajuceTipTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
           
            Korisnik k = (Korisnik)Session["logedIn"];

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                        {
                            gt1.Add(item);
                        }
                    }
                }
            }

            var sortedList = gt1.OrderByDescending(x => x.TipTreninga).ToList();

            ViewBag.GtsTrenerZavrseni = sortedList;


            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {

                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                        {
                            gt2.Add(item);
                        }
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;

            return View("~/Views/Trener/Index.cshtml");
        }

        [HttpPost]
        public ActionResult RastuceTipTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            Korisnik k = (Korisnik)Session["logedIn"];

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                        {
                            gt1.Add(item);
                        }
                    }
                }
            }

            var sortedList = gt1.OrderBy(x => x.TipTreninga).ToList();

            ViewBag.GtsTrenerZavrseni = sortedList;


            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {

                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                        {
                            gt2.Add(item);
                        }
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;

            return View("~/Views/Trener/Index.cshtml");
        }

        [HttpPost]
        public ActionResult OpadajuceDatumTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            Korisnik k = (Korisnik)Session["logedIn"];

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                        {
                            gt1.Add(item);
                        }
                    }
                }
            }

            var sortedList = gt1.OrderByDescending(x => x.DatumIVremeTreninga).ToList();

            ViewBag.GtsTrenerZavrseni = sortedList;


            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi) { 
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {

                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                        {
                            gt2.Add(item);
                        }
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;

            return View("~/Views/Trener/Index.cshtml");
        }

        [HttpPost]
        public ActionResult RastuceDatumTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            Korisnik k = (Korisnik)Session["logedIn"];

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                        {
                            gt1.Add(item);
                        }
                    }
                }
            }

            var sortedList = gt1.OrderBy(x => x.DatumIVremeTreninga).ToList();

            ViewBag.GtsTrenerZavrseni = sortedList;


            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                if (k.GrupniTreninziKorisnikTrener != null)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                    {

                        if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                        {
                            gt2.Add(item);
                        }
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;

            return View("~/Views/Trener/Index.cshtml");
        }

    }
}