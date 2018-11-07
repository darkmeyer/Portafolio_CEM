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

namespace Sistema_Desktop.Cem.Programa
{
    /// <summary>
    /// Lógica de interacción para PublicarPrograma.xaml
    /// </summary>
    public partial class PublicarPrograma : Window
    {
        public PublicarPrograma()
        {
            InitializeComponent();
            llenarProgramas();
        }

        public void llenarProgramas()
        {
            try
            {
                Biblioteca.ProgramaColeccion coleccion = new Biblioteca.ProgramaColeccion();
                cbprogramas.ItemsSource = coleccion.read("D").Select(p => p.Id_programa + " Fecha Inicio: " + p.Fecha_inicio);
            }
            catch (Exception e)
            {
                lblMsj.Content = "Error: " + e;
            } 
        }
        
        private void cbprogramas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Biblioteca.Programa programa = new Biblioteca.Programa()
                {
                    Id_programa = int.Parse(cbprogramas.SelectedItem.ToString().Split()[0])
                };
                programa.read();
                txtNombre.Text = programa.Nombre;
                txtCupos.Text = programa.Cupos.ToString();
                txtAlumMax.Text = programa.Alum_max.ToString();
                txtAlumMin.Text = programa.Alum_min.ToString();
                dp_fecha_inicio.Text = programa.Fecha_inicio.ToString();
                dp_fecha_termino.Text = programa.Fecha_termino.ToString();
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Programa programa = new Biblioteca.Programa()
                {
                    Id_programa = int.Parse(cbprogramas.SelectedItem.ToString().Split()[0])
                };
                programa.publicar();
                lblMsj.Content = programa.publicar();
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
