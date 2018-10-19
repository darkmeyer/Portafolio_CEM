using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Rol
    {
        public int Id_rol { get; set; }
        public string Descripcion { get; set; }

        public Rol()
        {

        }

        public List<Rol> read()
        {
            try
            {
                List<Datos.ROL> lista = CommonBC.ModeloCEM.ROL.Select(c => c).ToList();
                List<Rol> roles = new List<Rol>();
                foreach (var item in lista)
                {
                    Rol rol = new Rol() { Id_rol = (int)item.ID_ROL, Descripcion = item.DESCRIPCION };
                    roles.Add(rol);
                }
                return roles;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
