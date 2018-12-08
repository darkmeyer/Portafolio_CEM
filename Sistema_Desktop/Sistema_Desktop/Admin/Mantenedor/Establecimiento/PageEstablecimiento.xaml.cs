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

namespace Sistema_Desktop.Admin.Mantenedor.Establecimiento
{
    /// <summary>
    /// Lógica de interacción para PageEstablecimiento.xaml
    /// </summary>
    public partial class PageEstablecimiento : Page
    {
        public PageEstablecimiento()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void llenarGrid()
        {
            try
            {
                Biblioteca.Establecimiento est = new Biblioteca.Establecimiento();
                dataGrid.ItemsSource = est.readTodos();
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
                CrearEstablecimiento crear = new CrearEstablecimiento();
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
                Biblioteca.Establecimiento est = (Biblioteca.Establecimiento)dataGrid.SelectedItem;
                if (est != null)
                {
                    ActualizarEstablecimiento actualizarUsuario = new ActualizarEstablecimiento(est.Id_tributario);
                    actualizarUsuario.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Establecimiento del listado", "Aviso");
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
                Biblioteca.Establecimiento est = (Biblioteca.Establecimiento)dataGrid.SelectedItem;
                if (est != null)
                {
                    est.crud(3);
                    llenarGrid();
                    System.Windows.MessageBox.Show("Establecimiento Eliminado", "Aviso");
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Establecimiento del listado", "Aviso");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
