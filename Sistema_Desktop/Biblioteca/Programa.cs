using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Programa
    {
        public int Id_programa { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_termino { get; set; }
        public int Cupos { get; set; }
        public int Alum_max { get; set; }
        public int Alum_min { get; set; }
        public string Estado { get; set; }

        public Programa()
        {

        }


        public bool read()
        {
            try
            {
                Datos.PROGRAMA programa = null;
                programa = CommonBC.ModeloCEM.PROGRAMA.Where(u => u.ID_PROGRAMA.Equals(this.Id_programa)).FirstOrDefault();
                if (programa != null)
                {
                    this.Nombre = programa.NOMBRE_PROGRAMA;
                    this.Fecha_inicio = programa.FECHA_INICIO;
                    this.Fecha_termino = programa.FECHA_TERMINO;
                    this.Cupos = (int)programa.CUPOS;
                    this.Alum_max = (int)programa.CANT_ALUMNOS_MAX;
                    this.Alum_min = (int)programa.CANT_ALUMNOS_MIN;
                    this.Estado = programa.ESTADO;
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
                string nombreAccion = "";
                CommonBC.ModeloCEM.PROC_CRUDPROGRAMA(this.Id_programa,this.Nombre,this.Fecha_inicio, this.Fecha_termino, this.Cupos, this.Alum_max, this.Alum_min, this.Estado, accion);

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

        public string publicar()
        {
            try
            {
                OracleConnection con = CommonBC.Con;
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE PROGRAMA SET ESTADO = :param1 WHERE ID_PROGRAMA = :param2";
                cmd.Parameters.Add("param1", "A");
                cmd.Parameters.Add("param2", this.Id_programa);
                cmd.ExecuteNonQuery();
                return "Programa Publicado.";
            }
            catch (OracleException ex)
            {
                return "Exception Message: " + ex.Message + "\n" +
                "Exception Source: " + ex.Source;
            }
            catch (Exception ex)
            {
                return "Exception Message: " + ex.Message +"\n"+
                "Exception Source: " + ex.Source;
            }
        }

    }
}
