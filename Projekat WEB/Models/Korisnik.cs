using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Korisnik
    {
        public Korisnik(string korisnickoIme, string lozinka, string ime, string prezime, PolEnum.Pol pol, string email, DateTime godinaRodjenja, UlogaEnum.Uloga uloga, List<GrupniTrening> grupniTreninziKorisnikPrijavljen, List<GrupniTrening> grupniTreninziKorisnikTrener, FitnesCentar angazovanTrenerFitnesCentra, FitnesCentar vlasnikFitnesCentra)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            GodinaRodjenja = godinaRodjenja;
            Uloga = uloga;
            GrupniTreninziKorisnikPrijavljen = grupniTreninziKorisnikPrijavljen;
            GrupniTreninziKorisnikTrener = grupniTreninziKorisnikTrener;
            AngazovanTrenerFitnesCentra = angazovanTrenerFitnesCentra;
            VlasnikFitnesCentra = vlasnikFitnesCentra;
        }
        public Korisnik() { }
        public  string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public PolEnum.Pol Pol { get; set; }
        public string Email { get; set; }
        public DateTime GodinaRodjenja { get; set; }
        public UlogaEnum.Uloga Uloga { get; set; }
        public List<GrupniTrening> GrupniTreninziKorisnikPrijavljen { get; set; }
        public List<GrupniTrening> GrupniTreninziKorisnikTrener { get; set; }
        public FitnesCentar AngazovanTrenerFitnesCentra { get; set; }
        public FitnesCentar VlasnikFitnesCentra { get; set; }
        
    }
}