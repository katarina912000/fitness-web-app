using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class FitnesCentar
    {
        public FitnesCentar(string ime, string nazivUlice,int broj,string mesto,int postBroj, int godinaOtvaranja, string imeVlasnika,string prz, double cenaMesecneClanarine, double cenaGodisnjeClanarine, double cenaJednogTreninga, double cenaJednogGrupnogTreninga, double cenaJednogTrSaPersonalnimTr)
        {
            Ime = ime;
            Adresa adr = new Adresa();
            adr.Ulica = nazivUlice;
            adr.Broj = broj;
            adr.Grad = mesto;
            adr.PostanskiBroj = postBroj;
            GodinaOtvaranja = godinaOtvaranja;
            Korisnik k  = new Korisnik();
            k.Ime = imeVlasnika;
            k.Prezime = prz;
            CenaMesecneClanarine = cenaMesecneClanarine;
            CenaGodisnjeClanarine = cenaGodisnjeClanarine;
            CenaJednogTreninga = cenaJednogTreninga;
            CenaJednogGrupnogTreninga = cenaJednogGrupnogTreninga;
            CenaJednogTrSaPersonalnimTr = cenaJednogTrSaPersonalnimTr;
        }

        public string Ime { get; set; }
        //public Adresa Adresa { get; set; }
        public int GodinaOtvaranja { get; set; }
        //public Korisnik Vlasnik { get; set; }
        public double CenaMesecneClanarine { get; set; }
        public double CenaGodisnjeClanarine { get; set; }
        public double CenaJednogTreninga { get; set; }
        public double CenaJednogGrupnogTreninga { get; set; }
        public double CenaJednogTrSaPersonalnimTr { get; set; }


        //Korisnik kor = new Korisnik();
        


    }
}