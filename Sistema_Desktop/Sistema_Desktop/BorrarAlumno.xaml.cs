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
    /// Lógica de interacción para BorrarAlumno.xaml
    /// </summary>
    public partial class BorrarAlumno : Window
    {
        public BorrarAlumno()
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
                Alumno alumno = new Alumno() { Id_Tributario = txtRut.Text + "-" + txtRut_verificador.Text };
                if (alumno.read())
                {
                    txtNombre.Text = alumno.Nombre;
                    cb_ciudad.SelectedIndex = alumno.Id_Ciudad - 1;
                    txtAPaterno.Text = alumno.APaterno;
                    txtAMaterno.Text = alumno.AMaterno;
                    txt_direccion.Text = alumno.Direccion;
                    txt_email.Text = alumno.Email;
                    txt_tel_hogar.Text = alumno.Tel_hogar;
                    txt_tel_movil.Text = alumno.Tel_movil;
                    chb_activo.IsChecked = alumno.Activo.Equals("A") ? true : false;
                    dp_fecha_nac.Text = alumno.Fecha_nac.ToString();
                    lblMsj.Content = "Alumno Encontrado.";
                }
                else
                {
                    lblMsj.Content = "Alumno No Encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno alum = new Alumno()
                {
                    Nombre = txtNombre.Text,
                    Id_Ciudad = (int)cb_ciudad.SelectedIndex + 1,
                    APaterno = txtAPaterno.Text,
                    AMaterno = txtAMaterno.Text,
                    Direccion = txt_direccion.Text,
                    Email = txt_email.Text,
                    Tel_hogar = txt_tel_hogar.Text,
                    Tel_movil = txt_tel_movil.Text,
                    Activo = chb_activo.IsChecked == true ? "A" : "I",
                    Fecha_nac = DateTime.Parse(dp_fecha_nac.Text),
                    Id_Tributario = txtRut.Text + "-" + txtRut_verificador.Text
                };
                lblMsj.Content = alum.crud(3);
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
