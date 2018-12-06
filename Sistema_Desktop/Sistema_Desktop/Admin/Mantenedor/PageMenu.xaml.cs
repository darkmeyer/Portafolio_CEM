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

namespace Sistema_Desktop.Admin.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mantenedor.Usuario.PageUsuario();
        }

        private void btnAlumno_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mantenedor.Alumno.PageAlumno();
        }

        private void btnAnfitrion_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mantenedor.Anfitrion.PageAnfitrion();
        }

        private void btnEstablecimiento_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Mantenedor.Establecimiento.PageEstablecimiento();
        }
    }
}
