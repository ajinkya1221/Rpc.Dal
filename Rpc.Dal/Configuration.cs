using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Rpc.Dal
{
    public class Configuration
    {
        public static string RpcDb
        {
            get
            {
                string connectionString =
                    ConfigurationManager.ConnectionStrings["RpcDB"].ConnectionString;
                return connectionString;
            }
        }
    }
}
