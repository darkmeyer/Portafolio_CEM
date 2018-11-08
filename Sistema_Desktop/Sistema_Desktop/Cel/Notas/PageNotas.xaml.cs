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

namespace Sistema_Desktop.Cel.Notas
{
    /// <summary>
    /// Lógica de interacción para Notas.xaml
    /// </summary>
    public partial class PageNotas : Page
    {
        public PageNotas()
        {
            InitializeComponent();
        }

        private void btn_consultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultarNotas cNotas = new ConsultarNotas();
            cNotas.Show();
        }
    }
}
