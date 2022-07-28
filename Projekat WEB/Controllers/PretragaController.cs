using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekat_WEB.Models;
using System.Web.Mvc;

namespace Projekat_WEB.Controllers
{
    public class PretragaController : Controller
    {
        // GET: Pretraga
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PretragaNaziv(string ime)
        {
            List<FitnesCentar> fitnesCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            FitnesCentar nadjen = new FitnesCentar();

            string maloIme = ime.ToLower();
            foreach(FitnesCentar fCentar in fitnesCentri)
            {
                string maloNaziv = fCentar.Ime.ToLower();
                if (maloNaziv.Equals(maloIme))
                {
                    nadjen = fCentar;
                    ViewBag.Data = nadjen;
                    break;
                }else
                {
                   
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult PretragaAdresa(string ulica,string brojUlice,string mesto)
        {
            List<FitnesCentar> fCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            FitnesCentar nadjen = new FitnesCentar();
            string maloUlica = ulica.ToLower();
            string maloMesto = mesto.ToLower();
            int broj = Int32.Parse(brojUlice);
            if(ulica!="" && brojUlice!="" && mesto != "")
            {
                foreach(FitnesCentar fCentar in fCentri)
                {
                    string maloUlicaFC = fCentar.NazivUlice.ToLower();
                    string maloMestoFC = fCentar.Mesto.ToLower();
                    if(maloUlicaFC.Equals(maloUlica) && maloMestoFC.Equals(maloMesto) && fCentar.BrojAdr == broj)
                    {
                        nadjen = fCentar;
                        ViewBag.Data = nadjen;
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                ViewBag.Message = "Nisu dobro uneseni podaci";
            }
            return View("PretragaNaziv");
        }

        [HttpPost]
        public ActionResult PretragaGodine(string godMin,string godMaks)
        {
            List<FitnesCentar> fCentri = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            List<FitnesCentar> nadjeni = new List<FitnesCentar>();
            if(godMin!="" && godMaks != "")
            {
                int minGod, maksGod;
                bool min = Int32.TryParse(godMin, out minGod);
                bool maks = Int32.TryParse(godMaks, out maksGod);

                if (min && maks)
                {
                    foreach(FitnesCentar fc in fCentri)
                    {
                        if(fc.GodinaOtvaranja>minGod && fc.GodinaOtvaranja < maksGod)
                        {
                            nadjeni.Add(fc);
                            ViewBag.Nadjeni = nadjeni;
                            
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    ViewBag.Message = "Niste uneli broj";
                }
            }
           
            return View();
        }
    }
}