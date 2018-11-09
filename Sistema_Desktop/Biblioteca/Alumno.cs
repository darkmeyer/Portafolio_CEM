using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public Alumno read(int id)
        {
            try
            {
                //test
                Datos.ALUMNO alumno = null;
                alumno = CommonBC.ModeloCEM.ALUMNO.Where(a => a.ID_ALUMNO.Equals(id)).FirstOrDefault();
                if (alumno != null)
                {
                    this.Id_Alumno = id;
                    this.Id_Tributario = alumno.ID_TRIBUTARIO;
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
                    return this;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool read()
        {
            try
            {
                //test
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

        public List<Nota> readNotas()
        {
            try
            {
                //test
                Datos.ALUMNO alumno = null;
                alumno = CommonBC.ModeloCEM.ALUMNO.Where(a => a.ID_TRIBUTARIO.Equals(this.Id_Tributario)).FirstOrDefault();
                if (alumno != null)
                {  
                    List<Nota> notas = new List<Nota>();
                    OracleConnection con;
                    string conStr = "select alumno.ID_TRIBUTARIO, RESULTADO_ACADEMICO.PROMEDIO, RAMO.NOMBRE_CURSO from alumno" +
                        " JOIN RESULTADO_ACADEMICO ON RESULTADO_ACADEMICO.ID_ALUMNO = alumno.ID_ALUMNO " +
                        "JOIN NOTA ON NOTA.ID_RESULTADO = RESULTADO_ACADEMICO.ID_RESULTADO JOIN RAMO ON RAMO.ID_RAMO = RESULTADO_ACADEMICO.ID_RAMO" +
                        " GROUP BY alumno.ID_TRIBUTARIO, RESULTADO_ACADEMICO.PROMEDIO , RAMO.NOMBRE_CURSO HAVING alumno.ID_TRIBUTARIO = :param1";
                    con = CommonBC.Con;
                    con.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = conStr;
                    cmd.Parameters.Add("param1", this.Id_Tributario);
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Nota nota = new Nota()
                        {
                            Promedio = dr.GetInt32(1),
                            Nombre_curso = dr.GetString(2)
                            
                        };
                        notas.Add(nota);
                    }
                    return notas;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string crud(int accion)
        {
            try
            {
                System.Data.Objects.ObjectParameter myOutputParamString = new System.Data.Objects.ObjectParameter("vRESPUESTA", typeof(string));
                CommonBC.ModeloCEM.PROC_CRUDALUMNO(Id_Tributario, Nombre, APaterno, AMaterno, Fecha_nac, Tel_movil, Tel_hogar, Email, Activo, Direccion, Id_Ciudad, accion, myOutputParamString);
                return Convert.ToString(myOutputParamString.Value);

            }
            catch (Exception e)
            {
                return "Error: " + e;
            }            
        }         
        
        public int mora()
        {
            try
            {
                string api_url = "http://localhost:8585/WebService/webresources/mora";
                WebClient client = new WebClient();
                string result = client.DownloadString(api_url);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(result);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("idAlumno");
                int count = 0;
                foreach (XmlNode item in nodeList)
                {
                    foreach (XmlNode item1 in item.ChildNodes)
                    {
                        if(item1.Name.Equals("idAlumno"))
                        {
                            if(item1.InnerText.Equals(this.Id_Alumno.ToString()))
                            {
                                count++;
                            }
                        }
                    }
                }
                return count;
            }
            catch (Exception)
            {
                return 0;                
            }
        }
    }
}
