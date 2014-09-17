<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesActor.aspx.cs" Inherits="WebApplication1.WebForm2" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">    
    <link href="/Styles/formulario.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h2>OSAX</h2>
<h1 class="page-header">Roles de actor</h1>

<form runat="server">
<asp:Label ID="Label2" runat="server">Numero de campos:</asp:Label><asp:TextBox ID="campos" type="number" runat="server"/>
<asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Crear" OnClick="crearFormulario"/>
<h3>Atributos</h3>
    <div id="formulario" class="jumbotron">
        <div id="formulario" runat="server">
            <asp:Panel ID="Panel1" CssClass="divrow" runat="server">
                <asp:Label ID="Label1" Text="Nombre:" runat="server" CssClass="label label-default"></asp:Label>
                <asp:TextBox ID="nm" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <asp:Button runat="server" Text="Registrar" CssClass="btn btn-default" OnClick="registrar"/>
   
</form>

</asp:Content>