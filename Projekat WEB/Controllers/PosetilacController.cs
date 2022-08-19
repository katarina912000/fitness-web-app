﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;

namespace Projekat_WEB.Controllers
{
    public class PosetilacController : Controller
    {
        // GET: Posetilac
        public ActionResult Index()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();

            List<int> gts = new List<int>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }
            ViewBag.Gts = izdvojeni;

            return View();
        }
        [HttpPost]
        public ActionResult RastuceNaziv()
        {
            
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }
            var sortedList = izdvojeni.OrderBy(x => x.Id).ToList();

            ViewBag.Gts = sortedList;
            return View("~/Views/Posetilac/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceNaziv()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }
            var sortedList = izdvojeni.OrderByDescending(x => x.Id).ToList();

            ViewBag.Gts = sortedList;
            return View("~/Views/Posetilac/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult RastuceTip()
        {

            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }
            var sortedList = izdvojeni.OrderBy(x => x.TipTreninga).ToList();

            ViewBag.Gts = sortedList;
            return View("~/Views/Posetilac/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceTip()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }
            var sortedList = izdvojeni.OrderByDescending(x => x.TipTreninga).ToList();

            ViewBag.Gts = sortedList;
            return View("~/Views/Posetilac/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult RastuceDatum()
        {

            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }



            var sortedList = izdvojeni.OrderBy(x => x.DatumIVremeTreninga).ToList();

            ViewBag.Gts = sortedList;
            return View("~/Views/Posetilac/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceDatum()
        {

            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }



            var sortedList = izdvojeni.OrderByDescending(x => x.DatumIVremeTreninga).ToList();

            ViewBag.Gts = sortedList;
            return View("~/Views/Posetilac/Index.cshtml", sortedList);
        }

        [HttpPost]
        public ActionResult PrijavaTreninga(int id)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            GrupniTrening gt = new GrupniTrening();
            //id je id od grupnog treninga
            List<int> counts = new List<int>();
            foreach (var item in grupniTreninzi)
            {
                int count = 0;
                foreach (var k in korisnici)
                {
                    if (k.GrupniTreninziKorisnikPrijavljen != null)
                    {
                        for (int i = 0; i < k.GrupniTreninziKorisnikPrijavljen.Count; i++)
                        {
                            if (k.GrupniTreninziKorisnikPrijavljen[i] == item.Id)
                            {
                                count++;
                            }
                        }
                    }

                    counts.Add(count);//tu su sad brojevi koliko ima ukupno prijavljenih redom na nekom gt
                }
            }
            //sledi provera da li je broj prijavljenih veci od maks->to na view-u

            //prijaviti->upisati u bazu korisnici id grupnog tr
            Korisnik koris = (Korisnik)Session["logedIn"];

            if (koris.GrupniTreninziKorisnikPrijavljen == null)
            {
                koris.GrupniTreninziKorisnikPrijavljen = new List<int>();
            }

            koris.GrupniTreninziKorisnikPrijavljen.Add(id);

            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

            foreach (Korisnik kor in korisnici)
            {
                text += kor.ToString();
                if (kor.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }

            System.IO.File.WriteAllText(path1, text);

            //pronadjemo taj gt
            foreach (var gtr in grupniTreninzi)
            {
                if (gtr.Id == id)
                {
                    gt = gtr;
                }
            }
            //proverimo da li je null
            if (gt.Korisnici == null)
            {
                gt.Korisnici = new List<int>();
            }
            gt.Korisnici.Add(koris.Id);
            string text1 = null;
            var path2 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\GrupniTreninzi.txt";

            foreach (var gtre in grupniTreninzi)
            {
                text1 += gtre.ToString() + "\r";

            }

            System.IO.File.WriteAllText(path2, text1);

            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];


            HttpContext.Application["korisnici"] = korisnici;
            HttpContext.Application["grupniTreninzi"] = grupniTreninzi;
            return View("~/Views/Pocetni/Index.cshtml", fitnesCentri);
        }

        [HttpPost]
        public ActionResult IstorijaTreninga()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            //logika
            //izvucem iz ulogovanog korisnika,te grupne treninge i posaljem kao listu ili model
            Korisnik koris = (Korisnik)Session["logedIn"];
            List<int> gts = new List<int>();
            gts = koris.GrupniTreninziKorisnikPrijavljen;//idjevi tih treninga
            for (int j = 0; j < gts.Count; j++)
            {
                for (int i = 0; i < grupniTreninzi.Count; i++)
                {
                    if (grupniTreninzi[i].Id == gts[j])
                    {
                        izdvojeni.Add(grupniTreninzi[i]);
                    }
                }

            }
            ViewBag.Gts = izdvojeni;
            return View("Index");
        }
        [HttpPost]
        public ActionResult PretragaKombinovano(string naziv, int id, string tipTreninga, string nazivFC)
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            List<GrupniTrening> izdvojeni = new List<GrupniTrening>();
            if (naziv == "Grupni trening" && id == 0 && tipTreninga == "" && nazivFC == "")
            {
                ViewBag.Greska = " Nisu uneseni podaci za pretragu";
            }
            PretragaNaziv(naziv, id);

            PretragaTip(tipTreninga);

            PretragaNazivFC(nazivFC);

            return View();

        }
        //radi
        public void PretragaNaziv(string naziv, int id)
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            GrupniTrening nadjen = new GrupniTrening();
            Korisnik k = (Korisnik)Session["logedIn"];
            if (naziv != "" && id != 0)
            {
                string maloIme = naziv.ToLower();
                foreach (GrupniTrening gt in grupniTreninzi)
                {
                    string maloNaziv = gt.Naziv.ToLower();
                    for (int i = 0; i < k.GrupniTreninziKorisnikPrijavljen.Count; i++)
                    {
                        if (k.GrupniTreninziKorisnikPrijavljen[i] == id && gt.Id == id)
                        {
                            nadjen = gt;
                            ViewBag.Data = nadjen;

                            break;
                        }

                    }

                }
                if (nadjen == null)
                {
                    ViewBag.Greska = "Nije pronadjen grupni trening sa tim nazivom i id-jem";
                }
            }




        }

        public void PretragaTip(string tip)
        {
            Korisnik k = (Korisnik)Session["logedIn"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> gts = new List<GrupniTrening>();
            //sve korisnikove odredjenog tipa treninge
            if (tip != "")
            {
                for (int i = 0; i < k.GrupniTreninziKorisnikPrijavljen.Count; i++)
                {
                    foreach (var gt in grupniTreninzi)
                    {
                        if (gt.Id == k.GrupniTreninziKorisnikPrijavljen[i])
                        {
                            if (gt.TipTreninga.ToLower() == tip.ToLower())
                            {
                                gts.Add(gt);
                                ViewBag.Gts = gts;
                            }
                        }
                    }
                }
                if (gts.Count == 0)
                {
                    ViewBag.Greska = "Nije pronadjen grupni trening sa tim tipom";
                }
            }

        }


        //radi
        public void PretragaNazivFC(string nazivFC)
        {
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            Korisnik k = (Korisnik)Session["logedIn"];


            List<GrupniTrening> gtFC = new List<GrupniTrening>();
            List<GrupniTrening> gtFC1 = new List<GrupniTrening>();
            if (nazivFC != "")
            {
                foreach (var gt in grupniTreninzi)
                {
                    if (gt.FitnesCent.ToLower() == nazivFC.ToLower())
                    {
                        gtFC.Add(gt);
                    }
                }

                foreach (var gt1 in gtFC)
                {
                    for (int i = 0; i < k.GrupniTreninziKorisnikPrijavljen.Count; i++)
                    {
                        if (gt1.Id == k.GrupniTreninziKorisnikPrijavljen[i])
                        {
                            gtFC1.Add(gt1);
                            ViewBag.GrupniTr = gtFC1;
                        }
                    }
                }
                if (gtFC1.Count == 0)
                {
                    ViewBag.Greska = "Nije pronadjen  nijedan prijavljeni grupni trening sa tim nazivom fitnes centra";
                }
            }

        }
    }
}
