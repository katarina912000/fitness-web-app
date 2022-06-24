using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class FitnesCentar
    {
        public FitnesCentar(string ime, Adresa adresa, int godinaOtvaranja, Korisnik vlasnik, double cenaMesecneClanarine, double cenaGodisnjeClanarine, double cenaJednogTreninga, double cenaJednogGrupnogTreninga, double cenaJednogTrSaPersonalnimTr)
        {
            Ime = ime;
            Adresa = adresa;
            GodinaOtvaranja = godinaOtvaranja;
            Vlasnik = vlasnik;
            CenaMesecneClanarine = cenaMesecneClanarine;
            CenaGodisnjeClanarine = cenaGodisnjeClanarine;
            CenaJednogTreninga = cenaJednogTreninga;
            CenaJednogGrupnogTreninga = cenaJednogGrupnogTreninga;
            CenaJednogTrSaPersonalnimTr = cenaJednogTrSaPersonalnimTr;
        }

        public string Ime { get; set; }
        public Adresa Adresa { get; set; }
        public int GodinaOtvaranja { get; set; }
        public Korisnik Vlasnik { get; set; }
        public double CenaMesecneClanarine { get; set; }
        public double CenaGodisnjeClanarine { get; set; }
        public double CenaJednogTreninga { get; set; }
        public double CenaJednogGrupnogTreninga { get; set; }
        public double CenaJednogTrSaPersonalnimTr { get; set; }




    }
}