using DLLClass; //for SecurityHelper
using G21Assignment5.BuyerServiceRef;
using G21Assignment5.SellerServiceRef;
using System;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;

namespace G21Assignment5
{
    public partial class Staff : Page
    {
        SellerServiceClient sellerClient = new SellerServiceClient();
        Service1Client buyerClient = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.IsAuthenticated)
                {
                    //show staff dashboard
                    pnlDashboard.Visible = true;
                    lblWelcome.Text = $"Welcome, {User.Identity.Name}!"; //comes from FormsAuthentication cookie not persisitent
                }
                else
                {
                    //not authenticated = send back to staff login page
                    Response.Redirect("Staff.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("DefaultPage.aspx");
        }

        protected void btnCreateSeller_Click(object sender, EventArgs e)
        {
            string email = txtSellerEmail.Text.Trim();
            string name = txtSellerName.Text.Trim();
            string password = txtSellerPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                lblSellerStatus.Text = "Please fill out all seller fields.";
                return;
            }

            try
            {
                string hashedPw = SecurityHelper.HashString(password);
                int sellerId = sellerClient.CreateSeller(email, hashedPw, name);

                if (sellerId > 0)
                    lblSellerStatus.Text = $"Seller created successfully! ID: {sellerId}";
                else
                    lblSellerStatus.Text = "Failed to create seller.";
            }
            catch (Exception ex)
            {
                lblSellerStatus.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnCreateListing_Click(object sender, EventArgs e) //creating
        {
            try
            {
                int sellerId = int.Parse(txtListingSellerId.Text.Trim());
                string itemName = txtListingName.Text.Trim();
                decimal price = decimal.Parse(txtListingPrice.Text.Trim());

                int listingId = sellerClient.CreateListing(sellerId, itemName, price);

                if (listingId > 0)
                    lblListingStatus.Text = $"Listing created successfully! ID: {listingId}";
                else
                    lblListingStatus.Text = "Failed to create listing (check seller ID).";
            }
            catch (Exception ex)
            {
                lblListingStatus.Text = $"Error: {ex.Message}";
            }
        }
        protected void btnViewBuyers_Click(object sender, EventArgs e)
        {
            try
            {
                Service1Client client = new Service1Client();

                var buyers = client.getBuyers();

                if (buyers == null || buyers.Length == 0)
                {
                    litBuyers.Text = "No buyers found.";
                    return;
                }

                StringBuilder sb = new StringBuilder();

                foreach (var b in buyers)
                {
                    sb.Append($"{b.Name} ({b.Email})<br/>");
                }

                litBuyers.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                litBuyers.Text = "Error loading buyers: " + ex.Message;
            }

        }
    }
}
