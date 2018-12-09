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

        public List<Alumno> readTodos()
        {
            try
            {
                List<Datos.ALUMNO> listaAlumno = null;
                listaAlumno = CommonBC.ModeloCEM.ALUMNO.Select(a => a).ToList();
                if (listaAlumno != null)
                {
                    List<Alumno> list = new List<Alumno>();
                    foreach (var item in listaAlumno)
                    {
                        Alumno alum = new Alumno()
                        {
                            Id_Tributario = item.ID_TRIBUTARIO,
                            Id_Alumno = (int)item.ID_ALUMNO,
                            Nombre = item.NOMBRES,
                            APaterno = item.A_PATERNO,
                            AMaterno = item.A_MATERNO,
                            Fecha_nac = item.FECHA_NAC,
                            Tel_movil = item.TELEFONO_MOVIL,
                            Tel_hogar = item.TELEFONO_HOGAR,
                            Email = item.EMAIL,
                            Direccion = item.DIRECCION,
                            Id_Ciudad = (int)item.ID_CIUDAD,
                            Activo = item.ACTIVO
                        };
                        list.Add(alum);
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
                    string conStr = "select alumno.ID_TRIBUTARIO, RAMO.NOMBRE_CURSO, listagg(NOTA.NOTA, '  ' ) within group (order by NOTA.ID_NOTA) as NOTAS, RESULTADO_ACADEMICO.PROMEDIO from alumno JOIN RESULTADO_ACADEMICO ON RESULTADO_ACADEMICO.ID_ALUMNO = alumno.ID_ALUMNO JOIN NOTA ON NOTA.ID_RESULTADO = RESULTADO_ACADEMICO.ID_RESULTADO JOIN RAMO ON RAMO.ID_RAMO = RESULTADO_ACADEMICO.ID_RAMO GROUP BY alumno.ID_TRIBUTARIO, RESULTADO_ACADEMICO.PROMEDIO , RAMO.NOMBRE_CURSO HAVING alumno.ID_TRIBUTARIO = :param1";
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
                            Nombre_curso = dr.GetString(1),
                            Notas = dr.GetString(2),
                            Promedio = dr.GetInt32(3)   
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

                if (accion == 2)
                {
                    Datos.ALUMNO alumno = null;
                    alumno = CommonBC.ModeloCEM.ALUMNO.Where(a => a.ID_TRIBUTARIO == this.Id_Tributario).FirstOrDefault();
                    alumno.NOMBRES = this.Nombre;
                    alumno.A_PATERNO = this.APaterno;
                    alumno.A_MATERNO = this.AMaterno;
                    alumno.FECHA_NAC = this.Fecha_nac;
                    alumno.TELEFONO_MOVIL = this.Tel_movil;
                    alumno.TELEFONO_HOGAR = this.Tel_hogar;
                    alumno.EMAIL = this.Email;
                    alumno.DIRECCION = this.Direccion;
                    alumno.ACTIVO = this.Activo;
                    alumno.ID_CIUDAD = this.Id_Ciudad;

                    CommonBC.ModeloCEM.SaveChanges();
                }
                else if (accion == 3)
                {
                    Datos.ALUMNO alumno = null;
                    alumno = CommonBC.ModeloCEM.ALUMNO.Where(a => a.ID_TRIBUTARIO == this.Id_Tributario).FirstOrDefault();
                    alumno.ACTIVO = "D";

                    CommonBC.ModeloCEM.SaveChanges();
                }

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
