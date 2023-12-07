<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginUI.aspx.cs" Inherits="StockManagementSystemApp.UI.UserLoginUI" EnableEventValidation="false"  %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>

    <!-- Bootstrap core CSS-->
    
    <link href="../Scripts/Admintheme/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />

    <!-- Custom fonts for this template-->   
    <link href="../Scripts/Admintheme/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />

    <!-- Custom styles for this template-->  
    <link href="../Content/sb-admin.css" rel="stylesheet" />

  </head>

  <body class="bg-dark">
      <form id="loginForm"  runat="server">
    <div class="container">
      <div class="card card-login mx-auto mt-5">
        <div class="card-header">Login</div>
        <div class="card-body">
           
            <div class="form-group">
              <div class="form-label-group">
                     <asp:Label ID="Label2" runat="server" Text="User Name"></asp:Label>
                  <asp:TextBox ID="TextBoxUserName" class="form-control"  runat="server"></asp:TextBox>
                 
              </div>
            </div>
            <div class="form-group">
              <div class="form-label-group">
                     <asp:Label ID="Label1" runat="server" Text="Password"></asp:Label>
                  <asp:TextBox ID="TextBoxPassword" placeholder="Password" class="form-control" TextMode="Password"  runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="form-group">
              <asp:Label ID="loginMessage" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button class="btn btn-primary btn-block" ID="buttonLogin" runat="server" Text="Login" OnClick="ButtonLogin" />
          
          
        </div>
      </div>
    </div>
        </form>
    <!-- Bootstrap core JavaScript-->

   
    <script src="../Scripts/Admintheme/vendor/jquery/jquery.min.js"></script>
    <script src="../Scripts/Admintheme/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->    
    <script src="../Scripts/Admintheme/vendor/jquery-easing/jquery.easing.min.js"></script>


    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script>
        $(document).ready(function () {
            $("#buttonLogin").on("click", function () {
                $("#loginForm").validate({
                    rules: {
                        "<%= TextBoxUserName.UniqueID %>": {
                            required: true

                        },
                        "<%= TextBoxPassword.UniqueID %>": {
                            required: true

                        },
                    },
                    messages: {
                        "<%= TextBoxUserName.UniqueID %>": {
                            required: "User Name required"

                        },

                        "<%= TextBoxPassword.UniqueID %>": {
                            required: "Password required"

                        },
                    }


                });

            });


        });

    </script>
  </body>

</html>
