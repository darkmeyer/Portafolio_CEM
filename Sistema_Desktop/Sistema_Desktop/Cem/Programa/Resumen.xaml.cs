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
    /// Lógica de interacción para Resumen.xaml
    /// </summary>
    public partial class Resumen : Window
    {
        public Resumen()
        {
            InitializeComponent();
            llenarResumen();
        }

        private void llenarResumen()
        {
            try
            {
                ProgramaColeccion coleccion = new ProgramaColeccion();
                coleccion.readResumen();
                lblA.Content = coleccion.Where(a => a.Estado.Equals("A")).Count();
                lblT.Content = coleccion.Where(a => a.Estado.Equals("T")).Count();
                lblD.Content = coleccion.Where(a => a.Estado.Equals("D")).Count();
            }
            catch (Exception ex)
            {
                lblMsj.Content = "Error: " + ex;
            }
        }
    }
}
