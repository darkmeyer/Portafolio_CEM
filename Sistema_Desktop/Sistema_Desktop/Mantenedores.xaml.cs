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

namespace Sistema_Desktop
{
    /// <summary>
    /// Lógica de interacción para Mantenedores.xaml
    /// </summary>
    public partial class Mantenedores : Window
    {
        public Mantenedores()
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

        private void btn_crear_alumno_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumno crearAlum = new CrearAlumno();
            crearAlum.Show();
        }

        private void btn_actualizar_alumno_Click(object sender, RoutedEventArgs e)
        {
            ActualizarAlumno actualizarAlum = new ActualizarAlumno();
            actualizarAlum.Show();
        }

        private void btn_borrar_alumno_Click(object sender, RoutedEventArgs e)
        {
            BorrarAlumno borrarAlumno = new BorrarAlumno();
            borrarAlumno.Show();
        }
    }
}
