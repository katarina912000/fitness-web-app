using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class Komentar
    {
        public Komentar(int id,int posetilacKojiKomentarise, string fitnesCentarKomentar, string tekstKomentara, int ocena)
        {
            Id = id;

            Korisnik k = new Korisnik();
            k.Id = posetilacKojiKomentarise;
            PosetilacKojiKomentarise = posetilacKojiKomentarise;
            FitnesCentar fc = new FitnesCentar();
            fc.Ime = fitnesCentarKomentar;
            FitnesCentarKomentar = fitnesCentarKomentar;
            TekstKomentara = tekstKomentara;
            Ocena = ocena;
        }

        public Komentar() { }

        public int Id { get; set; }
        public int PosetilacKojiKomentarise { get; set; }
        public string FitnesCentarKomentar { get; set; }
        public string TekstKomentara { get; set; }
        public int Ocena { get; set; }

        public override string ToString()
        {
            return Id + ";" + PosetilacKojiKomentarise + ";" + FitnesCentarKomentar + ";" + TekstKomentara + ";" + Ocena;
        }
  }
}