<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmAdminActions1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 636px; height: 29px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:Image ID="imgLogo" runat="server" Height="56px" Width="625px" />
            &nbsp; &nbsp;&nbsp;
            <asp:HiddenField ID="txtOption" runat="server" />
            <asp:HiddenField ID="txtId" runat="server" />
            &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <table style="width: 620px; height: 10px; overflow: visible; position: relative; left: 0px; top: 0px; background-color: #cccccc;">
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 13px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 111px; height: 21px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
            <asp:HyperLink ID="lnkDefinition" runat="server" Style="left: 68px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -1px">Definir arena</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 30px">
            <asp:HyperLink ID="lnkCreate" runat="server"
                Style="left: 107px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Administrar arena (actividad)</asp:HyperLink></td>
                </tr>
                <tr>
                    <td style="height: 29px" colspan="4">
                        &nbsp;<asp:Button ID="btnAdminActor" runat="server"
                                Style="left: 20px; position: relative; top: 128px" Text="Administrar actores" Width="130px" OnClick="btnAdminActors_Click" />
                        <asp:HyperLink ID="lnkAdminAction" runat="server" Style="left: 20px; color: blue;
                            font-family: 'Tw Cen MT'; position: relative; top: -4px">Administrar funcionalidad</asp:HyperLink></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 15px">
                        <asp:Label ID="lblSelect" runat="server" Height="26px" Style="left: 216px; font-family: 'Tw Cen MT';
                            position: relative; top: -26px; font-weight: bold; color: black;" Width="248px"></asp:Label>
                        <asp:Label ID="lblAction" runat="server" Height="26px" Style="font-weight: bold; left: -35px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: 2px" Width="248px"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" rowspan="4" style="height: 93px">
                        <br />
                        <asp:Label ID="lblElementsA" runat="server" Height="26px" Style="font-weight: bold; left: 25px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: -11px" Width="273px">Elementos definidos en la funcionalidad</asp:Label>
                        <asp:Label ID="lblDef" runat="server" Height="26px" Style="font-weight: bold; left: 85px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: -10px" Width="227px">Elementos definidos en la arena</asp:Label>&nbsp;
                        <asp:Button ID="btnQuitActor" runat="server" OnClick="Quit_Click" Style="left: -241px;
                position: relative; top: 105px" Text=">> Quitar" Width="78px" />
                        <asp:Button ID="btnAddActor" runat="server" OnClick="Button1_Click" Style="left: 270px;
                position: relative; top: 54px" Text="<< Agregar" Width="78px" />
                        <asp:Label ID="lblActors" runat="server" Height="26px" Style="font-weight: bold; left: 199px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: 2px" Width="72px">Actores</asp:Label>
                        <asp:Label ID="lblRoles" runat="server" Height="26px" Style="font-weight: bold; left: 125px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: 187px" Width="72px">Roles</asp:Label>
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 358px; position: relative; top: 2px; background-color: white;">
                            <asp:CheckBoxList ID="lstActors" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div><div style="width: 233px; height: 132px; overflow: scroll; left: 19px; position: relative; top: -126px; background-color: white;">
                                <asp:CheckBoxList ID="lstActorsF" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                                </asp:CheckBoxList></div>
                        <div style="width: 233px; height: 132px; overflow: scroll; left: 21px; position: relative; top: -49px; background-color: white;">
                            <asp:CheckBoxList ID="lstRolesF" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Label ID="lblRoleAct" runat="server" Height="26px" Style="font-weight: bold;
                            left: 247px; color: black; font-family: 'Tw Cen MT'; position: relative; top: -9px"
                            Width="140px">Roles Actanciales</asp:Label><div style="width: 233px; height: 130px; overflow: scroll; left: 24px; position: relative; top: 16px; background-color: white;">
                            <asp:CheckBoxList ID="lstRolesAct" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <div style="width: 233px; height: 131px; overflow: scroll; left: 367px; position: relative; top: -114px; background-color: white;">
                            <asp:CheckBoxList ID="lstRolesActL" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button ID="btnQuitRole" runat="server" OnClick="delRole_Click" Style="left: 270px;
                position: relative; top: -404px" Text=">> Quitar" Width="78px" /><asp:Button ID="btnAddRole" runat="server" OnClick="addRole_Click" Style="left: 192px;
                position: relative; top: -432px" Text="<< Agregar" Width="78px" /><div style="width: 233px; height: 130px; overflow: scroll; left: 359px; position: relative; top: -490px; background-color: white;">
                            <asp:CheckBoxList ID="lstRoles" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button ID="Button1" runat="server" Style="left: 263px; position: relative; top: -135px"
                            Text="Regresar" Width="103px" />
                        <asp:Button ID="btnQuitRoleAct" runat="server" Style="left: 167px;
                position: relative; top: -340px" Text=">> Quitar" Width="78px" /><asp:Button ID="btnAddRoleAct" runat="server"  Style="left: 89px;
                position: relative; top: -368px" Text="<< Agregar" Width="78px" /></td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
            </table>
        </div>
        &nbsp;&nbsp;
    </form>
</body>
</html>
