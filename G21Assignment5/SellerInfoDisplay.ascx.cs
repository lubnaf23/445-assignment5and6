using G21Assignment5.SellerServiceRef;
using System;
using System.Web.UI;
//user control component 
namespace G21Assignment5
{
    public partial class SellerInfoDisplay : System.Web.UI.UserControl
    {
        //service call
        public int SellerId { get; set; } = 1; // Test default

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSellerInfo(); //initial load
            }
        }

        private void LoadSellerInfo()
        {
            //tied to create seller
            if (SellerId > 0)
            {
                try
                {
                    
                    var client = new SellerServiceClient();  //NOT accountservice

                    //implement get functionality rn just hardcoding respnse

                    //TEMP
                    lblName.Text = "Name: Test Seller"; 
                    lblEmail.Text = "Email: test@seller.com";
                    lblListings.Text = "Listings: 3"; //from create listing
                    lblStatus.Text = "Loaded from seller service (endpoint: " + client.Endpoint.Address.ToString() + ")";  //check works
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Service Error: " + ex.Message; //if any
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSellerInfo(); //recalling service 
            lblStatus.Text += " | Refreshed: " + DateTime.Now.ToShortTimeString();
        }
    }
}