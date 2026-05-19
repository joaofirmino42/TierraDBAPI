using System;
using System.Collections.Generic;
using System.Text;

namespace TierraDB.Dal.Model
{
    public class Hotel
    {
        public string NomeDoHotel { get; set; }
        public string PeriodoIn { get; set; }
        public string PeriodoOut { get; set; }
        public string Cidade { get; set; }
        public string Categoria { get; set; }
    }
}
