using Datos;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class CommonBC
    {
        private static Entities _ModeloCEM;

        public static Entities ModeloCEM
        {
            get
            {
                if (_ModeloCEM == null)
                {
                    _ModeloCEM = new Entities();
                }                
                return _ModeloCEM;
            }
        }

        private static OracleConnection _con;

        public static OracleConnection Con
        {
            get
            {
                _con = new OracleConnection("DATA SOURCE=localhost:1521/XE;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=DARKMEYER");
                return _con;
            }
        }        
    }
}
