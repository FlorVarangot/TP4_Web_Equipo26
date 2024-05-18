using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace WebApp
{
    public partial class ArticuloCarga : System.Web.UI.Page
    {
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
            Articulo nuevoArticulo = new Articulo();

            nuevoArticulo.Codigo = txtCodigo.Text;
            nuevoArticulo.Nombre = txtNombre.Text;
            nuevoArticulo.Descripcion = txtDescripcion.Text;
            nuevoArticulo.Marca = new Marca { Descripcion = txtMarca.Text };
            nuevoArticulo.Categoria = new Categoria { Descripcion = txtCategoria.Text };
            nuevoArticulo.Precio = float.Parse(txtPrecio.Text);
            nuevoArticulo.Imagen = new Imagen { ImagenURl = txtImagenUrl.Text };

            ListaArticulos.Add(nuevoArticulo);
            Response.Redirect("Default.aspx");


        }
    }
}