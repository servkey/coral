<%@ Page Language="C#" AutoEventWireup="true" Inherits="CoRaL.frmShowObjects" Codebehind="frmShowObjects.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 542px; height: 319px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Image ID="Image1"
                runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -16px; position: relative;
                top: 12px" Width="293px" />
            <table style="left: 46px; width: 454px; position: relative; top: 41px; height: 190px;
                background-color: #cccccc">
                <tr>
                    <td colspan="3">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 19px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3">
            <asp:HyperLink ID="lnkObject" runat="server" Style="left: 64px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -1px">Definir objetos</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 12px">
            <asp:HyperLink ID="lnkMostrar" runat="server"
                Style="left: 130px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Mostrar objetos</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 38px">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 38px">
            <asp:Label ID="lblName" runat="server" Style="left: 168px; font-family: 'Tw Cen MT';
                position: relative; top: 1px" Text="Objetos:" Width="165px"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 160px">
                    </td>
                    <td style="width: 433px; height: 160px; background-color: #cccccc">
                        &nbsp; &nbsp;
                <asp:ListBox ID="lstElements" runat="server" Height="92px" Style="left: 69px; position: relative;
                    top: -2px" Width="263px"></asp:ListBox></td>
                    <td style="width: 8px; height: 160px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 26px">
                    </td>
                    <td style="width: 433px; height: 26px; background-color: #cccccc">
          
            <asp:Button ID="btnBack" runat="server" Style="left: 89px;top: 0px; position: relative;"
                Text="Regresar" OnClick="btnBack_Click" Width="104px" />
            
            <asp:Button ID="btnUpdate" runat="server" Style="left: 120px; 
                top: -1px; position: relative;" Text="Actualizar" OnClick="btnUpdate_Click" Width="111px" /></td>
                    <td style="width: 8px; height: 26px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 26px">
                    </td>
                    <td style="width: 433px; height: 26px; background-color: #cccccc">
                    </td>
                    <td style="width: 8px; height: 26px">
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
            </table>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:ListBox ID="lstValues1" runat="server" Height="109px" Style="left: 54px; position: relative;
                top: 441px" Width="92px" Visible="False"></asp:ListBox>
            &nbsp;
            &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        </div>
        <asp:HiddenField ID="txtElement" runat="server" />
            <asp:ListBox ID="lstObjects" runat="server" Height="109px" Style="left: 0px; position: relative;
                top: 24px" Width="190px" Visible="False"></asp:ListBox>
    </form>
</body>
</html>
