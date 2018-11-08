using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Solicitud
    {
        public int Id_solicitud { get; set; }
        public int Duracion_programa { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha_solictud { get; set; }
        public int Id_Alumno { get; set; }
        public int Id_anfitrion { get; set; }
        public int Id_establecimiento { get; set; }
        public int Id_programa { get; set; }

        public Solicitud()
        {

        }

        public bool read()
        {
            try
            {
                //test
                Datos.SOLICITUD solictud = null;
                solictud = CommonBC.ModeloCEM.SOLICITUD.Where(a => a.ID_SOLICITUD.Equals(this.Id_solicitud)).FirstOrDefault();
                if (solictud != null)
                {
                    this.Duracion_programa = (int)solictud.DURACION_PROGRAMA;
                    this.Estado = solictud.ESTADO;
                    this.Fecha_solictud = solictud.FECHA_SOLICITUD;
                    this.Id_Alumno = (int)solictud.ID_ALUMNO;
                    this.Id_anfitrion = (int)solictud.ID_ANFITRION;
                    this.Id_establecimiento = (int)solictud.ID_ESTABLECIMIENTO;
                    this.Id_programa = (int)solictud.ID_PROGRAMA;
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

    }
}
