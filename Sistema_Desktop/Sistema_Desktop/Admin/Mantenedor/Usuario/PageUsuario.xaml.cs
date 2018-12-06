using Sistema_Desktop.Usuario;
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

namespace Sistema_Desktop.Admin.Mantenedor.Usuario
{
    /// <summary>
    /// Lógica de interacción para PageUsuario.xaml
    /// </summary>
    public partial class PageUsuario : Page
    {
        public PageUsuario()
        {
            InitializeComponent();
            llenarGrid();
        }

        private void llenarGrid()
        {
            try
            {
                Biblioteca.Usuario usuario = new Biblioteca.Usuario();
                dataGrid.ItemsSource = usuario.readTodos();                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Usuario usuario = (Biblioteca.Usuario)dataGrid.SelectedItem;
                if(usuario != null)
                {
                    usuario.crud(3);
                    llenarGrid();
                    System.Windows.MessageBox.Show("Usuario Eliminado", "Aviso");
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Usuario del listado", "Aviso");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Usuario usuario = (Biblioteca.Usuario)dataGrid.SelectedItem;
                if (usuario != null)
                {
                    ActualizarUsuario actualizarUsuario = new ActualizarUsuario(usuario.IdRegistro);
                    actualizarUsuario.Show();
                }
                else
                {
                    System.Windows.MessageBox.Show("Seleccione Usuario del listado", "Aviso");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario();
            crearUsuario.Show();
        }
    }
}
