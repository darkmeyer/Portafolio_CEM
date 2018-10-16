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
            Usuario usuario = new Usuario() {
                Username = username,
                Password = pass
            };

            if(usuario.login())
            {
                string rol = "";
                usuario.read();
                switch (usuario.Rol)
                {
                    case 1: rol = "Alumno"; break;
                    case 2: Mantenedores mantenedor = new Mantenedores(); mantenedor.Show(); this.Close(); break;
                    case 3: rol = "Cem"; break;
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
