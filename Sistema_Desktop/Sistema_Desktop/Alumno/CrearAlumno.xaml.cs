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
    /// Lógica de interacción para CrearAlumno.xaml
    /// </summary>
    public partial class CrearAlumno : Window
    {
        public CrearAlumno()
        {
            InitializeComponent();
            llenarCiudades();
        }

        private void llenarCiudades()
        {
            try
            {
                Ciudad ciudad = new Ciudad();
                cb_ciudad.ItemsSource = ciudad.read().Select(c => c.Id_ciudad+" "+c.Nombre);
                cb_ciudad.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                lblMsj.Content = "Error: "+e;                
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {                
                if(!(String.IsNullOrEmpty(txtRut.Text) || String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtAPaterno.Text) || String.IsNullOrEmpty(txtAMaterno.Text) || 
                    String.IsNullOrEmpty(dp_fecha_nac.Text) || String.IsNullOrEmpty(txt_tel_movil.Text) || String.IsNullOrEmpty(txt_tel_hogar.Text) || String.IsNullOrEmpty(txt_email.Text) || 
                    String.IsNullOrEmpty(txt_direccion.Text)))
                {
                    Alumno alum = new Alumno()
                    {
                        Id_Tributario = txtRut.Text,
                        Activo = "A",
                        AMaterno = txtAMaterno.Text,
                        APaterno = txtAPaterno.Text,
                        Direccion = txt_direccion.Text,
                        Email = txt_email.Text,
                        Fecha_nac = DateTime.Parse(dp_fecha_nac.Text),
                        Id_Ciudad = cb_ciudad.SelectedIndex+1,
                        Nombre = txtNombre.Text,
                        Tel_hogar = txt_tel_hogar.Text,
                        Tel_movil = txt_tel_movil.Text
                    };
                    lblMsj.Content = alum.crud(1);
                }
                else
                {
                    lblMsj.Content = "Llene todos los campos.";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
                
            }
        }
    }
}
