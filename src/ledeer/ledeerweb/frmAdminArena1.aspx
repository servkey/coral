<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmAdminArena1.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 662px; height: 29px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;
            <asp:Image ID="imgLogo" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -85px;
                position: relative; top: 3px" Width="293px" />
            <asp:HiddenField ID="txtOption" runat="server" />
            <asp:HiddenField ID="txtId" runat="server" />
            &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <table style="width: 620px; height: 1px; overflow: visible; position: relative; left: 14px; top: 0px; background-color: #cccccc;">
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
                    <td colspan="4" style="height: 29px">
            <asp:HyperLink ID="lnkCreate" runat="server"
                Style="left: 107px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Administrar arena (actividad)</asp:HyperLink>
                        <asp:Label ID="Label4" runat="server" Height="26px" Style="font-weight: bold; font-size: 10pt;
                            left: -70px; color: #000000; font-family: Arial, 'Tw Cen MT'; position: relative;
                            top: 35px" Width="68px">Arena >></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 12px" colspan="4">
                        <asp:Label ID="lblSelect" runat="server" Height="26px" Style="left: 194px; font-family: Arial, 'Tw Cen MT';
                            position: relative; top: 6px; font-weight: bold; color: darkblue; font-size: 10pt;" Width="248px"></asp:Label>
                        &nbsp;
                        </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 15px">
                        <asp:Button ID="btnAdminAction" runat="server"
                                Style="left: 216px; position: relative; top: 35px" Text="Administrar funcionalidades" Width="178px" OnClick="btnAdminActions_Click" Height="27px" />
                        <asp:Button ID="btnAdminActor" runat="server"
                                Style="left: -155px; position: relative; top: 35px" Text="Administrar actores" Width="178px" OnClick="btnAdminActors_Click" Height="27px" />
                        <asp:Label ID="Label1" runat="server" Height="26px" Style="font-weight: bold; font-size: 10pt;
                            left: -315px; color: darkblue; font-family: Arial, 'Tw Cen MT'; position: relative;
                            top: 125px" Width="215px">Elementos definidos en la arena</asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" rowspan="4" style="height: 93px">
                        <asp:Label ID="lblLEDEER" runat="server" Height="27px" Style="font-weight: bold;
                            left: 379px; color: darkblue; font-family: Arial, Tahoma, 'Tw Cen MT', 'Rockwell Extra Bold'; position: relative; top: 63px; font-size: 10pt;"
                            Width="223px">Elementos que pueden ser</asp:Label>&nbsp;
                        <hr />
                        <br />
                        <asp:Label ID="Label2" runat="server" Height="27px" Style="font-weight: bold; font-size: 10pt;
                            left: 380px; color: darkblue; font-family: Arial, Tahoma, 'Tw Cen MT', 'Rockwell Extra Bold';
                            position: relative; top: 28px" Width="223px">agregados a la arena</asp:Label>
                        &nbsp;
                        <div style="width: 233px; height: 132px; overflow: scroll; left: 370px; position: relative; top: 77px; background-color: white;">
                            <asp:CheckBoxList ID="lstActorsL" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button ID="btnQuitActor" runat="server" OnClick="Quit_Click" Style="left: 278px;
                position: relative; top: 14px" Text="Quitar >>" Width="78px" />
                        <asp:Button ID="btnAddActor" runat="server" OnClick="Button1_Click" Style="left: 195px;
                position: relative; top: -15px" Text="<< Agregar" Width="78px" />
                        <asp:Label ID="Label3" runat="server" Height="26px" Style="font-weight: bold; left: 119px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: -99px" Width="227px">Actores</asp:Label>
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 33px; position: relative; top: -78px; background-color: white;">
                            <asp:CheckBoxList ID="lstActors" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td colspan="4" rowspan="1" style="height: 161px">
                        <asp:Label ID="lblRole1" runat="server" Height="26px" Style="font-weight: bold; left: 290px;
                            color: black; font-family: 'Tw Cen MT'; position: relative; top: -56px" Width="227px">Roles</asp:Label>
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 33px; position: relative; top: -32px; background-color: white;">
                            <asp:CheckBoxList ID="lstRoles" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button ID="btnQuitRole" runat="server" OnClick="delRole_Click" Style="left: 276px;
                position: relative; top: -103px" Text="Quitar >>" Width="78px" /><asp:Button ID="btnAddRole" runat="server" OnClick="addRole_Click" Style="left: 199px;
                position: relative; top: -133px" Text="<< Agregar" Width="78px" /><div style="width: 233px; height: 132px; overflow: scroll; left: 366px; position: relative; top: -187px; background-color: white;">
                            <asp:CheckBoxList ID="lstRolesL" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button ID="btnDelRoleAct" runat="server" OnClick="btnDelRoleAct_Click" Style="left: 281px;
                            position: relative; top: -6px" Text="Quitar >>" Width="79px" /><asp:Button ID="btnAddRoleAct" runat="server" Style="left: 204px; position: relative;
                            top: -33px" Text="<< Agregar" Width="78px" OnClick="btnAddRoleAct_Click" /></td>
                </tr>
                <tr>
                    <td colspan="4" rowspan="1" style="height: 95px">
                        <asp:Label ID="lblRoleAct" runat="server" Height="26px" Style="font-weight: bold;
                            left: 267px; color: black; font-family: 'Tw Cen MT'; position: relative; top: -147px"
                            Width="227px">Roles Actanciales</asp:Label>
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 36px; position: relative; top: -122px; background-color: white;">
                            <asp:CheckBoxList ID="lstRolesAct" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div><asp:Button ID="btnAddAction" runat="server"
                                Style="left: 278px; position: relative; top: 30px" Text="<< Agregar" Width="80px" OnClick="btnAddAction_Click" />&nbsp;
                        <asp:Button ID="btnDelAction" runat="server" Style="left: 191px; position: relative;
                            top: 59px" Text="Quitar >>" Width="81px" OnClick="btnDelAction_Click" />
                        <div style="width: 233px; height: 131px; overflow: scroll; left: 367px; position: relative; top: -276px; background-color: white;">
                            <asp:CheckBoxList ID="lstRolesActL" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button
                                    ID="btnDelObject" runat="server" Style="left: 279px; position: relative; top: 119px"
                                    Text="Quitar >>" Width="80px" OnClick="btnDelObject_Click" />
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 35px; position: relative; top: -183px; background-color: white;">
                            <asp:CheckBoxList ID="lstActions" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Button ID="btnAddObject" runat="server" Style="left: 279px;
                                        position: relative; top: -64px" Text="<< Agregar" Width="80px" OnClick="btnAddObject_Click" />
                        <asp:Label ID="lblFuncionality" runat="server" Height="26px" Style="font-weight: bold;
                            left: 178px; color: black; font-family: 'Tw Cen MT'; position: relative; top: -375px"
                            Width="227px">Funcionalidades</asp:Label>&nbsp;
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 38px; position: relative; top: -127px; background-color: white;">
                            <asp:CheckBoxList ID="lstObjects" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        <asp:Label
                                    ID="lblObject" runat="server" Height="26px" Style="font-weight: bold; left: 284px;
                                    color: black; font-family: 'Tw Cen MT'; position: relative; top: -290px" Width="227px">Objetos</asp:Label>
                        &nbsp;&nbsp;
                        <div style="width: 233px; height: 130px; overflow: scroll; left: 370px; position: relative; top: -283px; background-color: white;">
                            <asp:CheckBoxList ID="lstObjectsL" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
                        &nbsp;
                        <div style="width: 230px; height: 130px; overflow: scroll; left: 366px; position: relative; top: -645px; background-color: white;">
                            <asp:CheckBoxList ID="lstActionsL" runat="server" Width="193px" style="font-family: 'Tw Cen MT'" OnSelectedIndexChanged="lstEle_SelectedIndexChanged">
                            </asp:CheckBoxList></div>
            <asp:Button ID="btnBack" runat="server" OnClick="Button2_Click" Style="left: 277px;
                position: relative; top: -338px" Text="Regresar" Width="85px" />
                        </td>
                </tr>
            </table>
        </div>
        &nbsp;&nbsp;
    </form>
</body>
</html>
