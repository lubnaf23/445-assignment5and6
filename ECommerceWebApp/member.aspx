<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="ECommerceWebApp.Member" MasterPageFile="~/Site.Master" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Member Page: Manage Your Account</h2>
    <p>Functions: Update profile, view cart (calls seller service for listings). Authenticated members only.</p>
    
    <!--default-->
    <asp:Panel ID="pnlLogin" runat="server" GroupingText="Login" DefaultButton="btnLogin">
        <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" Visible="false" />
        <br />Email: <asp:TextBox ID="txtEmail" runat="server" Width="200" /><br />
        Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200" /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary" />
        <asp:LinkButton ID="lnkRegister" runat="server" Text="New? Register Here" OnClick="ShowRegister" CssClass="ml-2" />
    </asp:Panel>
    
    <!--register-->
    <asp:Panel ID="pnlRegister" runat="server" GroupingText="Register" DefaultButton="btnRegister" Visible="false">
        <asp:Label ID="lblRegisterError" runat="server" ForeColor="Red" Visible="false" />
        <br />Email: <asp:TextBox ID="txtRegEmail" runat="server" Width="200" /><br />
        Password: <asp:TextBox ID="txtRegPassword" runat="server" TextMode="Password" Width="200" /><br />
        Confirm PW: <asp:TextBox ID="txtRegConfirmPW" runat="server" TextMode="Password" Width="200" /><br />
        Name: <asp:TextBox ID="txtRegName" runat="server" Width="200" /><br />
        <asp:Image ID="imgCaptcha" runat="server" ImageUrl="~/CaptchaImage.aspx" AlternateText="Captcha" Width="100" Height="50" /><br />
        Captcha: <asp:TextBox ID="txtCaptcha" runat="server" Width="100" /><br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-success" />
        <asp:LinkButton ID="lnkLogin" runat="server" Text="Already Registered? Login" OnClick="ShowLogin" CssClass="ml-2" />
    </asp:Panel>
    
    <!-- protected -->
    <asp:Panel ID="pnlMemberContent" runat="server" GroupingText="Member Dashboard" Visible="false">
        <h3>Welcome, <asp:Label ID="lblWelcomeUser" runat="server" /></h3>
        <p>Placeholder: Cart/listings (e.g., <asp:Button ID="btnViewListings" runat="server" Text="View Listings" OnClick="btnViewListings_Click" CssClass="btn btn-info" />).</p>
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    </asp:Panel>
 </asp:Content>
