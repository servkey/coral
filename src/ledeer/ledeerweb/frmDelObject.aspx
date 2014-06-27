<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDelObject.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 580px; height: 412px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;
            <asp:Image ID="Image1" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -88px;
                position: relative; top: 10px" Width="293px" />
            <table style="left: 13px; width: 552px; position: relative; top: 18px; height: 99px;
                background-color: #cccccc">
                <tr>
                    <td colspan="3">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 27px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: -2px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 170px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 27px">
                        &nbsp;<asp:HyperLink ID="lnkObj" runat="server" Style="left: 70px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 0px">Definir objeto</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="4">
            <asp:HyperLink ID="lnkAdmArena" runat="server"
                Style="left: 116px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Eliminar objeto</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 18px">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="width: 46px; height: 30px">
                    </td>
                    <td style="height: 30px">
                    </td>
                    <td style="width: 199px; height: 30px">
                    </td>
                    <td style="width: 170px; height: 30px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 22px">
            <asp:Label ID="lblObjeto" runat="server" Style="left: 187px; font-family: 'Tw Cen MT';
                position: relative; top: 0px" Text="Seleccionar objeto:" Width="245px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 24px">
            <asp:DropDownList ID="lstObjectos" runat="server" OnSelectedIndexChanged="lstArenas_SelectedIndexChanged"
                Style="left: 77px; position: relative; top: -2px" Width="404px">
            </asp:DropDownList></td>
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
            <asp:Button ID="btnEliminar" runat="server" OnClick="Button1_Click" Style="left: 130px;
                position: relative; top: -2px" Text="Eliminar" Width="89px" />
            <asp:Button ID="btnCancelar" runat="server" Style="left: 201px; position: relative;
                top: -3px" Text="Cancelar" Width="94px" OnClick="btnCancelar_Click" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="txtElement" runat="server" />
    </form>
</body>
</html>
