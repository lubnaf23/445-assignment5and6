<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ECommerceWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>E-Commerce Seller Site</h1>
    <p>This app manages seller accounts/listings. Test cases: 1. Create seller (valid → ID>0). 2. Refresh display → Labels update. 3. Reload for Global log.</p>


    <br />

    <asp:Button ID="btnTestGlobal" runat="server" Text="Test Global.asax" OnClick="btnTestGlobal_Click" />
    <asp:Label ID="lblGlobalLog" runat="server" Text="check debug output" />
    <br /><br />

    <%@ Register Src="~/SellerInfoDisplay.ascx" TagName="SellerDisplay" TagPrefix="uc" %>
    <uc:SellerDisplay ID="MyDisplay" runat="server" SellerId="1" />
    <br /><br />

    Email: <asp:TextBox ID="txtEmail" runat="server" />
    Password: <asp:TextBox ID="txtPw" runat="server" />
    Name: <asp:TextBox ID="txtName" runat="server" />
    <asp:Button ID="btnCreateSeller" runat="server" Text="Create Seller" OnClick="btnCreateSeller_Click" />
    <asp:Label ID="lblSellerResult" runat="server" />
</asp:Content>
