﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> listaProductos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}