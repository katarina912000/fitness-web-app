using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class GrupniTrening
    {
        public GrupniTrening(string naziv, int id, string tipTreninga, string fitnesCentar, int trajanjeTreninga, DateTime datumIVremeTreninga, int maxBrojPosetilaca, List<int> korisnici)
        {
            Id = id;

            Naziv = naziv;
            string tipTr = TipTreninga.ToString();
            tipTr = tipTreninga.ToUpper();
            TipTreninga = tipTr;
            FitnesCentar fc = new FitnesCentar();
            fc.Ime = fitnesCentar;
            FitnesCent = fitnesCentar;
            TrajanjeTreninga = trajanjeTreninga;
            DatumIVremeTreninga = datumIVremeTreninga;
            MaxBrojPosetilaca = maxBrojPosetilaca;
            List<Korisnik> users = new List<Korisnik>();
            for(int i=0;i<korisnici.Count;i++)
            {
                users[i].Id = korisnici[i];
                
            }
            Korisnici = korisnici;          
        }

        public GrupniTrening() { }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string TipTreninga { get; set; }        
        public int TrajanjeTreninga { get; set; }
        public string FitnesCent { get; set; }
        public DateTime DatumIVremeTreninga { get; set; }
        public int MaxBrojPosetilaca { get; set; }
        public List<int> Korisnici { get; set; } 




        
    }
}