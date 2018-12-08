using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sistema_Desktop.Usuario
{
    /// <summary>
    /// Lógica de interacción para ActualizarUsuario.xaml
    /// </summary>
    public partial class ActualizarUsuario : Window
    {
        public ActualizarUsuario(string rut)
        {
            InitializeComponent();
            llenarDatos(rut);
        }

        private void llenarDatos(string rut)
        {
            try
            {
                Biblioteca.Usuario usuario = new Biblioteca.Usuario() { IdRegistro = rut };
                if (usuario.read())
                {
                    txt_rut.Text = rut;
                    txt_usuario.Text = usuario.Username;
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(txt_rut.Text) || String.IsNullOrEmpty(txt_pass.Password)))
                {
                    string hash = string.Empty;

                    using (MD5 md5Hash = MD5.Create())
                    {
                        hash = GetMd5Hash(md5Hash, txt_pass.Password);
                    }
                    Biblioteca.Usuario usuario = new Biblioteca.Usuario()
                    {
                        IdRegistro = txt_rut.Text,
                        Password = hash,
                        Username = txt_usuario.Text
                    };
                    lblMsj.Content = usuario.crud(2);
                }
                else
                {
                    lblMsj.Content = "Llene todos los campos.";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
