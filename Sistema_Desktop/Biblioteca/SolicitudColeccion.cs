using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class SolicitudColeccion : List<Solicitud>
    {
        public SolicitudColeccion()
        {

        }

        public SolicitudColeccion read(string estado)
        {
            try
            {
                List<Datos.SOLICITUD> lista = new List<Datos.SOLICITUD>();
                lista = CommonBC.ModeloCEM.SOLICITUD.Where(s => s.ESTADO.Equals(estado)).ToList();
                foreach (var item in lista)
                {
                    Solicitud solicitud = new Solicitud()
                    {
                        Id_solicitud = (int)item.ID_SOLICITUD,
                        Duracion_programa = (int)item.DURACION_PROGRAMA,
                        Estado = item.ESTADO,
                        Fecha_solictud = item.FECHA_SOLICITUD,
                        Id_Alumno = (int)item.ID_ALUMNO,
                        Id_anfitrion = (int)item.ID_ANFITRION,
                        Id_establecimiento = (int)item.ID_ESTABLECIMIENTO,
                        Id_programa = (int)item.ID_PROGRAMA
                };
                    this.Add(solicitud);
                }

                return this;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
