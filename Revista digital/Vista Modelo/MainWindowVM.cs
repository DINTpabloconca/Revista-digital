﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_digital.Servicios;
using System.Windows.Controls;

namespace Revista_digital.Vista_Modelo
{
    class MainWindowVM : ObservableObject
    {
        private ServicioNavegacion servicioNavegacion;
        private UserControl contenidoVentana;
        public UserControl ContenidoVentana
        {
            get { return contenidoVentana; }
            set { SetProperty(ref contenidoVentana, value); }
        }
        public RelayCommand AbrirCreacionArticuloCommand { get; }
        public RelayCommand AbrirVistaAutorCommand { get; }
        
        public MainWindowVM()
        {
            servicioNavegacion = new ServicioNavegacion();
            AbrirCreacionArticuloCommand = new RelayCommand(AbrirCreacionArticulo);
            AbrirVistaAutorCommand = new RelayCommand(AbrirVistaAutor);
        }
        public void AbrirCreacionArticulo()
        {
            ContenidoVentana = servicioNavegacion.AbrirCreacionArticulo();
        }
        public void AbrirVistaAutor()
        {
            servicioNavegacion.AbrirVistaAutor();
        }
    }
}
