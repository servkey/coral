<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actores.aspx.cs" Inherits="WebApplication1.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<link href="/Styles/formulario.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1 class="page-header">Actores</h1>

<form id="Form1" runat="server">
    <asp:Label Text="Numero de campos:" runat="server"/>
    <asp:TextBox ID="campos" runat="server" type="number" min="1" value="1"/>
    <asp:Button CssClass="btn btn-default" runat="server" Text="Crear" OnClick="crearFormulario"/>    
    <h2>Atributos</h2>
    <div class="jumbotron">
        <div id="formulario" runat="server">
            <asp:Panel CssClass="divrow" runat="server">
                <asp:Label CssClass="label label-default" runat="server" Text="Categoría:"/>
                <asp:DropDownList ID="categorias" runat="server"/>                
            </asp:Panel>
            <asp:Panel ID="Panel1" CssClass="divrow" runat="server">
                <asp:Label ID="Label1" Text="Nombre:" runat="server" CssClass="label label-default"></asp:Label>
                <asp:TextBox ID="nm" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>

    <asp:Button ID="regis" Text="Registrar" runat="server" CssClass="btn btn-default" OnClick="registrar" />
</form>

</asp:Content>
