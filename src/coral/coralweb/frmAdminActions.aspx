<%@ Page Language="C#" AutoEventWireup="true" Inherits="CoRaL.frmAdminActions" Codebehind="frmAdminActions.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 561px; height: 427px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;&nbsp;
            <asp:Image ID="imgLogo" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -85px;
                position: relative; top: 3px" Width="293px" />
            <table style="left: 11px; position: relative; top: 15px; width: 540px; height: 278px; background-color: #cccccc;">
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 32px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkDefinirArena" runat="server" Style="left: 83px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -2px">Definir arena</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkAdmArena" runat="server"
                Style="left: 116px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: -1px">Administrar arena</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 17px">
            <asp:HyperLink ID="lnkAdminAction" runat="server" Style="left: 154px; color: blue;
                font-family: 'Tw Cen MT'; position: relative; top: 0px">Administrar funcionalidad</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        <asp:Label ID="lblName" runat="server" Style="font-weight: bold; left: 85px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Width="292px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        <hr />
                        <asp:Label ID="lblInst" runat="server" Style="left: 0px; font-family: 'Tw Cen MT';
                            position: relative; top: -6px"
                            Width="375px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 21px">
                    </td>
                    <td style="width: 318px; height: 21px">
                        <asp:Label ID="lblAction" runat="server" Style="left: 2px; font-family: 'Tw Cen MT';
                            position: relative; top: -3px" Text="Seleccionar funcionalidad  para administrar:" Width="287px"></asp:Label></td>
                    <td style="width: 77px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 21px">
                    </td>
                    <td style="width: 318px; height: 21px">
                        <asp:DropDownList ID="lstActions" runat="server" OnSelectedIndexChanged="lstArenas_SelectedIndexChanged"
                Style="left: 2px; position: relative; top: -1px" Width="279px">
                        </asp:DropDownList></td>
                    <td style="width: 77px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 21px">
                    </td>
                    <td style="width: 318px; height: 21px">
                    </td>
                    <td style="width: 77px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 9px">
                    </td>
                    <td style="width: 318px; height: 9px">
                        &nbsp;<asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Style="left: 4px;
                position: relative; top: 1px" Text="Crear escenario" Width="105px" />
            <asp:Button ID="btnCancelar" runat="server" Style="left: 71px; position: relative;
                top: 0px" Text="Cancelar" Width="94px" OnClick="btnCancelar_Click" /></td>
                    <td style="width: 77px; height: 9px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 9px">
                    </td>
                    <td style="width: 318px; height: 9px">
                    </td>
                    <td style="width: 77px; height: 9px">
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp;
        </div>
        &nbsp; &nbsp;
        <asp:HiddenField ID="txtOption" runat="server" />
        <asp:HiddenField ID="txtId" runat="server" />
    </form>
</body>
</html>
