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

namespace Sistema_Desktop.Cel.Notas
{
    /// <summary>
    /// Lógica de interacción para ConsultarNotas.xaml
    /// </summary>
    public partial class ConsultarNotas : Window
    {
        public ConsultarNotas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(!(String.IsNullOrEmpty(txt_rut.Text)))
                {
                    Alumno alum = new Alumno()
                    {
                        Id_Tributario = txt_rut.Text
                    };
                    alum.read();
                    lblNombre.Content = alum.Nombre+" "+alum.APaterno+" "+alum.AMaterno;
                    listbox.ItemsSource = alum.readNotas();
                }            
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
            
        }
    }
}
