﻿using System;
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

        public ProgramaColeccion read(string estado)
        {
            try
            {
                ProgramaColeccion coleccion = new ProgramaColeccion();
                List<Datos.PROGRAMA> lista = null;
                lista = CommonBC.ModeloCEM.PROGRAMA.Where(u => u.ESTADO.Equals(estado)).ToList();
                foreach (var item in lista)
                {
                    Programa programa = new Programa()
                    {
                        Id_programa = (int)item.ID_PROGRAMA,
                        Estado = item.ESTADO,
                        Fecha_inicio = item.FECHA_INICIO,
                        Fecha_termino = item.FECHA_TERMINO,
                        Cupos = (int)item.CUPOS,
                        Alum_max = (int)item.CANT_ALUMNOS_MAX,
                        Alum_min = (int)item.CANT_ALUMNOS_MIN
                    };
                    coleccion.Add(programa);
                }

                return coleccion;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
