using System;
using System.Collections.Generic;
using System.Text;

namespace TierraDB.Dal.Model
{
    public class Quote
    {
        public string NumeroFile { get; set; }
        public string PaxGrpNome { get; set; }
        public string Cliente { get; set; }
        public string Moeda { get; set; }
        public string Vendendor { get; set; }
        public string Cidade { get; set; }
        public string VersaoQuote { get; set; }
        public Pax Pax { get; set; }
    }
    public class Pax
    {
        public int Adultos { get; set; }
        public int Criancas { get; set; }
        public int Total { get; set; }
    }
}
