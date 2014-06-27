<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmCreateObject.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 558px; height: 382px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Image
                ID="imgLogo" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -57px;
                position: relative; top: 6px" Width="293px" />&nbsp;
            <table style="left: 14px; width: 540px; position: relative; top: 10px; height: 33px; background-color: #cccccc;">
                <tr>
                    <td style="height: 20px">
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 10px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 1px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
            <asp:HyperLink ID="lnkDefinition" runat="server" Style="left: 62px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 2px">Definir objeto</asp:HyperLink></td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
            <asp:HyperLink ID="HyperLink2" runat="server"
                Style="left: 132px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 3px">Crear arena</asp:HyperLink></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="width: 3px">
                    </td>
                    <td style="width: 3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <hr />
                    </td>
                    <td style="width: 3px">
                    </td>
                    <td style="width: 3px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        <asp:Label ID="lblName" runat="server" Style="left: 198px; font-family: 'Tw Cen MT';
                            position: relative; top: -1px" Text="Nombre del objeto:"></asp:Label></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        <asp:TextBox ID="txtName" runat="server" Style="left: 82px; font-family: 'Tw Cen MT';
                            position: relative; top: -2px" Width="367px"></asp:TextBox></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                        <asp:Label ID="lblValue" runat="server" Style="left: 209px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Text="Valor del objeto:"></asp:Label></td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                        <asp:TextBox ID="txtValue" runat="server" Style="left: 82px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Width="367px"></asp:TextBox></td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 20px">
            <asp:Button ID="btnGuardar" runat="server" OnClick="Button1_Click" Style="left: 161px;
                position: relative; top: 0px" Text="Guardar" /><asp:Button ID="btnCancel" runat="server" OnClick="Button2_Click" Style="left: 215px;
                position: relative; top: -1px" Text="Cancelar" /></td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="txtElement" runat="server" />
        &nbsp;
    </form>
</body>
</html>
