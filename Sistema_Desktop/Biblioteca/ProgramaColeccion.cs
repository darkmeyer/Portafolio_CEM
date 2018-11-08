using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class ProgramaColeccion : List<Programa>
    {

        public ProgramaColeccion()
        {

        }

        public void readResumen()
        {
            try
            {
                ProgramaColeccion coleccion = new ProgramaColeccion();
                List<Datos.PROGRAMA> lista = null;
                lista = CommonBC.ModeloCEM.PROGRAMA.Select(u => u).ToList();
                foreach (var item in lista)
                {
                    Programa programa = new Programa()
                    {
                        Id_programa = (int)item.ID_PROGRAMA,
                        Estado = item.ESTADO
                    };
                    this.Add(programa);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public ProgramaColeccion read(string estado)
        {
            try
            {
                List<Datos.PROGRAMA> lista = null;
                lista = CommonBC.ModeloCEM.PROGRAMA.Where(u => u.ESTADO.Equals(estado)).ToList();
                foreach (var item in lista)
                {
                    Programa programa = new Programa()
                    {
                        Id_programa = (int)item.ID_PROGRAMA,
                        Nombre = item.NOMBRE_PROGRAMA,
                        Estado = item.ESTADO,
                        Fecha_inicio = item.FECHA_INICIO,
                        Fecha_termino = item.FECHA_TERMINO,
                        Cupos = (int)item.CUPOS,
                        Alum_max = (int)item.CANT_ALUMNOS_MAX,
                        Alum_min = (int)item.CANT_ALUMNOS_MIN
                    };
                    this.Add(programa);
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
