<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comunidades.aspx.cs" Inherits="WebApplication1.Comunidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1 class="page-header">Comunidades</h1>

<form id="Form1" runat="server">
<asp:Label ID="Label1" runat="server">Número de campos:</asp:Label><asp:TextBox ID="campos" TYPE="number" min="1" value="1" runat="server"/>
<asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Crear" OnClick="crearFormulario"/>
<h3>Atributos</h3>
    <div class="jumbotron">
        <div id="formulario" runat="server">
            <asp:Panel ID="Panel1" CssClass="divrow" runat="server">
                <asp:Label ID="Label2" Text="Nombre:" runat="server" CssClass="label label-default"></asp:Label>
                <asp:TextBox ID="nm" runat="server"></asp:TextBox>
            </asp:Panel>
        </div>
    </div>
    <asp:Button ID="Button2" runat="server" Text="Registrar" CssClass="btn btn-default" OnClick="registrar"/>
   
</form>
</asp:Content>
