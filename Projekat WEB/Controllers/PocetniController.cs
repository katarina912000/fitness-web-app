using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public ActionResult Detalji()
        {
            //Write();
            return View("Detalji");
        }

        //upisivanje u txt fajl
        public void Write()
        {
            var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\FitnesCentri.txt";
            using(StreamWriter sw=new StreamWriter(path))
            {
                sw.Write("FLEX;Sutjeska;2;Novi Sad;21000;2014;Milan;Maric;2500,00;12000,00;500,00;300,00;1500,00");
            }
        }
        //citanje iz txt fajla
        public void Read()
        {
            var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\FitnesCentri.txt";
            if (System.IO.File.Exists(path))
            {
                using(TextReader tr=new StreamReader(path))
                {
                    var text = tr.ReadLine();
                }
            }

        }
    }
}