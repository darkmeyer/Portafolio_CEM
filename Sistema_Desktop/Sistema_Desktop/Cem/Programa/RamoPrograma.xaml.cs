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
    /// Lógica de interacción para RamoPrograma.xaml
    /// </summary>
    public partial class RamoPrograma : Window
    {
        public RamoPrograma()
        {
            InitializeComponent();
            llenarProgramas();
        }

        private void llenarProgramas()
        {
            try
            {
                Biblioteca.ProgramaColeccion coleccion = new Biblioteca.ProgramaColeccion();
                cbprogramas.ItemsSource = coleccion.read("D").Select(p => p.Id_programa + " " + p.Nombre + " Fecha Inicio: " + p.Fecha_inicio);
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
                listbox.ItemsSource = programa.listaRamos;
                listbox.IsEnabled = true;
                llenarRamos();
                cbRamos.IsEnabled = true;
                btnAgregarRamo.IsEnabled = true;
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }

        private void llenarRamos()
        {
            try
            {
                Biblioteca.RamoColeccion coleccion = new Biblioteca.RamoColeccion();
                coleccion.readTodos();
                cbRamos.ItemsSource = coleccion.Select(r => r.Id_ramo + " " + r.Nombre);
            }
            catch (Exception e)
            {
                lblMsj.Content = "Error: " + e;
            }
        }

        private void btnAgregarRamo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Biblioteca.Programa programa = new Biblioteca.Programa()
                {
                    Id_programa = int.Parse(cbprogramas.SelectedItem.ToString().Split()[0])
                };
                lblMsj.Content = programa.agregarRamo(int.Parse(cbRamos.SelectedItem.ToString().Split()[0]));
                programa.read();
                listbox.ItemsSource = programa.listaRamos;
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
