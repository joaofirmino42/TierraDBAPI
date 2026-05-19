using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Model;

namespace TierraDB.Dal.Interfaces
{
    public interface IQuoteRepository
    {
        public Quote RetornaQuote(string numero, string versao);
        public Pax RetornaPax();
    }
}
