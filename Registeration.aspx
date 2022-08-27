<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="FinalApp.Registeration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MyLogin</title>
    <link rel="stylesheet" href="Login.css" />
    <style type="text/css">
        .logo {
            width: 108px;
        }
        .password-box {
            height: 55px;
            width: 657px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Bgimage"></div>
        <div class="Maindiv">
            <div class="loginstatement">Please Register to Your account</div>
            <div class="email-box">
            <p class="logo">TK</p>
                
                <asp:TextBox ID="emailTextbox" runat="server" Width="170px" placeholder="Username" ></asp:TextBox>
                <hr />
                  <asp:TextBox ID="passwordTextbox" runat="server" Width="170px" placeholder="Password" ></asp:TextBox>
                <hr />  
                 <asp:TextBox ID="firstnameTextbox" runat="server" Width="170px" placeholder="First Name" ></asp:TextBox>
                <hr />  
                 <asp:TextBox ID="lastnameTextbox" runat="server" Width="170px" placeholder="Last Name" ></asp:TextBox>
                <hr />  
                 <asp:TextBox ID="genderTextBox" runat="server" Width="170px" placeholder="Gender" ></asp:TextBox>
                <hr />    
            </div>
            
            <div class="Registerbutton">
                <asp:Button runat="server" Text="Register" OnClick="RegisterClick" ></asp:Button>

            </div>

        </div>
    <div>
    
    </div>
    </form>
</body>
</html>
