﻿using Sistema_Desktop.Admin.Mantenedor.Establecimiento;
using Sistema_Desktop.Anfitrion;
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

namespace Sistema_Desktop.Admin.Mantenedor
{
    /// <summary>
    /// Lógica de interacción para PageMantenedores.xaml
    /// </summary>
    public partial class PageMantenedores : Page
    {
        public PageMantenedores()
        {
            InitializeComponent();
        }

        private void btn_crear_alumno_Click(object sender, RoutedEventArgs e)
        {
            CrearAlumno crearAlum = new CrearAlumno();
            crearAlum.Show();
        }

        private void btn_actualizar_alumno_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_borrar_alumno_Click(object sender, RoutedEventArgs e)
        {
            BorrarAlumno borrarAlumno = new BorrarAlumno();
            borrarAlumno.Show();
        }

        private void btn_crear_anfitrion_Click(object sender, RoutedEventArgs e)
        {
            CrearAnfitrion crearAnfitrion = new CrearAnfitrion();
            crearAnfitrion.Show();
        }

        private void btn_actualizar_anfitrion_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_crear_usuario_Click(object sender, RoutedEventArgs e)
        {
            CrearUsuario crearUsuario = new CrearUsuario();
            crearUsuario.Show();
        }

        private void btn_actualizar_usuario_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_borrar_usuario_Click(object sender, RoutedEventArgs e)
        {
            BorrarUsuario borrarUsuario = new BorrarUsuario();
            borrarUsuario.Show();
        }

        private void btn_borrar_anfitrion_Click(object sender, RoutedEventArgs e)
        {
            BorrarAnfitrion borrarAnfitrion = new BorrarAnfitrion();
            borrarAnfitrion.Show();
        }

        private void btn_crear_establecimiento_Click(object sender, RoutedEventArgs e)
        {
            CrearEstablecimiento crearEstablecimiento = new CrearEstablecimiento();
            crearEstablecimiento.Show();
        }

        private void btn_actualizar_establecimiento_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_borrar_establecimiento_Click(object sender, RoutedEventArgs e)
        {
            BorrarEstablecimiento borrarEstablecimiento = new BorrarEstablecimiento();
            borrarEstablecimiento.Show();
        }
    }
}
