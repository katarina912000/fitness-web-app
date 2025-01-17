﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Korisnik
    {
        public Korisnik(int id,string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, DateTime godinaRodjenja, string uloga, List<int> grupniTreninziKorisnikPrijavljen, List<int> grupniTreninziKorisnikTrener, string angazovanTrenerFitnesCentra, List<string> fitnesCentriVlasnik)
        {
            Id = id;

            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            
            Pol = pol.ToUpper();
            
            if (Pol == "MUSKI")
            {
                Pol = PolEnum.Pol.MUSKI.ToString();
            }
            else
            {
                Pol = PolEnum.Pol.ZENSKI.ToString();
            }

            Email = email;
            GodinaRodjenja = godinaRodjenja;
            Uloga = uloga.ToUpper();
            if (Uloga == "POSETILAC")
            {
                Uloga = UlogaEnum.Uloga.POSETILAC.ToString();
            }
            else if(Uloga == "TRENER")
            {
                Uloga = UlogaEnum.Uloga.TRENER.ToString();
            }else if(Uloga == "VLASNIK")
            {
                Uloga = UlogaEnum.Uloga.TRENER.ToString();

            }
            GrupniTreninziKorisnikPrijavljen = grupniTreninziKorisnikPrijavljen;
           
            //to su ids od gt
            GrupniTreninziKorisnikTrener = grupniTreninziKorisnikTrener;

            FitnesCentar fc = new FitnesCentar();
            fc.Ime = angazovanTrenerFitnesCentra;
            AngazovanTrenerFitnesCentra = angazovanTrenerFitnesCentra;

            FitnesCentriVlasnik = fitnesCentriVlasnik;
        }

            
        public Korisnik() { }

        public int Id { get; set; }
        public  string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime GodinaRodjenja { get; set; }
        public string Uloga { get; set; }
        public List<int> GrupniTreninziKorisnikPrijavljen { get; set; }
        public List<int> GrupniTreninziKorisnikTrener { get; set; }
        public string AngazovanTrenerFitnesCentra { get; set; }

        public List<string> FitnesCentriVlasnik { get; set; }

        private string UpisListi(List<int> objects)
        {
            string text = null;
            if (objects != null)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    text += objects[i];
                    if (i != objects.Count - 1)
                    {
                        text += ",";
                    }
                }
            }
           
            return text;
        }
        private string UpisListiString(List<string> objects)
        {
            string text = null;
            if (objects != null)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    text += objects[i];
                    if (i != objects.Count-1)
                    {
                        text += ",";
                    }
                }
            }
          
            return text;
        }



        public override string ToString()
        {

            return Id + ";" + KorisnickoIme + ";" + Lozinka + ";" + Ime + ";" + Prezime + ";" + Pol + ";" + Email + ";" + GodinaRodjenja.ToString("dd/MM/yyyy HH:mm") + ";" + Uloga.ToString() + ";" + UpisListi(GrupniTreninziKorisnikPrijavljen) + ";" + UpisListi(GrupniTreninziKorisnikTrener) + ";" + AngazovanTrenerFitnesCentra + ";" + UpisListiString(FitnesCentriVlasnik);
        }


    }
}