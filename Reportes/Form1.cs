using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Reportes
{
    public partial class Form1 : Form
    {
        List<Factura> _listaFacturas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosDePrueba();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _listaFacturas;


            //var reporte = new ReportedeFacturas();
            //reporte.SetDataSource(bindingSource);

            //crystalReportViewer1.ReportSource = reporte;
            //crystalReportViewer1.RefreshReport();
        }

        private void CargarDatosDePrueba()
        {
            _listaFacturas = new List<Factura>();

            var cliente1 = new Cliente(1, "Juan Perez", "5555555");
            var cliente2 = new Cliente(2, "Maria Martinez", "77777777");
            var fecha = DateTime.Now;

            var producto1 = new Producto(1, "Laptop", 15000);
            var producto2 = new Producto(1, "Monitor", 3000);
            var producto3 = new Producto(1, "Mouse", 200);

            var factura1 = new Factura(1, cliente1, fecha);
            factura1.AgregarProducto(producto1, 5);
            factura1.AgregarProducto(producto2, 2);

            var factura2 = new Factura(2, cliente2, fecha);
            factura2.AgregarProducto(producto1, 1);
            factura2.AgregarProducto(producto3, 1);

            var factura3 = new Factura(3, cliente1, fecha);
            factura3.AgregarProducto(producto2, 8);

            _listaFacturas.Add(factura1);
            _listaFacturas.Add(factura2);
            _listaFacturas.Add(factura3);
        }
    }
}
