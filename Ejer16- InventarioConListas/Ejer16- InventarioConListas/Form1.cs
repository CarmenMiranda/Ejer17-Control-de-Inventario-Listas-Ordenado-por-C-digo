using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer16__InventarioConListas
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
            inventario.agregarProducto(producto);
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtInformacion.Text=inventario.reporte();
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

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            float precio = Convert.ToSingle(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Producto producto = new Producto(codigo, txtNombre.Text, precio, cantidad);

            inventario.insertarProducto(producto, Convert.ToInt32(txtPosicion.Text));
        }

        private void btnAgregarInicio_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(txtCodigo.Text);
            float precio = Convert.ToSingle(txtPrecio.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            Producto producto = new Producto(codigo, txtNombre.Text, precio, cantidad);

            inventario.agregarProductoInicio(producto);
        }
    }
}
