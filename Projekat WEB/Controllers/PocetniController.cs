using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;
using System.Globalization;

namespace Projekat_WEB.Controllers
{
    public class PocetniController : Controller
    {
        // GET: Pocetni
        public ActionResult Index()
        {

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<Komentar> comments = (List<Komentar>)HttpContext.Application["komentari"];

            SortiranjeRastuce();

            grupniTreninzi = UpisIzBazeGrupniTreninzi();
            UpisIzBaze();
            korisnici = UpisIzBazeKorisnici();
            UpisIzBazeKomentari();

            
            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            ViewBag.Line = lines;
            int numOfLines = lines.ToList().Count;//broj 3
            ViewBag.Lines = numOfLines;
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            return View(fitnesCentri);
        }
       
        //tu smestiti za editovanje akciju
        [HttpPost] 
        public ActionResult EditConfirm(string ime, string prezime, string korIme, string lozinka, string pol, string email, string datumRodj)
        {
            
            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];


            Korisnik k = new Korisnik();
            k = (Korisnik)Session["logedIn"];
            
            if (k.Ime != ime)
            {
                k.Ime = ime;
            }
            if (k.Prezime !=prezime)
            {
                k.Prezime = prezime;
            }
            if (k.KorisnickoIme != korIme)
            {
                k.KorisnickoIme = korIme;
            }
            if (k.Lozinka != lozinka)
            {
                k.Lozinka = lozinka;
            }
            if (k.Pol != pol)
            {
                k.Pol = pol;
            }

            if (k.Email != email)
            {
                k.Email = email;
            }
            if (k.GodinaRodjenja.ToString() != datumRodj)
            {
                DateTime datetime = DateTime.ParseExact(datumRodj, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                // DateTime date=Convert.ToDateTime(datumRodj);
                //DateTime oDate = DateTime.ParseExact(datumRodj, "dd/MM/yyyy", null);
               // DateTime dat = DateTime.Parse(datumRodj);
                k.GodinaRodjenja = datetime;
            }


            string text = null;
            var path1 = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\Korisnici.txt";

            foreach (Korisnik kor in korisnici)
            {
                text+= kor.ToString();
                if (kor.Id.ToString() != "\r")
                {
                    text += "\r";
                }
            }
           
            System.IO.File.WriteAllText(path1, text);
          
            HttpContext.Application["korisnici"] = korisnici;

            return View("Index",fitnesCentri);
        }

        public void SortiranjeRastuce()
        {

            List<FitnesCentar> fitnesCentri = new List<FitnesCentar>();

            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            List<string> nazivi = new List<string>();
            //prvo sortiranje rastuce imena
            for(int i = 0; i < lines.ToList().Count; i++)
            {
                string oneLine = lines[i];
                string[] konacno = oneLine.Split(';');

                string ime = konacno[0];

                nazivi.Add(ime);
                nazivi.Sort();
            }
            //drugo za smestanje u users
            for (int i = 0; i < nazivi.Count; i++)
            {
                FitnesCentar fc = new FitnesCentar();
                
                fc.Ime = nazivi[i];
                for (int j = 0; j < lines.ToList().Count; j++)
                {
                    if (nazivi[i] == lines[j].Split(';')[0])
                    {
                        string oneLine = lines[j];
                        string[] konacno = oneLine.Split(';');
                        var id = Int32.Parse(konacno[1]);
                        var broj = Int32.Parse(konacno[3]);
                        var postBroj = Int32.Parse(konacno[5]);
                        var godOtvaranja = Int32.Parse(konacno[6]);
                        var cenaMesecneCl = Double.Parse(konacno[9]);
                        var cenaGodisnjeCl = Double.Parse(konacno[10]);
                        var cenaJednogTr = Double.Parse(konacno[11]);
                        var cenaJednogGrunogTr = Double.Parse(konacno[12]);
                        var cenaPersTr = Double.Parse(konacno[13]);

                        fc.Ime = konacno[0];
                        fc.Id = id;
                        fc.NazivUlice = konacno[2];
                        fc.BrojAdr = broj;
                        fc.Mesto = konacno[4];
                        fc.PostBr = postBroj;
                        fc.GodinaOtvaranja = godOtvaranja;
                        fc.ImeVl = konacno[7];
                        fc.Prz = konacno[8];
                        fc.KorisnickoImeVlasnika = konacno[7] + konacno[8];
                        fc.CenaMesecneClanarine = cenaMesecneCl;
                        fc.CenaGodisnjeClanarine = cenaGodisnjeCl;
                        fc.CenaJednogTreninga = cenaJednogTr;
                        fc.CenaJednogGrupnogTreninga = cenaJednogGrunogTr;
                        fc.CenaJednogTrSaPersonalnimTr = cenaPersTr;

                        break;
                    }
                }
                    

                fitnesCentri.Add(fc);

            }
            HttpContext.Application["fitnesCentri"] = fitnesCentri;
        }

        [HttpPost]
        public ActionResult Detalji(int id)
        {
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            

            List<Korisnik> korisnici = (List<Korisnik>)HttpContext.Application["korisnici"];
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            List<Komentar> comments = (List<Komentar>)HttpContext.Application["komentari"];
            List<Korisnik> korisnici2 = new List<Korisnik>();
            List<Komentar> kom = new List<Komentar>();
            Korisnik kor = (Korisnik)Session["logedIn"];
            List<GrupniTrening> gt=new List<GrupniTrening>();
            List<GrupniTrening> gtFC = new List<GrupniTrening>();
            gt = UpisIzBaze();
            
                foreach (FitnesCentar fc in fitnesCentri)
                {
                    if (fc.Id == id)
                    { 
                        ViewBag.Data = fc;

                        for (int i = 0; i < gt.Count; i++)
                        {
                            if (fc.Ime == gt[i].FitnesCent)
                            {
                                gtFC.Add(gt[i]);
                            
                            }
                        if (kor != null && kor.Uloga=="POSETILAC")
                        {
                            for (int q = 0; q < kor.GrupniTreninziKorisnikPrijavljen.Count; q++)
                            {
                                if (kor.GrupniTreninziKorisnikPrijavljen[q] == gt[i].Id)
                                {
                                    ViewBag.TreningKom = true;
                                    break;
                                }
                            }
                           
                        }
                    }
                    
                        ViewBag.GrupniTr = gtFC;

                        for (int j = 0; j < comments.Count; j++)
                        {

                            if (comments[j].FitnesCentarKomentar.ToLower() == fc.Ime.ToLower())
                            {
                                kom.Add(comments[j]);
                            }
                            
                        }
                    

                    }
               }

                foreach(Korisnik k in korisnici)
                {
                    for (int l = 0; l < kom.Count; l++)
                    {
                        if (k.Id == kom[l].PosetilacKojiKomentarise)
                        {
                            korisnici2.Add(k);
                        }
                    }
                }

            ViewBag.Lista = korisnici;
            ViewBag.Prijavljen = "prijavljen";
            ViewBag.Komentari = kom;
            ViewBag.KorisniciKom = korisnici2;
            ViewBag.IdFCa = id;
            HttpContext.Application["fitnesCentri"] = fitnesCentri;
            HttpContext.Application["grupniTreninzi"] = gt;
           
            return View(gtFC);

        }
        
        public List<Komentar> UpisIzBazeKomentari()
        {
            List<Komentar> komentari = new List<Komentar>();
            List<Komentar> comments = (List<Komentar>)HttpContext.Application["komentari"];
            if (komentari.Count == 0)
            {
                string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Komentari.txt"));
                string[] lines = text.Split('\r');
                for (int i = 0; i < lines.ToList().Count; i++)
                {
                    string oneLine = lines[i];
                    string[] konacno = oneLine.Split(';');
                    if (oneLine != "")
                    {
                        Komentar k = new Komentar();
                        var idd = Int32.Parse(konacno[0]);
                        var idPosetioca = Int32.Parse(konacno[1]);
                        var ocenaa = Int32.Parse(konacno[4]);

                        k.Id = idd;
                        k.PosetilacKojiKomentarise = idPosetioca;
                        k.FitnesCentarKomentar = konacno[2];
                        k.TekstKomentara = konacno[3];
                        k.Ocena = ocenaa;
                        
                        komentari.Add(k);
                    }

                }
            }
            comments = komentari;
            HttpContext.Application["komentari"] = comments;
            return komentari;
        }

        public List<GrupniTrening> UpisIzBazeGrupniTreninzi()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            List<GrupniTrening> grupniTr = new List<GrupniTrening>();
            if (grupniTr.Count == 0)
            {
                string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/GrupniTreninzi.txt"));
                string[] lines = text.Split('\r');
                for (int i = 0; i < lines.ToList().Count; i++)
                {
                    string oneLine = lines[i];
                    string[] konacno = oneLine.Split(';');
                    if (oneLine != "")
                    {
                        GrupniTrening gp = new GrupniTrening();

                        var idd = Int32.Parse(konacno[1]);
                        var trajanjeTr = Int32.Parse(konacno[4]);
                        var datum = konacno[5];
                        DateTime datetime = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                        var maksBrPoset = Int32.Parse(konacno[6]);
                        var obrisan = bool.Parse(konacno[7]);

                        gp.Naziv = konacno[0];
                            gp.Id = idd;
                            gp.TipTreninga = konacno[2];
                            gp.FitnesCent = konacno[3];
                            gp.DatumIVremeTreninga = datetime;
                            gp.TrajanjeTreninga = trajanjeTr;
                            gp.MaxBrojPosetilaca = maksBrPoset;
                        gp.Obrisan = obrisan;
                            grupniTr.Add(gp);
                        
                       
                    }
                   
                }
                
                    
             }


            HttpContext.Application["grupniTreninzi"] = grupniTr;
            return grupniTr;
        }

        //ovo je za detalji gt
        public List<GrupniTrening> UpisIzBaze()
        {
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            //smestanje  grupnih treninga
            List<GrupniTrening> grupniTreninzi = new List<GrupniTrening>();
            if (grupniTreninzi.Count == 0)
            {
                string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/GrupniTreninzi.txt"));
                string[] lines = text.Split('\r');
                for (int i = 0; i < lines.ToList().Count; i++)
                {
                    string oneLine = lines[i];
                    string[] konacno = oneLine.Split(';');
                    if (oneLine != "")
                    {
                        GrupniTrening gp = new GrupniTrening();
                        foreach (FitnesCentar fc in fitnesCentri)
                        {
                            if (fc.Ime == konacno[3])
                            {
                                
                                    var idd = Int32.Parse(konacno[1]);
                                    var trajanjeTr = Int32.Parse(konacno[4]);
                                    var datum = konacno[5];
                                    DateTime datetime = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                    var maksBrPoset = Int32.Parse(konacno[6]);
                                //string[] idsKor = konacno[7].Split(',');//1,2 ->tu su sad 1 i 2
                                //if (idsKor[0] != "")
                                //{
                                //    int[] idsKoris = Array.ConvertAll(idsKor, s => int.Parse(s));
                                //    gp.Korisnici = idsKoris.ToList();
                                //}
                                var obrisan = bool.Parse(konacno[7]);

                                gp.Naziv = konacno[0];
                                    gp.Id = idd;
                                    gp.TipTreninga = konacno[2];
                                    gp.FitnesCent = konacno[3];
                                    gp.DatumIVremeTreninga = datetime;
                                    gp.TrajanjeTreninga = trajanjeTr;
                                    gp.MaxBrojPosetilaca = maksBrPoset;
                                    gp.Obrisan = obrisan;
                                
                            }

                        }

                        grupniTreninzi.Add(gp);
                    }
                }
            }
            return grupniTreninzi;
        }

        [HttpPost]
        public ActionResult Edit()
        {
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];
            ViewBag.GrupniTr = grupniTreninzi;
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            List<GrupniTrening> gtrs = UpisIzBaze();
            ViewBag.GrupniTrFC = gtrs;
            ViewBag.Sesija = Session["logedIn"];
            return View();
        }

        //upis korisnika
        //popraviti upis da bude iz korisnici new
        public List<Korisnik> UpisIzBazeKorisnici()
        {

            List<Korisnik> korisnici = new List<Korisnik>();
            List<Korisnik> korisnici2 = (List<Korisnik>)HttpContext.Application["korisnici"];

            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/Korisnici.txt"));
            string[] lines = text.Split('\r');

            for (int i = 0; i < lines.ToList().Count; i++)
            {
                string oneLine = lines[i];
                string[] konacno = oneLine.Split(';');
                if (oneLine != "")
                {
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
                    DateTime datetime = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);


                    k.GodinaRodjenja = datetime;

                    k.Uloga = konacno[8];
                    if (konacno[9] != "")
                    {
                        string[] idsgtt = konacno[9].Split(',');//1,2 ->tu su sad 1 i 2                  
                        int[] idsGt = Array.ConvertAll(idsgtt, s => int.Parse(s));
                        k.GrupniTreninziKorisnikPrijavljen = idsGt.ToList();
                    }
                    if (konacno[10] != "")
                    {
                        string[] idsgtt = konacno[10].Split(',');
                        int[] idsGt = Array.ConvertAll(idsgtt, s => int.Parse(s));
                        k.GrupniTreninziKorisnikTrener = idsGt.ToList();
                    }
                    if (konacno[11] != "")
                    {
                        k.AngazovanTrenerFitnesCentra = konacno[11];
                    }
                    if (konacno[12] != "")
                    {
                        string[] fcs = konacno[12].Split(',');
                        k.FitnesCentriVlasnik = fcs.ToList();

                    }
                    korisnici.Add(k);
                }
            }
               
            HttpContext.Application["korisnici"] = korisnici;
            return korisnici;
        }
    
    }
}