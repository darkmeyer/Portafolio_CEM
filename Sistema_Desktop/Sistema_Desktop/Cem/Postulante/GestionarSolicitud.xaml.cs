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

namespace Sistema_Desktop.Cem.Postulante
{
    /// <summary>
    /// Lógica de interacción para GestionarSolicitud.xaml
    /// </summary>
    public partial class GestionarSolicitud : Window
    {
        public GestionarSolicitud()
        {
            InitializeComponent();
            llenarSolictudes();
        }

        private void llenarSolictudes()
        {
            try
            {
                SolicitudColeccion coleccion = new SolicitudColeccion();
                Alumno alum = new Alumno();
                cbSolicitud.ItemsSource = coleccion.read("P").Select(p => p.Id_solicitud + " " + alum.read(p.Id_Alumno).Id_Tributario + " Fecha: " + p.Fecha_solictud);
            }
            catch (Exception e)
            {
                lblMsj.Content = "Error: " + e;
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRechazar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbprogramas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Biblioteca.Solicitud solicitud = new Biblioteca.Solicitud()
                {
                    Id_solicitud = int.Parse(cbSolicitud.SelectedItem.ToString().Split()[0])
                };
                solicitud.read();
                Alumno alum = new Alumno();
                Establecimiento est = new Establecimiento();
                Biblioteca.Programa pro = new Biblioteca.Programa(){ Id_programa = solicitud.Id_programa };
                est.read(solicitud.Id_establecimiento);
                alum.read(solicitud.Id_Alumno);
                pro.read();
                txtMoras.Text = alum.mora().ToString();
                txtNombre.Text = alum.Nombre + " " + alum.APaterno;
                txtEstablecimiento.Text = est.Nombre;
                txtPrograma.Text = pro.Nombre;
                dp_fecha.Text = solicitud.Fecha_solictud.ToString();
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
