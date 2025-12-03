<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductCard.ascx.cs" Inherits="G21Assignment5.ProductCard" %>

<div style="border: 1px solid #ccc; border-radius: 10px; padding: 12px; width: 260px; margin: 8px; box-shadow: 2px 2px 6px #eee;">
    <asp:Image ID="imgProduct" runat="server" Width="240" Height="160"
        ImageUrl="~/Images/placeholder.png" />
    <h4>
        <asp:Label ID="lblName" runat="server" Text="Product Name" /></h4>
    <p>
        <asp:Label ID="lblDescription" runat="server" Text="Description..." />
    </p>
    <strong>Price:</strong>
    <asp:Label ID="lblPrice" runat="server" Text="$0.00" />
    <br />
    <asp:Label ID="lblAvailability" runat="server" ForeColor="Green" Text="Available" />
</div>
