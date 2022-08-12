using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class FitnesCentar
    {
        public FitnesCentar(string ime, int id, string nazivUlice,int broj,string mesto,int postBroj, int godinaOtvaranja, string imeVlasnika,string prz, double cenaMesecneClanarine, double cenaGodisnjeClanarine, double cenaJednogTreninga, double cenaJednogGrupnogTreninga, double cenaJednogTrSaPersonalnimTr)
        {
            Id = id;
            Ime = ime;

            Adresa adr = new Adresa();

            adr.Ulica = nazivUlice;
            NazivUlice = nazivUlice;

            adr.Broj = broj;
            BrojAdr = broj;

            adr.Grad = mesto;
            Mesto = mesto;

            adr.PostanskiBroj = postBroj;
            PostBr = postBroj;

            GodinaOtvaranja = godinaOtvaranja;
            
            Korisnik k  = new Korisnik();

            k.Ime = imeVlasnika;
            ImeVl = imeVlasnika;

            k.Prezime = prz;
            Prz = prz;

            k.KorisnickoIme = ImeVl + prz;
            KorisnickoImeVlasnika = k.KorisnickoIme;
            CenaMesecneClanarine = cenaMesecneClanarine;
            CenaGodisnjeClanarine = cenaGodisnjeClanarine;
            CenaJednogTreninga = cenaJednogTreninga;
            CenaJednogGrupnogTreninga = cenaJednogGrupnogTreninga;
            CenaJednogTrSaPersonalnimTr = cenaJednogTrSaPersonalnimTr;
        }

        public FitnesCentar(){}

        public string KorisnickoImeVlasnika { get; set; }
        public int Id { get; set; }
        public string Ime { get; set; }
        public string NazivUlice { get; set; } 
        public int BrojAdr { get; set; }
        public string Mesto { get; set; }
        public int PostBr { get; set; }
        public string ImeVl { get; set; }
        public string Prz { get; set; }

        public int GodinaOtvaranja { get; set; }
        public double CenaMesecneClanarine { get; set; }
        public double CenaGodisnjeClanarine { get; set; }
        public double CenaJednogTreninga { get; set; }
        public double CenaJednogGrupnogTreninga { get; set; }
        public double CenaJednogTrSaPersonalnimTr { get; set; }
        

    }
}