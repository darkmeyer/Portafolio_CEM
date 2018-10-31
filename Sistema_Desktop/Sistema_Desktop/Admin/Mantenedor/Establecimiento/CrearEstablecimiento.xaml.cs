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

namespace Sistema_Desktop.Admin.Mantenedor.Establecimiento
{
    /// <summary>
    /// Lógica de interacción para CrearEstablecimiento.xaml
    /// </summary>
    public partial class CrearEstablecimiento : Window
    {
        public CrearEstablecimiento()
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

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(txtRut.Text) || String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtDirecion.Text) || String.IsNullOrEmpty(txtEmail.Text) ||
                    String.IsNullOrEmpty(txtFono.Text)))
                {
                    Biblioteca.Establecimiento est = new Biblioteca.Establecimiento()
                    {
                        Id_tributario = txtRut.Text,
                        Direccion = txtDirecion.Text,
                        Email = txtEmail.Text,
                        Fono = txtFono.Text,
                        Nombre = txtNombre.Text,
                        Id_ciudad = cb_ciudad.SelectedIndex + 1
                    };
                    lblMsj.Content = est.crud(1);
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
