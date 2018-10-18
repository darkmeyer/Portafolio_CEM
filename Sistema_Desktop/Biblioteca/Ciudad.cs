using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Ciudad
    {
        public int Id_ciudad { get; set; }
        public string Nombre { get; set; }
        public int Id_pais { get; set; }

        public Ciudad()
        {

        }

        public List<Ciudad> read()
        {
            try
            {                
                List<Datos.CIUDAD> lista = CommonBC.ModeloCEM.CIUDAD.Select(c => c).ToList();
                List<Ciudad> ciudades = new List<Ciudad>();
                foreach (var item in lista)
                {
                    Ciudad ciudad = new Ciudad() {Id_ciudad = (int)item.ID_CIUDAD, Nombre = item.NOMBRE, Id_pais = (int)item.ID_PAIS};
                    ciudades.Add(ciudad);
                }
                return ciudades;
            }
            catch (Exception)
            {
                return null;                
            }
        }

    }
}
