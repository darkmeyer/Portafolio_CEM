using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Establecimiento
    {
        public int Id_establecimiento { get; set; }
        public string Id_tributario { get; set; }
        public string Nombre { get; set; }
        public string Fono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int Id_ciudad { get; set; }

        public Establecimiento()
        {

        }

        public bool read()
        {
            try
            {
                Datos.ESTABLECIMIENTO establecimiento = null;
                establecimiento = CommonBC.ModeloCEM.ESTABLECIMIENTO.Where(u => u.ID_TRIBUTARIO.Equals(this.Id_tributario)).FirstOrDefault();
                if (establecimiento != null)
                {
                    this.Id_establecimiento = (int)establecimiento.ID_ESTABLECIMIENTO;
                    this.Nombre = establecimiento.NOMBRE_ESTABLECIMIENTO;
                    this.Fono = establecimiento.TELEFONO;
                    this.Email = establecimiento.EMAIL;
                    this.Direccion = establecimiento.DIRECCION;
                    this.Id_ciudad = (int)establecimiento.ID_CIUDAD;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string crud(int accion)
        {
            try
            {
                if(accion == 3)
                {
                    if(CommonBC.ModeloCEM.PROGRAMA.Where(p => p.ESTABLECIMIENTO.Where(e => e.ID_TRIBUTARIO.Equals(this.Id_tributario)).Count() > 0).Count() > 0)
                    {
                        return "No se puede Borrar Establecimientos en uso";
                    }
                }
                string nombreAccion = "";
                CommonBC.ModeloCEM.PROC_CRUDESTABLECIMIENTO(this.Id_tributario, this.Nombre, this.Fono, this.Email, this.Direccion, this.Id_ciudad, accion);

                switch (accion)
                {
                    case 1: nombreAccion = "Creacion"; break;
                    case 2: nombreAccion = "Actualizacion"; break;
                    case 3: nombreAccion = "Eliminacion"; break;
                }
                return nombreAccion + " Exitosa.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }
    }
}
