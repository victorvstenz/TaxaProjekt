using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace TaxaProjekt
{
    public class Biler
    {
        public string Navn { get; set; }
        public string Årgang { get; set; }
        public string Mærke { get; set; }

        public string Aktivitet { get; set; } = "Ledig";
        public Biler(string navn, string årgang, string mærke)
        {
            Navn = navn;
            Årgang = årgang;
            Mærke = mærke;
        }

        public override string ToString()
        {
            return $"{Navn} - {Aktivitet}";
        }
    }
}
