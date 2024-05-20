<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="card mx-auto" style="max-width: 700px;">
    <div class="row g-0">
        <div class="col-md-6">
            <asp:Image ID="detalleImagen" runat="server" CssClass="card-img-top img-fluid rounded-start" Style="height: 100%; object-fit: cover;" />
        </div>
        <div class="col-md-6 d-flex align-items-center">
            <div class="card-body">
                <h5 class="card-title">
                    <asp:Label ID="detalleNombre" runat="server" />
                </h5>
                <p class="card-text">
                    <asp:Label ID="detalleDescripcion" runat="server" />
                </p>
                <p class="card-text">
                    <asp:Label ID="detallePrecio" runat="server" />
                </p>
                <p class="card-text">
                    <asp:Label ID="detalleMarca" runat="server" />
                </p>
                <p class="card-text">
                    <asp:Label ID="detalleCategoria" runat="server" />
                </p>
                <a href='Carrito.aspx?id=<%#ID %>' class="btn btn-success">¡Lo quiero!</a>

                <a href="Default.aspx" class="btn btn-success">Regresar</a>
            </div>
        </div>
    </div>
</div>


</asp:Content>
