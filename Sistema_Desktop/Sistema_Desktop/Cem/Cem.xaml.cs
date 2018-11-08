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

namespace Sistema_Desktop.Cem
{
    /// <summary>
    /// Lógica de interacción para Cem.xaml
    /// </summary>
    public partial class Cem : Window
    {
        public Cem()
        {
            InitializeComponent();
            lbl_usuario.Content = "Cem";
        }

        private void btn_cerrar_sesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Programa.PagePrograma();
        }

        private void btnNotas_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Cel.Notas.PageNotas();
        }

        private void btnPostulantes_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Postulante.PagePostulante();
        }
    }
}
