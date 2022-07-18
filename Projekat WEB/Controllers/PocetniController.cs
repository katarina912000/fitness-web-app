using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat_WEB.Controllers
{
    public class PocetniController : Controller
    {
        // GET: Pocetni
        public ActionResult Index()
        {

            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            ViewBag.Line = lines;
            int numOfLines = lines.ToList().Count;//broj 3
            ViewBag.Lines = numOfLines;
         
            return View();
        }

        

        
        [HttpPost]
        public ActionResult Detalji()
        {
            //Write();
            string text = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            string[] lines = text.Split('\n');//tu su sad 3 stringa 3 linije

            ViewBag.Data = lines;

            //string[] text = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/FitnesCentri.txt"));
            //string[] realText = null;
            //for(int i = 0; i < text.ToList().Count; i++)
            //{
            //    realText = text[i].Split(';');
            //    ViewBag.Data = realText;
            //}

            
            return View("Detalji");
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