<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.Views.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Model definition</title>
    <link type="text/css" href="../Styles/bootstrap.min.css" rel="Stylesheet"/>
    <link type="text/css"  rel="Stylesheet" href="../Styles/simple-sidebar.css" />  
    <script src="../Scripts/jquery-2.1.1.min.js" type="text/javascript"></script>    
    <script src="../Scripts/interaction.js" type="text/javascript"></script>
    <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
</head>
    <body>
        <div id="wrapper">

            <!-- Sidebar -->
            <div id="sidebar-wrapper">
                <ul class="sidebar-nav">
                    <li class="sidebar-brand"> 
                    <a href="#">Model Description</a>                                                
                    </li>
                    <li> <a class="slide" href="#" >Actors</a>
                        <ul id="actors" class="elemHeader" runat="server">                            
                            <li id="newAct" class="newitem" >new ...</li>                            
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Objects</a>
                        <ul id="objects" class="elemHeader" runat="server">
                            <li id="newObj" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Roles</a>
                        <ul id="roles" class="elemHeader" runat="server">
                            <li id="newRol" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Categories</a>
                        <ul id="categories" runat="server" class="elemHeader">
                            <li id="newCat" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Tasks</a>
                        <ul id="tasks" runat="server" class="elemHeader">
                            <li id="newTsk" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Comunities</a>
                        <ul id="comunities" runat="server" class="elemHeader">
                            <li id="newCom" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Goals</a>
                        <ul id="goals" runat="server" class="elemHeader">
                            <li id="newGoa" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Activities</a>
                        <ul id="activities" runat="server" class="elemHeader">
                            <li id="newAtv" class="newitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a class="slide" href="#">Objectives</a>
                        <ul id="objectives" runat="server" class="elemHeader">
                            <li id="newObv" class="newitem" >new ...</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!-- /#sidebar-wrapper -->

            <div id="page-content-wrapper">                                                            
            </div>

        </div>
        <form id="form1" runat="server">
    
        </form>
    </body>
</html>
