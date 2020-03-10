using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class SqlDALConfig
    {
        public SqlDALConfig(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string connectionString { get; }
    }
}
