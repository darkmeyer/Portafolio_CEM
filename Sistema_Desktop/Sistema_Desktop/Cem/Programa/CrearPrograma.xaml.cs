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
    /// Lógica de interacción para CrearPrograma.xaml
    /// </summary>
    public partial class CrearPrograma : Window
    {
        public CrearPrograma()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(String.IsNullOrEmpty(txtNombre.Text) || String.IsNullOrEmpty(txtCupos.Text) || String.IsNullOrEmpty(txtAlumMax.Text) ||
                    String.IsNullOrEmpty(txtAlumMin.Text)) || String.IsNullOrEmpty(dp_fecha_inicio.Text) || String.IsNullOrEmpty(dp_fecha_termino.Text))
                {
                    Biblioteca.Programa programa = new Biblioteca.Programa()
                    {
                        Id_programa = 0,
                        Nombre = txtNombre.Text,
                        Fecha_inicio = DateTime.Parse(dp_fecha_inicio.Text),
                        Fecha_termino = DateTime.Parse(dp_fecha_termino.Text),
                        Alum_max = int.Parse(txtAlumMax.Text),
                        Alum_min = int.Parse(txtAlumMin.Text),
                        Cupos = int.Parse(txtCupos.Text),
                        Estado = "D"
                    };
                    lblMsj.Content = programa.crud(1);
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
