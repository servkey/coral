<%@ Page Language="C#" AutoEventWireup="true" Inherits="CoRaL.frmAdminActions2" Codebehind="frmAdminActions2.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>LEDEER</title>
    <script type="text/javascript" language="javascript">
        
        function getCursorPos(textElement) {
            var sOldText = textElement.value;
            var objRange = document.selection.createRange();
            var sOldRange = objRange.text;
            var sWeirdString = '#%~';
            objRange.text = sOldRange + sWeirdString; objRange.moveStart('character', (0 - sOldRange.length - sWeirdString.length));
            var sNewText = textElement.value;
            objRange.text = sOldRange;
            for (i=0; i <= sNewText.length; i++) {
                var sTemp = sNewText.substring(i, i + sWeirdString.length);
                if (sTemp == sWeirdString) {
                    var cursorPos = (i - sOldRange.length);
                    return cursorPos;
                }
            }
        }
 
        function updatePosition(textBox){
            //document.getElementById("linea").innerHTML = "Línea: ";
            var cadena = textBox.value;
            var index = getCursorPos(textBox);
            
            var lin = 1;
            var col = 1;
            for (var i = 0; i < index; i++){
                if (cadena.charAt(i) == '\n'){
                    col = 0;
                    lin++;
                }
                col ++;
            }
            document.getElementById("linea").innerHTML = "Línea: " + lin + "   Columna: " + col;//getCursorPos(textBox);
        }

        function SumaValores_CallBack(response){
            if (response.error != null){
             alert("Los valores introducidos no son válidos.");
             return;
            }
            target="message";
            document.getElementById(target).innerHTML = response.value;
        }
    
      function getErrors_CallBack(response){
            document.getElementById("message").innerHTML = "";
            var dt = response.value;
            var Output = document.getElementById("message");
            if(dt != null && dt.Tables != null)
            {
                var t = new Array();
                t[t.length] = "<table border=3>";
               
               if (dt.Tables[0].Rows.length > 0){
                    //Encabezado de la tabla
                    t[t.length] = "<tr>";
                    t[t.length] = "<td>&nbsp;&nbsp;Código de error&nbsp;&nbsp;</td>";
                    t[t.length] = "<td>&nbsp;&nbsp;&nbsp;&nbsp;Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    t[t.length] = "<td>&nbsp;&nbsp;&nbsp;&nbsp;Línea&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                    t[t.length] = "<td>&nbsp;&nbsp;&nbsp;Símbolo&nbsp;&nbsp;&nbsp;</td>";
                    t[t.length] = "</tr>";
               
                    for(var i=0; i < dt.Tables[0].Rows.length; i++)
                    {
                        t[t.length] = "<tr>";
                        t[t.length] = "<td>" + dt.Tables[0].Rows[i].Code + "</td>";
                        t[t.length] = "<td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt.Tables[0].Rows[i].Description + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>";
                        t[t.length] = "<td>" + dt.Tables[0].Rows[i].Line + "</td>";
                        t[t.length] = "<td>" + dt.Tables[0].Rows[i].Symbol + "</td>";
                        t[t.length] = "</tr>";
                    }
                }else{
                        t[t.length] = "<tr>";
                        t[t.length] = "<td>Las sentencias del escenario no produjeron nigún error.</td>";
                        t[t.length] = "</tr>";
                }
                 
                Output.innerHTML = t.join("");                
                Output.innerHTML = Output.innerHTML + "</table>"; //cerrar tabla
                Output.focus();
            }else
                alert('Error en análisis');
            Output.focus();
        } 
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <div  style="  margin-right:auto; margin-left:auto; width: 703px; height: 29px; background-color: white;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Image
                ID="imgLogo" runat="server" Height="92px" ImageUrl="~/ledeer.png" Style="left: -48px;
                position: relative; top: 5px" Width="293px" />
            &nbsp; &nbsp;&nbsp;
            <asp:HiddenField ID="txtId" runat="server" />
            <asp:HiddenField ID="txtIdA" runat="server" />
            <asp:HiddenField ID="txtIdS" runat="server" />
            <asp:HiddenField ID="txtOption" runat="server" />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
            <table style="width: 678px; height: 10px; overflow: visible; position: relative; left: 12px; top: 4px; background-color: #cccccc;">
                <tr>
                    <td colspan="3" style="height: 21px">
            <asp:HyperLink ID="lnkLEDEER" runat="server" NavigateUrl="~/frmLEDEER.aspx" Style="left: 13px;
                color: blue; font-family: 'Tw Cen MT'; position: relative; top: 0px">Definir elementos de LEDEER</asp:HyperLink></td>
                    <td style="width: 115px; height: 21px;">
                    </td>
                    <td style="width: 139px; height: 21px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 26px">
            <asp:HyperLink ID="lnkDefinition" runat="server" Style="left: 68px; color: blue; font-family: 'Tw Cen MT';
                position: relative; top: -1px">Definir arena</asp:HyperLink>
                    </td>
                    <td colspan="1" style="height: 26px; width: 139px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 30px">
            <asp:HyperLink ID="lnkAdminArena" runat="server"
                Style="left: 107px; color: blue; font-family: 'Tw Cen MT'; position: relative;
                top: 0px">Administrar arena (actividad)</asp:HyperLink></td>
                    <td colspan="1" style="height: 30px; width: 139px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 30px">
                        <asp:HyperLink ID="lnkAdminAction" runat="server" Style="left: 173px; color: blue;
                            font-family: 'Tw Cen MT'; position: relative; top: -2px">Administrar funcionalidad</asp:HyperLink></td>
                    <td colspan="1" style="height: 30px; width: 139px;">
                    </td>
                </tr>
                <tr>
                    <td style="height: 15px" colspan="4">
                        <asp:Label ID="lblSelect" runat="server" Height="26px" Style="left: 189px; font-family: 'Tw Cen MT';
                            position: relative; top: 3px; font-weight: bold; color: black;" Width="248px"></asp:Label>
                        </td>
                    <td colspan="1" style="height: 15px; width: 139px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 19px">
                        <asp:Label ID="lblAction" runat="server" Height="26px" Style="font-weight: bold;
                            left: 187px; color: black; font-family: 'Tw Cen MT'; position: relative; top: 2px"
                            Width="248px"></asp:Label></td>
                    <td colspan="1" style="height: 19px; width: 139px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 28px">
                        <hr />
                        &nbsp;</td>
                    <td colspan="1" style="height: 28px; width: 139px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" rowspan="4" style="height: 93px">
                        <table style="width: 606px">
                            <tr>
                                <td style="width: 127px; height: 36px">
                        <asp:Button ID="btnAdminActor" runat="server"
                                Style="left: 6px; position: relative; top: 0px" Text="Guardar" Width="122px" OnClick="btnSaveSentences_Click" Height="25px" /></td>
                                <td style="width: 114px; height: 36px">
                                <input onclick="_Default.getErrors(txtSentences.value,txtIdA.value,txtIdS.value,getErrors_CallBack);" type="button" value="Analizar" style="width: 122px; height: 25px" />
                                </td>
                                <td style="height: 36px; width: 116px;">
                        &nbsp;&nbsp;
                                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click1" 
                                        Text="Button" />
                                </td>
                                <td style="width: 184px; height: 36px">
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 127px; height: 31px">
                        <asp:Button ID="btnCheck" runat="server"
                                Style="left: 6px; position: relative; top: -1px" Text="Exportar arena" Width="122px" OnClick="btnCheck_Click" Height="25px" /></td>
                                <td style="width: 114px; height: 31px">
                                    <asp:Button ID="Button1" runat="server"
                                Style="left: -1px; position: relative; top: -1px" Text="Exportar escenario" Width="122px" OnClick="btnExport_Click" Height="25px" /></td>
                                <td style="width: 116px; height: 31px">
                                </td>
                                <td style="width: 184px; height: 31px">
                        <div id="linea" style="left: 65px; width: 148px; position: relative; top: 8px; height: 29px; font-size: 11px; font-family: Tahoma; background-color: silver; border-left-color: gainsboro; border-bottom-color: gainsboro; vertical-align: middle; border-top-style: solid; border-top-color: gainsboro; border-right-style: solid; border-left-style: solid; text-align: center; border-right-color: gainsboro; border-bottom-style: solid;">
                        </div>
                                </td>
                            </tr>
                        </table>
                        &nbsp; &nbsp;
                        &nbsp; &nbsp;
                        &nbsp; &nbsp;
                        <asp:Label ID="lblDef" runat="server" Height="26px" Style="font-weight: bold; left: -2px;
                            color: darkblue; font-family: Arial, 'Tw Cen MT'; position: relative; top: 53px; font-size: 10pt;" Width="222px">Sentencias de escenario: </asp:Label>&nbsp;&nbsp;
                        <hr />
                        &nbsp; &nbsp; &nbsp;
                            <asp:TextBox ID="txtSentences" runat="server" Height="632px" Width="427px" TextMode="MultiLine" style="left: -1px; position: relative; top: 46px; font-size: 18px; font-family: 'Agency FB';"></asp:TextBox>
                            &nbsp; &nbsp; &nbsp;&nbsp;
                        <table style="left: 458px; width: 191px; position: relative; top: -641px; height: 556px">
                            <tr>
                                <td style="width: 215px; position: relative; height: 12px">
                                    <asp:Panel ID="pnlActors" runat="server" GroupingText="Actores" Height="159px" Style="left: 3px;
                                        position: relative; top: 27px" Width="189px">
                                        <asp:ListBox ID="lstActors" runat="server" Height="128px" Width="175px"></asp:ListBox></asp:Panel>
                                    <asp:Panel ID="pnlRoles" runat="server" GroupingText="Roles" Height="159px" Style="left: 2px;
                                        position: relative; top: 32px" Width="189px">
                                        <asp:ListBox ID="lstRoles" runat="server" Height="128px" Width="175px"></asp:ListBox></asp:Panel>
                                    <asp:Panel ID="pnlRolesAct" runat="server" GroupingText="Roles actanciales" Height="158px"
                                        Style="left: 2px; position: relative; top: 36px" Width="189px">
                                        <asp:ListBox ID="lstRolesAct" runat="server" Height="128px" Width="175px"></asp:ListBox></asp:Panel>
                                    <asp:Panel ID="pnlObjects" runat="server" GroupingText="Objetos" Height="157px" Style="left: 2px;
                                        position: relative; top: 40px" Width="189px">
                                        <asp:ListBox ID="lstObjects" runat="server" Height="128px" Width="176px"></asp:ListBox></asp:Panel>
                                </td>
                            </tr>
                        </table>
                        <div id="message" style="width: 623px; overflow:auto; height: 72px; font-size: 8pt; left: 27px; font-family: Tahoma; position: relative; top: -590px; background-color: white; text-align: left;">
                         </div>
                    </td>
                    <td colspan="1" style="height: 93px; width: 139px;">
                    </td>
                    <td colspan="1" style="height: 93px; width: 271px;">
                    </td>
                </tr>
                </table>
        </div>

         
        &nbsp;&nbsp;
        
    </form>
</body>
</html>
