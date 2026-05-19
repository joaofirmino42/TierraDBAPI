using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Model;

namespace TierraDB.Dal.Repository
{
    public class ServicoRepository : IServicoRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public ServicoRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Servico> RetornaServico(string numero, string versao)
        {
            using (var con = _connectionFactory.CreateConnection())
            {
                string sql = $@"

SELECT      Quotation_Grupo.Quotation_Id AS NumeroFile, File_Transfers.OptQuote AS VersaoQuote, File_Transfers.Data_From AS DiaDoServico, File_Transfers.Ordem, File_Transfers.Transf_nome AS NomeDoServico, 
                         Ranges.VendaNet, Ranges.Valor, Ranges.Venda AS ValorTotal, Ranges.ValorTotal, Ranges.Ranges_de, Ranges.Ranges_ate, S_Descr_Servicos.S_Descr_Longa AS Descritivo
FROM            S_Servicos INNER JOIN
                         S_Descr_Servicos ON S_Servicos.Servicos_Id = S_Descr_Servicos.Servicos_Id INNER JOIN
                         File_Transfers INNER JOIN
                         File_Carrinho ON File_Transfers.File_id = File_Carrinho.File_id INNER JOIN
                         Quotation_Grupo ON File_Carrinho.Quotation_Grupo_Id = Quotation_Grupo.Quotation_Grupo_Id INNER JOIN
                         Ranges ON File_Transfers.File_Transf_id = Ranges.FileTabelaId ON S_Servicos.Servicos_Nome = File_Transfers.Transf_nome AND S_Servicos.Cid_Id = File_Transfers.Trf_CID_id
WHERE        (Quotation_Grupo.Quotation_Id = {numero}) AND (File_Transfers.OptQuote = {versao}) AND (Ranges.Flag = N'servico')
ORDER BY DiaDoServico, File_Transfers.Ordem
";

                return con.Query<Servico>(sql).ToList();

            }
        }
    }
}
