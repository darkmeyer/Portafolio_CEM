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
        public int IdRegistro { get; set; }
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

        public bool read()
        {
            try
            {
                Datos.USUARIO usuario = null;
                usuario =  CommonBC.ModeloCEM.USUARIO.Where(u => u.USERNAME.Equals(this.Username) && u.PASSWORD.Equals(this.Password)).FirstOrDefault();
                if (usuario != null)
                {
                    this.IdRegistro = (int)(usuario.ID_REGISTRO);
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
    }
}
