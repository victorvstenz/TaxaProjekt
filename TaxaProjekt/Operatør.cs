using System;
using System.Collections.Generic;
using System.Text;

namespace TaxaProjekt
{
    public class Operatør
    {
        public string Navn { get; set; }
        public string Kode { get; set; }

        public Operatør(string navn, string kode)
        {
            Navn = navn;
            Kode = kode;
        }
    }

}
