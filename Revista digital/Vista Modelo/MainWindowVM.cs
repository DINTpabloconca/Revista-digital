using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_digital.Modelo;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Revista_digital.Vista_Modelo
{
    class MainWindowVM : ObservableObject
    {
        public RelayCommand AbrirCreacionArticulo { get; }
        
    }
}
