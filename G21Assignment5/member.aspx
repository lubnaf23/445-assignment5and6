<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="G21Assignment5.Member" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Dashboard - Group 21 E-Commerce</title>
    <style>
        body { font-family: Arial; margin: 40px; background-color: #fafafa; }
        .container {
            width: 100%;              /*full width*/
            max-width: 1400px;        /*wide enough for horizontal listings*/
            margin: auto;
            padding: 30px;
            background-color: white;
            box-shadow: 0 0 8px #ccc;
            border-radius: 8px;
        }
        h2 { text-align: center; }
        p { text-align: center; }
        .btn {
            display: inline-block;
            width: auto;
            padding: 12px 16px;
            margin: 10px auto;
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
        .btn:hover { background-color: #0056b3; }
        .button-row {
            text-align: center;
            margin-top: 15px;
        }
        .status { color: red; text-align: center; margin-top: 10px; }
        .welcome { text-align: center; color: green; font-weight: bold; }
        .listing-container {
            display: flex;
            flex-wrap: nowrap;        /*keep all listings in one row*/
            gap: 20px;
            overflow-x: auto;         /*allow horizontal scroll if too many*/
        }
        .listing-container > * {
            flex: 0 0 auto;           /*prevent stretching*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <asp:Panel ID="pnlMemberContent" runat="server" Visible="false">
                <asp:Label ID="lblWelcomeUser" runat="server" CssClass="welcome"></asp:Label>
                <br /><br />

                <h2>Member Page: Manage Your Account</h2>
                    <p>View available listings. Authenticated members only.</p>

                <asp:Label ID="lblListingStatus" runat="server" CssClass="status"></asp:Label>

                <div class="button-row">
                    <asp:Button ID="btnViewListings" runat="server" Text="View Listings"
                        OnClick="btnViewListings_Click" CssClass="btn" />
                </div>

                <!-- inline listing display -->
                <asp:Literal ID="litListings" runat="server"></asp:Literal>

                <!-- horizontal listings -->
                <div class="listing-container">
                    <asp:PlaceHolder ID="phListings" runat="server"></asp:PlaceHolder>
                </div>

                <div class="button-row">
                    <asp:Button ID="btnLogout" runat="server" Text="Logout"
                        OnClick="btnLogout_Click" CssClass="btn" />
                </div>
            </asp:Panel>

            <br />
            <asp:HyperLink NavigateUrl="DefaultPage.aspx" runat="server">Back to Home</asp:HyperLink>
        </div>
    </form>
</body>
</html>
