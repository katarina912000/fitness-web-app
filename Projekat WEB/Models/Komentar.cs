using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Komentar
    {
        public Komentar(Korisnik posetilacKojiKomentarise, FitnesCentar fitnesCentarKomentar, string tekstKomentara, int ocena)
        {
            PosetilacKojiKomentarise = posetilacKojiKomentarise;
            FitnesCentarKomentar = fitnesCentarKomentar;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
        }

        public Korisnik PosetilacKojiKomentarise { get; set; }
        public FitnesCentar FitnesCentarKomentar { get; set; }
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }
    }
}