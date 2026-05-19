using System;
using System.Collections.Generic;
using System.Text;
using TierraDB.Dal.Model;

namespace TierraDB.Dal.Interfaces
{
    public interface IHotelRepository
    {
        public List<Hotel> RetornaHotel(string numero, string versao);
    }
}
