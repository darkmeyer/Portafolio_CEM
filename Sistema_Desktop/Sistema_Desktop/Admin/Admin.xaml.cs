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
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace Sistema_Desktop.Admin
{
    /// <summary>
    /// Lógica de interacción para Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            lbl_usuario.Content = "Admin";
        }
        
        private void btn_cerrar_sesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnMantenedores_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mantenedor.PageMenu();
        }

        private void btnPrograma_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Cem.Programa.PagePrograma();
        }

        private void btnNotas_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Cel.Notas.PageNotas();
        }
    }
}
