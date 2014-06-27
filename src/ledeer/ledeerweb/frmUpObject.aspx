<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmUpObject.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 560px; height: 500px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Image ID="Image1" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -60px;
                position: relative; top: 13px" Width="293px" />
            <table style="left: 18px; width: 524px; position: relative; top: 20px; height: 35px; background-color: #cccccc;">
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
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 12px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 2px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 3px; height: 20px">
                    </td>
                    <td style="width: 3px; height: 20px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
            <asp:HyperLink ID="lnkDefinition" runat="server" Style="left: 51px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 0px">Definir objeto</asp:HyperLink></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
            <asp:HyperLink ID="HyperLink2" runat="server"
                Style="left: 93px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px" Width="111px">Modificar objeto</asp:HyperLink></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 21px">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        <asp:Label ID="lblName1" runat="server" Style="left: 201px; font-family: 'Tw Cen MT';
                            position: relative; top: 0px" Text="Seleccionar  objeto:"></asp:Label></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        <asp:DropDownList ID="lstObjects" runat="server" OnSelectedIndexChanged="lstArenas_SelectedIndexChanged"
                            Style="left: 85px; position: relative; top: 1px" Width="370px">
                        </asp:DropDownList></td>
                    <td style="width: 3px; height: 21px">
                    </td>
                    <td style="width: 3px; height: 21px">
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
                    <td style="height: 14px">
                        <asp:Button ID="btnCancel" runat="server" OnClick="Button2_Click" Style="left: 309px;
                position: relative; top: -1px" Text="Cancelar" Width="85px" />
            <asp:Button ID="btnGuardar" runat="server" OnClick="Button1_Click" Style="left: 50px;
                position: relative; top: -1px" Text="Actualizar" /></td>
                    <td style="width: 3px; height: 14px">
                    </td>
                    <td style="width: 3px; height: 14px">
                    </td>
                </tr>
                <tr>
                    <td style="height: 14px">
                    </td>
                    <td style="width: 3px; height: 14px">
                    </td>
                    <td style="width: 3px; height: 14px">
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="txtElement" runat="server" />
        &nbsp;
    </form>
</body>
</html>
