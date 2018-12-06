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
    /// Lógica de interacción para CrearUsuario.xaml
    /// </summary>
    public partial class CrearUsuario : Window
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(txt_rut.Text) || String.IsNullOrEmpty(txt_pass.Password) || String.IsNullOrEmpty(txt_usuario.Text)))
                {
                    string hash = string.Empty;

                    using (MD5 md5Hash = MD5.Create())
                    {
                        hash = GetMd5Hash(md5Hash, txt_pass.Password);
                    }
                    Biblioteca.Usuario usuario = new Biblioteca.Usuario()
                    {
                        IdRegistro = txt_rut.Text,
                        Username = txt_usuario.Text,
                        Password = hash
                    };
                    lblMsj.Content = usuario.crud(1);
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
