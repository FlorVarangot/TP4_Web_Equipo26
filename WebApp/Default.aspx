<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col">
            <h2>WEB APP CARRITO</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-5"></div>
        <div class="col">
            <i class="fa-solid fa-basket-shopping"></i>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="input-group">
                <div class="form-outline">
                    <input type="search" id="form1" class="form-control" />
                    <label class="form-label" for="form1">Search</label>
                </div>
                <button type="button" class="btn btn-secondary  ">
                    <i class="fas fa-search"></i>
                </button>
            </div>
        </div>
    </div>
    <hr />


    <div class="d-flex justify-content-center">
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <% foreach (dominio.Articulo arti in ListaArticulos)
                { %>
            <div class="col">
                <div class="card h-100">
                    <% 
                        string imageUrl = string.IsNullOrEmpty(arti.Imagen.ImagenURl) ? "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRU-YyTxMcA9tGqbKd-9EgVe5pzPBazsWyt1L4ICuWPTA&s" : arti.Imagen.ImagenURl;
                    %>
                    <img src="<%= imageUrl %>" class="card-img-top img-fluid" alt="Imagen de <%: arti.Nombre %>"
                        style="max-height: 200px; object-fit: contain;">
                    <div class="card-body">
                        <h5 class="card-title"><%: arti.Nombre %></h5>
                        <p class="card-text"><strong>Descripcion:</strong> <%: arti.Descripcion %></p>
                        <p class="card-text"><strong>Precio:</strong> <%: arti.Precio %></p>
                        <p class="card-text"><strong>Marca:</strong> <%: arti.Marca %></p>
                        <p class="card-text"><strong>Categoría:</strong> <%: arti.Categoria %></p>
                        <a href="Carrito.aspx?id=<%: arti.ID %>" class="btn btn-success" >Lo quiero!!!</a>
                        

                        <%--Qué tal si sumamos un dropdown list en 1 por default para seleccionar la cantidad desde aquí, 
                            y entonces el btnSumar capture la cantidad junto con el ID?--%>

                        <br />
                        <a href="Detalle.aspx?id=<%: arti.ID %>">Ver Detalle</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>


</asp:Content>
