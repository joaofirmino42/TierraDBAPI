using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Model;

namespace TierraDB.Dal.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;
        public HotelRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public List<Hotel> RetornaHotel(string numero, string versao)
        {
            using (var con = _connectionFactory.CreateConnection())
            {
                string sql = $@"
SELECT        Quotation_Grupo.Quotation_Id AS NumeroFile, File_Tarifas.OptQuote AS VersaoQuote, File_Tarifas.S_nome AS NomeDoHotel, File_Tarifas.Data_From AS PeriodoIn, File_Tarifas.Data_To AS PeriodoOut, 
                         Cidade.CID_nome AS Cidade, File_Tarifas.Room AS Categoria
FROM            Supplier INNER JOIN
                         Cidade ON Supplier.CID_id = Cidade.CID_id INNER JOIN
                         File_Tarifas INNER JOIN
                         File_Carrinho ON File_Tarifas.File_id = File_Carrinho.File_id INNER JOIN
                         Quotation_Grupo ON File_Carrinho.Quotation_Grupo_Id = Quotation_Grupo.Quotation_Grupo_Id ON Supplier.S_id = File_Tarifas.S_id
WHERE        (Quotation_Grupo.Quotation_Id = {numero}) AND (File_Tarifas.OptQuote = {versao})
ORDER BY PeriodoIn, File_Tarifas.Ordem

";
                return con.Query<Hotel>(sql).ToList();
            }
        }
    }
}
