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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sistema_Desktop.Admin.Mantenedor.Alumno
{
    /// <summary>
    /// Lógica de interacción para PageAlumno.xaml
    /// </summary>
    public partial class PageAlumno : Page
    {
        public PageAlumno()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void llenarGrid()
        {
            try
            {
                Biblioteca.Alumno alumno = new Biblioteca.Alumno();
                dataGrid.ItemsSource = alumno.readTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CrearAlumno crear = new CrearAlumno();
                crear.Show();
            }
            catch (Exception)
            {
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Alumno alum = (Biblioteca.Alumno)dataGrid.SelectedItem;
                if (alum != null)
                {
                    ActualizarAlumno actualizarAlumno = new ActualizarAlumno(alum.Id_Tributario);
                    actualizarAlumno.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Alumno del listado", "Aviso");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Alumno alum = (Biblioteca.Alumno)dataGrid.SelectedItem;
                if (alum != null)
                {
                    alum.crud(3);
                    llenarGrid();
                    System.Windows.MessageBox.Show("Alumno Eliminado (Activo D)", "Aviso");
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Alumno del listado", "Aviso");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
