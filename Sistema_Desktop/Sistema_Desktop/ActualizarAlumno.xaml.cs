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
using System.Windows.Shapes;

namespace Sistema_Desktop
{
    /// <summary>
    /// Lógica de interacción para ActualizarAlumno.xaml
    /// </summary>
    public partial class ActualizarAlumno : Window
    {
        public ActualizarAlumno()
        {
            InitializeComponent();
            llenarCiudades();
        }

        private void llenarCiudades()
        {
            try
            {
                Ciudad ciudad = new Ciudad();
                cb_ciudad.ItemsSource = ciudad.read().Select(c => c.Id_ciudad + " " + c.Nombre);
                cb_ciudad.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                lblMsj.Content = "Error: " + e;
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno alumno = new Alumno() {Id_Tributario = txtRut.Text+"-"+txtRut_verificador.Text };
                if(alumno.read())
                {
                    txtNombre.Text = alumno.Nombre;
                    cb_ciudad.SelectedIndex = alumno.Id_Ciudad - 1;
                    lblMsj.Content = "Alumno Encontrado.";
                }
                else
                {
                    lblMsj.Content = "Alumno No Encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: "+ex;
            }
        }
    }
}
