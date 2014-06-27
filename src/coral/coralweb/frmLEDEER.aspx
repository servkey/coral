<%@ Page Language="C#" AutoEventWireup="true" Inherits="CoRaL.frmLEDEER" Codebehind="frmLEDEER.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
<script language="javascript" type="text/javascript">
// <!CDATA[

function HR1_onclick() {

}

// ]]>
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div  style="  margin-right:auto; margin-left:auto; width: 539px; height: 434px; background-color: white; position: relative;">
            &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: 17px;
                position: relative; top: -21px" Width="293px" />
            <table style="left: 28px; width: 492px; position: relative; top: 0px; height: 70px;
                background-color: #cccccc">
                <tr>
                    <td style="width: 30px; height: 27px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 27px">
            <asp:LinkButton ID="lnkDefinition" runat="server" Style="left: 9px; font-family: 'Tw Cen MT';
                position: relative; top: 0px" Width="204px">Definir elementos de LEDEER</asp:LinkButton></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 27px">
                        <hr id="HR1" style="width: 485px" onclick="return HR1_onclick()" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 27px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 23px">
            <asp:HyperLink ID="lnkArenas" runat="server" Style="left: 61px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 0px" Width="204px">Definir arena</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 23px">
            <asp:HyperLink ID="lnkActors" runat="server" Style="left: 62px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: 0px" Width="184px">Definir actores</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 23px">
            <asp:HyperLink ID="lnkRoles" runat="server" Style="left: 62px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -1px" Width="188px">Definir roles</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 23px">
            <asp:HyperLink ID="lnkRolesActanciales" runat="server" Style="left: 62px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -4px" Width="182px">Definir roles actanciales</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 23px">
            <asp:HyperLink ID="lnkObjects" runat="server" Style="left: 62px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -8px" Width="128px">Definir objetos</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 13px">
            <asp:HyperLink ID="lnkActions" runat="server" Style="left: 62px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -10px" Width="162px">Definir funcionalidades</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="width: 30px; height: 22px">
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
