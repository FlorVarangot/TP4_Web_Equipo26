﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-2"></div>
    </div>
    <hr />
    <div class="row">
        <div>
            <asp:GridView class="table" runat="server" CssClass="table table-dark table-bordered" ID="dgvArticulos" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Codigo" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca" />
                    <asp:BoundField HeaderText="Precio unitario" DataField="Precio" />

                    <%-- Agrego botones para gestionar cantidad --%>
                    <asp:TemplateField HeaderText="Cantidad">
                        <ItemTemplate>
                            <asp:Button ID="btnMenos" runat="server" Text="-" OnClick="btnMenos_Click" CommandArgument='<%# Eval("ID") %>' />
                            <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>' />
                            <asp:Button ID="btnMas" runat="server" Text="+" OnClick="btnMas_Click" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />


                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" BackColor="Red" OnClick="btnEliminar_Click" Text="Eliminar" ForeColor="White" BorderStyle="Groove" runat="server" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col" style="color: white; font-size: 25px">
            <div>
                <a href="Default.aspx" class="btn btn-success">Seguir comprando</a>
                <asp:Button ID="btnComprar" runat="server" Text="Finalizar Compra" OnClick="btnComprar_Click" CssClass="btn btn-success" Style="align-content: end" />
                <asp:Label ID="lblTotal" runat="server" visible=true Text='<%# "Total compra: $" + Session["Total"].ToString() %>' />
                <%--<asp:Label ID="Label1" runat="server" visible=true Text='Total compra = $10000' />--%>
            </div>
            <div>
                <asp:Button ID="btnVolverInicio" runat="server" Text="Vaciar Mi carrito" CssClass="btn btn-secondary" OnClick="btnVolverInicio_Click" />
            </div>
        </div>
    </div>
    <hr />
</asp:Content>
