<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmAdminArena.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 558px; height: 376px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:Image ID="imgLogo" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -71px;
                position: relative; top: 9px" Width="293px" />
            <table style="left: 28px; width: 515px; position: relative; top: 14px; height: 139px;
                background-color: #cccccc">
                <tr>
                    <td style="width: 213px; height: 9px">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 10px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 136px; height: 9px">
                    </td>
                    <td style="width: 131px; height: 9px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 213px; height: 10px">
            <asp:HyperLink ID="lnkArena" runat="server" Style="left: 49px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 1px" NavigateUrl="~/frmDefinitionArena.aspx">Definir arena</asp:HyperLink></td>
                    <td style="width: 136px; height: 10px">
                    </td>
                    <td style="width: 131px; height: 10px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 213px; height: 11px">
            <asp:HyperLink ID="HyperLink2" runat="server"
                Style="left: 97px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 3px">Administrar arena</asp:HyperLink></td>
                    <td style="width: 136px; height: 11px">
                    </td>
                    <td style="width: 131px; height: 11px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
            <asp:Label ID="Label1" runat="server" Style="left: 119px; font-family: 'Tw Cen MT';
                position: relative; top: 0px" Text="Seleccionar actividad (arena):" Width="312px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
            <asp:DropDownList ID="lstArenas" runat="server" OnSelectedIndexChanged="lstArenas_SelectedIndexChanged"
                Style="left: 57px; position: relative; top: 0px" Width="404px">
            </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
            <asp:Button ID="btnCancelar" runat="server" Style="left: 279px; position: relative;
                top: -1px" Text="Cancelar" Width="94px" OnClick="btnCancelar_Click" />
            <asp:Button ID="btnAdministrar" runat="server" OnClick="Button1_Click" Style="left: 17px;
                position: relative; top: 0px" Text="Administrar" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 9px">
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp;
        </div>
        <asp:HiddenField ID="txtElement" runat="server" />
    </form>
</body>
</html>
