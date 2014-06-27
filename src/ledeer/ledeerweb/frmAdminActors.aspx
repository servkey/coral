<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmAdminActors.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 567px; height: 411px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;<asp:Image ID="imgLogo" runat="server" Height="92px" ImageUrl="~/ledeer.png"
                Style="left: -73px; position: relative; top: 5px" Width="293px" />
            <table style="left: 7px; position: relative; top: 10px; width: 554px; height: 336px; background-color: #cccccc;">
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 20px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 2px">Definir elementos de LEDEER</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkDefinirArena" runat="server" Style="left: 67px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 0px">Definir arena</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkAdmArena" runat="server"
                Style="left: 94px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Administrar arena</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        <asp:Label ID="lblName" runat="server" Style="font-weight: bold; left: 114px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Width="292px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        <hr />
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        <asp:Label ID="lblInst" runat="server" Style="left: 108px; font-family: 'Tw Cen MT';
                            position: relative; top: -2px" Text="Seleccionar actor para asignar un role de la arena"
                            Width="375px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 21px">
                    </td>
                    <td style="width: 318px; height: 21px">
                        <asp:Label ID="lblActor" runat="server" Style="left: 104px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Text="Seleccionar actor:" Width="133px"></asp:Label></td>
                    <td style="width: 77px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px; height: 21px">
                    </td>
                    <td style="width: 318px; height: 21px">
                        <asp:DropDownList ID="lstActors" runat="server" OnSelectedIndexChanged="lstArenas_SelectedIndexChanged"
                Style="left: 40px; position: relative; top: 0px" Width="261px">
                        </asp:DropDownList></td>
                    <td style="width: 77px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        &nbsp;<asp:Button ID="btnViewRole" runat="server" OnClick="btnViewRole_Click" Style="left: 401px;
                            position: relative; top: -24px" Text="Ver role" />
                        <asp:Label ID="lblRoleCurrent" runat="server" Style="font-weight: bold; left: 142px;
                            color: #0066cc; font-family: 'Tw Cen MT'; position: relative; top: -4px" Width="254px"></asp:Label></td>
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
                    <td style="width: 84px; height: 21px">
                    </td>
                    <td style="width: 318px; height: 21px">
                        <asp:Label ID="lblRoles" runat="server" Style="left: 87px; font-family: 'Tw Cen MT';
                            position: relative; top: -7px" Text="Seleccionar nuevo role:" Width="203px"></asp:Label></td>
                    <td style="width: 77px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 84px">
                    </td>
                    <td style="width: 318px">
                        <asp:DropDownList ID="lstRoles" runat="server" OnSelectedIndexChanged="lstArenas_SelectedIndexChanged"
                Style="left: 37px; position: relative; top: 0px" Width="261px">
                        </asp:DropDownList></td>
                    <td style="width: 77px">
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
                        &nbsp;<asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Style="left: 49px;
                position: relative; top: 0px" Text="Guardar" Width="89px" />
            <asp:Button ID="btnCancelar" runat="server" Style="left: 96px; position: relative;
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
        <asp:HiddenField ID="txtOption" runat="server" />
        <asp:HiddenField ID="txtId" runat="server" />
        &nbsp;
    </form>
</body>
</html>
