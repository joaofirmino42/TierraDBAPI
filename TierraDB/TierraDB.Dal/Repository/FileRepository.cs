using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Model;

namespace TierraDB.Dal.Repository
{
    public class FileRepository : IQuoteRepository
    {
       
        private readonly ISqlConnectionFactory _connectionFactory;
        public FileRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Quote RetornaQuote(string numero, string versao)
        {
            using (var con = _connectionFactory.CreateConnection())
            {
                string sql = $@"

                SELECT       Quotation_Grupo.Quotation_Id AS NumeroFile, Quotation_Grupo.Pax_Group_Name AS PaxGrpNome, Cliente.Cliente_nome AS Cliente, Moeda.Moeda_nome AS Moeda, Usuarios.US_nome AS Vendendor
                FROM            Quotation_Grupo INNER JOIN
                                         Cliente ON Quotation_Grupo.Cliente_id = Cliente.Cliente_id INNER JOIN
                                         Moeda ON Quotation_Grupo.Moeda_id = Moeda.Moeda_id INNER JOIN
                                         Usuarios ON Quotation_Grupo.US_Vendedor_id = Usuarios.US_id
                WHERE        (Quotation_Grupo.Quotation_Id = {numero})

                            ";

                return con.Query<Quote>(sql).SingleOrDefault();
            }
        }

        public Pax RetornaPax()
        {
            using (var con = _connectionFactory.CreateConnection())
            {
                string sql = @"
SELECT        Quotation_Grupo.Quotation_Id AS NumeroFile, Quotation_Grupo_Qtd_Adult.Qtd AS Adultos, Quotation_Grupo_Qtd_Chd.Qtd AS Criancas, Quotation_Grupo_Qtd_Adult.Qtd + Quotation_Grupo_Qtd_Chd.Qtd AS Total
FROM            Quotation_Grupo INNER JOIN
                         Quotation_Grupo_Qtd_Adult ON Quotation_Grupo.Quotation_Grupo_Id = Quotation_Grupo_Qtd_Adult.Quotation_Grupo_Id INNER JOIN
                         Quotation_Grupo_Qtd_Chd ON Quotation_Grupo.Quotation_Grupo_Id = Quotation_Grupo_Qtd_Chd.Quotation_Grupo_Id
WHERE        (Quotation_Grupo.Quotation_Id = 32924)
";
                return con.Query<Pax>(sql).SingleOrDefault();
            }
        }
    }
}
