using System;
using System.Collections.Generic;
using System.Text;

namespace TaxaProjekt
{
    public class Chauffør
    {
        public string Navn { get; set; }
        public string Kode { get; set; }
        public string Status { get; set; } = "Fri";
        public int ID;
        public string ArbejdsTid { get; set; }

        public double Tid { get; set; }

        public bool PåArbejde { get; set; } = false;

        public DateTime? CheckIndTid { get; set; }
        public DateTime? CheckUdTid { get; set; }
        public static int IDCounter = 0;

        public Chauffør(string navn, string kode, string arbejdstid)
        {
            Navn = navn;
            Kode = kode;
            ArbejdsTid = arbejdstid;
        }
        public override string ToString()
        {
            return $"{Navn} - {Status} - {ArbejdsTid}";
        }
        public Biler biler { get; set; } // Nu har chaufførerne adgang til at få en bil.

        public Bestilling bestilling { get; set; } // KOM NU
    }


}
