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

        public bool read(int id)
        {
            try
            {
                Datos.ESTABLECIMIENTO establecimiento = null;
                establecimiento = CommonBC.ModeloCEM.ESTABLECIMIENTO.Where(u => u.ID_ESTABLECIMIENTO == id).FirstOrDefault();
                if (establecimiento != null)
                {
                    this.Id_tributario = establecimiento.ID_TRIBUTARIO;
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

        public List<Establecimiento> readTodos()
        {
            try
            {
                List<Datos.ESTABLECIMIENTO> listaEstablecimiento = null;
                listaEstablecimiento = CommonBC.ModeloCEM.ESTABLECIMIENTO.Select(e => e).ToList();
                if (listaEstablecimiento != null)
                {
                    List<Establecimiento> list = new List<Establecimiento>();
                    foreach (var item in listaEstablecimiento)
                    {
                        Establecimiento est = new Establecimiento()
                        {
                            Nombre = item.NOMBRE_ESTABLECIMIENTO,
                            Id_tributario = item.ID_TRIBUTARIO,
                            Id_establecimiento = (int)item.ID_ESTABLECIMIENTO,
                            Id_ciudad = (int)item.ID_CIUDAD,
                            Direccion = item.DIRECCION,
                            Email = item.EMAIL,
                            Fono = item.TELEFONO
                        };
                        list.Add(est);
                    }
                    return list;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public string crud(int accion)
        {
            try
            {
                if (accion == 3)
                {
                    if (CommonBC.ModeloCEM.PROGRAMA.Where(p => p.ESTABLECIMIENTO.Where(e => e.ID_TRIBUTARIO.Equals(this.Id_tributario)).Count() > 0).Count() > 0)
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

                Datos.ESTABLECIMIENTO establecimiento = null;
                establecimiento = CommonBC.ModeloCEM.ESTABLECIMIENTO.Where(e => e.ID_TRIBUTARIO == this.Id_tributario).FirstOrDefault();
                establecimiento.NOMBRE_ESTABLECIMIENTO = this.Nombre;
                establecimiento.TELEFONO = this.Fono;
                establecimiento.EMAIL = this.Email;
                establecimiento.DIRECCION = this.Direccion;
                establecimiento.ID_CIUDAD = this.Id_ciudad;

                CommonBC.ModeloCEM.SaveChanges();

                return nombreAccion + " Exitosa.";
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }
    }
}
