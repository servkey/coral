//var agregar[] = {
//    function campo(){
//        var lista = document.getElementsById("lista");
//        lista.innerHTML
//    }
//}
$(document).ready(function () {        
    var InputsWrapper = $("#lista");
    var AddButton = $("#AddButton");
    $(AddButton).click(function (e)
    {        
        $(InputsWrapper).append('<li><asp:Label runat="server">Nombre:</asp:Label><asp:TextBox ID="TextBox" runat="server"></asp:TextBox><asp:Label runat="server">Valor:</asp:Label><asp:TextBox ID="TextBoxx" runat="server"></asp:TextBox></li>');
        return false;
    });

    $("body").on("click", ".removeclass", function (e) { //user click on remove text
        if (x > 1) {
            $(this).parent('li').remove(); //remove text box
            x--; //decrement textbox
        }
        return false;
    })

});