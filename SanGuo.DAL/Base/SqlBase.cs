using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SanGuo.DAL
{
    public class SqlBase
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLconnection"].ConnectionString;
    }
}
