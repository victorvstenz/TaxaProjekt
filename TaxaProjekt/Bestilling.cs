using System;
using System.Collections.Generic;
using System.Text;

namespace TaxaProjekt
{
    public class Bestilling
    {
        public string Adresse { get; set; }
        public string Destination { get; set; }
        public string Navn { get; set; }
        public string Tid { get; set; }
        public string TelefonNummer { get; set; }
        public int OrdreNummer { get; set; }
        public static int OrdreTæller = 0;

        public Bestilling(string adresse, string destination, string navn, string tid, string telefonnummer)
        {
            Adresse = adresse;
            Destination = destination;
            Navn = navn;
            Tid = tid;
            TelefonNummer = telefonnummer;
        }

        public override string ToString()
        {
            return $"{Navn} - {Adresse} -> {Destination} - {Tid} - {TelefonNummer}";
        }

    }
}
