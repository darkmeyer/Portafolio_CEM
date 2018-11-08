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

namespace Sistema_Desktop.Cel
{
    /// <summary>
    /// Lógica de interacción para Cel.xaml
    /// </summary>
    public partial class Cel : Window
    {
        public Cel()
        {
            InitializeComponent();
            lbl_usuario.Content = "Cel";
        }

        private void btn_cerrar_sesion_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void btnNotas_Click(object sender, RoutedEventArgs e)
        {             
            Main.Content = new Notas.PageNotas();
        }
    }
}
