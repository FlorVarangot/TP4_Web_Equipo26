<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticuloCarga.aspx.cs" Inherits="WebApp.ArticuloCarga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div class="row">
     <div class="col-4"></div>
     <div class="col">
         <h2>AGREGAR NUEVO ARTICULO</h2>
         <br />
     </div>
     <br />
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="ID" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="CODIGO" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="NOMBRE" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="DESCRIPCION" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="PRECIO" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="MARCA" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="CATEGORIA" CssClass="form-control" runat="server" />
             <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <div class="mb-3">
             <asp:Label Text="URL IMAGEN" CssClass="form-label" runat="server" />
             <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" />
         </div>
     </div>
 </div>
 <div class="row">
     <div class="col-6">
         <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" /> 
        
     </div>
 </div>


</asp:Content>
