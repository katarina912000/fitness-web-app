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
        public ActionResult PregledKomentara()
        {
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            List<Komentar> comments = new List<Komentar>();
            Korisnik k = (Korisnik)Session["logedIn"];
            foreach(var item in komentari)
            { foreach(var it in k.FitnesCentriVlasnik)
                    if (item.FitnesCentarKomentar == it)
                    {
                        comments.Add(item);
                    }
            }
            
            return View(comments);
        }
        [HttpPost]
        public ActionResult StanjeOdobri(int id)
        {
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];

            foreach(var item in komentari)
            {
                if (item.Id == id)
                {
                    item.Stanje = 1;
                }
            }

           
            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Komentari.txt";

            foreach (var k in komentari)
            {
                text += k.ToString();
                if (k.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }
            List<Komentar> comments = new List<Komentar>();
            Korisnik ko = (Korisnik)Session["logedIn"];
         

            System.IO.File.WriteAllText(path1, text);
            HttpContext.Application["komentari"] = komentari;
            foreach (var item in komentari)
            {
                foreach (var it in ko.FitnesCentriVlasnik)
                    if (item.FitnesCentarKomentar == it)
                    {
                        comments.Add(item);
                    }
            }
            return View("PregledKomentara", comments);
        }
        [HttpPost]
        public ActionResult StanjeOdbij(int id)
        {
            List<Komentar> komentari = (List<Komentar>)HttpContext.Application["komentari"];
            List<Komentar> comments = new List<Komentar>();
            Korisnik ko = (Korisnik)Session["logedIn"];
            
            foreach (var item in komentari)
            {
                if (item.Id == id)
                {
                    item.Stanje = 0;
                }
            }


            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Komentari.txt";

            foreach (var k in komentari)
            {
                text += k.ToString();
                if (k.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }

            System.IO.File.WriteAllText(path1, text);
            HttpContext.Application["komentari"] = komentari;
            foreach (var item in komentari)
            {
                foreach (var it in ko.FitnesCentriVlasnik)
                    if (item.FitnesCentarKomentar == it)
                    {
                        comments.Add(item);
                    }
            }
            return View("PregledKomentara", comments);
        }
       

        [HttpPost]
        public ActionResult BlokirajTrenera()
        {
            
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik korisnik = (Korisnik)Session["logedIn"];
            List<Korisnik> treneri = new List<Korisnik>();

           
            foreach(var item in korisnici)
            {
                foreach(var it in korisnik.FitnesCentriVlasnik)
                {
                    if (it == item.AngazovanTrenerFitnesCentra && item.AngazovanTrenerFitnesCentra!=null)
                    {
                        treneri.Add(item);
                    }
                }
               
            }

            return View(treneri);
        }

        [HttpPost]
        public ActionResult Blokiraj(int id)
        {
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            foreach(var item in korisnici)
            {
                if (item.Id == id && item.AngazovanTrenerFitnesCentra!=null)
                {
                    item.Id = 0;
                    //blokiran
                }
            }
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
            HttpContext.Application["korisnici"] = korisnici;

            Korisnik korisnik = (Korisnik)Session["logedIn"];
            List<Korisnik> treneri = new List<Korisnik>();


            foreach (var item in korisnici)
            {
                foreach (var it in korisnik.FitnesCentriVlasnik)
                {
                    if (it == item.AngazovanTrenerFitnesCentra && item.AngazovanTrenerFitnesCentra != null )
                    {
                        treneri.Add(item);
                    }
                }

            }
            return View("BlokirajTrenera",treneri);
        }
        [HttpPost]
        public ActionResult Add(string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email,string fitnesCentar, string godinaRodjenja)
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
                if (korisnik.FitnesCentriVlasnik.Exists(x => x.Equals(fitnesCentar)))
                {
                    if(pol == PolEnum.Pol.MUSKI.ToString() || pol == PolEnum.Pol.ZENSKI.ToString())
                    {
                        Korisnik kor = new Korisnik(countID, korisnickoIme, lozinka, ime, prezime, pol, email, dateTime, UlogaEnum.Uloga.TRENER.ToString(), new List<int>(), new List<int>(), fitnesCentar, new List<string>());


                        korisnici.Add(kor);
                        ViewBag.Message = "Uspesno dodat trener:" + korisnickoIme;
                    }else {

                        ViewBag.Message = "Pol treba da bude muski ili zenski,probajte opet";

                    }

                }
                else
                {
                    ViewBag.Message = "Niste vlasnik tog fitnes centra ili popravite slova pri upisu istog! :)";
                }
               
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
            
            return View("RegistrujTrenera");
        }

        [HttpPost]
        public ActionResult PrikaziFitnesCentre()
        {
            Korisnik k = (Korisnik)Session["logedIn"];
            List<FitnesCentar> fc = new List<FitnesCentar>();
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            foreach(var item in fitnesCentri)
            {
                for(int i = 0; i < k.FitnesCentriVlasnik.Count; i++)
                {
                    if (item.Ime == k.FitnesCentriVlasnik[i])
                    {
                        fc.Add(item);
                    }
                }
            }
            return View(fc);
        }

        [HttpPost]
        public ActionResult ModifikovanjeFitnesCentra(int id)
        {
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            foreach (FitnesCentar fc in fitnesCentri)
            {
                if (fc.Id == id)
                {
                    ViewBag.Data = fc;
                }
            }
                    return View();
        }

        [HttpPost]
        public ActionResult Izmeni(int id,string ime,string nazivUlice,string broj,string mesto,string postBroj,string godina,string cenaMesecneCl, string cenaGodisnjeCl, string cenaJednogTr, string cenaJednogGrupnogTr,string cenaJednogTrsaPersonalnimTr)
        {
            Korisnik k = (Korisnik)Session["logedIn"];
            List<FitnesCentar> fc = new List<FitnesCentar>();
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            foreach (var item in fitnesCentri)
            {
                for (int i = 0; i < k.FitnesCentriVlasnik.Count; i++)
                {
                    if (item.Ime == k.FitnesCentriVlasnik[i])
                    {
                        fc.Add(item);//tu su sada fcentri od vlasnika
                    }
                }
            }
            int br;      
            int postbr;
            int cenaJednog;
            int cenaMes;
            int god;
            int cenaGod;
            int cenaJednogGrupnog;
            int cenaJednPers;
            Int32.TryParse(broj, out br);
            Int32.TryParse(godina, out god);
            Int32.TryParse(postBroj, out postbr);
            
            Int32.TryParse(cenaMesecneCl, out cenaMes);
           
            Int32.TryParse(cenaGodisnjeCl, out cenaGod);
            
            Int32.TryParse(cenaJednogTr, out cenaJednog);
            
            Int32.TryParse(cenaJednogGrupnogTr, out cenaJednogGrupnog);
            Int32.TryParse(cenaJednogTrsaPersonalnimTr, out cenaJednPers);


            if (ime!=""&&nazivUlice!=""&& broj != "" && mesto != "" && postBroj != "" && godina != ""&& cenaMesecneCl != "" && cenaGodisnjeCl != ""&& cenaJednogGrupnogTr != "" && cenaJednogTr != "" && cenaJednogTrsaPersonalnimTr!="")
            {
                foreach (var item in fc)
                {
                    if (item.Id == id)
                    {
                        if (item.Ime != ime)
                        {
                            k.FitnesCentriVlasnik.Remove(item.Ime);
                            k.FitnesCentriVlasnik.Add(ime);
                            item.Ime = ime;
                            
                        }
                        if (item.NazivUlice != nazivUlice)
                        {
                            item.NazivUlice = nazivUlice;
                        }
                        if (item.BrojAdr != br)
                        {
                            item.BrojAdr = br;
                        }
                        if (item.Mesto != mesto)
                        {
                            item.Mesto = mesto;
                        }
                        if (item.PostBr != postbr)
                        {
                            item.PostBr = postbr;
                        }
                        if (item.GodinaOtvaranja != god)
                        {
                            item.GodinaOtvaranja = god;
                        }
                        if (item.CenaMesecneClanarine != cenaMes)
                        {
                            item.CenaMesecneClanarine = cenaMes;
                        }
                        if (item.CenaGodisnjeClanarine != cenaGod)
                        {
                            item.CenaGodisnjeClanarine = cenaGod;
                        }
                        if (item.CenaJednogTreninga != cenaJednog)
                        {
                            item.CenaJednogTreninga = cenaJednog;
                        }
                        if (item.CenaJednogGrupnogTreninga != cenaJednogGrupnog)
                        {
                            item.CenaJednogGrupnogTreninga = cenaJednogGrupnog;
                        }
                        if (item.CenaJednogTrSaPersonalnimTr != cenaJednPers)
                        {
                            item.CenaJednogTrSaPersonalnimTr = cenaJednPers;
                        }

                    }
                }

                //
                string text1 = null;
                var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

                foreach (var korisn in korisnici)
                {
                    text1 += korisn.ToString();
                    if (korisn.Id.ToString() != "\r")
                    {
                        text1 += "\r";
                    }
                }

                System.IO.File.WriteAllText(path, text1);//
                HttpContext.Application["korisnici"] = korisnici;


                //
                string text = null;
                var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\FitnesCentri.txt";

                foreach (var kor in fitnesCentri)
                {
                    if (kor.Ime != "")
                    {
                        text += kor.ToString();
                        if (kor.Ime.ToString() != "\r")
                        {
                            text += "\r";
                        }
                    }
                    
                }

                System.IO.File.WriteAllText(path1, text);

                HttpContext.Application["fitnesCentri"] = fitnesCentri;
                //

            }
            else
            {
                ViewBag.Greska = "Ne smeju ostati prazna polja :)";
            }
            return View("PrikaziFitnesCentre",fc);
        }

        [HttpPost]
        public ActionResult KreirajFC(string ime, string nazivUlice, string broj, string mesto, string postBroj, string godina, string cenaMesecneCl, string cenaGodisnjeCl, string cenaJednogTr, string cenaJednogGrupnogTr,string cenaJednogTrsaPersonalnimTr)
        {
            List<FitnesCentar> fc1 = new List<FitnesCentar>();
            Korisnik k = (Korisnik)Session["logedIn"];
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            FitnesCentar fc = new FitnesCentar();
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];


            int br;
            int postbr;
            int cenaJednog;
            int cenaMes;
            int god;
            int cenaGod;
            int cenaJednogGrupnog;
            int cenaJednPers;

            List<int> countId=new List<int>();
            foreach(var item in fitnesCentri)
            {
                countId.Add(item.Id);
            }
            int maxId = countId.Max();
            if (ime != "" && nazivUlice != "" && broj != "" && mesto != "" && postBroj != "" && godina != "" && cenaMesecneCl != "" && cenaGodisnjeCl != "" && cenaJednogGrupnogTr != "" && cenaJednogTr != "")
            {

                if (Int32.TryParse(broj, out br) && Int32.TryParse(cenaJednogTrsaPersonalnimTr, out cenaJednPers) && Int32.TryParse(godina, out god) && Int32.TryParse(postBroj, out postbr) && Int32.TryParse(cenaMesecneCl, out cenaMes) && Int32.TryParse(cenaGodisnjeCl, out cenaGod) && Int32.TryParse(cenaJednogTr, out cenaJednog) && Int32.TryParse(cenaJednogGrupnogTr, out cenaJednogGrupnog))
                {
                    fc.Ime = ime;
                    fc.Id = ++maxId;
                    fc.NazivUlice = nazivUlice;
                    fc.BrojAdr = br;
                    fc.Mesto = mesto;
                    fc.PostBr = postbr;
                    fc.GodinaOtvaranja = god;
                    fc.ImeVl = k.Ime;
                    fc.Prz = k.Prezime;
                    fc.KorisnickoImeVlasnika = k.KorisnickoIme;
                    fc.CenaMesecneClanarine = cenaMes;
                    fc.CenaGodisnjeClanarine = cenaGod;
                    fc.CenaJednogTreninga = cenaJednog;
                    fc.CenaJednogGrupnogTreninga = cenaJednogGrupnog;
                    fc.CenaJednogTrSaPersonalnimTr = cenaJednPers;
                    fitnesCentri.Add(fc);
                    // string text = null;
                    var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\FitnesCentri.txt";
                    string text = null;
                   

                    foreach (var kor in fitnesCentri)
                    {
                        if (kor.Ime.Equals("")){
                            fitnesCentri.Remove(kor);
                        }
                        else
                        {
                            text += kor.ToString();
                            if (kor.Ime.ToString() != "\r")
                            {
                                text += "\r";
                            }
                        }
                    }

                    System.IO.File.WriteAllText(path1, text);

                    HttpContext.Application["fitnesCentri"] = fitnesCentri;

                    //dodati i u korisnicima
                    k.FitnesCentriVlasnik.Add(ime);
                    string text1 = null;
                    var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

                    foreach (var ko in korisnici)
                    {
                        text1 += ko.ToString();
                        if (ko.Id.ToString() != "\r")
                        {
                            text1 += "\r";
                        }
                    }

                    System.IO.File.WriteAllText(path, text1);

                    ViewBag.Message = "Uspesno unet fitnes centar :)";

                    
                    //
                }
                else
                {
                    ViewBag.Greska = "Na polja: broj adrese, postanski broj, godina otvaranja i cene  mora biti broj";
                }
            }
            else
            {
                ViewBag.Greska = "Ne smeju ostati prazna polja :)";

            }

            foreach (var item in fitnesCentri)
            {
                for (int i = 0; i < k.FitnesCentriVlasnik.Count; i++)
                {
                    if (item.Ime == k.FitnesCentriVlasnik[i])
                    {
                        fc1.Add(item);
                    }
                }
            }

            return View("PrikaziFitnesCentre",fc1);

        }

        [HttpPost]
        public ActionResult BrisanjeFC(int id)
        {
            Korisnik k = (Korisnik)Session["logedIn"];
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            FitnesCentar fc1 = new FitnesCentar();
            List<FitnesCentar> fc = new List<FitnesCentar>();
            List<GrupniTrening> gt = new List<GrupniTrening>();
            List<string> centriVlasnik = new List<string>();
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            bool mozeLiSeBrisat = true;
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            foreach (var item in fitnesCentri)
            {
                for (int i = 0; i < k.FitnesCentriVlasnik.Count; i++)
                {
                    if (item.Ime == k.FitnesCentriVlasnik[i])
                    {
                        fc.Add(item);
                    }
                }
            }
            foreach (var it in fitnesCentri)
            {
                if (it.Id == id)
                {
                    fc1 = it;
                    break;
                }
            }
            
            
            foreach(var gtr in grupniTreninzi)
            {
                if(gtr.Obrisan!=true && gtr.FitnesCent == fc1.Ime )
                {
                   
                    gt.Add(gtr);
                
                }
            }

            if (gt.Exists(x => x.DatumIVremeTreninga > DateTime.Now))
            {
                mozeLiSeBrisat = false;
               
            }
            if (mozeLiSeBrisat)
            {
                

                foreach (var fCentar in fc)
                {
                    if (fCentar.Id == id)
                    {
                        fc.Remove(fCentar);

                        break;
                    }
                }

                foreach (var it in fitnesCentri)
                {
                    if (it.Id == id)
                    {
                        it.Obrisan = true;
                        break;
                    }
                }

                foreach (var fce in fc)
                {
                    centriVlasnik.Add(fce.Ime);

                }
                k.FitnesCentriVlasnik = centriVlasnik;


                var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\FitnesCentri.txt";
                string text = null;
                foreach (var kor in fitnesCentri)
                {
                    if (kor.Ime != "")
                    {
                        text += kor.ToString();
                        if (kor.Ime.ToString() != "\r")
                        {
                            text += "\r";
                        }
                    }

                }

                System.IO.File.WriteAllText(path1, text);

                foreach (var korisnik in korisnici)
                {
                    if (korisnik.Uloga == "TRENER" && korisnik.AngazovanTrenerFitnesCentra == fc1.Ime)
                    {
                        korisnik.AngazovanTrenerFitnesCentra = "";
                    }
                }

                string text1 = null;
                var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

                foreach (var ko in korisnici)
                {
                    text1 += ko.ToString();
                    if (ko.Id.ToString() != "\r")
                    {
                        text1 += "\r";
                    }
                }

                System.IO.File.WriteAllText(path, text1);

                
            }
            else
            {
                ViewBag.Greska = "NE moze se obrisati jer postoji trening u buducnosti u tom fitnes centru";
            }
            HttpContext.Application["korisnici"] = korisnici;
            HttpContext.Application["fitnesCentri"] = fitnesCentri;

            return View("PrikaziFitnesCentre", fc);
        }
    }
}