<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SellerInfoDisplay.ascx.cs" Inherits="ECommerceWebApp.SellerInfoDisplay" %>
<div style="border:1px solid #ccc; padding:15px; width:300px; background-color:#f9f9f9;">
    <h4>Seller profile</h4>
    <asp:Label ID="lblName" runat="server" Text="Name: N/A" Font-Bold="true" /><br />
    <asp:Label ID="lblEmail" runat="server" Text="Email: N/A" /><br />
    <asp:Label ID="lblListings" runat="server" Text="Listings: 0" /><br />
    <asp:Button ID="btnRefresh" runat="server" Text="Refresh from Service" OnClick="btnRefresh_Click" />
    <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Blue" />
</div>