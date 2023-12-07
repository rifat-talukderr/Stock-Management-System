<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockOutUI.aspx.cs" Inherits="StockManagementSystemApp.UI.StockOutUI" EnableEventValidation="false" %>


<!DOCTYPE html>




<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Setup Category</title>



    <!-- Bootstrap core CSS
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
        -->
    <link href="../Scripts/Admintheme/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom fonts for this template
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
        -->
    <link href="../Scripts/Admintheme/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />

    <!-- Page level plugin CSS
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">
        -->
    <link href="../Scripts/Admintheme/vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet" />

    <!-- Custom styles for this template
    <link href="css/sb-admin.css" rel="stylesheet">
        -->
    <link href="../Content/sb-admin.min.css" rel="stylesheet" />
    <link href="../style/categoryCustomStyle.css" rel="stylesheet" />

</head>

<body id="page-top">
    <form id="stockOutFrom" runat="server" >
     <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

        <a class="navbar-brand mr-1" href="index.aspx">Stock Management</a>

        <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle" href="#">
            <i class="fas fa-bars"></i>
        </button>



        <!-- Navbar -->
         <ul class="navbar-nav ml-auto">

            <li class="nav-item">
                 <asp:Button ID="Button1" class="btn btn-danger"  runat="server" Text="Logout" OnClick="LogoutClick" />   
            </li>
        </ul>

    </nav>

    <div id="wrapper">

        <!-- Sidebar -->
        <ul class="sidebar navbar-nav">
            <li class="nav-item">
                <a class="nav-link" href="CategoryUI.aspx">
                    <i class="fas fa-fw fa-table"></i>

                    <span>Category</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="CompanyUI.aspx">
                    <i class="fas fa-fw fa-table"></i>
                    <span>Company</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="ItemUI.aspx">
                    <i class="fas fa-fw fa-table"></i>
                    <span>Item</span></a>
            </li>

            <li class="nav-item">
                <a class="nav-link" href="StockInUI.aspx">
                    <i class="fas fa-fw fa-table"></i>
                    <span>Stock In</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="StockOutUI.aspx">
                    <i class="fas fa-fw fa-table"></i>
                    <span>Stock Out</span></a>
            </li>

            <li class="nav-item">
                <a class="nav-link" href="SearchViewUI.aspx">
                    <i class="fas fa-fw fa-table"></i>
                    <span>Search and View</span></a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="ViewSalesDateUI.aspx">
                    <i class="fas fa-fw fa-table"></i>
                    <span>View Sales</span></a>
            </li>
        </ul>

        <div id="content-wrapper">

            <div class="container-fluid">
                
                    
                        <div class="container">

                            <div class="row justify-content-center align-items-center form-horizontal">

                                <div class="form-group form-group-sm col-sm-6">
                                    <!--inputbox--->
                                    <div class="row">
                                        <asp:Label ID="Label1" class="col-sm-3 col-form-label" runat="server" Text="Company"></asp:Label>


                                        <div class="col-sm-9 custompadding">
                                            <asp:DropDownList ID="DropDownCompanyList" CssClass="form-control" runat="server"  OnSelectedIndexChanged="DropdownCompanySelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
                                            <asp:Label ID="LabelCompanyMessageError" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                       
                                        <asp:Label ID="Label6" class="col-sm-3 col-form-label" runat="server" Text="Item"></asp:Label>
                                        <div class="col-sm-9 custompadding">

                                            <asp:DropDownList ID="DropDownItemList" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDwonItemSelectedIndexChanged"  ></asp:DropDownList> 
                                            <asp:Label ID="LabelItemMessageError" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">                       
                                         <asp:Label ID="Label3" class="col-sm-3 col-form-label" runat="server" Text="ReorderLevel"></asp:Label>
                                        <div class="col-sm-9 custompadding">

                                             <asp:TextBox ID="TextBoxReorderLevel" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="row">
                                        
                                        <asp:Label ID="Label2" class="col-sm-3 col-form-label" runat="server" Text="AvailableQuantity"></asp:Label>
                                        <div class="col-sm-9 custompadding">
                                            <asp:TextBox ID="TextBoxAvailableQuantity" class="form-control" runat="server" ReadOnly="True"  ></asp:TextBox>


                                        </div>
                                    </div>
                                    <div class="row">
                                        <asp:Label ID="Label4" class="col-sm-3 col-form-label" runat="server"  Text="Stock Out Quantity"></asp:Label>
                                        
                                        <div class="col-sm-9 custompadding">
                                           <asp:TextBox ID="TextBoxStockOut" class="form-control" onkeydown = "return (!(event.keyCode>=65) && event.keyCode!=32);" runat="server"  ></asp:TextBox>
                                            <asp:Label ID="LabelStockInMessageError" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>


                                    <!---inputboxend-->
                                </div>


                            </div>

                            <div class="row justify-content-center align-items-center">

                                <div class="col-sm-3 custompadding ">
                                    <asp:Button ID="ButtonSave" runat="server" Text="Add" class="btn btn-primary" Width="332px" OnClick="SaveButtonStockOut" />
                                </div>

                            </div>

                       <div class="row justify-content-center align-items-center">
                             <div class="col-sm-3 custompadding ">
                         <asp:Label ID="Label5" Visible="false" CssClass="alert alert-success" runat="server"></asp:Label>
                            </div>
                        </div>
                    
                    <div class="row justify-content-center align-items-center">
                             <div class="col-sm-3 custompadding ">
                         <asp:Label ID="LabelMessage" Visible="false" CssClass="alert alert-success" runat="server"></asp:Label>
                            </div>
                        </div>
                    <!---asp code-->

                    
                        
                        <asp:GridView ID="GridViewStockOutList" runat="server" CssClass="table table-hover table-striped" ShowFooter="True" AutoGenerateColumns="False" Height="150px">
                            <Columns>

                                <asp:TemplateField>
                                    <HeaderTemplate>Serial No.</HeaderTemplate>
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Item">
                                    <ItemTemplate>
                                        <asp:Label ID="ItemName" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField Visible="false" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn">
                                    <ItemTemplate>
                                        <asp:Label ID="idItemHiddenField" runat="server" Text='<%#Eval("Itemid") %>'></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Company">
                                    <ItemTemplate>

                                        <asp:Label ID="CompanyName" runat="server" Text='<%# Eval("Company") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                                 <asp:TemplateField Visible="false" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn">
                                    <ItemTemplate>
                                        <asp:Label ID="idCompanyHiddenField" runat="server" Text='<%#Eval("Companyid") %>'></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>


                                <asp:TemplateField Visible="false" ItemStyle-CssClass="hideGridColumn" HeaderStyle-CssClass="hideGridColumn">
                                    <ItemTemplate>
                                        <asp:Label ID="idHiddenAvailquantity" runat="server" Text='<%#Eval("Availablequantity") %>'></asp:Label>

                                    </ItemTemplate>

                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Quantity">
                                    <ItemTemplate>
                                        <asp:Label ID="quantityName" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>

                                    </ItemTemplate>


                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>
                       <div class="row justify-content-center align-items-center ">
                       <asp:Button ID="ButtonSellId" class="btn btn-success " runat="server" Text="Sell" Visible="False" OnClick="sellButtonClick" width="140px" />&nbsp;
                        <asp:Button ID="DamageButton" class="btn btn-warning " runat="server" OnClick="DamageButtonClick" Text="Damage" Visible="False" width="140px" />&nbsp;

                       <asp:Button ID="LostButton"  class="btn btn-danger"  runat="server" OnClick="LostButtonClick" Text="Lost" Visible="False" width="140px" />
                        </div>
                        
                    </div>

                
                <!---end asp code-->


            </div>
            <!-- /.container-fluid -->

            <!-- Sticky Footer -->
            <footer class="sticky-footer">
                <div class="container my-auto">
                    <div class="copyright text-center my-auto">
                       <span>Copyright © by Team Danpithe</span>
                    </div>
                </div>
            </footer>

        </div>
        <!-- /.content-wrapper -->

    </div>
    <!-- /#wrapper -->
    <

        <!-- Scroll to Top Button-->
    <a class="scroll-to-top rounded" href="#page-top">
        <i class="fas fa-angle-up"></i>
    </a>

    <!-- Logout Modal-->
    <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
                <div class="modal-footer">
                    <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-primary" href="login.html">Logout</a>
                </div>
            </div>
        </div>
    </div>
    </form>
    <!-- Bootstrap core JavaScript
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        -->
    <script src="../Scripts/Admintheme/vendor/jquery/jquery.min.js"></script>
    <script src="../Scripts/Admintheme/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
        -->
    <script src="../Scripts/Admintheme/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Page level plugin JavaScript
    <script src="vendor/datatables/jquery.dataTables.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.js"></script>
        -->
    <script src="../Scripts/Admintheme/vendor/datatables/jquery.dataTables.js"></script>
    <script src="../Scripts/Admintheme/vendor/datatables/dataTables.bootstrap4.js"></script>

    <!-- Custom scripts for all pages
    <script src="js/sb-admin.min.js"></script>
        -->
    <script src="../Scripts/Admintheme/sb-admin.min.js"></script>

    <!-- Demo scripts for this page
    <script src="js/demo/datatables-demo.js"></script>
        -->
    <script src="../Scripts/Admintheme/datatables-demo.js"></script>
 <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>

   <script type ="text/javascript" >
        $(document).ready(function () {
            $("#ButtonSave").on("click", function () {
                //custom validation rule for Dropdown List  
                $.validator.addMethod("CheckDownCompanyList", function (value, element, param) {
                    if (value == '0')
                        return false;
                    else
                        return true;
                }, "Please select a Company.");

                $.validator.addMethod("CheckDropDownItemList", function (value, element, param) {
                    if (value == '0')
                        return false;
                    else
                        return true;
                }, "Please select a Item");


                $("#stockOutFrom").validate({
                    rules: {

                        "<%=DropDownCompanyList.UniqueID %>": {
                            CheckDownCompanyList: true
                        },

                        "<%=DropDownItemList.UniqueID %>": {
                            CheckDropDownItemList: true
                        },
                        "<%= TextBoxStockOut.UniqueID %>": {
                            required: true
                        },


                    },
                    messages: {
                        //This section we need to place our custom validation message for each control.  
                        "<%= TextBoxStockOut.UniqueID %>": {
                            required: "Please enter Stock Out Quantity"

                        },
                    },
                });

            });
        });
    </script>  
</body>

</html>



