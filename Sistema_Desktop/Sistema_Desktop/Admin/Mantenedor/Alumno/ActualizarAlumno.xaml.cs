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
        public ActualizarAlumno(string rut)
        {
            InitializeComponent();
            llenarCiudades();
            llenarDatos(rut);
        }

        private void llenarDatos(string rut)
        {
            try
            {
                Biblioteca.Alumno alum = new Biblioteca.Alumno() { Id_Tributario = rut };
                if (alum.read())
                {
                    txtRut.Text = alum.Id_Tributario;
                    txtNombre.Text = alum.Nombre;
                    cb_ciudad.SelectedIndex = alum.Id_Ciudad - 1;
                    txtAPaterno.Text = alum.APaterno;
                    txtAMaterno.Text = alum.AMaterno;
                    txt_direccion.Text = alum.Direccion;
                    txt_email.Text = alum.Email;
                    txt_tel_hogar.Text = alum.Tel_hogar;
                    txt_tel_movil.Text = alum.Tel_movil;
                    dp_fecha_nac.Text = alum.Fecha_nac.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
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

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(txtRut.Text) || String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtAPaterno.Text) || String.IsNullOrEmpty(txtAMaterno.Text) ||
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
                        Id_Ciudad = cb_ciudad.SelectedIndex + 1,
                        Nombre = txtNombre.Text,
                        Tel_hogar = txt_tel_hogar.Text,
                        Tel_movil = txt_tel_movil.Text
                    };
                    lblMsj.Content = alum.crud(2);
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
