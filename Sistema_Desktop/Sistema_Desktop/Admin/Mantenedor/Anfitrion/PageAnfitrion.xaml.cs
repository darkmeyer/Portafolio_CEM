using Sistema_Desktop.Anfitrion;
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

namespace Sistema_Desktop.Admin.Mantenedor.Anfitrion
{
    /// <summary>
    /// Lógica de interacción para PageAnfitrion.xaml
    /// </summary>
    public partial class PageAnfitrion : Page
    {
        public PageAnfitrion()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void llenarGrid()
        {
            try
            {
                Biblioteca.Anfitrion anfitrion = new Biblioteca.Anfitrion();
                dataGrid.ItemsSource = anfitrion.readTodos();
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
                CrearAnfitrion crear = new CrearAnfitrion();
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
                Biblioteca.Anfitrion anf = (Biblioteca.Anfitrion)dataGrid.SelectedItem;
                if (anf != null)
                {
                    ActualizarAnfitrion actualizarAnfitrion = new ActualizarAnfitrion(anf.Id_tributario);
                    actualizarAnfitrion.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Anfitiron del listado", "Aviso");
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
                Biblioteca.Anfitrion anf = (Biblioteca.Anfitrion)dataGrid.SelectedItem;
                if (anf != null)
                {
                    anf.crud(3);
                    llenarGrid();
                    System.Windows.MessageBox.Show("Anfitrion Eliminado (Cupos 0)", "Aviso");
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Anfitrion del listado", "Aviso");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
