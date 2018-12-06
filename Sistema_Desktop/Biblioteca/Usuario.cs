using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
    {
        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Ingrese Usuario.");
                else
                    if (value.Length > 20)
                        throw new Exception("Largo permitido superado..");
                    else
                        username = value;
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Equals(""))
                    throw new Exception("Ingrese Contraseña.");
                else
                    password = value;
            }
        }


        public string IdRegistro { get; set; }
        public int Rol { get; set; }

        public Usuario()
        {

        }

        public bool login()
        {
            try
            {
                return CommonBC.ModeloCEM.USUARIO.Where( u => u.USERNAME.Equals(this.Username) && u.PASSWORD.Equals(this.Password)).Count() > 0;
            }
            catch (Exception e)
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
            {//cvcvc
                Datos.USUARIO usuario = null;
                usuario = CommonBC.ModeloCEM.USUARIO.Where( u => u.ID_REGISTRO.Equals(this.IdRegistro)).FirstOrDefault();
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

        public List<Usuario> readTodos()
        {
            try
            {//cvcvc
                List<Datos.USUARIO> listaUsuario = null;
                listaUsuario = CommonBC.ModeloCEM.USUARIO.Select(u => u).ToList();
                if (listaUsuario != null)
                {
                    List<Usuario> list = new List<Usuario>();
                    foreach (var item in listaUsuario)
                    {
                        Usuario user = new Usuario()
                        {
                            Username = item.USERNAME,
                            IdRegistro = item.ID_REGISTRO
                        };
                        list.Add(user);
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
