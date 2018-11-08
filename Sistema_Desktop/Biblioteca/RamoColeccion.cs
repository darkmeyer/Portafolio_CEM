using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class RamoColeccion : List<Ramo>
    {

        public RamoColeccion()
        {

        }

        public void readTodos()
        {
            try
            {
                RamoColeccion coleccion = new RamoColeccion();
                List<Datos.RAMO> lista = null;
                lista = CommonBC.ModeloCEM.RAMO.Select(u => u).ToList();
                foreach (var item in lista)
                {
                    Ramo programa = new Ramo()
                    {
                        Id_ramo = (int)item.ID_RAMO,
                        Nombre = item.NOMBRE_CURSO
                    };
                    this.Add(programa);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
