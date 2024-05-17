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
                <div class="form-outline" data-mdb-input-init>
                    <input type="search" id="form1" class="form-control" />
                    <label class="form-label" for="form1">Search</label>
                </div>
                <button type="button" class="btn btn-secondary  " data-mdb-ripple-init>
                    <i class="fas fa-search"></i>
                </button>
            </div>
        </div>
    </div>
    <hr />
    <div class="row ">
        <div class="col">
            <%-- Esto no debe ser una dgv sino tarjetas --%>
            <asp:GridView class="table" runat="server" ID="dgvArticulos"></asp:GridView>
        </div>
    </div>
    <div class="row">
        <%-- Botones para las tarjetas: --%>
        <div class="col">
            <asp:Button Text="+" runat="server" />
            <asp:Label Text="0" runat="server" />
            <asp:Button Text="-" runat="server" />
        </div>
    </div>
</asp:Content>
