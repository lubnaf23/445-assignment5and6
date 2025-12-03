<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultPage.aspx.cs" Inherits="G21Assignment5.DefaultPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default Page - Group 21 E-Commerce</title>
    <style>
        body { font-family: Arial; margin: 40px; background-color: #fafafa; }
        .container { width: 1280px; margin: auto; padding: 30px; background-color: white; box-shadow: 0 0 8px #ccc; border-radius: 8px; }
        h1 { text-align: center; margin-top: 0; }
        p { line-height: 1.6; color: #555; }
        .btn { width: 45%; padding: 10px; margin: 10px; background-color: #007bff; color: white; border: none; cursor: pointer; border-radius: 4px; }
        .btn:hover { background-color: #0056b3; }
        .nav-buttons { text-align: center; margin-top: 20px; }

        table { border-collapse: collapse; width: 100%; margin-top: 25px; }
        th, td { border: 1px solid #ccc; padding: 8px; text-align: left; vertical-align: top; }
        th { background-color: #e9e9e9; font-weight: bold; }
        td { background-color: #ffffff; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <h1>E-Commerce Site</h1>
            <p>This is the Default page for our Assignment 5 (Group 21 Section 74166).</p>
            <p>This E-Commerce site facilitates sales between buyers and sellers, and allows for management of both classes of users.</p>
            <p>Listings can be created, viewed, and modified.</p>

            <div class="nav-buttons">
                <asp:Button ID="btnMember" runat="server" Text="Member Page" CssClass="btn" OnClick="btnMember_Click" />
                <asp:Button ID="btnStaff" runat="server" Text="Staff Page" CssClass="btn" OnClick="btnStaff_Click" />
            </div>

            <h2>Application & Components Summary</h2>

            <table>
                <tr>
                    <th>Provider</th>
                    <th>Page / Component Type</th>
                    <th>Description</th>
                    <th>Parameters / Return Type</th>
                    <th>Implementation Details</th>
                    <th>Where It’s Used</th>
                    <th>Try-It Link</th>
                </tr>

                <!-- MEMBER PAGE -->
                <tr>
                    <td>Lubna Firdaus</td>
                    <td>Member ASPX Page</td>
                    <td>Enables buyer registration, CAPTCHA validation, password hashing, and item browsing.</td>
                    <td>email, password, name</td>
                    <td>Creates a buyer entry</td>
                    <td>Uses BuyerService for registration and ItemListingService for item search.</td>
                    <td>Member.aspx</td>
                    <td>—</td>
                </tr>

                <!-- SELLER SERVICE -->
                <tr>
                    <td>Lubna Firdaus</td>
                    <td>Seller Service</td>
                    <td>Provides remote operations to create sellers and create product listings.</td>
                    <td>CreateSeller(email, pwHash, name); CreateListing(sellerId, itemName, price)</td>
                    <td>int</td>
                    <td>Implemented as a WCF service. Stores seller and listing data in XML files.</td>
                    <td>Consumed on Staff.aspx for seller onboarding and entering new listings.</td>
                    <td><a href="http://webstrar21.fulton.asu.edu/page1/SellerService.svc">Try It</a></td>
                </tr>

                <!-- SESSION / GLOBAL.ASAX -->
                <tr>
                    <td>Lubna Firdaus</td>
                    <td>Session / Global.asax</td>
                    <td>Manages session state including CAPTCHA values and authentication state.</td>
                    <td>Session["Captcha"]</td>
                    <td>Session variable</td>
                    <td>Used for CAPTCHA matching and authentication flow.</td>
                    <td>Member.aspx, Staff.aspx</td>
                    <td>—</td>
                </tr>

                <!-- STAFF PAGE -->
                <tr>
                    <td>Peyton Gray</td>
                    <td>Staff ASPX Page</td>
                    <td>Administrative dashboard for creating sellers, creating listings, and viewing buyers.</td>
                    <td>Seller and listing inputs</td>
                    <td>IDs returned by service</td>
                    <td>Uses SellerService and BuyerService. Protected by Forms Authentication.</td>
                    <td>Staff.aspx</td>
                    <td>—</td>
                </tr>

                <!-- PRODUCT CARD -->
                <tr>
                    <td>Peyton Gray</td>
                    <td>User Control</td>
                    <td>Displays item information including name, price, image, availability, and description.</td>
                    <td>string properties → UI</td>
                    <td>UI control output</td>
                    <td>Implemented as a reusable ASCX Web User Control.</td>
                    <td>Rendered on Member.aspx to show items returned from ItemListingService.</td>
                    <td>Visible on Member page</td>
                </tr>

                <!-- DLL -->
                <tr>
                    <td>Peyton Gray</td>
                    <td>DLL</td>
                    <td>Provides hashing and symmetric encryption/decryption functions.</td>
                    <td>HashString(input); Encrypt(text,key); Decrypt(cipher,key)</td>
                    <td>string</td>
                    <td>Implemented as a C# Class Library. Used for password hashing and cryptographic demonstration.</td>
                    <td>Used on Member.aspx and Staff.aspx for secure password processing.<br />
                        Demonstrated interactively on TryIt.aspx.</td>
                    <td><a href="TryIt.aspx">Try It</a></td>
                </tr>

                <!-- ITEM LISTING SERVICE -->
                <tr>
                    <td>Peyton Gray</td>
                    <td>Item Listing Service</td>
                    <td>Provides remote product-listing operations. Supports keyword search and returns a list of sample items.</td>
                    <td>string searchTerm, int page, int pageSize</td>
                    <td>Item[]</td>
                    <td>Implemented as a WCF service using ServiceContract/DataContract. Contains a static in-memory catalog.</td>
                    <td>Consumed on Member.aspx to allow buyers to browse available items.</td>
                    <td><a href="http://webstrar21.fulton.asu.edu/page0/ItemListingService.svc">Try It</a></td>
                </tr>

                <!-- DEFAULT PAGE -->
                <tr>
                    <td>Sreehari Sreedev</td>
                    <td>Default ASPX Page</td>
                    <td>Landing page showing application overview and component summary table.</td>
                    <td>None</td>
                    <td>Static content</td>
                    <td>Serves as the index page for navigation to Member and Staff functionality.</td>
                    <td>This page</td>
                    <td>—</td>
                </tr>

                <!-- LOGIN PAGE -->
                <tr>
                    <td>Sreehari Sreedev</td>
                    <td>Login Page</td>
                    <td>Handles member and staff authentication and buyer registration with CAPTCHA verification.</td>
                    <td>string email, string password, string role</td>
                    <td>bool</td>
                    <td>Implemented as an ASPX WebForm using SecurityHelper.HashString(), Session state, BuyerService.addBuyer(), and FormsAuthentication.</td>
                    <td>Entry point for all users; redirects to Member.aspx or Staff.aspx after login.</td>
                    <td>Visible on Login page</td>
                </tr>

                <!-- CAPTCHA -->
                <tr>
                    <td>Sreehari Sreedev</td>
                    <td>Dynamic Image Component</td>
                    <td>Generates random CAPTCHA images to prevent automated form submissions.</td>
                    <td>None</td>
                    <td>Image output</td>
                    <td>Implemented as CaptchaImage.aspx using ASP.NET image rendering (GDI+).</td>
                    <td>Used exclusively on Member.aspx during buyer registration.</td>
                    <td>Visible on Member page</td>
                </tr>

                <!-- BUYER SERVICE -->
                <tr>
                    <td>Sreehari Sreedev</td>
                    <td>Buyer Service</td>
                    <td>Handles buyer registration, retrieving buyer names, and listing all buyers.</td>
                    <td>addBuyer(email, pwHash, name); getBuyerName(email); getBuyers()</td>
                    <td>bool, string, Buyer[]</td>
                    <td>Implemented as a WCF service. Buyer information stored in Member.xml in the same WebStrar folder.</td>
                    <td>Used on Member.aspx for registration and Staff.aspx to display buyers.</td>
                    <td><a href="http://webstrar21.fulton.asu.edu/page2/Service1.svc">Try It</a></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
