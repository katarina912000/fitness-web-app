using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Komentar
    {
        public Komentar(string posetilacKojiKomentarise, string fitnesCentarKomentar, string tekstKomentara, int ocena)
        {
            Korisnik k = new Korisnik();
            k.KorisnickoIme = posetilacKojiKomentarise;
            FitnesCentar fc = new FitnesCentar();
            fc.Ime = fitnesCentarKomentar;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
        }

       
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }
    }
}