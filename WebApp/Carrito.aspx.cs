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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["compras"] == null)
                {
                    Session["compras"] = new List<Articulo>();
                }

                if (Session["Total"] == null)
                {
                    Session["Total"] = 0;
                }

                if (Session["CantidadArticulos"] == null)
                {
                    Session["CantidadArticulos"] = 0;
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
                            Session["Total"] = Total(listaCarrito);
                            actualizarCarrito(listaCarrito);

                        }
                        else
                        {
                            //Si el art no está en carrito, lo agrega
                            seleccionado.Cantidad = 1;
                            seleccionado.Subtotal = seleccionado.Precio;
                            listaCarrito.Add(seleccionado);
                            Session["Total"] = Total(listaCarrito);
                            actualizarCarrito(listaCarrito);
                        }
                        
                        Session["compras"] = listaCarrito;
                    }                 
                }
                dgvArticulos.DataSource = listaCarrito;
                dgvArticulos.DataBind();
                lblTotal.DataBind();
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
                Session.Remove("compras");
                Session.Add("compras", compras);
                Session["Total"] = Total(compras);
                actualizarCarrito(compras);
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
                Session.Remove("compras");
                Session.Add("compras", compras);
                Session["Total"] = Total(compras);
                actualizarCarrito(compras);
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
                actualizarCarrito(compras);

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

        //Comprar no debería hacer nada en esta consigna, y el total deberia mostrarse todo el tiempo.
        //Dejo porque ayuda aún actualizar Total
        protected void btnComprar_Click(object sender, EventArgs e)
        {
            List<Articulo> compras = (List<Articulo>)Session["compras"];
            float total = Total(compras);
            lblTotal.Text = "Total compra: $" + total.ToString();
            Session["compras"] = compras;
            dgvArticulos.DataSource = compras;
            dgvArticulos.DataBind();
        }

        protected void btnVolverInicio_Click(object sender, EventArgs e)
        {
            Session["compras"] = new List<Articulo>();
            Session["Total"] = 0;
            Session["CantidadArticulos"] = 0;

            Response.Redirect("Default.aspx");
        }

        public int contarArticulos(List<Articulo> lista)
        {
            int cantidad = 0;
            foreach (Articulo articulo in lista)
            {
                cantidad += articulo.Cantidad;
            }
            return cantidad;
        }

        public void actualizarCarrito(List<Articulo> lista)
        {
            int cantidad = contarArticulos(lista);
            Session["CantidadArticulos"] = cantidad;
        }
    }
    
}