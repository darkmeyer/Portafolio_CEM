using Biblioteca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string username = txt_rut.Text;
            string pass = txt_pass.Password;
            Biblioteca.Usuario usuario = new Biblioteca.Usuario() {
                Username = username,
                Password = pass
            };

            if(usuario.login())
            {
                string rol = "";
                usuario.rolUsuario();
                switch (usuario.Rol)
                {
                    case 1: rol = "Alumno"; break;
                    case 2: Admin.Admin admin = new Admin.Admin(); admin.Show(); this.Close(); break;
                    case 3: Cem.Cem cem = new Cem.Cem(); cem.Show(); this.Close(); break;
                    case 4: rol = "Cel"; break;
                    case 5: rol = "Anfitrion"; break;
                }
                lblMsj.Content = rol;
            }
            else
            {
                lblMsj.Content = "Datos Incorrectos";
            }
        }
    }
}
