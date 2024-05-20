using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Articulo
    {
        
        public int ID { get; set; }
        
        [DisplayName("Código")]        
        
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public float Precio { get; set; }

        [DisplayName("Categoía")]
        public Categoria Categoria { get; set; }            
        public List<Imagen>Imagenes { get; set; }
        
        //public Imagen Imagen { get; set; }

        public int Cantidad { get; set; }

        public float Subtotal { get; set; }

    }
}
