using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Reportes
{
    public partial class Form1 : Form
    {
        List<Factura> _listaFacturas;
        List<Cliente> _listaClientes;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void CargarDatosDePrueba()
        {
            _listaFacturas = new List<Factura>();
            _listaClientes = new List<Cliente>();

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

            var factura4 = new Factura(4, cliente1, fecha);
            factura4.AgregarProducto(producto1, 10);

            _listaFacturas.Add(factura1);
            _listaFacturas.Add(factura2);
            _listaFacturas.Add(factura3);
            _listaFacturas.Add(factura4);

            _listaClientes.Add(cliente1);
            _listaClientes.Add(cliente2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarDatosDePrueba();

            switch (comboBox1.Text)
            {
                case "Ventas":
                    {
                        var bindingSource = new BindingSource();
                        bindingSource.DataSource = _listaFacturas;

                        var reporte = new ReportedeFacturas();
                        reporte.SetDataSource(bindingSource);

                        var facturaDetalle = new List<FacturaDetalle>();
                        foreach (var factura in _listaFacturas)
                        {
                            foreach (var detalle in factura.ListaFacturaDetalle)
                            {
                                facturaDetalle.Add(detalle);
                            }
                        }

                        reporte.Subreports[0].SetDataSource(facturaDetalle);

                        crystalReportViewer1.ReportSource = reporte;
                        break;
                    }
                case "Reporte de Ventas Por Clientes":
                    {
                        var bindingSource = new BindingSource();
                        bindingSource.DataSource = _listaClientes;

                        var reporte = new ReporteClientes();
                        reporte.SetDataSource(bindingSource);

                        crystalReportViewer1.ReportSource = reporte;
                        break;
                    }
                default:
                    break;
            }

            crystalReportViewer1.RefreshReport();
        }
    }
}
