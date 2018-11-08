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

namespace Sistema_Desktop.Cem.Programa
{
    /// <summary>
    /// Lógica de interacción para CrearRamo.xaml
    /// </summary>
    public partial class CrearRamo : Window
    {
        public CrearRamo()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Ramo ramo = new Ramo()
                {
                    Creditos = int.Parse(txtCreditos.Text),
                    Nombre = txtNombre.Text,
                    Siglas = txtSiglas.Text
                };
                lblMsj.Content = ramo.crear();

            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
