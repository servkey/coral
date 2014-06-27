<%@ Page Language="C#" AutoEventWireup="true" Inherits="CoRaL.frmShow" Codebehind="frmShow.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 609px; height: 406px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -74px;
                position: relative; top: 6px" Width="293px" />
            <asp:HiddenField ID="txtOption" runat="server" />
            <table style="width: 583px; height: 99px; left: 12px; position: relative; top: 7px; background-color: #cccccc;">
                <tr>
                    <td colspan="3">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 13px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 170px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
            <asp:HyperLink ID="lnkDefinition" runat="server" Style="left: 68px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -1px">Definir</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
            <asp:HyperLink ID="lnkCreate" runat="server"
                Style="left: 107px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Mostrar </asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="height: 24px" colspan="4">
                        <asp:Label ID="lblSelect" runat="server" Height="26px" Style="left: 188px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Width="210px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 24px">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" rowspan="4">
                        <br />
                        <asp:ListBox ID="lstElements" runat="server" Height="80px" Style="left: 124px; position: relative;
                            top: -2px" Width="307px"></asp:ListBox><br />
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
            <asp:Button ID="btnUpdate" runat="server" OnClick="Button1_Click" Style="left: 165px;
                position: relative; top: 0px" Text="Actualizar" /><asp:Button ID="btnCancel" runat="server" OnClick="Button2_Click" Style="left: 215px;
                position: relative; top: 0px" Text="Regresar" Width="85px" /></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp;&nbsp;
        </div>
    </form>
</body>
</html>
