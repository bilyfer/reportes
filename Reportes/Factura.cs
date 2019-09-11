using System;
using System.Collections.Generic;

namespace Reportes
{
    public class Factura
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<FacturaDetalle> ListaFacturaDetalle { get; set; }

        public Factura(int id, Cliente cliente, DateTime fecha)
        {
            Id = id;
            NombreCliente = cliente.Nombre;
            Fecha = fecha;
            ListaFacturaDetalle = new List<FacturaDetalle>();
        }

        internal void AgregarProducto(Producto producto, int cantidad)
        {
            var id = ListaFacturaDetalle.Count + 1;
            var nuevoFacturaDetalle = new FacturaDetalle(id, producto, cantidad);
            nuevoFacturaDetalle.FacturaId = Id;

            ListaFacturaDetalle.Add(nuevoFacturaDetalle);
        }
    }

    public class FacturaDetalle
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string DescripcionProducto { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double SubTotal { get; set; }

        public FacturaDetalle(int id, Producto producto, int cantidad)
        {
            Id = id;
            DescripcionProducto = producto.Descripcion;
            Cantidad = cantidad;
            Precio = producto.Precio;
            SubTotal = Cantidad * Precio;
        }
    }
}
