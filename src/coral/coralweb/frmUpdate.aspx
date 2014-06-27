<%@ Page Language="C#" AutoEventWireup="true" Inherits="CoRaL.frmUpdate" Codebehind="frmUpdate.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 601px; height: 373px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:Image
                ID="Image1" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -48px;
                position: relative; top: 8px" Width="293px" />
            <asp:HiddenField ID="txtOption" runat="server" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <table style="width: 583px; height: 99px; left: 9px; position: relative; top: 5px; background-color: #cccccc;">
                <tr>
                    <td colspan="3" style="height: 20px">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 13px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 170px; height: 20px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 37px">
            <asp:HyperLink ID="lnkDefinition" runat="server" Style="left: 68px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -1px">Definir</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
            <asp:HyperLink ID="lnkCreate" runat="server"
                Style="left: 107px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Modificar </asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="height: 30px" colspan="4">
                        <asp:Label ID="lblSelect" runat="server" Height="26px" Style="left: 188px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Text="Seleccionar nombre" Width="210px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:DropDownList ID="lstElements" runat="server" Style="left: 105px; position: relative;
                            top: 0px" Width="343px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4">
            <asp:Label ID="lblName" runat="server" Style="left: 188px; font-family: 'Tw Cen MT';
                position: relative; top: 0px" Text="Nuevo nombre" Height="26px" Width="210px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4">
            <asp:TextBox ID="txtName" runat="server" Style="left: 89px; font-family: 'Tw Cen MT';
                position: relative; top: -1px" Width="367px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 46px; height: 5px">
                    </td>
                    <td style="height: 5px">
                    </td>
                    <td style="width: 199px; height: 5px">
                    </td>
                    <td style="width: 170px; height: 5px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
            <asp:Button ID="btnUpdate" runat="server" OnClick="Button1_Click" Style="left: 164px;
                position: relative; top: 0px" Text="Actualizar" /><asp:Button ID="btnCancel" runat="server" OnClick="Button2_Click" Style="left: 230px;
                position: relative; top: 0px" Text="Cancelar" Width="85px" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
