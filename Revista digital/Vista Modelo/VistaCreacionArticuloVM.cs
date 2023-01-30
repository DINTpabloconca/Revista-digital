using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Revista_digital.Modelo;
using Revista_digital.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revista_digital.Vista_Modelo
{
    class VistaCreacionArticuloVM : ObservableObject
    {
        public ServicioCreacionArticulo servicioArticulo;

        public RelayCommand AñadirArticuloCommand { get; }

        public RelayCommand ExaminarImagenCommand { get; }

        public RelayCommand VaciarArticuloCommand { get; }

        private Articulo articuloCreado;

        public Articulo ArticuloCreado
        {
            get { return articuloCreado; }
            set { SetProperty(ref articuloCreado, value); }
        }


        public VistaCreacionArticuloVM()
        {
            servicioArticulo = new ServicioCreacionArticulo();
            ArticuloCreado = new Articulo();
            AñadirArticuloCommand = new RelayCommand(AñadirArticulo);
            ExaminarImagenCommand = new RelayCommand(ExaminarImagen);
            VaciarArticuloCommand = new RelayCommand(VaciarArticulo);
        }

        public void AñadirArticulo()
        {
            //Aquí añadir el artículo a la base de datos

            //Aquí se vuelve a dejar vacío el artículo
            VaciarArticulo();
        }

        public void VaciarArticulo()
        {
            ArticuloCreado = new Articulo();
        }
        public void ExaminarImagen()
        {
            ArticuloCreado.Imagen = servicioArticulo.ExaminaImagen();

        }
    }
}
