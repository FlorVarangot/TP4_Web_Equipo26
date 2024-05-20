using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int ID;
                    if (int.TryParse(Request.QueryString["id"], out ID))
                    {
                        List<Articulo> ListaOriginal = (List<Articulo>)Session["ListaArticulos"];
                        Articulo seleccionado = ListaOriginal.Find(x => x.ID == ID);
                        if (seleccionado != null)
                        {
                            rptImages.DataSource = seleccionado.Imagenes;
                            rptImages.DataBind();

                            detalleImagen.ImageUrl = seleccionado.Imagenes[0].ImagenURl;
                            detalleNombre.Text = seleccionado.Nombre;
                            detalleDescripcion.Text = seleccionado.Descripcion;
                            detallePrecio.Text = seleccionado.Precio.ToString();
                            detalleMarca.Text = seleccionado.Marca.Descripcion;
                            detalleCategoria.Text = seleccionado.Categoria.Descripcion;
                       }
                    }
                }
            }
        }
    }
}
