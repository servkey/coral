$(document).ready(function () {

    $(".newitem").click(function () {
        var id = $(this).attr('id');
        var ulid;
        var html;
        var itemname = prompt("Nombre del elemento nuevo", "elemento");
        if (itemname == null) return;
        switch (id) {
            case 'newAct':
                ulid = "#actors";
                html = "Actors";
                break;
            case 'newObj':
                ulid = "#objects";
                html = "Objects";
                break;
            case 'newRol':
                ulid = "#roles";
                html = "Roles";
                break;
            case 'newCat':
                ulid = "#categories";
                html = "Categories";
                break;
            case 'newTsk':
                ulid = "#tasks";
                html = "Tasks";
                break;
            case 'newCom':
                ulid = "#comunities";
                html = "Comunities";
                break;
            case 'newGoa':
                ulid = "#goals";
                html = "Goals";
                break;
            case 'newAtv':
                ulid = "#activities";
                html = "Activities";
                break;
            case 'newObv':
                ulid = "#objectives";
                html = "Objectives";
                break;
            default:
                alert("Function Undefined.");
                break;
        }
        var itemid = "item" + itemname;
        $(ulid).append('<li id="' + itemid + '" class="tabitem">' + itemname + '</li>');
        $("#" + itemid).click(function () {
            var tabName = $(this).html();
            addElementTable(tabName);
        });
        slideElement(html);
    });

    $(".slide").click(function () {
        var html = $(this).html();
        slideElement(html);
    });


    function addElementTable(tableName) {
        var id = "#item" + tableName;
        var table = '<div class="elementTable"><h3> > ' + tableName + '</h3>' +
                    '<div class="attributes-wrapper"> <ul id="table-' + tableName + '" class="elementAttributes">' +
                    '<li id="addatt-' + tableName + '" ><span class="glyphicon glyphicon-plus"></span> Add Attribute</li>' +
                    '<li id="addrel-' + tableName + '" ><span class="glyphicon glyphicon-plus"></span> Add Relation</li>' +
                    '</div> </div>';
        $("#page-content-wrapper").append(table);
        disbaleElment(id);
        $("#addatt-" + tableName).click(function () {
            var id = $(this).attr('id');
            addAttribute(id);
        });
    }

    function disbaleElment(id) {
        $(id).off();
        $(id).css("background-color", "#BB4A4E");
        $(id).css("width", "180px");
        $(id).css("margin", "0px");
        $(id).css("padding", "0px");
    }

    function slideElement(html) {
        var selector;
        switch (html) {
            case 'Actors':
                ulid = "#actors li";
                break;
            case 'Objects':
                ulid = "#objects li";
                break;
            case 'Roles':
                ulid = "#roles li";
                break;
            case 'Categories':
                ulid = "#categories li";
                break;
            case 'Tasks':
                ulid = "#tasks li";
                break;
            case 'Comunities':
                ulid = "#comunities li";
                break;
            case 'Goals':
                ulid = "#goals li";
                break;
            case 'Activities':
                ulid = "#activities li";
                break;
            case 'Objectives':
                ulid = "#objectives li";
                break;
            default:
                alert("Function Undefined.");
                break;
        }
        if ($(ulid).is(':visible')) {
            $(ulid).slideUp();
        } else {
            $(ulid).slideDown();
        }
        return false;
        makeDraggable();
    }

    function addAttribute(childId) {        
        var attributeName = prompt("Attribute's name");
        var attributeClass = prompt("Attribute class");        
        $("#" + childId).parent().append('<li><span class="attribute">' + attributeName + '</span>  :<span class="attributeClass">' + attributeClass + '</span></li>');
    }
});