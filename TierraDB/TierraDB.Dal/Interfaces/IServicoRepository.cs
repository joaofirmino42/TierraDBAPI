using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Model;

namespace TierraDB.Dal.Interfaces
{
    public interface IServicoRepository
    {
        public List<Servico> RetornaServico(string numero, string versao);
    }
}
