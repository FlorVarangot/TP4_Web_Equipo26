<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            Tu carrito:
        </div>
        <div class="col">
            <i class="fa-solid fa-basket-shopping"></i>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-6">
            <asp:GridView class="table" runat="server" ID="dgvArticulos"></asp:GridView>
        </div>
    </div>
</asp:Content>
