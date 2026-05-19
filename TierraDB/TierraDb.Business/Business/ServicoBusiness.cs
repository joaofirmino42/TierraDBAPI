using System;
using System.Collections.Generic;
using System.Text;
using TierraDb.Business.Interface;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Model;

namespace TierraDb.Business.Business
{
    public class ServicoBusiness : IServicoBusiness
    {
        private readonly IServicoRepository _servicoRepository;
        public ServicoBusiness(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }
        public List<Servico> RetornaServico(string numero, string versao)
        {
            var servico = _servicoRepository.RetornaServico(numero,versao);
            return servico;

        }
    }
}
