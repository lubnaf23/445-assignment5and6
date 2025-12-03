using System;
using System.Web.UI;
using System.Web.Security;//forms
using System.Xml;
using System.IO;
using DLLClass;
using G21Assignment5.SellerServiceRef;
using G21Assignment5.ItemListingServiceRef;

namespace G21Assignment5
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    // Show member dashboard
                    pnlMemberContent.Visible = true;
                    lblWelcomeUser.Text = $"Welcome, {User.Identity.Name}!"; // comes from FormsAuthentication cookie
                }
                else
                {
                    // Send back to login pageif not authenticated
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Response.Redirect("DefaultPage.aspx");
        }

        protected void btnViewListings_Click(object sender, EventArgs e)
        {
            try
            {
                G21Assignment5.ItemListingServiceRef.ItemListingServiceClient client = new G21Assignment5.ItemListingServiceRef.ItemListingServiceClient();
                var listings = client.GetItems("", 1, 10);

                pnlMemberContent.Visible = true;
                litListings.Text = ""; // clear

                foreach (var item in listings)
                {
                    ProductCard card = (ProductCard)LoadControl("~/ProductCard.ascx");
                    card.ProductName = item.Name;
                    card.Description = item.Description;
                    card.Price = (double)item.Price;
                    card.IsAvailable = item.IsAvailable;
                    card.ImageUrl = item.ImageUrl;

                    // Add the card to the placeholder container
                    phListings.Controls.Add(card);
                }

                lblListingStatus.Text = $"Loaded {listings.Length} listings.";
            }
            catch (Exception ex)
            {
                lblListingStatus.Text = $"Error loading listings: {ex.Message}";
            }
        }   
       
    }
}