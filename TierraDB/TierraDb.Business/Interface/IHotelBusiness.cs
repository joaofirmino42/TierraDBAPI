using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Model;

namespace TierraDb.Business.Interface
{
    public interface IHotelBusiness
    {
        public List<Hotel> RetornaHotel(string numero, string versao);
    }
}
