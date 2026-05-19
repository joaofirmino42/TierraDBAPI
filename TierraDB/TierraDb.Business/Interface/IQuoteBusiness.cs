using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Model;
namespace TierraDb.Business.Interface
{
    public interface IQuoteBusiness
    {
        public Quote RetornaQuote(string numero, string versao);
      //  public Pax RetornaPax();
    }
}
