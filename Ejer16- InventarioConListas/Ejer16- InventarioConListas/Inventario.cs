using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer16__InventarioConListas
{
    class Inventario
    {
        private int _numeroProductos;
        public int numeroProductos { get { return _numeroProductos; } }
        public Producto inicio;

        public Inventario()
        {
            _numeroProductos = 0;
            inicio = null;
        }

        public void agregarProducto(Producto nuevo)
        {
            if (inicio == null)
                inicio = nuevo;
            else {
                Producto temporal = inicio;
                while (temporal.productoSiguiente != null)
                    temporal= temporal.productoSiguiente;
                temporal.productoSiguiente=nuevo;
            }
            _numeroProductos++;
        }

        public void agregarProductoInicio(Producto nuevo) {
            if (inicio == null)
                inicio = nuevo;
            else {
                nuevo.productoSiguiente = inicio;
                inicio = nuevo;
            }
            _numeroProductos++;
        }

        public Producto buscarProducto(int codigo)
        {
            Producto actual = inicio;
            bool productoEncontrado = false;
            while (actual != null && productoEncontrado == false) {
                if (actual.codigo == codigo)
                    productoEncontrado = true;
                else
                    actual = actual.productoSiguiente;
            }
            if (productoEncontrado == true)
                return actual;
            else
                return null;
        }

        public void eliminarProducto(int codigo)
        {
            Producto actual = inicio;
            bool productoEncontrado = false;

            while (actual.productoSiguiente != null && productoEncontrado==false) {
                if (actual.codigo == codigo){
                    inicio = actual.productoSiguiente;
                    productoEncontrado = true;
                }
                else{
                    if (actual.productoSiguiente.codigo == codigo){
                        actual.productoSiguiente = actual.productoSiguiente.productoSiguiente;
                        _numeroProductos--;
                        productoEncontrado = true;
                    }
                    else
                        actual = actual.productoSiguiente;
                }
            } 
        }

        public string reporte()
        {
            string texto = "";
            if (numeroProductos != 0){
                Producto actual = inicio;
                while (actual != null){
                    texto += actual.ToString() + Environment.NewLine;
                    actual = actual.productoSiguiente;
                }
            }
            else
                texto = "No hay productos.";
            return texto; 
        }

        public void insertarProducto(Producto nuevo, int posicion)
        {
            Producto actual = inicio;

            for (int contador1 = 0; (posicion-1) > contador1 && actual!=null; contador1++)
                actual = actual.productoSiguiente;

            nuevo.productoSiguiente = actual.productoSiguiente;
            actual.productoSiguiente = nuevo;
            _numeroProductos++;
 
        }
    }
}
