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
            //List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<FitnesCentar> fCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            List<Korisnik> baza = UpisIzBaze();
            
            //provera da li je kor.ime pronadjeno ako jeste,bool logedIn 
            foreach (Korisnik k in baza)
            {
                if (korisnickoIme.Equals(""))
                {
                    ViewBag.Greska = "Nije uspesno logovanje,nije popunjeno korisnicko ime";
                    return View("~/Views/Pocetni/Index.cshtml");
                }
                if (k.KorisnickoIme == korisnickoIme)
                {
                    Session["logedIn"] = k;
                    k.LogedIn = true;

                    //moram upisati u bazu da je true polje
                    ViewBag.Login = "Korisnik je ulogovan!";
                    ViewBag.Greska = "";
                    return View("~/Views/Pocetni/Index.cshtml",fCentri);
                }
                else
                {
                    ViewBag.Greska = "Nije uspesno logovanje,nije registrovan korisnik";

                }

                //provera za vlasnika,ne treba jos
                ////proci kroz sve fc 
                //foreach(FitnesCentar fc in fCentri)
                //{
                //    if (korisnickoIme == fc.KorisnickoImeVlasnika)
                //    {
                //        k.Uloga = UlogaEnum.Uloga.VLASNIK;
                //    }
                   
                //}
                
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(string korisnickoIme,string lozinka,string ime,string prezime,string pol,string email,string godinaRodjenja)
        {
            List<Korisnik> baza=UpisIzBaze();
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            Korisnik k = (Korisnik)Session["RegKor"];
            Korisnik koris = (Korisnik)Session["logedIn"];
            int countID = 0;
            countID = baza.Count;
            if (korisnickoIme!="" && lozinka!=""&& ime!="" && prezime != "" && pol != null && email != "" && godinaRodjenja!="" )
            {
                for(int i = 0; i < baza.Count; i++)
                {
                    countID = baza[i].Id;
                    if (baza[i].KorisnickoIme == korisnickoIme)
                    {
                        ViewBag.Greska = "Postoji vec user sa tim korisnickim imenom";
                        return RedirectToAction("Index");
                    }
                    
                }
                countID++;
                    
                        
                DateTime dateTime = DateTime.Parse(godinaRodjenja);
                
                Korisnik kor = new Korisnik(countID, korisnickoIme, lozinka, ime, prezime, pol, email, dateTime,"POSETILAC",null,null,null,null,true);


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

        public List<Korisnik> UpisIzBaze()
        {

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            
            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Korisnici.txt"));
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.ToList().Count; i++)
            {
                string oneLine = lines[i];
                string[] konacno = oneLine.Split(';');

                Korisnik k = new Korisnik();

                var id = Int32.Parse(konacno[0]);
                k.Id = id;
                k.KorisnickoIme = konacno[1];
                k.Lozinka = konacno[2];

                k.Ime = konacno[3];
                k.Prezime = konacno[4];
                k.Pol = konacno[5];
                k.Email = konacno[6];
                string date = konacno[7];
                DateTime dateTime = DateTime.Parse(date);
                k.GodinaRodjenja = dateTime;
                k.LogedIn = false;


                korisnici.Add(k);

            }
            HttpContext.Application["korisnici"] = korisnici;
            return korisnici;
        }
    }
}