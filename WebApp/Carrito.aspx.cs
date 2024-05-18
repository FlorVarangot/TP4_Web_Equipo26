using dominio;
using negocio;
using System;
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
        //Instancio para utilizar en la funcionalidad de Carrito
        public Articulo articulo;
        public Carrito carrito;
        public List<Articulo> compras;

        /*   protected void Page_Load(object sender, EventArgs e)
           {
               //1) If para validar si existe Session["compras"]
               //si es null, carrito = new Carrito(); y Session.Add("compras", carrito);
               //sino, carrito = (Carrito)Session["compras"];

               //Aquí iría la lógica para agregar articulo al listado:
               //(El boton "lo quiero!" va a capturar ID)
               //2) IF si el request.id capturado != null
                       //bandera en false
                       //me guardo el ID
                       //articulo = buscarArticulo(ID);

                   //For para recorrer todos los articulos en carrito
                       //si coincide Id, art.Cantidad +=1
                       //bandera en true

                   //Si despues del for bandera = false,
                       //articulo.Cantidad = 1;
                       //carrito.agregarArticulo(articulo);
                       //bandera = true;

               // 3) totalizarCompra();

               ArticuloNegocio negocio = new ArticuloNegocio();
               List<Articulo> lista = negocio.listar();

               dgvArticulos.DataSource = lista;
               dgvArticulos.DataBind();

           }
           */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int ID = int.Parse(Request.QueryString["id"]);
                    List<Articulo> Carrito;
                    Carrito = Session["miCarrito"] != null ? (List<Articulo>)Session["miCarrito"] : new List<Articulo>();

                    List<Articulo> ListaOriginal = (List<Articulo>)Session["ListaArticulos"];
                    Articulo seleccionado = ListaOriginal.Find(x => x.ID == ID);
                    Carrito.Add(seleccionado);
                    //Aca actualizo
                    Session["miCarrito"] = Carrito;

                    dgvArticulos.DataSource = (List<Articulo>)Session["miCarrito"];
                    dgvArticulos.DataBind();
                }
            }
        }
    }
}