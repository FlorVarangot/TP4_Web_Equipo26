using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    internal class Carrito
    {
        private List<Articulo> lista = new List<Articulo>();

        public void agregarArticulo(Articulo articulo)
        {
            lista.Add(articulo);
        }

        public List<Articulo> getLista() { return lista; }

        public void eliminarArticulo()
        {
            //Agregar logica para quitar articulo del carrito
        }

        //Método para buscar el id capturado en el listado de articulos del carrito
        //Se elimana bsuca rarticulo porque no va a hacer falta

        //Método para sacar el total de la compra
        public decimal totalizarCompra()
        {
            decimal total = 0;
            foreach (Articulo articulo in lista)
            {
                total += (decimal)articulo.Cantidad * (decimal)articulo.Precio;
            }
            return total;
        }

        //Sugerencia: método que recibe un listado y un id.
        public int contarArticulos(List<Articulo> lista, int Id)
        {
            int cantidad = 0;
            //Agregar lógica
            // Recorrer el listado, si encuentra arti con == id, cantidad++
            //Devuelve cantidad
            return cantidad;
        }
    }
}
