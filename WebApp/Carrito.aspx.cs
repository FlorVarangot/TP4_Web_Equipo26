using dominio;
using negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Carrito : System.Web.UI.Page
    {
        
        //Eliminar mi carrito
        public Micarrito micarrito = new Micarrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["compras"] == null)
                {
                    Session["compras"] = new List<Articulo>();
                }

                List<Articulo> listaCarrito = (List<Articulo>)Session["compras"];
                List<Articulo> ListaOriginal = (List<Articulo>)Session["ListaArticulos"];

                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int ID))
                {
                    
                    Articulo seleccionado = ListaOriginal.Find(x => x.ID == ID);

                    if (seleccionado != null)
                    {
                        Articulo articuloCarrito = listaCarrito.Find(x => x.ID == seleccionado.ID);
                        if (articuloCarrito != null)
                        {

                            articuloCarrito.Cantidad += 1;

                        }
                        else
                        {
                            //Si el art no está en carrito, lo agrega
                            seleccionado.Cantidad = 1;
                            seleccionado.Subtotal = seleccionado.Precio;
                            listaCarrito.Add(seleccionado);
                            Session["Total"] = Total(listaCarrito); //
                        }
                        
                        Session["compras"] = listaCarrito;

                        
                    }                 
                }

       
                dgvArticulos.DataSource = listaCarrito;
                dgvArticulos.DataBind();

            }
           
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
                articulo.Subtotal = articulo.Precio * articulo.Cantidad;
                Session["compras"] = compras;
                Session["Total"] = Total(compras); //
            }

            dgvArticulos.DataSource = compras;
            dgvArticulos.DataBind();
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
                articulo.Subtotal = articulo.Precio * articulo.Cantidad;
                Session["compras"] = compras;
                Session["Total"] = Total(compras);
            }

            dgvArticulos.DataSource = compras;
            dgvArticulos.DataBind();
        }

         
        protected void btnEliminar_Click(object sender, EventArgs e)
        {


            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            List<Articulo> compras = (List<Articulo>)Session["compras"];
            Articulo articulo = compras.Find(x => x.ID == id);
            if (articulo != null)
            {
                compras.Remove(articulo);
                Session["compras"] = compras;
                Session["Total"] = Total(compras);
                dgvArticulos.DataSource = compras;
                dgvArticulos.DataBind();
            }

        }

        private float Total(List<Articulo> articulos)
        {
            float total = 0;
            foreach (var articulo in articulos)
            {
                total += articulo.Precio * articulo.Cantidad; 
            }

            return total;
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            List<Articulo> compras = (List<Articulo>)Session["compras"];
            float total = Total(compras);
            lblTotal.Text = "Total $" + total.ToString();
            Session["compras"] = compras;
            dgvArticulos.DataSource = compras;
            dgvArticulos.DataBind();
        }

        protected void btnVolverInicio_Click(object sender, EventArgs e)
        {
            Session["compras"] = new List<Articulo>();
            Session["Total"] = 0;
            Response.Redirect("Default.aspx");
        }
    }
    
}