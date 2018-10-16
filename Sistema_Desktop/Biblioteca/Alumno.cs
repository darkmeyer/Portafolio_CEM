using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Alumno
    {
        public int Id_Alumno { get; set; }
        public string Id_Tributario { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public DateTime Fecha_nac { get; set; }
        public string Tel_movil { get; set; }
        public string Tel_hogar { get; set; }
        public string Email { get; set; }
        public string Activo { get; set; }
        public string Direccion { get; set; }
        public int Id_Ciudad { get; set; }

        public Alumno()
        {

        }

        public bool read()
        {
            try
            {            
                Datos.ALUMNO alumno = null;
                alumno = CommonBC.ModeloCEM.ALUMNO.Where(a => a.ID_TRIBUTARIO.Equals(this.Id_Tributario)).FirstOrDefault();
                if (alumno != null)
                {
                    this.Id_Alumno = (int)alumno.ID_ALUMNO;
                    this.Nombre = alumno.NOMBRES;
                    this.APaterno = alumno.A_PATERNO;
                    this.AMaterno = alumno.A_MATERNO;
                    this.Fecha_nac = alumno.FECHA_NAC;
                    this.Tel_movil = alumno.TELEFONO_MOVIL;
                    this.Tel_hogar = alumno.TELEFONO_HOGAR;
                    this.Email = alumno.EMAIL;
                    this.Activo = alumno.ACTIVO;
                    this.Direccion = alumno.DIRECCION;
                    this.Id_Ciudad = (int)alumno.ID_CIUDAD;
                    return true;
                }
                else
                    return false;
                }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool crud(int accion)
        {
            try
            {
                int count = CommonBC.ModeloCEM.ALUMNO.Count();
                CommonBC.ModeloCEM.PROC_CRUDALUMNO(Id_Tributario, Nombre, APaterno, AMaterno, Fecha_nac, Tel_movil, Tel_hogar, Email, Activo, Direccion, Id_Ciudad, accion);
                return (CommonBC.ModeloCEM.ALUMNO.Count() - count) == 1;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }            
        }


    }
}
