<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StockManagementSystemApp.UI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Stock Management</title>


    <link href="../Content/Bootstrap3.3.7/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    
    
 <%--   <script src="../Content/Bootstrap3.3.7/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>--%>
    <!--using Font Awesome-->

    <link href="../Content/Bootstrap3.3.7/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../style/CustomStyle.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">


        <!--for NavBar-->

        <script src="../Content/Bootstrap3.3.7/jquery-3.3.1.min.js"></script>

        <!--NavBar-->
        <nav class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">

                    <!--for hamburger Icon when NavBar collapses-->

                    <a class="navbar-brand" href="index.aspx">
                        <span class="glyphicon glyphicon-folder-close"
                            aria-hidden="true"></span>Stock Management
                    </a>
                </div>

                <!--now add elements
                for Collapsing navbar  we use another div with class-->

                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-2">
                    <%-- <ul class="nav navbar-nav">
                        <li>
                            <a href="#">About</a>
                        </li>
                        <li>
                            <a href="#">Contact</a>
                        </li>
                    </ul>--%>

                    <ul class="nav navbar-nav navbar-right marginTop">
                        <li>
                            <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Logout" OnClick="LogoutClick" />
                        </li>

                    </ul>

                </div>
            </div>

        </nav>

        <div class="container">
            <div class="jumbotron">
                <h1><i class="fa fa-building-o" aria-hidden="true"></i>Stock Management System</h1>
                <p>We want to turn our inventory faster than our people.</p>
            </div>

            <div class="row fix">

                <%-- Category Setup --%>
                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail  ">
                        <img class="card-img-top " alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/category%20(1).jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">Category Setup</h4>
                            <p class="card-text">Create Category For Your Products.</p>
                            <asp:Button ID="ButtonCategory" class="btn btn-primary" runat="server" Text="Setup Category" OnClick="CategoryButtonClick" />
                        </div>
                    </div>

                </div>

                <%-- Company Setup --%>
                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail">
                        <img class="card-img-top" alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/enterprise.jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">Company Setup</h4>
                            <p class="card-text">Setup Company for different products.</p>

                            <asp:Button ID="ButtonCompany" class="btn btn-primary" runat="server" Text="Setup Company" OnClick="ButtonCompany_Click" />
                        </div>
                    </div>

                </div>

                <%-- Item Setup --%>
                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail">
                        <img class="card-img-top" alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/item.jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">Item Setup</h4>
                            <p class="card-text">Setup item for specific company and category</p>
                            <asp:Button ID="ButtonItem" class="btn btn-primary" runat="server" Text="Setup Item" OnClick="ButtonItem_Click" />
                        </div>
                    </div>

                </div>

                <%-- Stock IN --%>
                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail">

                        <img class="card-img-top" alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/stockin.jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">Stock IN</h4>
                            <p class="card-text">Stock Your Product.</p>
                            <asp:Button ID="ButtonStockIn" class="btn btn-primary" runat="server" Text="Stock In" OnClick="ButtonStockIn_Click" />
                        </div>
                    </div>

                </div>

                <%-- Stock Out --%>
                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail">

                        <img class="card-img-top" alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/stockout.jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">Stock Out</h4>
                            <p class="card-text">Stock out your product</p>
                            <asp:Button ID="ButtonstockOutQuantity" class="btn btn-primary" runat="server" Text="Stock Out" OnClick="ButtonstockOutQuantity_Click" />
                        </div>
                    </div>

                </div>

                <%-- Search & View Items Summary --%>
                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail">
                        <img class="card-img-top" alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/Search.jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">Search & View Items Summary</h4>
                            <p class="card-text">Search & View Items in your stock.</p>
                            <asp:Button ID="ButtonSearchview" class="btn btn-primary" runat="server" Text="Search View" OnClick="ButtonSearchview_Click" />
                        </div>
                    </div>

                </div>

                <%-- View Sales Between Two Dates --%>

                <div class="col-lg-4 col-sm-6">

                    <div class="card thumbnail">
                        <img class="card-img-top" alt="100%x180" style="height: 180px; width: 70%; display: block;" src="../img/date.jpg" data-holder-rendered="true" />
                        <div class="card-body text-center custompadding">
                            <h4 class="card-title">View Sales Between Two Dates</h4>
                            <p class="card-text">View Sales Between history between Two given Dates.</p>
                            <asp:Button ID="viewSellsButton" class="btn btn-primary" runat="server" Text="View Sell" OnClick="viewSellsButton_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>


        <%-- Footer --%>

        <hr>
        <div class="footer-bottom">
            <div class="container-fluid">

                <!--<hr> -->
                <div class="text-center center-block">
                    <!-- <p class="txt-railway">- Bootsnipp.com -</p> -->
                    <!-- <br /> -->
                    <a href="https://www.facebook.com/bootsnipp">
                        <i id="social-fb"
                            class="fa fa-facebook-square fa-3x social"></i>
                    </a>
                    <a href="https://twitter.com/bootsnipp">
                        <i id="social-tw" class="fa fa-twitter-square fa-3x social"></i>
                    </a>
                    <a href="https://plus.google.com/+Bootsnipp-page">
                        <i id="social-gp"
                            class="fa fa-google-plus-square fa-3x social"></i>
                    </a>
                    <a href="mailto:bootsnipp@gmail.com">
                        <i id="social-em" class="fa fa-envelope-square fa-3x social"></i>
                    </a>
                    <div class="copyright">
                        © 2018, All rights reserved

                    </div>
                    <div class="design">

                        <a href="#">Cool!! </a>| <a target="_blank" href="#">Web Design & Development by Team Danpithe</a>

                    </div>
                </div>

            </div>
        </div>
      <%--  </div>
        </div>
        </div>--%>
         <script src="../Content/Bootstrap3.3.7/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
