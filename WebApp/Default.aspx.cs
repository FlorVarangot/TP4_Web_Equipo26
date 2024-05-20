using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["ListaArticulos"] != null)
                   ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
                else
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    ListaArticulos = negocio.listar();
                    Session.Add("ListaArticulos", ListaArticulos);
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            string nombreProducto = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(nombreProducto))
            {
                if (Session["ListaArticulos"] != null)
                {
                    List<Articulo> ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
                    
                    Articulo productoSeleccionado = ListaArticulos.Find(arti => arti.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
                    if (productoSeleccionado != null)
                    {
                       
                        Response.Redirect("Detalle.aspx?id=" + productoSeleccionado.ID);
                    }
                }
            }
        }
    }
}