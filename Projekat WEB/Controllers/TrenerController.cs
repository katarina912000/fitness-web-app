using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat_WEB.Models;
using System.Web.Mvc;
using System.Globalization;

namespace Projekat_WEB.Controllers
{
    public class TrenerController : Controller
    {
        // GET: Trener
        public ActionResult Index()
        {
            Korisnik k = (Korisnik)Session["logedIn"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> gt = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                {
                    if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                    {
                        gt.Add(item);
                    }
                }
            }

            ViewBag.GtsTrenerZavrseni = gt;
            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                {
                    
                    if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                    {
                        gt2.Add(item);
                    }
                }
            }
            ViewBag.GtPredstojeci = gt2;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;
            return View();
        }

        [HttpPost]
        public ActionResult KreirajTrening()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            return View(grupniTreninzi);
        }
        bool  valja2, valja3, valja4, valja5 = false;
        [HttpPost]
        public ActionResult Kreiraj( string id,string fitnesCent, string trajanje, string datum,string vreme, string tip, string maksPosetilaca)
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            GrupniTrening gt = new GrupniTrening();
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

           
            if (fitnesCent!="" && trajanje != "" && datum!="" && vreme!="" && tip != "" && maksPosetilaca != "")
            {
                //znaci da su sva polja unesena
                int idd;
                Int32.TryParse(id, out idd);

                int trajanj;
                Int32.TryParse(trajanje, out trajanj);

                int makspos;
                Int32.TryParse(maksPosetilaca, out makspos);

                string datumIvreme = datum +" "+ vreme;
                DateTime date = DateTime.Parse(datumIvreme);
               

                for (int i=0;i<grupniTreninzi.Count;i++) 
                {
                    gt.Id = idd;
                    if (fitnesCentri.Exists(x => x.Ime.Equals(fitnesCent)))
                    {
                        gt.FitnesCent = fitnesCent;
                        valja2 = true;
                    }
                    else
                    {
                        ViewBag.Greska += ", i ne postoji takav fitnes centar u bazi";
                    }

                    if (trajanj > 0 && trajanj <= 60)
                    {
                        gt.TrajanjeTreninga = trajanj;
                        valja3 = true;


                    }
                    else
                    {
                        ViewBag.Greska += ", i trajanje treninga treba biti pozitivan broj manji od 60";
                    }


                    if ((date - DateTime.Now).Days >= 3)
                    {
                        gt.DatumIVremeTreninga = date;
                        valja4 = true;

                    }
                    else
                    {
                        ViewBag.Greska += ", i datum treninga treba biti najmanje 3 dana unapred";
                    }

                    gt.TipTreninga = tip.ToLower();
                    if(makspos>0 && makspos < 50)
                    {
                        gt.MaxBrojPosetilaca = makspos;
                        valja5 = true;

                    }
                    else
                    {
                        ViewBag.Greska += ", i maksimalan broj posetioca treba da je broj pozitivan i  manji od 50";
                    }

                }

            }
            else
            {
                ViewBag.Greska = "Nisu sva polja popunjena.";
            }
            if (valja2 && valja3 && valja4 && valja5)
            {
                grupniTreninzi.Add(gt);
            }
            Korisnik k = (Korisnik)Session["logedIn"];
            k.GrupniTreninziKorisnikTrener.Add(Int32.Parse(id));
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            //ispis da je on trener tog tr
            string text1 = null;
            var path2 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

            foreach (var kor in korisnici)
            {
                text1 += kor.ToString();
                if (kor.Id.ToString() != "\r")
                {
                    text1 += "\r";
                }
            }

            System.IO.File.WriteAllText(path2, text1);

            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\GrupniTreninzi.txt";

            foreach (var kor in grupniTreninzi)
            {
                text += kor.ToString();
                if (kor.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }

            System.IO.File.WriteAllText(path1, text);

            HttpContext.Application["grupniTreninzi"] = grupniTreninzi;
            return View("KreirajTrening",grupniTreninzi);
        }

        [HttpPost]

        public ActionResult ModifikujTrening(int id)
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            GrupniTrening gt = new GrupniTrening();
            foreach (GrupniTrening gt1 in grupniTreninzi)
            {
                if (gt1.Id == id)
                {
                    gt = gt1;
                    Session["logTr"] = gt;
                    break;
                }
            }

            ViewBag.SesijaGT = gt;

            return View();
            
        }
        [HttpPost]

        public ActionResult EditConfirm(int id,string fitnesCent,int trajanje,string datum,string tip,int maksPosetilaca)
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            GrupniTrening gt1 = (GrupniTrening)Session["logTr"];
            if (gt1.Id!=id)
            {
                gt1.Id = id;
            }
            if (gt1.FitnesCent.ToLower() != fitnesCent.ToLower())
            {
                gt1.FitnesCent = fitnesCent;
            }
            if (gt1.TrajanjeTreninga != trajanje)
            {
                gt1.TrajanjeTreninga = trajanje;
            }
            if (gt1.DatumIVremeTreninga.ToString() != datum)
            {
                DateTime datetime = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                gt1.DatumIVremeTreninga = datetime;
            }
            if (gt1.TipTreninga.ToLower() != tip.ToLower())
            {
                gt1.TipTreninga = tip;

            }
            if (gt1.MaxBrojPosetilaca != maksPosetilaca)
            {
                gt1.MaxBrojPosetilaca = maksPosetilaca;

            }
            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\GrupniTreninzi.txt";

            foreach (var kor in grupniTreninzi)
            {
                text += kor.ToString();
                if (kor.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }

            System.IO.File.WriteAllText(path1, text);

            HttpContext.Application["grupniTreninzi"] = grupniTreninzi;
            return RedirectToAction("Index");
        }


        [HttpPost]

        public ActionResult ObrisiTrening(int id)
        {
            //prosledjen je id od tog gt
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
           
            foreach (GrupniTrening gt in grupniTreninzi)
            {
                foreach(var k in korisnici)
                {
                    if (k.Uloga == "POSETILAC")
                    {
                        for (int i = 0; i < k.GrupniTreninziKorisnikPrijavljen.Count; i++)
                        {
                            if (gt.Id == id)
                            {
                                gt.Obrisan = true;
                            }
                        }
                    }
                }
               
            }
            //ponovo da se ispise fajl
            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\GrupniTreninzi.txt";

            foreach (GrupniTrening gt in grupniTreninzi)
            {
                text += gt.ToString();
                if (gt.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }

            System.IO.File.WriteAllText(path1, text);

            return View("Index");
        }
        [HttpPost]

        public ActionResult Prikazi()
        {
            Korisnik k = (Korisnik)Session["logedIn"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<GrupniTrening> gt = new List<GrupniTrening>();
            foreach(var item in grupniTreninzi)
            {
                for(int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                {
                    if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                    {
                        gt.Add(item);
                    }
                }
            }

            ViewBag.GtsTrenerZavrseni = gt;
            List<GrupniTrening> gt2 = new List<GrupniTrening>();

            foreach (var item in grupniTreninzi)
            {
                for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                {
                    
                    if (k.Uloga=="POSETILAC" && k.GrupniTreninziKorisnikPrijavljen[i] == item.Id)
                    {
                        ViewBag.PrijavljenPosetilac = "Posetilac je prijavljen";
                        break;
                    }
                    if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga > DateTime.Now)
                    {
                        gt2.Add(item);
                    }
                }
            }
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            ViewBag.Korisnici = korisnici;
            ViewBag.GtPredstojeci = gt2;
            return View("Index");
        }


        [HttpPost]
        public ActionResult SpisakPosetilaca(int id)
        {
            //treba vratiti spisak korisnickih imena
            List<string> korImena = new List<string>();
            //trebaju mi posetioci
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            foreach (var item in korisnici)
            {
                if (item.Uloga == "POSETILAC")
                {
                    for (int i = 0; i < item.GrupniTreninziKorisnikPrijavljen.Count; i++)
                    {
                        if (item.GrupniTreninziKorisnikPrijavljen[i] == id)
                        {
                            korImena.Add(item.KorisnickoIme);
                        }
                    }

                }
            }

            return View(korImena);
        }
        [HttpPost]
        public ActionResult PretragaKombinovano(int id,string tipTreninga)
        {
            if (id == 0 && tipTreninga == "")
            {
                ViewBag.Greska = " Nisu uneseni podaci za pretragu";
            }

            PretragaNaziv(id);

            PretragaTip(tipTreninga);

            return View();
        }
        public void PretragaNaziv( int id)
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            GrupniTrening nadjen = new GrupniTrening();
            Korisnik k = (Korisnik)Session["logedIn"];

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                {
                    if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                    {
                        gt1.Add(item);
                    }
                }
            }
            if ( id != 0)
            {
                foreach (GrupniTrening gt in gt1)
                {
                    
                        if (gt.Id== id)
                        {
                            nadjen = gt;
                            ViewBag.Data = nadjen;

                            break;
                        }
                        
                }
                if (nadjen.Id == 0)
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

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            foreach (var item in grupniTreninzi)
            {
                for (int i = 0; i < k.GrupniTreninziKorisnikTrener.Count; i++)
                {
                    if (k.GrupniTreninziKorisnikTrener[i] == item.Id && item.DatumIVremeTreninga < DateTime.Now)
                    {
                        gt1.Add(item);
                    }
                }
            }
            //sve korisnikove odredjenog tipa treninge
            if (tip != "")
            {
                    foreach (var gt in gt1)
                    {
                        if (gt.TipTreninga.ToLower() == tip.ToLower())
                        {
                                gts.Add(gt);
                                ViewBag.Gts = gts;
                           
                        }
                    }
                
                if (gts.Count == 0)
                {
                    ViewBag.Greska = "Nije pronadjen grupni trening sa tim tipom";
                }
            }

        }


    }
}