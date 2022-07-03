using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class GrupniTrening
    {
        public GrupniTrening(string naziv, string tipTreninga, string fitnesCentar, int trajanjeTreninga, DateTime datumIVremeTreninga, int maxBrojPosetilaca, List<string> korisnici)
        {
            Naziv = naziv;
            string tipTr = TipTreninga.ToString();
            tipTr = tipTreninga.ToUpper();
            FitnesCentar fc = new FitnesCentar();
            fc.Ime = fitnesCentar;
            TrajanjeTreninga = trajanjeTreninga;
            DatumIVremeTreninga = datumIVremeTreninga;
            MaxBrojPosetilaca = maxBrojPosetilaca;
            List<Korisnik> users = new List<Korisnik>();
            for(int i=0;i<korisnici.Count;i++)
            {
                users[i].KorisnickoIme = korisnici[i];
                
            }            
        }

        public GrupniTrening() { }

        public string Naziv { get; set; }
        public TipTreningaEnum.TipTreninga TipTreninga { get; set; }        
        public int TrajanjeTreninga { get; set; }
        public DateTime DatumIVremeTreninga { get; set; }
        public int MaxBrojPosetilaca { get; set; }
       




        
    }
}