using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_WEB.Models;


namespace Projekat_WEB.Controllers
{
    public class SortiranjaController : Controller
    {
        // GET: Sortiranja
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RastuceGodine()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];



            var sortedList = fitnesCentri2.OrderBy(x => x.GodinaOtvaranja).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }

        [HttpPost]
        public ActionResult RastuceNaziv()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            

            var sortedList = fitnesCentri2.OrderBy(x=>x.Ime).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult RastuceAdrese()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

            

            var sortedList = fitnesCentri2.OrderBy(x => x.NazivUlice).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceAdrese()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];

          

            var sortedList = fitnesCentri2.OrderByDescending(x => x.NazivUlice).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }
        [HttpPost]
        public ActionResult OpadajuceGodine()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];



            var sortedList = fitnesCentri2.OrderByDescending(x => x.GodinaOtvaranja).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml", sortedList);
        }

        [HttpPost]
        public ActionResult OpadajuceNaziv()
        {
            List<FitnesCentar> fitnesCentri2 = (List<FitnesCentar>)HttpContext.Application["fitnesCentri"];
            
            
            
            var sortedList=fitnesCentri2.OrderByDescending(x=>x.Ime).ToList();

            HttpContext.Application["fitnesCentri"] = sortedList;
            return View("~/Views/Pocetni/Index.cshtml",sortedList);
        }
    }
}