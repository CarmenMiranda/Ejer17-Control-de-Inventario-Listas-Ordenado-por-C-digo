using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer17__InventarioListasOrdenado
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
            else{
                Producto temporal = inicio;
                bool nuevoMenor = false;
                while (temporal.productoSiguiente != null && nuevoMenor == false){
                    if (temporal.productoSiguiente.codigo > nuevo.codigo)
                        nuevoMenor = true;
                    else
                        temporal = temporal.productoSiguiente;
                }
                if (temporal == inicio || temporal.productoSiguiente == null){
                    if (temporal.codigo > nuevo.codigo){
                        nuevo.productoSiguiente = temporal;
                        inicio = nuevo;
                    }
                    else{
                        nuevo.productoSiguiente = temporal.productoSiguiente;
                        temporal.productoSiguiente = nuevo;
                    }
                }
                else{
                    if (nuevoMenor || temporal.codigo > nuevo.codigo){
                        nuevo.productoSiguiente = temporal.productoSiguiente;
                        temporal.productoSiguiente = nuevo;
                    }
                    else
                        temporal.productoSiguiente = nuevo;
                }
            }
            _numeroProductos++;
        }

        public bool confirmarCodigo(int codigo) {
            Producto actual = inicio;
            bool codigoEncontrado = false;
            while (actual != null && codigoEncontrado == false){
                if (actual.codigo == codigo)
                    codigoEncontrado = true;
                else
                    actual = actual.productoSiguiente;
            }
            if (codigoEncontrado == true) 
                return false;
            else
                return true;
        }

        public Producto buscarProducto(int codigo)
        {
            Producto actual = inicio;
            bool productoEncontrado = false;
            while (actual != null && productoEncontrado == false){
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

            while (actual.productoSiguiente != null && productoEncontrado == false){
                if (actual.codigo == codigo) {
                    inicio = actual.productoSiguiente;
                    productoEncontrado = true;
                }
                else {
                    if(actual.productoSiguiente.codigo == codigo){
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
    }
}
