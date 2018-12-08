using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Anfitrion
    {
        public int Id_anfitrion { get; set; }
        public string Id_tributario { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public DateTime Fecha_nac { get; set; }
        public string Tel_movil { get; set; }
        public string Tel_hogar { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Estado_antecedentes { get; set; }
        public int Cupos_alojamiento { get; set; }
        public DateTime Fecha_antecedentes { get; set; }
        public int Id_Ciudad { get; set; }


        public Anfitrion()
        {

        }

        public bool read()
        {
            try
            {
                Datos.ANFITRION anfitrion = null;
                anfitrion = CommonBC.ModeloCEM.ANFITRION.Where(a => a.ID_TRIBUTARIO.Equals(this.Id_tributario)).FirstOrDefault();
                if (anfitrion != null)
                {
                    this.Id_anfitrion = (int)anfitrion.ID_ANFITRION;
                    this.Nombre = anfitrion.NOMBRES_RESPONSABLE;
                    this.APaterno = anfitrion.A_PATERNO_RESPONSABLE;
                    this.AMaterno = anfitrion.A_MATERNO_RESPONSABLE;
                    this.Fecha_nac = anfitrion.FECHA_NAC;
                    this.Tel_movil = anfitrion.TELEFONO_MOVIL;
                    this.Tel_hogar = anfitrion.TELEFONO_HOGAR;
                    this.Email = anfitrion.EMAIL;
                    this.Direccion = anfitrion.DIRECCION;
                    this.Estado_antecedentes = anfitrion.ESTADO_ANTECEDENTES;
                    this.Cupos_alojamiento = (int)anfitrion.CUPOS_ALOJAMIENTO;
                    this.Fecha_antecedentes = anfitrion.FECHA_ANTECEDENTES;
                    this.Id_Ciudad = (int)anfitrion.ID_CIUDAD;
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

        public List<Anfitrion> readTodos()
        {
            try
            {
                List<Datos.ANFITRION> listaAnfitrion = null;
                listaAnfitrion = CommonBC.ModeloCEM.ANFITRION.Select(a => a).ToList();
                if (listaAnfitrion != null)
                {
                    List<Anfitrion> list = new List<Anfitrion>();
                    foreach (var item in listaAnfitrion)
                    {
                        Anfitrion anf = new Anfitrion()
                        {
                            Id_tributario = item.ID_TRIBUTARIO,
                            Id_anfitrion = (int)item.ID_ANFITRION,
                            Nombre = item.NOMBRES_RESPONSABLE,
                            APaterno = item.A_PATERNO_RESPONSABLE,
                            AMaterno = item.A_MATERNO_RESPONSABLE,
                            Fecha_nac = item.FECHA_NAC,
                            Tel_movil = item.TELEFONO_MOVIL,
                            Tel_hogar = item.TELEFONO_HOGAR,
                            Email = item.EMAIL,
                            Direccion = item.DIRECCION,
                            Estado_antecedentes = item.ESTADO_ANTECEDENTES,
                            Cupos_alojamiento = (int)item.CUPOS_ALOJAMIENTO,
                            Fecha_antecedentes = item.FECHA_ANTECEDENTES,
                            Id_Ciudad = (int)item.ID_CIUDAD,
                    };
                        list.Add(anf);
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
                System.Data.Objects.ObjectParameter myOutputParamString = new System.Data.Objects.ObjectParameter("vRESPUESTA", typeof(string));
                CommonBC.ModeloCEM.PROC_CRUDANFITRION(this.Id_tributario, this.Nombre, this.APaterno, this.AMaterno, this.Fecha_nac, this.Tel_movil, this.Tel_hogar, this.Email, this.Direccion,
                    this.Estado_antecedentes, this.Cupos_alojamiento, this.Fecha_antecedentes, this.Id_Ciudad, accion, myOutputParamString);
                if(accion == 2)
                {
                    Datos.ANFITRION anfitrion = null;
                    anfitrion = CommonBC.ModeloCEM.ANFITRION.Where(a => a.ID_TRIBUTARIO == this.Id_tributario).FirstOrDefault();
                    anfitrion.NOMBRES_RESPONSABLE = this.Nombre;
                    anfitrion.A_PATERNO_RESPONSABLE = this.APaterno;
                    anfitrion.A_MATERNO_RESPONSABLE = this.AMaterno;
                    anfitrion.FECHA_NAC = this.Fecha_nac;
                    anfitrion.TELEFONO_MOVIL = this.Tel_movil;
                    anfitrion.TELEFONO_HOGAR = this.Tel_hogar;
                    anfitrion.EMAIL = this.Email;
                    anfitrion.DIRECCION = this.Direccion;
                    anfitrion.ESTADO_ANTECEDENTES = this.Estado_antecedentes;
                    anfitrion.CUPOS_ALOJAMIENTO = this.Cupos_alojamiento;
                    anfitrion.FECHA_ANTECEDENTES = this.Fecha_antecedentes;
                    anfitrion.ID_CIUDAD = this.Id_Ciudad;

                    CommonBC.ModeloCEM.SaveChanges();
                }
                else if(accion == 3)
                {
                    Datos.ANFITRION anfitrion = null;
                    anfitrion = CommonBC.ModeloCEM.ANFITRION.Where(a => a.ID_TRIBUTARIO == this.Id_tributario).FirstOrDefault();                    
                    anfitrion.CUPOS_ALOJAMIENTO = 0;

                    CommonBC.ModeloCEM.SaveChanges();
                }

                return Convert.ToString(myOutputParamString.Value);
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }
    }
}
