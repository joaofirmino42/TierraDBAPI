using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TierraDB.Dal.Interfaces
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
