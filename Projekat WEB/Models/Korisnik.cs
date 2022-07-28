using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Korisnik
    {
        public Korisnik(int id,string korisnickoIme, string lozinka, string ime, string prezime, string pol, string email, DateTime godinaRodjenja, string uloga, List<string> grupniTreninziKorisnikPrijavljen, List<string> grupniTreninziKorisnikTrener, string angazovanTrenerFitnesCentra, List<string> fitnesCentriVlasnik)
        {
            Id = id;

            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            string po = Pol.ToString();
            po = pol.ToUpper();
            Email = email;
            GodinaRodjenja = godinaRodjenja;
            string role = Uloga.ToString();
            role = uloga.ToUpper();

            List<GrupniTrening> gt1 = new List<GrupniTrening>();
            for (int i = 0; i < grupniTreninziKorisnikPrijavljen.Count; i++)
            {
                gt1[i].Naziv = grupniTreninziKorisnikPrijavljen[i];
            }

            List<GrupniTrening> gt2 = new List<GrupniTrening>();
            for (int i = 0; i < grupniTreninziKorisnikTrener.Count; i++)
            {
                gt2[i].Naziv = grupniTreninziKorisnikTrener[i];
            }

            FitnesCentar fc = new FitnesCentar();
            fc.Ime = angazovanTrenerFitnesCentra;

            List<FitnesCentar> centri = new List<FitnesCentar>();
            for(int i = 0; i < fitnesCentriVlasnik.Count; i++)
            {
                centri[i].Ime = fitnesCentriVlasnik[i];
            }

        }

            
        public Korisnik() { }

        public int Id { get; set; }
        public  string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public PolEnum.Pol Pol { get; set; }
        public string Email { get; set; }
        public DateTime GodinaRodjenja { get; set; }
        public UlogaEnum.Uloga Uloga { get; set; }
        
       
        
    }
}