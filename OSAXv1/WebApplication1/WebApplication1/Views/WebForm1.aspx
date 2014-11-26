<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.Views.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Model definition</title>
    <link type="text/css" href="../Styles/bootstrap.min.css" rel="Stylesheet"/>
    <link type="text/css"  rel="Stylesheet" href="../Styles/simple-sidebar.css" />  
</head>
    <body>
        <div id="wrapper">
            <!-- Sidebar -->
            <div id="sidebar-wrapper">
                <ul class="sidebar-nav">
                    <li class="sidebar-brand"> 
                    <a href="#">Model Description</a>                                                
                    </li>
                    <li> <a href="#">Actors</a>
                        <ul id="actors" runat="server">
                            <li class="tabitem" draggable = "true">Player</li>
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Objects</a>
                        <ul id="objects" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Roles</a>
                        <ul id="roles" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Categories</a>
                        <ul id="categories" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Tasks</a>
                        <ul id="tasks" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Comunities</a>
                        <ul id="comunities" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Goals</a>
                        <ul id="goals" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li> 
                    <li> <a href="#">Activities</a>
                        <ul id="activities" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                    <li> <a href="#">Objectives</a>
                        <ul id="objectives" runat="server">
                            <li class="tabitem" >new ...</li>
                        </ul>
                    </li>
                </ul>
            </div>
            <!-- /#sidebar-wrapper -->

            <div id="page-content-wrapper">
               
            </div>

            <!-- Page Content 
            <div id="page-content-wrapper">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <h1>Simple Sidebar</h1>
                            <p>This template has a responsive menu toggling system. The menu will appear collapsed on smaller screens, and will appear non-collapsed on larger screens. When toggled using the button below, the menu will appear/disappear. On small screens, the page content will be pushed off canvas.</p>
                            <p>Make sure to keep all page content within the <code>#page-content-wrapper</code>.</p>
                            <a href="#menu-toggle" class="btn btn-default" id="menu-toggle">Toggle Menu</a>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /#page-content-wrapper -->

        </div>
        <!-- /#wrapper -->

        <!-- jQuery -->
        <script src="../Scripts/jquery.js" type="text/javascript"></script>

        <!-- Bootstrap Core JavaScript -->
        <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>

        <!-- Menu Toggle Script -->
        <script type="text/javascript">
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        </script>
        <form id="form1" runat="server">
    
        </form>
    </body>
</html>
