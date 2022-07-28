using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;

namespace Projekat_WEB.Controllers
{
    public class PocetniController : Controller
    {
        // GET: Pocetni
        public ActionResult Index()
        {
            Sortiranje();
            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            ViewBag.Line = lines;
            int numOfLines = lines.ToList().Count;//broj 3
            ViewBag.Lines = numOfLines;
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            return View(fitnesCentri);
        }


        public void Sortiranje()
        {

            List<FitnesCentar> fitnesCentri = new List<FitnesCentar>();

            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            List<string> nazivi = new List<string>();
            //prvo sortiranje imena
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
            foreach (FitnesCentar fc in fitnesCentri)
            {
                if (fc.Id == id)
                {
                    ViewBag.Data = fc;
                }
            }
            return View();
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