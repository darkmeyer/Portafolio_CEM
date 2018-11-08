using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Ramo
    {
        public int Id_ramo { get; set; }
        public string Siglas { get; set; }
        public string Nombre { get; set; }
        public int Cupos_disponibles { get; set; }
        public int Creditos { get; set; }
        public int Cupos_inciales { get; set; }
        public string Activo { get; set; }


        public Ramo()
        {

        }


        public bool read()
        {
            try
            {
                Datos.RAMO ramo = null;
                ramo = CommonBC.ModeloCEM.RAMO.Where(u => u.ID_RAMO.Equals(this.Id_ramo)).FirstOrDefault();
                if (ramo != null)
                {
                    this.Nombre = ramo.NOMBRE_CURSO;
                    this.Siglas = ramo.SIGLAS_RAMO;
                    this.Activo = ramo.ACTIVO;
                    this.Creditos = (int)ramo.VALOR_CREDITO;
                    this.Cupos_disponibles = (int)ramo.CUPOS_DISPONIBLES;
                    this.Cupos_inciales = (int)ramo.CUPOS_INICIALES;
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

        public string crear()
        {/*
            try
            {
                Datos.RAMO ramo = new Datos.RAMO()
                {
                    ACTIVO = "A",
                    CUPOS_INICIALES = 0,
                    CUPOS_DISPONIBLES = 0,
                    NOMBRE_CURSO = this.Nombre,
                    SIGLAS_RAMO = this.Siglas,
                    VALOR_CREDITO = this.Creditos
                };
                CommonBC.ModeloCEM.RAMO.ToList().Clear();
                CommonBC.ModeloCEM.RAMO.Add(ramo);
                CommonBC.ModeloCEM.SaveChanges();
                return "Ramo Creado exitosamente.";
            }
            catch (Exception e)
            {

                return "Error: " + e;
            }*/
            try
            {
                OracleConnection con = CommonBC.Con;
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO RAMO (SIGLAS_RAMO,NOMBRE_CURSO,CUPOS_DISPONIBLES,VALOR_CREDITO,CUPOS_INICIALES,ACTIVO) VALUES(:param1,:param2,:param3,:param4,:param5,:param6)";
                cmd.Parameters.Add("param1", this.Siglas);
                cmd.Parameters.Add("param2", this.Nombre);
                cmd.Parameters.Add("param3", "0");
                cmd.Parameters.Add("param4", this.Creditos);
                cmd.Parameters.Add("param5", "0");
                cmd.Parameters.Add("param6", "A");
                cmd.ExecuteNonQuery();
                con.Close();
                return "Ramo Creado.";
            }
            catch (OracleException ex)
            {
                return "Exception Message: " + ex.Message + "\n" +
                "Exception Source: " + ex.Source;
            }
            catch (Exception ex)
            {
                return "Exception Message: " + ex.Message + "\n" +
                "Exception Source: " + ex.Source;
            }
        }
    }
}
