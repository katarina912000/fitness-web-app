using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_WEB.Models
{
    public class GrupniTrening
    {
        public GrupniTrening(string naziv, int id, string tipTreninga, string fitnesCentar, int trajanjeTreninga, DateTime datumIVremeTreninga, int maxBrojPosetilaca, List<int> korisnici,bool obrisan)
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
        public bool Obrisan { get; set; }

        private string UpisListi(List<int> objects)
        {
            string text = null;
            if (objects != null)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    text += objects[i];
                    if (i != objects.Count - 1)
                    {
                        text += ",";
                    }
                }
            }

            return text;
        }

        public override string ToString()
        {
            return "Grupni trening"+";"+Id + ";" +TipTreninga+";"+FitnesCent+";"+TrajanjeTreninga+";"+DatumIVremeTreninga.ToString("dd/MM/yyyy HH:mm") +";"+MaxBrojPosetilaca+";"+UpisListi(Korisnici)+Obrisan;
        }



    }
}