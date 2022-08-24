using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;

namespace Projekat_WEB.Controllers
{
    public class VlasnikController : Controller
    {
        // GET: Vlasnik
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrujTrenera()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, string godinaRodjenja)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            int countID = 0;
            Korisnik korisnik = (Korisnik)Session["logedIn"];
            countID = korisnici.Count;
            if (korisnickoIme != "" && lozinka != "" && ime != "" && prezime != "" && pol != "" && email != "" && godinaRodjenja != "")
            {
                for (int i = 0; i < korisnici.Count; i++)
                {
                    countID = korisnici[i].Id;
                    if (korisnici[i].KorisnickoIme == korisnickoIme)
                    {
                        ViewBag.Greska = "Postoji vec user sa tim korisnickim imenom";
                        return RedirectToAction("Index");
                    }

                }
                countID++;


                DateTime dateTime = DateTime.Parse(godinaRodjenja);

                Korisnik kor = new Korisnik(countID, korisnickoIme, lozinka, ime, prezime, pol, email, dateTime,UlogaEnum.Uloga.TRENER.ToString(), new List<int>(), new List<int>(), "", new List<string>());


                korisnici.Add(kor);

                
                ViewBag.Message = "Uspesno dodat trener:" + korisnickoIme;

                string text = null;
                var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

                foreach (var k in korisnici)
                {
                    text += k.ToString();
                    if (k.Id.ToString() != "\r")
                    {
                        text += "\r";
                    }
                }

                System.IO.File.WriteAllText(path1, text);
            }
            else
            {
                ViewBag.Greska = "Nisu popunjena sva polja kako treba";
            }


            HttpContext.Application["korisnici"] = korisnici;



            return RedirectToAction("Index","Pocetni");
        }
    }
}