using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Micarrito
    {
        private List<Articulo> lista = new List<Articulo>();

        public void agregarArticulo(Articulo articulo)
        {
            lista.Add(articulo);
            
        }

        public bool Verificar(int id, List<Articulo> Lista)
        {

            foreach (Articulo articulo in Lista)
            {
                if (id == articulo.ID)
                {
                    return false;
                }
            }
            return true;
        }


        public List<Articulo> getLista() { return lista; }


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
