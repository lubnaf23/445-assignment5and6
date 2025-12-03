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

            <asp:Panel ID="pnlDashboard" runat="server" Visible="false">
                <asp:Label ID="lblWelcome" runat="server" CssClass="welcome"></asp:Label>
                <br /><br />
                <h2>Seller Management</h2>
                <asp:Label ID="lblSellerStatus" runat="server" CssClass="status"></asp:Label><br />
                <br />

                <!-- Create Seller -->
                <fieldset style="border: 1px solid #ccc; padding: 10px; border-radius: 6px;">
                    <legend><b>Create Seller</b></legend>
                    <asp:TextBox ID="txtSellerEmail" runat="server" CssClass="input-field" placeholder="Seller Email"></asp:TextBox>
                    <asp:TextBox ID="txtSellerName" runat="server" CssClass="input-field" placeholder="Seller Name"></asp:TextBox>
                    <asp:TextBox ID="txtSellerPassword" runat="server" CssClass="input-field" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:Button ID="btnCreateSeller" runat="server" Text="Create Seller" CssClass="btn" OnClick="btnCreateSeller_Click" />
                </fieldset>

                <br />

                <!-- Create Listing -->
                <fieldset style="border: 1px solid #ccc; padding: 10px; border-radius: 6px;">
                    <legend><b>Create Listing</b></legend>
                    <asp:TextBox ID="txtListingSellerId" runat="server" CssClass="input-field" placeholder="Seller ID"></asp:TextBox>
                    <asp:TextBox ID="txtListingName" runat="server" CssClass="input-field" placeholder="Item Name"></asp:TextBox>
                    <asp:TextBox ID="txtListingPrice" runat="server" CssClass="input-field" placeholder="Price"></asp:TextBox>
                    <asp:Button ID="btnCreateListing" runat="server" Text="Create Listing" CssClass="btn" OnClick="btnCreateListing_Click" />
                    <asp:Label ID="lblListingStatus" runat="server" CssClass="status"></asp:Label>
                </fieldset>

                <br />

                <!-- View Members -->
                <fieldset style="border: 1px solid #ccc; padding: 10px; border-radius: 6px;">
                    <legend><b>View Buyers</b></legend>
                    <asp:Button ID="btnViewBuyers" runat="server" Text="View All Buyers"
                        CssClass="btn" OnClick="btnViewBuyers_Click" />
                    <div style="margin-top: 15px;">
                        <asp:Literal ID="litBuyers" runat="server"></asp:Literal>
                    </div>
                </fieldset>

                <br />
                <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn" OnClick="btnLogout_Click" />
                <br /><br />
            </asp:Panel>

            <br />
            <asp:HyperLink NavigateUrl="DefaultPage.aspx" runat="server">Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
