<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/CaseReg.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <center>
    <h1>OSAX</h1>
    <form id="form1" runat="server">
    <div class="frame">    
        <asp:Label Text="Caso de estudio:" runat="server"/> <asp:DropDownList ID="casos" runat="server"></asp:DropDownList><br />
        <asp:Label Text="Contraseña: " runat="server"/> <asp:TextBox ID="pass" TextMode="Password" runat="server"/><br />
        <asp:Button Text="Entrar" runat="server" OnClick="loggear"/>
        <a href="RegistroCaso.aspx" >Dar de alta un caso</a>
    </div>
    </form>
    </center>
</body>
</html>
