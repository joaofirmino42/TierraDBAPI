using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TierraDb.Business.Interface;
using TierraDB.Dal.Model;

namespace TierraDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IQuoteBusiness _quoteBusiness;
        private readonly IHotelBusiness _hotelBusiness;
        private readonly IServicoBusiness _servicoBusiness;
        public HomeController(IQuoteBusiness quoteBusiness, IHotelBusiness hotelBusiness, IServicoBusiness servicoBusiness)
        {
            _quoteBusiness = quoteBusiness;
            _hotelBusiness= hotelBusiness;
            _servicoBusiness = servicoBusiness;
        }

        [HttpGet("{numero}/{versao}")]
        public IActionResult Get(string numero, string versao)
        {
            var quote = _quoteBusiness.RetornaQuote(numero, versao);
            return Ok(quote);
        }

        [HttpGet("Hotel/{numero}/{versao}")]
        public IActionResult GetHotel(string numero, string versao)
        {
            var hotel = _hotelBusiness.RetornaHotel(numero, versao);
            return Ok(hotel);
        }


        [HttpGet("Servico/{numero}/{versao}")]
        public IActionResult GetServico(string numero, string versao)
        {
            var servico = _servicoBusiness.RetornaServico(numero, versao);
            return Ok(servico);
        }
    }
}
