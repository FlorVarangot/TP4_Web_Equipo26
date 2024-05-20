<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
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
                        <a href="Carrito.aspx?id=<%: arti.ID %>" class="btn btn-success" >¡Lo quiero!</a>
                        

                        <%--Qué tal si sumamos un dropdown list en 1 por default para seleccionar la cantidad desde aquí, 
                            y entonces el btnSumar capture la cantidad junto con el ID? (Flor)--%>

                        <br />
                        <a href="Detalle.aspx?id=<%: arti.ID %>">Ver más</a>
                    </div>
                </div>
            </div>
            <% } %>
        </div>
    </div>


</asp:Content>
