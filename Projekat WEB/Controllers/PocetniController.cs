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
            SortiranjeRastuce();

            grupniTreninzi = UpisIzBazeGrupniTreninzi();
            UpisIzBaze();
            korisnici = UpisIzBazeKorisnici();
            

            
            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            ViewBag.Line = lines;
            int numOfLines = lines.ToList().Count;//broj 3
            ViewBag.Lines = numOfLines;
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            return View(fitnesCentri);
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
                         }
                    
                        ViewBag.GrupniTr = gtFC;
                    }
                }




            ViewBag.Lista = korisnici;
            HttpContext.Application["fitnesCentri"] = fitnesCentri;
            HttpContext.Application["grupniTreninzi"] = gt;
           
            return View();

        }
        
        public List<GrupniTrening> UpisIzBazeGrupniTreninzi()
        {
            List<GrupniTrening> grupniTr = new List<GrupniTrening>();
            if (grupniTr.Count == 0)
            {
                string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/GrupniTreninzi.txt"));
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.ToList().Count; i++)
                {
                    string oneLine = lines[i];
                    string[] konacno = oneLine.Split(';');
                    GrupniTrening gp = new GrupniTrening();
                    
                    var idd = Int32.Parse(konacno[1]);
                    var trajanjeTr = Int32.Parse(konacno[4]);
                    var datum = konacno[5];
                    DateTime datetime = DateTime.ParseExact(datum, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    var maksBrPoset = Int32.Parse(konacno[6]);
                    
                    gp.Naziv = konacno[0];
                    gp.Id = idd;
                    gp.TipTreninga = konacno[2];
                    gp.FitnesCent = konacno[3];
                    gp.DatumIVremeTreninga = datetime;
                    gp.TrajanjeTreninga = trajanjeTr;
                    gp.MaxBrojPosetilaca = maksBrPoset;

                    grupniTr.Add(gp);
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
                string[] lines = text.Split('\n');
                for (int i = 0; i < lines.ToList().Count; i++)
                {
                    string oneLine = lines[i];
                    string[] konacno = oneLine.Split(';');
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
                            string[] idsKor = konacno[7].Split(',');//1,2 ->tu su sad 1 i 2

                            //idsgtt = konacno[9].Split(',');
                            int[] idsKoris = Array.ConvertAll(idsKor, s => int.Parse(s));
                            gp.Korisnici = idsKoris.ToList();
                            gp.Naziv = konacno[0];
                            gp.Id = idd;
                            gp.TipTreninga = konacno[2];
                            gp.FitnesCent = konacno[3];
                            gp.DatumIVremeTreninga = datetime;
                            gp.TrajanjeTreninga = trajanjeTr;
                            gp.MaxBrojPosetilaca = maksBrPoset;
                        }
                       
                    }
                    grupniTreninzi.Add(gp);
                }
            }

            
            return grupniTreninzi;
        }
        public List<Korisnik> UpisIzBazeKorisnici()
        {

            List<Korisnik> korisnici = new List<Korisnik>();
            List<GrupniTrening> grupniTreninzi = (List<GrupniTrening>)HttpContext.Application["grupniTreninzi"];

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
               
                k.Uloga = (UlogaEnum.Uloga)Enum.Parse(typeof(UlogaEnum.Uloga),konacno[8]);
                if (konacno[9] != "")
                {
                    string[] idsgtt = konacno[9].Split(',');//1,2 ->tu su sad 1 i 2

                    //idsgtt = konacno[9].Split(',');
                    int[] idsGt = Array.ConvertAll(idsgtt, s => int.Parse(s));

                    for (int m = 0; m < grupniTreninzi.Count; m++)
                    {
                        for (int j = 0; j < idsGt.Length; j++)
                        {
                            if (idsGt[j] == grupniTreninzi[m].Id)
                            {
                                ViewBag.GrupniTrening = grupniTreninzi[m].Naziv + " u " + grupniTreninzi[m].FitnesCent;
                            }
                        }

                    }
                    k.GrupniTreninziKorisnikPrijavljen = idsGt.ToList();
                }


                k.LogedIn = bool.Parse(konacno[13].ToLower());


                korisnici.Add(k);

            }
            HttpContext.Application["korisnici"] = korisnici;
            return korisnici;
        }
    

  


        
        ////citanje iz txt fajla
        //public void Read()
        //{
        //    var path = @"C:\Users\dabet\source\repos\Projekat WEB\Projekat WEB\App_Data\FitnesCentri.txt";
        //    if (System.IO.File.Exists(path))
        //    {
        //        using(TextReader tr=new StreamReader(path))
        //        {
        //            var text = tr.ReadLine();
        //        }
        //    }

        //}


    }
}