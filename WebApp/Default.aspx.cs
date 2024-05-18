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
            if (!IsPostBack) // Verifico si es la primera carga de la página
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

        protected void BtnSumar_Click(object sender, EventArgs e)
        {

        }
    }
}