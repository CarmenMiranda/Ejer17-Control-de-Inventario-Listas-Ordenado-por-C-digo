using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer17__InventarioListasOrdenado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Inventario inventario = new Inventario();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            float precio = Convert.ToSingle(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Producto producto = new Producto(codigo, txtNombre.Text, precio, cantidad);

            if (inventario.confirmarCodigo(codigo))
                inventario.agregarProducto(producto);
            else {
                txtCodigo.Text = "";
                MessageBox.Show("Código no disponible");
                txtCodigo.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Producto producto = inventario.buscarProducto(Convert.ToInt32(txtCodigo.Text));
            if (producto != null)
                txtInformacion.Text = producto.ToString();
            else
                txtInformacion.Text = "El producto no existe";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            inventario.eliminarProducto(Convert.ToInt32(txtCodigo.Text));
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtInformacion.Text = inventario.reporte();
        }
    }
}
