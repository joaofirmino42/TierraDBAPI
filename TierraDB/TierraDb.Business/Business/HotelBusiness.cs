using System;
using System.Collections.Generic;
using System.Text;
using TierraDb.Business.Interface;
using TierraDB.Dal.Interfaces;
using TierraDB.Dal.Model;

namespace TierraDb.Business.Business
{
    public class HotelBusiness: IHotelBusiness
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelBusiness(IHotelRepository hotelRepository)
        {
            _hotelRepository= hotelRepository;
        }

        public List<Hotel> RetornaHotel(string numero, string versao)
        {
            var hotel = _hotelRepository.RetornaHotel(numero,  versao);
            return hotel;
        }
    }
}
