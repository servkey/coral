<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmDefinitions.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 558px; height: 383px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -65px;
                position: relative; top: 8px" Width="293px" />
            <table style="left: 12px; line-height: 22pt; position: relative; top: 8px; width: 530px; height: 235px; background-color: #cccccc;">
                <tr>
                    <td style="height: 20px" colspan="2">
                        <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx"
                Style="left: 66px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="height: 20px" colspan="2">
                        <asp:HyperLink ID="lnkDefinition" runat="server" Width="274px" style="left: 119px; color: blue; font-family: 'Tw Cen MT'; position: relative; top: -1px" >Definir</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="height: 11px" colspan="2">
                        <hr />
                    </td>
                </tr>
                            <tr>
                                <td style="width: 119px; height: 20px">
                                </td>
                                <td style="width: 165px; height: 20px">
                                    <asp:HyperLink ID="lnkCreate" runat="server"
                                        Style="left: 2px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                                        top: 0px">Crear</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 119px; height: 31px;">
                                </td>
                                <td style="width: 165px; height: 31px;">
                                    <asp:HyperLink ID="lnkDel" runat="server" Style="left: 2px;
                                        color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Eliminar</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 119px">
                                </td>
                                <td style="width: 165px">
                                    <asp:HyperLink ID="lnkUpdate" runat="server" Style="left: 2px;
                                        color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Modificar</asp:HyperLink></td>
                            </tr>
                            <tr>
                                <td style="width: 119px">
                                </td>
                                <td style="width: 165px">
                                    <asp:HyperLink ID="lnkShow" runat="server" Style="left: 4px;
                                        color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Mostrar</asp:HyperLink></td>
                            </tr>
                <tr>
                    <td style="width: 119px">
                    </td>
                    <td style="width: 165px">
                        <asp:HyperLink ID="lnkAdmin" runat="server" Style="left: 5px; color: blue; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Visible="False">Administrar arena</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 119px">
                    </td>
                    <td style="width: 165px">
                    </td>
                </tr>
                        </table>
        </div>
    </form>
</body>
</html>
