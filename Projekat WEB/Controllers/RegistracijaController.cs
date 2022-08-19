using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;
using System.IO;

namespace Projekat_WEB.Controllers
{
    public class RegistracijaController : Controller
    {
        // GET: Registracija
        public ActionResult Index()
        {
            //iscitavanje iz baze

            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            List<FitnesCentar> fCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            Session["logedIn"] = null;
            return View("~/Views/Pocetni/Index.cshtml",fCentri);
        }

        [HttpPost]
        public ActionResult Login(string korisnickoIme,string lozinka)
        {
            List<FitnesCentar> fCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];

            foreach (Korisnik k in korisnici)
            {
                
                if (korisnickoIme.Equals(""))
                {
                    ViewBag.Greska = "Nije uspesno logovanje,nije popunjeno korisnicko ime";
                    return View("~/Views/Pocetni/Index.cshtml");
                }
                if (k.KorisnickoIme == korisnickoIme)
                {
                    Session["logedIn"] = k;                  
                    ViewBag.Login = "Korisnik je ulogovan!";
                    ViewBag.Greska = "";
                    return View("~/Views/Pocetni/Index.cshtml",fCentri);
                }
                else
                {
                    ViewBag.Greska = "Nije uspesno logovanje,nije registrovan korisnik";

                }

            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(string korisnickoIme,string lozinka,string ime,string prezime,string pol,string email,string godinaRodjenja)
        {
            //List<Korisnik> baza=UpisIzBaze();
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik k = (Korisnik)Session["RegKor"];
            Korisnik koris = (Korisnik)Session["logedIn"];
            int countID = 0;
            countID = korisnici.Count;
            if (korisnickoIme!="" && lozinka!=""&& ime!="" && prezime != "" && pol != null && email != "" && godinaRodjenja!="" )
            {
                for(int i = 0; i < korisnici.Count; i++)
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
                
                Korisnik kor = new Korisnik(countID, korisnickoIme, lozinka, ime, prezime, pol, email, dateTime,"POSETILAC",new List<int>(),new List<int>(),"" ,new List<string>() );


                korisnici.Add(kor);
                Session["RegKor"] = kor;
                Session["logedIn"] = kor;

                var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";
                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    
                    sw.Write("\n"+kor.ToString());

                }
            }else
            {
                ViewBag.Greska = "Nisu popunjena sva polja kako treba";
            }
            
            
           HttpContext.Application["korisnici"] = korisnici;

            
            return View();
        }

        //public List<Korisnik> UpisIzBaze()
        //{

        //    List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            
        //    string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Korisnici.txt"));
        //    string[] lines = text.Split('\n');

        //    for (int i = 0; i < lines.ToList().Count; i++)
        //    {
        //        string oneLine = lines[i];
        //        string[] konacno = oneLine.Split(';');

        //        Korisnik k = new Korisnik();

        //        var id = Int32.Parse(konacno[0]);
        //        k.Id = id;
        //        k.KorisnickoIme = konacno[1];
        //        k.Lozinka = konacno[2];

        //        k.Ime = konacno[3];
        //        k.Prezime = konacno[4];
        //        k.Pol = konacno[5];
        //        k.Email = konacno[6];
        //        string date = konacno[7];
        //        DateTime dateTime = DateTime.Parse(date);
        //        k.GodinaRodjenja = dateTime;
        //        k.Uloga = (UlogaEnum.Uloga)Enum.Parse(typeof(UlogaEnum.Uloga), konacno[8]);
        //        if (konacno[9] != "")
        //        {
        //            string[] idsgtt = konacno[9].Split(',');//1,2 ->tu su sad 1 i 2                  
        //            int[] idsGt = Array.ConvertAll(idsgtt, s => int.Parse(s));
        //            k.GrupniTreninziKorisnikPrijavljen = idsGt.ToList();
        //        }
        //        if (konacno[10] != "")
        //        {
        //            string[] idsgtt = konacno[10].Split(',');
        //            int[] idsGt = Array.ConvertAll(idsgtt, s => int.Parse(s));
        //            k.GrupniTreninziKorisnikTrener = idsGt.ToList();
        //        }
        //        if (konacno[11] != "")
        //        {
        //            k.AngazovanTrenerFitnesCentra = konacno[11];
        //        }
        //        if (konacno[12] != "")
        //        {
        //            string[] fcs = konacno[12].Split(',');
        //            k.FitnesCentriVlasnik = fcs.ToList();

        //        }
        //        korisnici.Add(k);
        //    }
        //    HttpContext.Application["korisnici"] = korisnici;
        //    return korisnici;
        //}
    }
}