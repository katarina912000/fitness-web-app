using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class GrupniTrening
    {
        public GrupniTrening(string naziv, string tipTreninga, FitnesCentar fitnesCentar, int trajanjeTreninga, DateTime datumIVremeTreninga, int maxBrojPosetilaca, List<Korisnik> korisnici)
        {
            Naziv = naziv;
            TipTreningaEnum tip = new TipTreningaEnum();
            tipTreninga = ;

            FitnesCentar = fitnesCentar;
            TrajanjeTreninga = trajanjeTreninga;
            DatumIVremeTreninga = datumIVremeTreninga;
            MaxBrojPosetilaca = maxBrojPosetilaca;
            Korisnici = korisnici;
        }

        public string Naziv { get; set; }
        //public TipTreningaEnum.TipTreninga TipTreninga { get; set; }
        public FitnesCentar FitnesCentar { get; set; }
        public int TrajanjeTreninga { get; set; }
        public DateTime DatumIVremeTreninga { get; set; }
        public int MaxBrojPosetilaca { get; set; }
        public List<Korisnik> Korisnici { get; set; }




        
    }
}