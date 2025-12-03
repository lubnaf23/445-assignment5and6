<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="G21Assignment5.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login / Register - Group 21 E-Commerce</title>
    <style>
        body { font-family: Arial; margin: 40px; background-color: #fafafa; }
        .container { width: 400px; margin: auto; padding: 30px; background-color: white; box-shadow: 0 0 8px #ccc; border-radius: 8px; }
        h2, h3 { text-align: center; margin-top: 0; }
        .input-field { width: 95%; padding: 8px; margin-top: 10px; border: 1px solid #ccc; border-radius: 4px; }
        .btn { width: 100%; padding: 10px; margin-top: 15px; background-color: #007bff; color: white; border: none; cursor: pointer; border-radius: 4px; }
        .btn:hover { background-color: #0056b3; }
        .status { color: red; text-align: center; margin-top: 10px; }
        .role-label { font-size: 12px; color: #555; margin-bottom: 5px; display: block; }
        .role-options { display: flex; justify-content: center; gap: 20px; margin-bottom: 15px; }
        .captcha { display: flex; align-items: center; margin-top: 10px; }
        .captcha img { margin-left: 10px; border: 1px solid #ccc; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" CssClass="status"></asp:Label>

            <!-- Login Panel -->
            <asp:Panel ID="pnlLogin" runat="server">
                <span class="role-label">Login as:</span>
                <div class="role-options">
                    <asp:RadioButtonList ID="rblRole" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Member" Value="Member" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>

                <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field" Placeholder="Email/Username"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password" Placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
                <asp:Button ID="btnShowRegister" runat="server" Text="Register as Member" CssClass="btn" OnClick="btnShowRegister_Click" />
            </asp:Panel>

            <!-- Registration Panel -->
            <asp:Panel ID="pnlRegister" runat="server" Visible="false">
                <h3>Member Registration</h3>
                <asp:TextBox ID="txtRegEmail" runat="server" CssClass="input-field" Placeholder="Email"></asp:TextBox>
                <asp:TextBox ID="txtRegName" runat="server" CssClass="input-field" Placeholder="Name"></asp:TextBox>
                <asp:TextBox ID="txtRegPassword" runat="server" CssClass="input-field" TextMode="Password" Placeholder="Password"></asp:TextBox>
                <asp:TextBox ID="txtRegConfirmPW" runat="server" CssClass="input-field" TextMode="Password" Placeholder="Confirm Password"></asp:TextBox>
                
                <div class="captcha">
                    <asp:TextBox ID="txtCaptcha" runat="server" CssClass="input-field" Placeholder="Enter Captcha"></asp:TextBox>
                    <asp:Image ID="imgCaptcha" runat="server" ImageUrl="~/CaptchaImage.aspx" />
                </div>

                <asp:Button ID="btnRefreshCaptcha" runat="server" Text="Refresh Captcha" CssClass="btn" OnClick="btnRefreshCaptcha_Click" />
                <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn" OnClick="btnRegister_Click" />
                <asp:Button ID="btnBackToLogin" runat="server" Text="Back to Login" CssClass="btn" OnClick="btnBackToLogin_Click" />
                <asp:Label ID="lblRegisterError" runat="server" CssClass="status"></asp:Label>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
