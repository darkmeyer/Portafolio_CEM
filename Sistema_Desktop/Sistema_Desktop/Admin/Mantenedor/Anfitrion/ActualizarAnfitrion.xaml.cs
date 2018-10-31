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

namespace Sistema_Desktop.Anfitrion
{
    /// <summary>
    /// Lógica de interacción para ActualizarAnfitrion.xaml
    /// </summary>
    public partial class ActualizarAnfitrion : Window
    {
        public ActualizarAnfitrion()
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
                Biblioteca.Anfitrion anf = new Biblioteca.Anfitrion() { Id_tributario = txtRut.Text };
                if (anf.read())
                {
                    txtNombre.Text = anf.Nombre;
                    cb_ciudad.SelectedIndex = anf.Id_Ciudad - 1;
                    txtAPaterno.Text = anf.APaterno;
                    txtAMaterno.Text = anf.AMaterno;
                    txt_direccion.Text = anf.Direccion;
                    txt_email.Text = anf.Email;
                    txt_tel_hogar.Text = anf.Tel_hogar;
                    txt_tel_movil.Text = anf.Tel_movil;
                    dp_fecha_nac.Text = anf.Fecha_nac.ToString();
                    txt_cupos.Text = anf.Cupos_alojamiento.ToString();
                    lblMsj.Content = "Anfitrion Encontrado.";
                }
                else
                {
                    lblMsj.Content = "Anfitrion No Encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(txtRut.Text) || String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtAPaterno.Text) || String.IsNullOrEmpty(txtAMaterno.Text) ||
                    String.IsNullOrEmpty(txt_cupos.Text) || String.IsNullOrEmpty(txt_tel_movil.Text) || String.IsNullOrEmpty(txt_tel_hogar.Text) || String.IsNullOrEmpty(txt_email.Text) ||
                    String.IsNullOrEmpty(txt_direccion.Text)))
                {
                    Biblioteca.Anfitrion anf = new Biblioteca.Anfitrion()
                    {
                        Id_tributario = txtRut.Text,
                        Estado_antecedentes = "A",
                        AMaterno = txtAMaterno.Text,
                        APaterno = txtAPaterno.Text,
                        Direccion = txt_direccion.Text,
                        Email = txt_email.Text,
                        Fecha_nac = DateTime.Parse(dp_fecha_nac.Text),
                        Id_Ciudad = cb_ciudad.SelectedIndex + 1,
                        Nombre = txtNombre.Text,
                        Tel_hogar = txt_tel_hogar.Text,
                        Tel_movil = txt_tel_movil.Text,
                        Fecha_antecedentes = DateTime.Now,
                        Cupos_alojamiento = Int32.Parse(txt_cupos.Text)
                    };
                    lblMsj.Content = anf.crud(2);
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
