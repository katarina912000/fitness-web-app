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
            Korisnik kor = new Korisnik();
            if (korisnickoIme.Equals("") || lozinka.Equals(""))
            {
                ViewBag.Greska = "Nije uspesno logovanje,nije  popunjeno korisnicko ime ili lozinka";
                return View("~/Views/Pocetni/Index.cshtml", fCentri);
            }
            else
            {
                foreach (Korisnik k in korisnici)
                {
                    if (k.KorisnickoIme == korisnickoIme )
                    {
                        if (k.Lozinka == lozinka)
                        {
                            kor = k;
                            break;
                        }
                        else
                        {
                            ViewBag.Greska = "Neispravna lozinka.";
                            break;
                        }
                       
                    }
 
                }
                if (!korisnici.Exists(x => x.KorisnickoIme.Equals(korisnickoIme)))
                {
                    ViewBag.Greska = "Nije uspesno logovanje,nije registrovan korisnik";


                }else
                {
                    if (kor.Uloga == "TRENER" && kor.AngazovanTrenerFitnesCentra == null)
                    {
                        ViewBag.Greska = "Treneru,ne mozete se prijaviti u aplikaciju,vlasnik je obrisao fitnes centar";
                        
                    }else if(kor.Uloga=="TRENER" && kor.Id == 0)
                    {
                        ViewBag.Greska = "Treneru,blokirani ste od strane vlasnika,ne mozete se prijaviti";
                    }
                    else
                    {
                        Session["logedIn"] = kor;
                        ViewBag.Login = "Korisnik je ulogovan!";
                        ViewBag.Greska = "";
                        return View("~/Views/Pocetni/Index.cshtml", fCentri);
                    }
                }
               

            }

            return View("~/Views/Pocetni/Index.cshtml", fCentri);

        }

        [HttpPost]
        public ActionResult Add(string korisnickoIme,string lozinka,string ime,string prezime,string pol,string email,string godinaRodjenja)
        {
           
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<FitnesCentar> fCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            int countID = 0;
            countID = korisnici.Count;
            List<int> ids = new List<int>();
            foreach(var it in korisnici)
            {
                ids.Add(it.Id);
            }
            countID = ids.Count+1;
            if (korisnickoIme!="" && lozinka!=""&& ime!="" && prezime != "" && pol != null && email != "" && godinaRodjenja!="" )
            {
                for(int i = 0; i < korisnici.Count; i++)
                {
                    
                    
                    if (korisnici[i].KorisnickoIme == korisnickoIme)
                    {
                        ViewBag.Greska = "Postoji vec user sa tim korisnickim imenom";
                        return RedirectToAction("Index");
                    }
                    
                }
               
                        
                DateTime dateTime = DateTime.Parse(godinaRodjenja);
                
                Korisnik kor = new Korisnik(countID, korisnickoIme, lozinka, ime, prezime, pol, email, dateTime,"POSETILAC",new List<int>(),new List<int>(),"" ,new List<string>() );

                korisnici.Add(kor);
                
                Session["logedIn"] = kor;
                ViewBag.Ulogovan = "Korisnik je registrovan i ulogovan!";
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

            
            return View("~/Views/Pocetni/Index.cshtml", fCentri);
        }

    
    }
}