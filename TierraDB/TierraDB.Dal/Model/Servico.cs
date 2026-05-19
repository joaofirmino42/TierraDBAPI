using System;
using System.Collections.Generic;
using System.Text;

namespace TierraDB.Dal.Model
{
    public class Servico
    {
        public string DiaDoServico { get; set; }
        public string NomeDoServico { get; set; }
        public decimal ValorPorPax { get; set; }
        public decimal ValorTotal { get; set; }
        public string Descritivo { get; set; }
    }
}
