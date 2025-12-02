<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="G21Assignment5.Staff" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Login - Group 21 E-Commerce</title>
    <style>
        body { font-family: Arial; margin: 40px; background-color: #fafafa; }
        .container { width: 400px; margin: auto; padding: 30px; background-color: white; box-shadow: 0 0 8px #ccc; border-radius: 8px; }
        h2 { text-align: center; }
        .input-field { width: 95%; padding: 8px; margin-top: 10px; }
        .btn { width: 100%; padding: 10px; margin-top: 15px; background-color: #007bff; color: white; border: none; cursor: pointer; border-radius: 4px; }
        .btn:hover { background-color: #0056b3; }
        .status { color: red; text-align: center; margin-top: 10px; }
        .welcome { text-align: center; color: green; font-weight: bold; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Staff Login</h2>

            <asp:Panel ID="pnlLogin" runat="server">
                <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field" placeholder="Username"></asp:TextBox>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password" placeholder="Password"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn" OnClick="btnLogin_Click" />
                <asp:Label ID="lblStatus" runat="server" CssClass="status"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="pnlDashboard" runat="server" Visible="false">
                <asp:Label ID="lblWelcome" runat="server" CssClass="welcome"></asp:Label>
                <br /><br />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
                <br /><br />
                <h3>Staff Dashboard</h3>
            </asp:Panel>

            <br />
            <asp:HyperLink NavigateUrl="DefaultPage.aspx" runat="server">← Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
