<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            Tu carrito:
        <div class="col">
            <i class="fa-solid fa-basket-shopping"></i>
        </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div>
            <asp:GridView class="table" runat="server" CssClass="table table-dark table-bordered" ID="dgvArticulos" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Precio $" DataField="Precio" />
                    <%--<asp:ButtonField ButtonType="Image" HeaderText=""  ImageUrl="~/Recursos/Eliminar.png" />--%>
                    <asp:BoundField HeaderText="Cantidad" />
                    <asp:ButtonField ButtonType="Image" CommandName="BtnEliminar" HeaderText=""  ImageUrl="~/Recursos/Eliminar.png" ControlStyle-Height="20px" ControlStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                    
                  
                 
                </Columns>
            </asp:GridView>
        </div>
    </div>

  


    <div class="row">
        <div class="col">
            <a href="Default.aspx" class="btn btn-primary">Seguir comprando</a>
        </div>
    </div>
</asp:Content>
