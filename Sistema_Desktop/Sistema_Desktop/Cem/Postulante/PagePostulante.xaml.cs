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

namespace Sistema_Desktop.Cem.Postulante
{
    /// <summary>
    /// Lógica de interacción para PagePostulante.xaml
    /// </summary>
    public partial class PagePostulante : Page
    {
        public PagePostulante()
        {
            InitializeComponent();
        }

        private void btn_gestionar_Click(object sender, RoutedEventArgs e)
        {
            GestionarSolicitud gestion = new GestionarSolicitud();
            gestion.Show();
        }
    }
}
