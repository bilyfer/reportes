using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }

        public Producto(int id, string descripcion, double precio)
        {
            Id = id;
            Descripcion = descripcion;
            Precio = precio;
        }
    }
}
