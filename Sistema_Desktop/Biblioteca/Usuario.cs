using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string IdRegistro { get; set; }
        public int Rol { get; set; }

        public Usuario()
        {

        }

        public bool login()
        {
            try
            {
                return CommonBC.ModeloCEM.USUARIO.Where(u => u.USERNAME.Equals(this.Username) && u.PASSWORD.Equals(this.Password)).Count() > 0;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public bool rolUsuario()
        {
            try
            {
                Datos.USUARIO usuario = null;
                usuario =  CommonBC.ModeloCEM.USUARIO.Where(u => u.USERNAME.Equals(this.Username) && u.PASSWORD.Equals(this.Password)).FirstOrDefault();
                if (usuario != null)
                {
                    this.IdRegistro = usuario.ID_REGISTRO;
                    this.Rol = (int)(usuario.ID_ROL);
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

        public bool read()
        {
            try
            {
                Datos.USUARIO usuario = null;
                usuario = CommonBC.ModeloCEM.USUARIO.Where(u => u.ID_REGISTRO.Equals(this.IdRegistro)).FirstOrDefault();
                if (usuario != null)
                {
                    this.Username = usuario.USERNAME;
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
                System.Data.Objects.ObjectParameter myOutputParamString = new System.Data.Objects.ObjectParameter("vRESPUESTA",typeof(string));
                CommonBC.ModeloCEM.PROC_CRUDUSUARIO(this.Username, this.Password, this.IdRegistro, accion, myOutputParamString);

                string msj = Convert.ToString(myOutputParamString.Value);
                return msj;
            }
            catch (Exception e)
            {
                return "Error: " + e;
            }
        }
    }
}
