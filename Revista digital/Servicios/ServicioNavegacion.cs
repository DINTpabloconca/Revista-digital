
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Revista_digital.Vistas;


namespace Revista_digital.Servicios
{
    class ServicioNavegacion
    {
        public CreacionArticuloUserControl AbrirCreacionArticulo()
        {
            return new CreacionArticuloUserControl();
        }
        public bool? AbrirVistaAutor()
        {
            VistaAutor vistaAutor = new VistaAutor();
            return vistaAutor.ShowDialog();
        }
    }
}
