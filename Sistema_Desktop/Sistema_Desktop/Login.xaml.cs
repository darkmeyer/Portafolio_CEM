using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_Desktop
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txt_rut.Text;
                string pass = txt_pass.Password;
                string hash = string.Empty;

                using (MD5 md5Hash = MD5.Create())
                {
                    hash = GetMd5Hash(md5Hash, txt_pass.Password);
                }
                Biblioteca.Usuario usuario = new Biblioteca.Usuario()
                {
                    Username = username,
                    Password = hash
                };

                if (usuario.login())
                {
                    string rol = "";
                    usuario.rolUsuario();
                    switch (usuario.Rol)
                    {
                        case 1: rol = "Alumno"; break;
                        case 2: Admin.Admin admin = new Admin.Admin(); admin.Show(); this.Close(); break;
                        case 3: Cem.Cem cem = new Cem.Cem(); cem.Show(); this.Close(); break;
                        case 4: Cel.Cel cel = new Cel.Cel(); cel.Show(); this.Close(); break;
                        case 5: rol = "Anfitrion"; break;
                    }
                    lblMsj.Content = rol;
                }
                else
                {
                    lblMsj.Content = "Datos Incorrectos";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = ex.Message;
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

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        
    }
}
