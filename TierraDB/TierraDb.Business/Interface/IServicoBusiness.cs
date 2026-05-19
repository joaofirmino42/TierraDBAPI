using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Model;

namespace TierraDb.Business.Interface
{
    public interface IServicoBusiness
    {
        public List<Servico> RetornaServico(string numero, string versao);
    }
}
