using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Korisnik
    {
        public Korisnik(int id,string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, DateTime godinaRodjenja, string uloga, List<int> grupniTreninziKorisnikPrijavljen, List<string> grupniTreninziKorisnikTrener, string angazovanTrenerFitnesCentra, List<string> fitnesCentriVlasnik,bool logedIn)
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
            string role = Uloga.ToString();
            role = uloga.ToUpper();

            //List<GrupniTrening> gt1 = new List<GrupniTrening>();
            //for (int i = 0; i < grupniTreninziKorisnikPrijavljen.Count; i++)
            //{
            //    gt1[i].Naziv = grupniTreninziKorisnikPrijavljen[i];
            //}
            GrupniTreninziKorisnikPrijavljen = grupniTreninziKorisnikPrijavljen;
           
            //to su ids od gt
            GrupniTreninziKorisnikTrener = grupniTreninziKorisnikTrener;

            FitnesCentar fc = new FitnesCentar();
            fc.Ime = angazovanTrenerFitnesCentra;
            AngazovanTrenerFitnesCentra = angazovanTrenerFitnesCentra;

            //List<FitnesCentar> centri = new List<FitnesCentar>();
            //for(int i = 0; i < fitnesCentriVlasnik.Count; i++)
            //{
            //    centri[i].Ime = fitnesCentriVlasnik[i];
            //}
            FitnesCentriVlasnik = fitnesCentriVlasnik;
            LogedIn = logedIn;
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
        public UlogaEnum.Uloga Uloga { get; set; }
        public List<int> GrupniTreninziKorisnikPrijavljen { get; set; }
        public List<string> GrupniTreninziKorisnikTrener { get; set; }
        public string AngazovanTrenerFitnesCentra { get; set; }

        public List<string> FitnesCentriVlasnik { get; set; }
        public bool LogedIn { get; set; }

        public override string ToString()
        {
            return Id + ";" + KorisnickoIme + ";" + Lozinka + ";" + Ime + ";" + Prezime + ";" + Pol + ";" + Email + ";" + GodinaRodjenja + ";" + Uloga + ";" + GrupniTreninziKorisnikPrijavljen + ";" + GrupniTreninziKorisnikTrener + ";" + AngazovanTrenerFitnesCentra + ";" + FitnesCentriVlasnik + ";" + LogedIn;
        }


    }
}