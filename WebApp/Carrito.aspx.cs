using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Carrito : System.Web.UI.Page
    {
        public Micarrito micarrito = new Micarrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["compras"] == null)
                {
                    Session.Add("compras", new List<Articulo>());
                }

                if (Request.QueryString["id"] != null)
                {
                    int ID = int.Parse(Request.QueryString["id"]);
                    List<Articulo> listaCarrito = (List<Articulo>)Session["compras"];
                    List<Articulo> ListaOriginal = (List<Articulo>)Session["ListaArticulos"];
                    Articulo seleccionado = ListaOriginal.Find(x => x.ID == ID);

                    if (seleccionado != null)
                    {
                        Articulo articuloCarrito = listaCarrito.Find(x => x.ID == seleccionado.ID);
                        if (articuloCarrito != null)
                        {
                            



                            //CON ESTSA VALIDACION ACA; SI TOCO + SUMA DOBLE 
                            //Si el art ya está en carrito, le sumo cant
                            //articuloCarrito.Cantidad += 1;

                            //Me gustaria que si ya existe en mi carrito, entonces me avise, o ponga el boton en disabled.
                            //messageBox? label.Text?
                        }
                        else
                        {
                            //Si el art no está en carrito, lo agrega
                            seleccionado.Cantidad = 1;
                            listaCarrito.Add(seleccionado);
                        }
                        Session["compras"] = listaCarrito;
                    }

                    dgvArticulos.DataSource = (List<Articulo>)Session["compras"];
                    dgvArticulos.DataBind();
                }
            }

           micarrito.totalizarCompra();
        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            List<Articulo> compras = (List<Articulo>)Session["compras"];
            Articulo articulo = compras.Find(x => x.ID == id);

            if (articulo != null && articulo.Cantidad < 6)
            {
                articulo.Cantidad += 1;
                Session["compras"] = compras;
            }

            Response.Redirect(Request.RawUrl);
            //    dgvArticulos.DataSource = micarrito.getLista();
            //    dgvArticulos.DataBind();
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            List<Articulo> compras = (List<Articulo>)Session["compras"];
            Articulo articulo = compras.Find(x => x.ID == id);
            if (articulo != null && articulo.Cantidad > 1)
            {
                articulo.Cantidad -= 1;
                Session["compras"] = compras;
            }

           Response.Redirect(Request.RawUrl);
            //dgvArticulos.DataSource = micarrito.getLista();
            //dgvArticulos.DataBind();
        }

        // A revisar posible conflicto con agregar 
        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["id"] != null)
            {
                Button btn = (Button)sender;
                int id = int.Parse(btn.CommandArgument);
                List<Articulo> compras = (List<Articulo>)Session["compras"];
                Articulo articulo = compras.Find(x => x.ID == id);
                if (id == articulo.ID)
                {
                    compras.Remove(articulo);

                }
            }
            Response.Redirect(Request.RawUrl);
            


        }
    }
}