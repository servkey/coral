<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroCaso.aspx.cs" Inherits="WebApplication1.RegistroCaso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registro de Casos</title>
    <link href="Styles/CaseReg.css" rel="Stylesheet" type="text/css"/>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <div class="frame">
        <asp:Label Text="Nombre:  " runat="server" /><asp:TextBox ID="nombre" runat="server" />
        <asp:Label Text="Contraseña:  " runat="server"></asp:Label><asp:TextBox ID="pass" runat="server"/>
        <asp:Button Text="Registrar" OnClick="registrar"  runat="server" />
    </div>
    </form>
    </center>
</body>
</html>
