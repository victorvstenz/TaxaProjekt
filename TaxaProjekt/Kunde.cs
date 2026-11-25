using System;
using System.Collections.Generic;
using System.Text;

namespace TaxaProjekt
{
    public class Kunde
    {
        public string Navn { get; set; }
        public string Kode { get; set; }

        public Kunde(string navn, string kode)
        {
            Navn = navn;
            Kode = kode;
        }
    }
}
