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

namespace Sistema_Desktop.Cem.Programa
{
    /// <summary>
    /// Lógica de interacción para PagePrograma.xaml
    /// </summary>
    public partial class PagePrograma : Page
    {
        public PagePrograma()
        {
            InitializeComponent();
        }

        private void btn_crear_usuario_Click(object sender, RoutedEventArgs e)
        {
            CrearPrograma programa = new CrearPrograma();
            programa.Show();
        }

        private void btn_actualizar_usuario_Click(object sender, RoutedEventArgs e)
        {
            PublicarPrograma publicarP = new PublicarPrograma();
            publicarP.Show();
        }
    }
}
