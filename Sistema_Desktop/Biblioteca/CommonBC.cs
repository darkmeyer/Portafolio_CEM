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
    }
}
