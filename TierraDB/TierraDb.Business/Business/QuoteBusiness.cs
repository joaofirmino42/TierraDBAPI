using System;
using System.Collections.Generic;
using System.Text;
using TierraDb.Business.Interface;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Model;

namespace TierraDb.Business.Business
{
    public class QuoteBusiness : IQuoteBusiness
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteBusiness(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        public Quote RetornaQuote(string numero, string versao)
        {
            Quote quote = new Quote();
            quote.Pax = new Pax();
            var quoteRetorno = _quoteRepository.RetornaQuote(numero, versao);
            var pax = _quoteRepository.RetornaPax();

            quote.NumeroFile = quoteRetorno.NumeroFile;
            quote.PaxGrpNome = quoteRetorno.PaxGrpNome;
            quote.Cliente = quoteRetorno.Cliente;
            quote.Moeda = quoteRetorno.Moeda;
            quote.Vendendor = quoteRetorno.Vendendor;
            quote.Cidade = quoteRetorno.Cidade;


            quote.Pax.Adultos = pax.Adultos;
            quote.Pax.Criancas = pax.Criancas;
            quote.Pax.Total = pax.Total;
            quote.VersaoQuote = versao;
            return quote;
        }
    }
}
