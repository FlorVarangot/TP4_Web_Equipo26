<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>BIENVENIDO/A</h1>
        <h2>WEB APP CARRITO</h2>
        <div>
            <i class="fa-solid fa-basket-shopping"></i>
        </div>
        <div>
            <asp:Button ID="BtnProductos" class="btn btn-warning" runat="server" Text="Ir a PRODUCTOS" />
        </div>
    </div>


</asp:Content>
