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

namespace Sistema_Desktop.Usuario
{
    /// <summary>
    /// Lógica de interacción para BorrarUsuario.xaml
    /// </summary>
    public partial class BorrarUsuario : Window
    {
        public BorrarUsuario()
        {
            InitializeComponent();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Usuario usuario = new Biblioteca.Usuario()
                {
                    IdRegistro = txt_rut.Text,
                    
                };
                lblMsj.Content = usuario.crud(3);
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Usuario usuario = new Biblioteca.Usuario() { IdRegistro = txt_rut.Text };
                if (usuario.read())
                {
                    txt_usuario.Text = usuario.Username;
                    lblMsj.Content = "Usuario Encontrado.";
                }
                else
                {
                    lblMsj.Content = "Usuario No Encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
